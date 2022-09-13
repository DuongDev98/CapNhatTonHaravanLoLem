using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace CapNhatTonLoLem
{
    public class HaravanUtils
    {
        public static void CapNhatTonKho(string token, Inventory inventory, ref string error)
        {
            string queryUrl = "https://apis.haravan.com/com/inventories/adjustorset.json";
            try
            {
                HttpWebRequest httpWeb = (HttpWebRequest)WebRequest.Create(queryUrl);
                httpWeb.Method = "POST";
                httpWeb.ContentType = "application/json; charset=UTF-8";
                httpWeb.Accept = "application/json";
                httpWeb.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);

                DataPostInventory itemPost = new DataPostInventory();
                itemPost.inventory = inventory;

                string data = JsonConvert.SerializeObject(itemPost);
                using (Stream writer = httpWeb.GetRequestStream())
                {
                    byte[] arr = Encoding.UTF8.GetBytes(data);
                    writer.Write(arr, 0, arr.Length);
                }

                using (StreamReader reader = new StreamReader(httpWeb.GetResponse().GetResponseStream()))
                {
                    string resp = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
        }

        public static string GetLocationId(string token, ref string error)
        {
            string queryUrl = "https://apis.haravan.com/com/locations.json";
            try
            {
                WebClient wc = new WebClient();
                wc.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
                string data = wc.DownloadString(queryUrl);
                JObject rs = JObject.Parse(data);
                JArray arr = JArray.Parse(rs["locations"].ToString());
                return arr[0]["id"].ToString();
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return "";
            }
        }
        public static List<Product> GetProducts(string token, ref string error)
        {
            List<Product> lst = new List<Product>();
            int page = 1;
            string queryUrl = "https://apis.haravan.com/com/products.json?page={0}";
            List<Product> temp = new List<Product>();
            decimal number = 0;
            do
            {
                temp = LayDuLieuSanPham(token, string.Format(queryUrl, page), ref number, ref error);
                if (temp != null) foreach (Product p in temp) lst.Add(p);
                page++;
                Thread.Sleep(400);
            }
            while (number > 0);
            return lst;
        }

        private static List<Product> LayDuLieuSanPham(string token, string queryUrl, ref decimal number, ref string error)
        {
            try
            {
                List<Product> lst = new List<Product>();
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                WebClient wc = new WebClient();
                wc.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
                string data = wc.DownloadString(queryUrl);
                JObject json = JObject.Parse(data);
                JArray arr = JArray.Parse(json["products"].ToString());
                number = arr.Count;
                foreach (JObject item in arr)
                {
                    Product pro = JsonConvert.DeserializeObject<Product>(item.ToString());
                    foreach (Variant v in pro.variants)
                    {
                        if (v.barcode != null || v.sku != null)
                        {
                            lst.Add(pro);
                        }
                    }
                }
                return lst;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return null;
            }
        }

        public static void UpdatePrice(string token, long productid, List<VariantPrice> lstPrice, ref string error)
        {
            string queryUrl = "https://apis.haravan.com/com/products/"+productid+".json";
            try
            {
                HttpWebRequest httpWeb = (HttpWebRequest)WebRequest.Create(queryUrl);
                httpWeb.Method = "PUT";
                httpWeb.ContentType = "application/json; charset=UTF-8";
                httpWeb.Accept = "application/json";
                httpWeb.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);

                DataPostProductPrice itemPost = new DataPostProductPrice(productid, lstPrice);

                string data = JsonConvert.SerializeObject(itemPost);
                using (Stream writer = httpWeb.GetRequestStream())
                {
                    byte[] arr = Encoding.UTF8.GetBytes(data);
                    writer.Write(arr, 0, arr.Length);
                }

                using (StreamReader reader = new StreamReader(httpWeb.GetResponse().GetResponseStream()))
                {
                    string resp = reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                HttpWebResponse resp = (HttpWebResponse)ex.Response;
                if ((int)resp.StatusCode == 422)
                {
                    error = "";
                }
                else
                {
                    error = ex.Message;
                }
            }
        }
    }

    public class DataPostProductPrice
    {
        public DataPostProductPrice(long productId, List<VariantPrice> lst)
        {
            product = new ProductPrice();
            product.id = productId;
            product.variants = lst;
        }
        public ProductPrice product { set; get; }
    }

    public class ProductPrice
    {
        public long id { set; get; }
        public List<VariantPrice> variants { set; get; }
    }

    public class VariantPrice
    {
        public long id { set; get; }
        public long price { set; get; }
    }

    public class Product
    {
        public long id { set; get; }
        public string title { set; get; }
        public List<Variant> variants { set; get; }
        //public string product_id { set; get; }
        public List<Option> options { set; get; }
    }

    public class Variant
    {
        public long id { set; get; }
        public string barcode { set; get; }
        public string sku { set; get; }
        public long inventory_quantity { set; get; }
        public long price { set; get; }
    }

    public class Option
    {
        public string name { set; get; }
        public long id { set; get; }
        public long position { set; get; }
        public long product_id { set; get; }
    }

    public class DataPostInventory
    {
        public Inventory inventory { set; get; }
    }

    public class Inventory
    {
        public long location_id { set; get; }
        public string type { set; get; }
        public string reason { set; get; }
        public string note { set; get; }
        public List<TonKhoItem> line_items { set; get; }
    }

    public class UpdateItem
    {
        public string barcode { set; get; }
        public long product_id { set; get; }
        public long product_variant_id { set; get; }
        public long inventory_quantity { set; get; }
    }

    public class TonKhoItem
    {
        public long product_id { set; get; }
        public long product_variant_id { set; get; }
        public long quantity { set; get; }
    }
}
