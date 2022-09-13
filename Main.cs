using Microsoft.Win32.TaskScheduler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace CapNhatTonLoLem
{
    public partial class Main : Form
    {
        decimal counter = 0;
        BackgroundWorker bw;
        public Main()
        {
            InitializeComponent();

            //txtToken.TextChanged += TxtToken_TextChanged;
            //txtServer.TextChanged += TxtServer_TextChanged;
            //txtUser.TextChanged += TxtUser_TextChanged;
            //txtPass.TextChanged += TxtPass_TextChanged;
            //txtDatabase.TextChanged += TxtDatabase_TextChanged;
            //numChuKy.ValueChanged += NumChuKy_ValueChanged;
            //chkKhoiDongCungWin.CheckedChanged += ChkKhoiDongCungWin_CheckedChanged;

            notifyIcon.Click += new EventHandler(notifyIcon_Click);
            btnLuuCauHinh.Click += BtnLuuCauHinh_Click;
            btnCapNhat.Click += new EventHandler(btnCapNhat_Click);
            btnAn.Click += new EventHandler(btnAn_Click);

            bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);

            progressBar.Visible = false;
        }

        private void BtnLuuCauHinh_Click(object sender, EventArgs e)
        {
            SaveConfig();
            ChayCungWindows(chkKhoiDongCungWin.Checked);
            ShowInfo("Xong");
        }

        private void ChayCungWindows(bool p)
        {
            string taskName = "LolemHaravan";
            if (p)
            {
                //create task scheduler
                DateTime startTime = DateTime.Now.AddDays(-1);
                using (TaskService ts = new TaskService())
                {
                    TaskDefinition td = ts.NewTask();
                    td.Principal.RunLevel = TaskRunLevel.Highest;
                    td.RegistrationInfo.Description = taskName;
                    td.Settings.ExecutionTimeLimit = TimeSpan.Zero;
                    LogonTrigger trigger = new LogonTrigger();
                    trigger.Delay = new TimeSpan(0, 0, 10);
                    td.Triggers.Add(trigger);
                    td.Actions.Add(System.Reflection.Assembly.GetEntryAssembly().Location, "", "");
                    Task t = ts.GetTask(taskName);
                    if (t != null)
                    {
                        td = t.Definition;
                        ts.RootFolder.RegisterTaskDefinition(taskName, td);
                    }
                    else
                    {
                        ts.RootFolder.RegisterTaskDefinition(taskName, td);
                    }
                }
            }
            else
            {
                //delete task scheduler
                using (TaskService ts = new TaskService())
                {
                    if (ts.GetTask(taskName) != null)
                    {
                        ts.RootFolder.DeleteTask(taskName, false);
                    }
                }
            }
        }

        private void TxtToken_TextChanged(object sender, EventArgs e)
        {
            SaveConfig();
        }

        private void loadIp()
        {
            WebClient wc = new WebClient();
            string ip = wc.DownloadString("http://thuanvietsoft.com/ketnoi.php?kh=lolem&cmd=getip");
            txtServer.Text = ip;
            SaveConfig();
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            counter = numChuKy.Value * 60;
            progressBar.Visible = false;
            tmrCapNhat.Enabled = true;
            tmrProccess.Enabled = false;
            EnableControls(true);
        }

        private void EnableControls(bool finish)
        {
            txtToken.Enabled = finish;
            txtServer.Enabled = finish;
            txtUser.Enabled = finish;
            txtPass.Enabled = finish;
            txtDatabase.Enabled = finish;
            numChuKy.Enabled = finish;
            chkKhoiDongCungWin.Enabled = finish;
            btnLuuCauHinh.Enabled = finish;
            btnCapNhat.Enabled = finish;
            btnAn.Enabled = finish;
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            TaiDuLieuLenHaravan();
        }

        private void TaiDuLieuLenHaravan()
        {
            progressBar.Invoke(new MethodInvoker(delegate {
                progressBar.Visible = true;
                tmrProccess.Enabled = true;
                tmrCapNhat.Enabled = false;
                EnableControls(false);
            }));

            DateTime timeStart = DateTime.Now;
            bool hasError = false;
            string error = "";

            SqlParameter pDMATHANGID = new SqlParameter("@THOIGIAN", SqlDbType.DateTime);
            pDMATHANGID.Value = Config.LoadTime();
            Database db = new Database(txtServer.Text.Trim(), txtUser.Text.Trim(), txtPass.Text.Trim(), txtDatabase.Text.Trim());

            //bool updateAll = true;
            //string sqlTonKho = @"SELECT DMATHANGID, DMATHANG.CODE, DMATHANG.MASANCO, SUM(TON) AS TON FROM OTONKHO INNER JOIN DMATHANG ON OTONKHO.DMATHANGID = DMATHANG.ID
            //WHERE COALESCE(OTONKHO.TIMEMODIFIED, OTONKHO.TIMEMODIFIED) >= @THOIGIAN
            //GROUP BY DMATHANGID, DMATHANG.CODE, DMATHANG.MASANCO";
            //string sqlMatHang = @"SELECT ID, CODE, MASANCO, GIABAN FROM DMATHANG WHERE STATUS = 30 AND COALESCE(TIMEMODIFIED, TIMEMODIFIED)>= @THOIGIAN";

            //DataTable dtTonLoLem = null, dtMatHang = null;
            //if (updateAll)
            //{
            //    sqlTonKho = @"SELECT DMATHANGID, DMATHANG.CODE, DMATHANG.MASANCO, SUM(TON) AS TON FROM OTONKHO INNER JOIN DMATHANG ON OTONKHO.DMATHANGID = DMATHANG.ID
            //    GROUP BY DMATHANGID, DMATHANG.CODE, DMATHANG.MASANCO";
            //    dtTonLoLem = db.GetTable(sqlTonKho, null, out error);

            //    sqlMatHang = @"SELECT ID, CODE, MASANCO, GIABAN FROM DMATHANG WHERE STATUS = 30";
            //    dtMatHang = db.GetTable(sqlMatHang, null, out error);
            //}
            //else
            //{
            //    dtTonLoLem = db.GetTable(sqlTonKho, new SqlParameter[] { pDMATHANGID }, out error);
            //    if (error.Length == 0) dtMatHang = db.GetTable(sqlMatHang, new SqlParameter[] { pDMATHANGID }, out error);
            //}

            string sqlTonKho = @"SELECT DMATHANGID, DMATHANG.CODE, DMATHANG.MASANCO, SUM(TON) AS TON FROM OTONKHO INNER JOIN DMATHANG ON OTONKHO.DMATHANGID = DMATHANG.ID
                GROUP BY DMATHANGID, DMATHANG.CODE, DMATHANG.MASANCO";
            DataTable dtTonLoLem = db.GetTable(sqlTonKho, null, out error);

            string sqlMatHang = @"SELECT ID, CODE, MASANCO, GIABAN FROM DMATHANG WHERE STATUS = 30";
            DataTable dtMatHang = db.GetTable(sqlMatHang, null, out error);

            if (error.Length > 0)
            {
                InvokeThongBao("Lỗi: " + error);
                hasError = true;
            }
            else
            {
                InvokeThongBao("Đang lấy dữ liệu từ Haravan");
                List<Product> lstHaravan = HaravanUtils.GetProducts(txtToken.Text.Trim(), ref error);
                if (error.Length > 0)
                {
                    InvokeThongBao("Lỗi: " + error);
                    hasError = true;
                }
                else
                {
                    //b1.Cập nhật tồn kho
                    if (dtTonLoLem.Rows.Count > 0)
                    {
                        InvokeThongBao("Xử lý dữ liệu tồn kho");
                        List<UpdateItem> lstUpdate = new List<UpdateItem>();
                        foreach (DataRow rLoLem in dtTonLoLem.Rows)
                        {
                            string maHang = rLoLem["CODE"] == DBNull.Value ? "" : rLoLem["CODE"].ToString();
                            string maSanCo = rLoLem["MASANCO"] == DBNull.Value ? "" : rLoLem["MASANCO"].ToString();

                            //tìm kiếm, nếu có trong haravan thì cập nhật
                            foreach (Product p in lstHaravan)
                            {
                                bool added = false;
                                foreach (Variant variant in p.variants)
                                {
                                    UpdateItem item = new UpdateItem();
                                    item.product_id = p.id;
                                    item.product_variant_id = variant.id;
                                    item.inventory_quantity = variant.inventory_quantity;
                                    item.barcode = "";

                                    if (maHang.Length > 0 && (variant.barcode == maHang || variant.sku == maHang))
                                    {
                                        item.barcode = maHang;
                                    }

                                    if (maSanCo.Length > 0 && (variant.barcode == maSanCo || variant.sku == maSanCo))
                                    {
                                        item.barcode = maSanCo;
                                    }

                                    if (item.barcode.Length > 0)
                                    {
                                        lstUpdate.Add(item);
                                        added = true;
                                    }
                                }
                                if (added) break;
                            }
                        }

                        InvokeThongBao("Cập nhật dữ liệu tồn kho");
                        if (lstUpdate.Count > 0)
                        {
                            //lấy location id
                            string locationId = HaravanUtils.GetLocationId(txtToken.Text.Trim(), ref error);
                            if (error.Length > 0 && (locationId == null || locationId.Length == 0))
                            {
                                InvokeThongBao("Lỗi: " + error);
                                hasError = true;
                            }
                            else
                            {
                                error = "";
                                //Cập nhật 200 sản phẩm 1 lần
                                List<TonKhoItem> lstTemp = new List<TonKhoItem>();
                                for (int i = 0; i < lstUpdate.Count; i++)
                                {
                                    int dem = i + 1;
                                    UpdateItem temp = lstUpdate[i];

                                    //lấy tồn kho
                                    decimal tonKho = LayTonKho(dtTonLoLem, temp.barcode);
                                    if (tonKho != temp.inventory_quantity)
                                    {
                                        //kiểm tra biến thể không thể trùng
                                        bool isDuplicate = false;
                                        foreach (TonKhoItem itemCheck in lstTemp)
                                        {
                                            if (itemCheck.product_id == temp.product_id && itemCheck.product_variant_id == temp.product_variant_id)
                                            {
                                                isDuplicate = true;
                                            }
                                        }

                                        if (!isDuplicate)
                                        {
                                            TonKhoItem itemUpdate = new TonKhoItem();
                                            itemUpdate.product_id = temp.product_id;
                                            itemUpdate.product_variant_id = temp.product_variant_id;
                                            itemUpdate.quantity = (long)(tonKho - temp.inventory_quantity);
                                            lstTemp.Add(itemUpdate);
                                        }
                                    }
                                    if (lstTemp.Count > 0 && (lstTemp.Count % 200 == 0 || dem == lstUpdate.Count))
                                    {
                                        System.Threading.Thread.Sleep(500);

                                        Inventory dataPost = new Inventory();
                                        dataPost.location_id = long.Parse(locationId);
                                        //dataPost.type = "set";
                                        dataPost.type = "adjust";
                                        dataPost.reason = "newproduct";
                                        dataPost.note = "Cập nhật tồn từ PM Thuần Việt";
                                        dataPost.line_items = lstTemp;
                                        HaravanUtils.CapNhatTonKho(txtToken.Text.Trim(), dataPost, ref error);
                                        if (error.Length > 0)
                                        {
                                            InvokeThongBao("Lỗi: " + error);
                                            hasError = true;
                                            break;
                                        }
                                        else
                                        {
                                            lstTemp = new List<TonKhoItem>();
                                        }
                                    }
                                }
                            }
                        }
                    }

                    //2.Cập nhật giá mặt hàng
                    if (!hasError)
                    {
                        error = "";
                        InvokeThongBao("Cập nhật dữ liệu giá mặt hàng");
                        foreach (DataRow rowMatHang in dtMatHang.Rows)
                        {
                            if (error.Length > 0)
                            {
                                hasError = true;
                                break;
                            }

                            string maHang = rowMatHang["CODE"] == DBNull.Value ? "" : rowMatHang["CODE"].ToString(),
                                   maSanCo = rowMatHang["MASANCO"] == DBNull.Value ? "" : rowMatHang["MASANCO"].ToString();
                            long giaBan = rowMatHang["GIABAN"] == DBNull.Value ? 0 : (long)decimal.Parse(rowMatHang["GIABAN"].ToString());
                            //kiểm tra giá nếu khác nhau thì cập nhật
                            foreach (Product p in lstHaravan)
                            {
                                bool update = false;

                                List<VariantPrice> lstTemp = new List<VariantPrice>();
                                foreach (Variant variant in p.variants)
                                {
                                    bool added = false;
                                    if (maHang.Length > 0 && (variant.barcode == maHang || variant.sku == maHang) && variant.price != giaBan)
                                    {
                                        added = true;
                                    }

                                    if (maSanCo.Length > 0 && (variant.barcode == maSanCo || variant.sku == maSanCo) && variant.price != giaBan)
                                    {
                                        added = true;
                                    }

                                    VariantPrice variantPrice = new VariantPrice();
                                    variantPrice.id = variant.id;
                                    variantPrice.price = added ? giaBan : variant.price;
                                    lstTemp.Add(variantPrice);

                                    if (added)
                                    {
                                        update = true;
                                    }
                                }

                                if (update)
                                {
                                    //cập nhật dữ liệu lên haravan
                                    if (lstTemp.Count > 0)
                                    {
                                        System.Threading.Thread.Sleep(500);
                                        HaravanUtils.UpdatePrice(txtToken.Text.Trim(), p.id, lstTemp, ref error);
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            if (!hasError)
            {
                InvokeThongBao("");
                //Config.SaveTime(timeStart);
            }
            else
            {
                InvokeThongBao("Lỗi: " + error);
            }
        }

        private decimal LayTonKho(DataTable dtLoLem, string barcode)
        {
            DataRow[] rows = dtLoLem.Select("CODE='"+ barcode +"' OR MASANCO='"+barcode+"'");
            if (rows.Length > 0)
            {
                return (decimal)rows[0]["TON"];
            }
            return 0;
        }

        void InvokeThongBao(string text)
        {
            lblThongBao.Invoke(new MethodInvoker(delegate {
                lblThongBao.Text = text;
            }));
        }

        void tmrCapNhat_Tick(object sender, EventArgs e)
        {
            tmrCapNhat.Enabled = false;
            hienThiGio(counter);
            counter--;
            if (counter < 0)
            {
                counter = numChuKy.Value * 60;
                bw.RunWorkerAsync();
            }
            else
            {
                tmrCapNhat.Enabled = true;
            }
        }

        void hienThiGio(decimal number)
        {
            int phut = (int)number / 60, giay = (int)number - phut * 60;
            lblDemNguoc.Text = "Cập nhật sau: " + phut + ":" + giay;
        }

        void notifyIcon_Click(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            Show();
        }

        void btnAn_Click(object sender, EventArgs e)
        {
            Hide();
            notifyIcon.Visible = true;
            notifyIcon.Icon = Icon;
            notifyIcon.BalloonTipText = "Dịch vụ đồng bộ dữ liệu Haravan";
            notifyIcon.BalloonTipTitle = "Đồng bộ Haravan";
            notifyIcon.ShowBalloonTip(3000);
        }

        void btnCapNhat_Click(object sender, EventArgs e)
        {
            bw.RunWorkerAsync();
        }

        private void ChkKhoiDongCungWin_CheckedChanged(object sender, EventArgs e)
        {
            SaveConfig();
        }

        private void NumChuKy_ValueChanged(object sender, EventArgs e)
        {
            SaveConfig();
            counter = numChuKy.Value * 60;
        }

        private void TxtDatabase_TextChanged(object sender, EventArgs e)
        {
            SaveConfig();
        }

        private void TxtPass_TextChanged(object sender, EventArgs e)
        {
            SaveConfig();
        }

        private void TxtUser_TextChanged(object sender, EventArgs e)
        {
            SaveConfig();
        }

        private void TxtServer_TextChanged(object sender, EventArgs e)
        {
            SaveConfig();
        }
        private void SaveConfig()
        {
            ConfigData data = new ConfigData(txtToken.Text.Trim(), txtServer.Text.Trim(), txtUser.Text.Trim(), txtPass.Text.Trim(), txtDatabase.Text.Trim(),
                (int)numChuKy.Value, chkKhoiDongCungWin.Checked);
            Config.SaveConfig(data);
            counter = numChuKy.Value * 60;
        }
        private void Main_Load(object sender, EventArgs e)
        {
            progressBar.Visible = false;
            progressBar.Step = 1;
            LoadConfig();
            //loadIp();
            counter = numChuKy.Value * 60;
            tmrCapNhat.Enabled = true;
        }

        private void LoadConfig()
        {
            ConfigData data = Config.LoadConfig();
            txtToken.Text = data.token;
            txtServer.Text = data.server;
            txtUser.Text = data.user;
            txtPass.Text = data.pass;
            txtDatabase.Text = data.database;
            numChuKy.Value = data.chuKy;
            chkKhoiDongCungWin.Checked = data.khoiDongCungWin;
        }

        private void tmrProccess_Tick(object sender, EventArgs e)
        {
            tmrProccess.Enabled = false;
            progressBar.PerformStep();
            if (progressBar.Value == progressBar.Maximum)
                progressBar.Value = progressBar.Minimum;
            tmrProccess.Enabled = true;
        }

        void ShowInfo(string text)
        {
            MessageBox.Show(text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        void ShowWarning(string text)
        {
            MessageBox.Show(text, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
