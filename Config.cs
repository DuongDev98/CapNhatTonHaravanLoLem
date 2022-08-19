using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapNhatTonLoLem
{
    public class Config
    {
        private static string DATA_FILE = Directory.GetCurrentDirectory() + @"\config.json";
        private static string DATE_FILE = Directory.GetCurrentDirectory() + @"\date.dat";
        public static void SaveConfig(ConfigData data)
        {
            File.WriteAllText(DATA_FILE, JsonConvert.SerializeObject(data));
        }
        public static ConfigData LoadConfig()
        {
            if (!File.Exists(DATA_FILE))
            {
                File.AppendAllText(DATA_FILE, "");
            }
            ConfigData data = null;
            string json = File.ReadAllText(DATA_FILE);
            if (json.Length == 0) data = new ConfigData();
            else data = JsonConvert.DeserializeObject<ConfigData>(json);
            return data;
        }
        public static void SaveTime()
        {
            File.WriteAllText(DATE_FILE, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
        }
        public static DateTime LoadTime()
        {
            DateTime time = new DateTime(1990, 1, 1);
            if (!File.Exists(DATE_FILE))
            {
                return time;
            }

            string data = File.ReadAllText(DATE_FILE);
            if (data.Length > 0) time = DateTime.ParseExact(data, "dd/MM/yyyy HH:mm:ss", null);
            return time;
        }
    }

    public class ConfigData
    {
        public ConfigData()
        {
            token = "";
            server = "171.249.40.243";
            user = "lolem";
            pass = "@lolem@Admin123456#";
            database = "lolem";
            chuKy = 20;
            khoiDongCungWin = false;
        }
        public ConfigData(string token, string server, string user, string pass, string database, int chuKy, bool khoiDongCungWin)
        {
            this.token = token;
            this.server = server;
            this.user = user;
            this.pass = pass;
            this.database = database;
            this.chuKy = chuKy;
            this.khoiDongCungWin = khoiDongCungWin;
        }

        public string token { set; get; }
        public string server { set; get; }
        public string user { set; get; }
        public string pass { set; get; }
        public string database { set; get; }
        public int chuKy { set; get; }
        public bool khoiDongCungWin { set; get; }
    }
}