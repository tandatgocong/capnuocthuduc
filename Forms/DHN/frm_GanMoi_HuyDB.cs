using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using CAPNUOCTHUDUC.LinQ;
using CAPNUOCTHUDUC.Forms.DHN.BC;
using CAPNUOCTHUDUC.Utilities;
using System.Globalization;

namespace CAPNUOCTHUDUC.Forms.DHN
{
    public partial class frm_GanMoi_HuyDB : UserControl
    {
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_DieuChinhThongTin).Name);
        public frm_GanMoi_HuyDB()
        {
            InitializeComponent();

            cbToDS.SelectedIndex = 0;

        }

        private void tabItem2_Click(object sender, EventArgs e)
        {
            this.txtNam.Text = DateTime.Now.Year.ToString();
            this.rNam.Text = DateTime.Now.Year.ToString();
            if (DateTime.Now.Month == 12)
            {
                cbKyDS.SelectedIndex = 0;
                rHieuLuc.SelectedIndex = 0;
            }
            else
            {
                cbKyDS.SelectedIndex = DateTime.Now.Month;
                rHieuLuc.SelectedIndex = DateTime.Now.Month;
            }

        }

        /// <summary>
        /// Hủy Danh Bộ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        TB_DULIEUKHACHHANG huyDanhBo = null;
        void LoadThongTinHuy()
        {
            string sodanhbo = this.huy_danhbo.Text.Replace("-", "");
            if (sodanhbo.Length == 11)
            {
                huyDanhBo = DAL.DULIEUKH.C_DuLieuKhachHang.finByDanhBo(sodanhbo);
                if (huyDanhBo != null)
                {
                    H_LOTRINH.Text = huyDanhBo.LOTRINH;
                    H_DOT.Text = huyDanhBo.DOT;
                    H_HOPDONG.Text = huyDanhBo.HOPDONG;
                    H_HOTEN.Text = huyDanhBo.HOTEN;
                    H_SONHA.Text = huyDanhBo.SONHA;
                    H_TENDUONG.Text = huyDanhBo.TENDUONG;
                    try
                    {
                        LinQ.TB_QUAN q = DAL.SYS.C_Quan.finByMaQuan(huyDanhBo.QUAN);
                        if (q != null)
                        {
                            H_QUAN.Text = q.TENQUAN;
                            LinQ.TB_PHUONG ph = DAL.SYS.C_Phuong.finbyPhuong(q.MAQUAN, huyDanhBo.PHUONG.Trim());
                            H_PHUONG.Text = ph.TENPHUONG;
                        }
                    }
                    catch (Exception)
                    {
                    }
                    H_GIABIEU.Text = huyDanhBo.GIABIEU;
                    H_DINHMUC.Text = huyDanhBo.DINHMUC;
                    H_SOPHIEU.Focus();
                }
                else
                {
                    TB_DULIEUKHACHHANG_HUYDB khachhanghuy = DAL.DULIEUKH.C_DuLieuKhachHang.finByDanhBoHuy(sodanhbo);
                    if (khachhanghuy != null)
                    {
                        H_LOTRINH.Text = khachhanghuy.LOTRINH;
                        H_DOT.Text = khachhanghuy.DOT;
                        H_HOPDONG.Text = khachhanghuy.HOPDONG;
                        H_HOTEN.Text = khachhanghuy.HOTEN;
                        H_SONHA.Text = khachhanghuy.SONHA;
                        H_TENDUONG.Text = khachhanghuy.TENDUONG;
                        try
                        {
                            LinQ.TB_QUAN q = DAL.SYS.C_Quan.finByMaQuan(huyDanhBo.QUAN);
                            if (q != null)
                            {
                                H_QUAN.Text = q.TENQUAN;
                                LinQ.TB_PHUONG ph = DAL.SYS.C_Phuong.finbyPhuong(q.MAQUAN, huyDanhBo.PHUONG.Trim());
                                H_PHUONG.Text = ph.TENPHUONG;
                            }
                        }
                        catch (Exception)
                        {
                        }
                        //txtHieuLuc.Text = "Hết HL " + khachhanghuy.HIEULUCHUY;
                        H_GIABIEU.Text = khachhanghuy.GIABIEU;
                        H_DINHMUC.Text = khachhanghuy.DINHMUC;
                        //H_NGAYGAN.ValueObject = khachhanghuy.NGAYTHAY;
                        //H_KIEMDINH.ValueObject = khachhanghuy.NGAYKIEMDINH;
                        //H_HIEUDH.Text = khachhanghuy.HIEUDH;
                        //H_CO.Text = khachhanghuy.CODH;
                        //H_CAP.Text = khachhanghuy.CAP;
                        //H_SOTHAN.Text = khachhanghuy.SOTHANDH;
                        //H_VITRI.Text = khachhanghuy.VITRIDHN;
                        //H_CHITHAN.Text = khachhanghuy.CHITHAN;
                        //H_CHIGOC.Text = khachhanghuy.CHIGOC;
                        btCapNhatHuy.Enabled = true;

                    }
                    else
                    {

                        MessageBox.Show(this, "Không Tìm Thấy Thông Tin !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //   Refesh();
                    }
                }
            }
        }
        private void huy_danhbo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                LoadThongTinHuy();
            }
        }

        private void btHuyDanhBo_Click(object sender, EventArgs e)
        {
            if (huyDanhBo != null)
            {
                TB_DULIEUKHACHHANG_HUYDB hKhacHang = new TB_DULIEUKHACHHANG_HUYDB();
                hKhacHang.KHU = huyDanhBo.KHU;
                hKhacHang.DOT = huyDanhBo.DOT;
                hKhacHang.CUON_GCS = huyDanhBo.CUON_GCS;
                hKhacHang.CUON_STT = huyDanhBo.CUON_STT;
                hKhacHang.DANHBO = huyDanhBo.DANHBO;
                hKhacHang.LOTRINH = huyDanhBo.LOTRINH;
                hKhacHang.NGAYGANDH = huyDanhBo.NGAYGANDH;
                hKhacHang.HOPDONG = huyDanhBo.HOPDONG;
                hKhacHang.HOTEN = huyDanhBo.HOTEN;
                hKhacHang.SONHA = huyDanhBo.SONHA;
                hKhacHang.TENDUONG = huyDanhBo.TENDUONG;
                hKhacHang.PHUONG = huyDanhBo.PHUONG;
                hKhacHang.QUAN = huyDanhBo.QUAN;
                hKhacHang.CHUKY = huyDanhBo.CHUKY;
                hKhacHang.CODE = huyDanhBo.CODE;
                hKhacHang.CODEFU = huyDanhBo.CODEFU;
                hKhacHang.GIABIEU = huyDanhBo.GIABIEU;
                hKhacHang.DINHMUC = huyDanhBo.DINHMUC;
                hKhacHang.SH = huyDanhBo.SH;
                hKhacHang.HCSN = huyDanhBo.HCSN;
                hKhacHang.SX = huyDanhBo.SX;
                hKhacHang.DV = huyDanhBo.DV;
                hKhacHang.CODH = huyDanhBo.CODH;
                hKhacHang.HIEUDH = huyDanhBo.HIEUDH;
                hKhacHang.CAP = huyDanhBo.CAP;
                hKhacHang.SOTHANDH = huyDanhBo.SOTHANDH;
                hKhacHang.CHITHAN = huyDanhBo.CHITHAN;
                hKhacHang.CHIGOC = huyDanhBo.CHIGOC;
                hKhacHang.VITRIDHN = huyDanhBo.VITRIDHN;
                hKhacHang.NGAYTHAY = huyDanhBo.NGAYTHAY;
                hKhacHang.NGAYKIEMDINH = huyDanhBo.NGAYKIEMDINH;
                hKhacHang.SODHN = huyDanhBo.SODHN;
                hKhacHang.MSTHUE = huyDanhBo.MSTHUE;
                hKhacHang.SOHO = huyDanhBo.SOHO;
                hKhacHang.CHISOKYTRUOC = huyDanhBo.CHISOKYTRUOC;
                hKhacHang.SOPHIEU = this.H_SOPHIEU.Text;
                hKhacHang.NGAYHUY = DateTime.Now.Date;
                hKhacHang.HIEULUCHUY = cbKyDS.Items[cbKyDS.SelectedIndex].ToString() + "/" + this.txtNam.Text;
                hKhacHang.NGUYENNHAN = this.NGUYENNHAN.Text;
                hKhacHang.GHICHU = this.GHICHU.Text; ;
                hKhacHang.CREATEDATE = DateTime.Now;
                hKhacHang.CREATEBY = "";
                hKhacHang.MADMA = huyDanhBo.MADMA;
                hKhacHang.CHUKYDS = 20;
                if (DAL.DULIEUKH.C_DuLieuKhachHang.HuyDanhBo(hKhacHang, huyDanhBo))
                {
                    MessageBox.Show(this, "Hủy Danh Bộ Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //DAL.LinQConnection.ExecuteCommand_("DELETE FROM DK_GIAMHOADON WHERE DHN_DANHBO='" + huyDanhBo.DANHBO + "'");
                    H_LOTRINH.Text = "";
                    H_DOT.Text = "";
                    H_HOPDONG.Text = "";
                    H_HOTEN.Text = "";
                    H_SONHA.Text = "";
                    H_TENDUONG.Text = "";
                    H_QUAN.Text = "";
                    H_PHUONG.Text = "";
                    H_GIABIEU.Text = "";
                    H_DINHMUC.Text = "";
                    huy_danhbo.Text = "";

                    this.huy_danhbo.Focus();
                }
                else
                {
                    MessageBox.Show(this, "Hủy Danh Bộ Thất Bại !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btXemHuyDanhBo_Click(object sender, EventArgs e)
        {
            string hieuluc = rHieuLuc.Items[rHieuLuc.SelectedIndex].ToString() + "/" + this.rNam.Text;
            DataTable table = new DataTable();
            table.Columns.Add("STT", typeof(string));
            table.Columns.Add("TODS", typeof(string));
            table.Columns.Add("TENTO", typeof(string));
            table.Columns.Add("SOLUONG", typeof(string));

            DataRow myDataRow = table.NewRow();
            myDataRow["STT"] = 1;
            myDataRow["TODS"] = "TD";
            myDataRow["TENTO"] = "THỦ ĐỨC";
            int tb01 = DAL.DULIEUKH.C_DuLieuKhachHang.SoLuongHuy("TD", hieuluc);
            myDataRow["SOLUONG"] = tb01;
            table.Rows.Add(myDataRow);

            myDataRow = table.NewRow();
            myDataRow["STT"] = 2;
            myDataRow["TODS"] = "Q9";
            myDataRow["TENTO"] = "QUẬN 9";
            int tb02 = DAL.DULIEUKH.C_DuLieuKhachHang.SoLuongHuy("Q9", hieuluc);
            myDataRow["SOLUONG"] = tb02;
            table.Rows.Add(myDataRow);

            myDataRow = table.NewRow();
            myDataRow["STT"] = 3;
            myDataRow["TODS"] = "Q2";
            myDataRow["TENTO"] = "QUẬN 2";
            int tp = DAL.DULIEUKH.C_DuLieuKhachHang.SoLuongHuy("Q2", hieuluc);
            myDataRow["SOLUONG"] = tp;
            table.Rows.Add(myDataRow);


            myDataRow = table.NewRow();
            myDataRow["STT"] = 4;
            myDataRow["TODS"] = "BD";
            myDataRow["TENTO"] = "BÌNH DƯƠNG";
            int tp02 = DAL.DULIEUKH.C_DuLieuKhachHang.SoLuongHuy("BD", hieuluc);
            myDataRow["SOLUONG"] = tp02;
            table.Rows.Add(myDataRow);



            // tong ket

            myDataRow = table.NewRow();
            myDataRow["STT"] = "";
            myDataRow["TODS"] = "";
            myDataRow["TENTO"] = "";
            myDataRow["SOLUONG"] = tb01 + tb02 + tp;
            table.Rows.Add(myDataRow);
            dataGridView1.DataSource = table;






        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.OwningColumn.Name == "DANHSACH")
            {
                string hieuluc = rHieuLuc.Items[rHieuLuc.SelectedIndex].ToString() + "/" + this.rNam.Text;
                string tods = dataGridView1.Rows[e.RowIndex].Cells["TODS"].Value + "";
                string tento = "".Equals((dataGridView1.Rows[e.RowIndex].Cells["TENTO"].Value + "")) ? "ĐỘI QLĐHN" : "TỔ " + (dataGridView1.Rows[e.RowIndex].Cells["TENTO"].Value + "");

                frm_HuyDanhBo frm = new frm_HuyDanhBo(tods, hieuluc, tento);
                frm.ShowDialog();
            }
        }

        private void btCapNhatHuy_Click(object sender, EventArgs e)
        {
            string sodanhbo = this.huy_danhbo.Text.Replace("-", "");
            TB_DULIEUKHACHHANG_HUYDB hKhacHang = DAL.DULIEUKH.C_DuLieuKhachHang.finByDanhBoHuy(sodanhbo);
            if (hKhacHang != null)
            {

                hKhacHang.KHU = huyDanhBo.KHU;
                hKhacHang.DOT = huyDanhBo.DOT;
                hKhacHang.CUON_GCS = huyDanhBo.CUON_GCS;
                hKhacHang.CUON_STT = huyDanhBo.CUON_STT;
                hKhacHang.DANHBO = huyDanhBo.DANHBO;
                hKhacHang.LOTRINH = huyDanhBo.LOTRINH;
                hKhacHang.NGAYGANDH = huyDanhBo.NGAYGANDH;
                hKhacHang.HOPDONG = huyDanhBo.HOPDONG;
                hKhacHang.HOTEN = huyDanhBo.HOTEN;
                hKhacHang.SONHA = huyDanhBo.SONHA;
                hKhacHang.TENDUONG = huyDanhBo.TENDUONG;
                hKhacHang.PHUONG = huyDanhBo.PHUONG;
                hKhacHang.QUAN = huyDanhBo.QUAN;
                hKhacHang.CHUKY = huyDanhBo.CHUKY;
                hKhacHang.CODE = huyDanhBo.CODE;
                hKhacHang.CODEFU = huyDanhBo.CODEFU;
                hKhacHang.GIABIEU = huyDanhBo.GIABIEU;
                hKhacHang.DINHMUC = huyDanhBo.DINHMUC;
                hKhacHang.SH = huyDanhBo.SH;
                hKhacHang.HCSN = huyDanhBo.HCSN;
                hKhacHang.SX = huyDanhBo.SX;
                hKhacHang.DV = huyDanhBo.DV;
                hKhacHang.CODH = huyDanhBo.CODH;
                hKhacHang.HIEUDH = huyDanhBo.HIEUDH;
                hKhacHang.CAP = huyDanhBo.CAP;
                hKhacHang.SOTHANDH = huyDanhBo.SOTHANDH;
                hKhacHang.CHITHAN = huyDanhBo.CHITHAN;
                hKhacHang.CHIGOC = huyDanhBo.CHIGOC;
                hKhacHang.VITRIDHN = huyDanhBo.VITRIDHN;
                hKhacHang.NGAYTHAY = huyDanhBo.NGAYTHAY;
                hKhacHang.NGAYKIEMDINH = huyDanhBo.NGAYKIEMDINH;
                hKhacHang.SODHN = huyDanhBo.SODHN;
                hKhacHang.MSTHUE = huyDanhBo.MSTHUE;
                hKhacHang.SOHO = huyDanhBo.SOHO;
                hKhacHang.CHISOKYTRUOC = huyDanhBo.CHISOKYTRUOC;
                hKhacHang.SOPHIEU = this.H_SOPHIEU.Text;
                hKhacHang.NGAYHUY = DateTime.Now.Date;
                hKhacHang.HIEULUCHUY = cbKyDS.Items[cbKyDS.SelectedIndex].ToString() + "/" + this.txtNam.Text;
                hKhacHang.NGUYENNHAN = this.NGUYENNHAN.Text;
                hKhacHang.GHICHU = this.GHICHU.Text; ;
                hKhacHang.CREATEDATE = DateTime.Now;
                hKhacHang.CREATEBY = "";
                hKhacHang.MADMA = huyDanhBo.MADMA;
                hKhacHang.CHUKYDS = 20;
                if (DAL.DULIEUKH.C_DuLieuKhachHang.HuyDanhBo(hKhacHang, huyDanhBo))
                {
                    MessageBox.Show(this, "Hủy Danh Bộ Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    H_LOTRINH.Text = "";
                    H_DOT.Text = "";
                    H_HOPDONG.Text = "";
                    H_HOTEN.Text = "";
                    H_SONHA.Text = "";
                    H_TENDUONG.Text = "";
                    H_QUAN.Text = "";
                    H_PHUONG.Text = "";
                    H_GIABIEU.Text = "";
                    H_DINHMUC.Text = "";
                    huy_danhbo.Text = "";

                    this.huy_danhbo.Focus();
                }
                else
                {
                    MessageBox.Show(this, "Hủy Danh Bộ Thất Bại !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                DataObject d = dataGridView2.GetClipboardContent();
                Clipboard.SetDataObject(d);
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                string s = Clipboard.GetText();
                string[] lines = s.Split('\n');
                int row = 0;
                int col = dataGridView2.CurrentCell.ColumnIndex;
                foreach (string line in lines)
                {
                    dataGridView2.Rows.Add();
                    //MessageBox.Show(this, line);
                    if (line.Length > 0)
                    {
                        string[] cells = line.Split('\t');
                        for (int i = 0; i < cells.GetLength(0); ++i)
                        {
                            try
                            {
                                if ((col + i) == 4)
                                {
                                    string[] sdate = cells[i].Split('/');
                                    dataGridView2[col + i, row].Value = sdate[0] + "/" + sdate[1] + "/" + (sdate[2].Length == 2 ? ("20" + sdate[2]) : sdate[2]);
                                }
                                else if ((col + i) == 6)
                                {
                                    if (cells[i] == "\"" || cells[i] == "'" || cells[i] == "" || cells[i] == "" || cells[i] == "-")
                                    {
                                        dataGridView2[col + i, row].Value = dataGridView2.Rows[row-1].Cells["HIEU"].Value + "";
                                    }
                                    else
                                    {
                                        dataGridView2[col + i, row].Value = Convert.ChangeType(Strings.convertToUnSign(cells[i]), dataGridView2[col + i, row].ValueType);                
                                    }
                                }
                                else if ((col + i) == 21)
                                {
                                    string[] sdate = cells[i].Split('/');
                                    dataGridView2[col + i, row].Value = sdate[0] + "/"  + (sdate[1].Length == 2 ? ("20" + sdate[1]) : sdate[2]);
                                }
                                else
                                {
                                    dataGridView2[col + i, row].Value = Convert.ChangeType(Strings.convertToUnSign(cells[i]), dataGridView2[col + i, row].ValueType);
                                }
                            }
                            catch (Exception ex)
                            {
                                log.Error(ex);
                            }

                        }
                        row++;
                        
                    }
                    
                }


            }
        }

        public int tods()
        {
            if (cbToDS.SelectedIndex == 1)
                return 2;
            else if (cbToDS.SelectedIndex == 2)
                return 3;
            return 1;
        
        }
        private void btCapNhatThongTin_Click(object sender, EventArgs e)
        {
            string listDanhBa = "";
            int result=0;
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                try 
	            {
                    string danhbo = dataGridView2.Rows[i].Cells["DANHBO"].Value.ToString().Replace(" ", "");
                    if (danhbo.Length > 5)
                    {
                        listDanhBa += ("'" + danhbo + "',");
                        TB_DULIEUKHACHHANG kh = DAL.DULIEUKH.C_DuLieuKhachHang.finByDanhBo(danhbo);
                        if (kh == null)
                        {
                            kh = new TB_DULIEUKHACHHANG();
                            kh.KHU = "4";
                            kh.DOT = dataGridView2.Rows[i].Cells["DOT2"].Value.ToString();
                            kh.CUON_GCS = dataGridView2.Rows[i].Cells["LT2"].Value.ToString();
                            kh.CUON_STT = dataGridView2.Rows[i].Cells["LT3"].Value.ToString();
                            kh.LOTRINH = dataGridView2.Rows[i].Cells["LT1"].Value.ToString() + dataGridView2.Rows[i].Cells["LT2"].Value.ToString() + dataGridView2.Rows[i].Cells["LT3"].Value.ToString();
                            kh.DANHBO = danhbo;
                            kh.NGAYGANDH = dataGridView2.Rows[i].Cells["NGAYGAN"].Value.ToString();
                            kh.HOPDONG = dataGridView2.Rows[i].Cells["HD1"].Value.ToString() + dataGridView2.Rows[i].Cells["HD2"].Value.ToString() + dataGridView2.Rows[i].Cells["HD3"].Value.ToString();
                            kh.HOTEN = dataGridView2.Rows[i].Cells["G_HOTEN"].Value.ToString();
                            kh.SONHA = "";
                            kh.TENDUONG = dataGridView2.Rows[i].Cells["DIACHI"].Value.ToString();
                            kh.PHUONG = dataGridView2.Rows[i].Cells["PHUONG"].Value.ToString();
                            kh.QUAN = dataGridView2.Rows[i].Cells["QUAN"].Value.ToString();
                            kh.GIABIEU = dataGridView2.Rows[i].Cells["GB"].Value.ToString();
                            kh.DINHMUC = dataGridView2.Rows[i].Cells["DM"].Value.ToString();
                            kh.CODH = dataGridView2.Rows[i].Cells["TLK"].Value.ToString();
                            kh.HIEUDH = dataGridView2.Rows[i].Cells["HIEU"].Value.ToString();
                            kh.SOTHANDH = dataGridView2.Rows[i].Cells["SOTHAN"].Value.ToString();
                            kh.NGAYTHAY = DateTime.ParseExact(dataGridView2.Rows[i].Cells["NGAYGAN"].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture); ;
                            kh.BAOTHAY = false;
                            kh.CREATEDATE = DateTime.Now;
                            kh.CREATEBY = dataGridView2.Rows[i].Cells["DOT1"].Value.ToString();
                            kh.BKGANMOI = this.txtDotGM.Text;
                            string[] sdate = dataGridView2.Rows[i].Cells["HIEULUC"].Value.ToString().Split('/');
                            kh.KY = int.Parse(sdate[0]);
                            kh.NAM = int.Parse(sdate[1]);
                            kh.KY_ = int.Parse(sdate[0]);
                            kh.TODS = tods();
                            result += DAL.DULIEUKH.C_DuLieuKhachHang.Insert(kh);
                        }
                        else
                        {
                            kh.KHU = "4";
                            kh.DOT = dataGridView2.Rows[i].Cells["DOT2"].Value.ToString();
                            kh.CUON_GCS = dataGridView2.Rows[i].Cells["LT2"].Value.ToString();
                            kh.CUON_STT = dataGridView2.Rows[i].Cells["LT3"].Value.ToString();
                            kh.LOTRINH = dataGridView2.Rows[i].Cells["LT1"].Value.ToString() + dataGridView2.Rows[i].Cells["LT2"].Value.ToString() + dataGridView2.Rows[i].Cells["LT3"].Value.ToString();
                            kh.DANHBO = danhbo;
                            kh.NGAYGANDH = dataGridView2.Rows[i].Cells["NGAYGAN"].Value.ToString();
                            kh.HOPDONG = dataGridView2.Rows[i].Cells["HD1"].Value.ToString() + dataGridView2.Rows[i].Cells["HD2"].Value.ToString() + dataGridView2.Rows[i].Cells["HD3"].Value.ToString();
                            kh.HOTEN = dataGridView2.Rows[i].Cells["G_HOTEN"].Value.ToString();
                            kh.SONHA = "";
                            kh.TENDUONG = dataGridView2.Rows[i].Cells["DIACHI"].Value.ToString();
                            kh.PHUONG = dataGridView2.Rows[i].Cells["PHUONG"].Value.ToString();
                            kh.QUAN = dataGridView2.Rows[i].Cells["QUAN"].Value.ToString();
                            kh.GIABIEU = dataGridView2.Rows[i].Cells["GB"].Value.ToString();
                            kh.DINHMUC = dataGridView2.Rows[i].Cells["DM"].Value.ToString();
                            kh.CODH = dataGridView2.Rows[i].Cells["TLK"].Value.ToString();
                            kh.HIEUDH = dataGridView2.Rows[i].Cells["HIEU"].Value.ToString();
                            kh.SOTHANDH = dataGridView2.Rows[i].Cells["SOTHAN"].Value.ToString();
                            kh.NGAYTHAY = DateTime.ParseExact(dataGridView2.Rows[i].Cells["NGAYGAN"].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture); ;
                            kh.BAOTHAY = false;
                            kh.CREATEDATE = DateTime.Now;
                            kh.CREATEBY = dataGridView2.Rows[i].Cells["DOT1"].Value.ToString();
                            kh.BKGANMOI = this.txtDotGM.Text;
                            string[] sdate = dataGridView2.Rows[i].Cells["HIEULUC"].Value.ToString().Split('/');
                            kh.KY = int.Parse(sdate[0]);
                            kh.NAM = int.Parse(sdate[1]);
                            kh.KY_ = int.Parse(sdate[0]);
                            kh.TODS = tods();
                            DAL.DULIEUKH.C_DuLieuKhachHang.Update();
                            log.Error("Trung danh bo " + danhbo);
                        }
                    }
                    else {
                        this.dataGridView2.Rows[i].Cells["0"].ErrorText = "Lỗi ! Kiểm Tra Dữ Liệu !";
                    }
                    
	            }
	            catch (Exception ex)
	            {
                    log.Error(ex);
                    this.dataGridView2.Rows[i].Cells[0].ErrorText = "Lỗi ! Kiểm Tra Dữ Liệu !";
	            }
                
            }
            ////
            listDanhBa = listDanhBa.Remove(listDanhBa.Length - 1, 1);
            string _sql = "SELECT ROW_NUMBER() OVER (ORDER BY DANHBO  DESC) [STT],DOT,LOTRINH,DANHBO,HOPDONG,HOTEN,SONHA +' ' + TENDUONG AS DIACHI,CODH AS TLK,NGAYTHAY,SOTHANDH,HIEUDH,QUAN,PHUONG,GIABIEU,DINHMUC,(CONVERT(VARCHAR(10),KY)+'/' + CONVERT(VARCHAR(10),NAM)) AS HL ";
            _sql +=" FROM TB_DULIEUKHACHHANG ";
            _sql += "WHERE DANHBO IN (" + listDanhBa + ")";
            dataGridView3.DataSource = DAL.LinQConnection.getDataTable(_sql);
            label1.Text = "Tổng số db gắn mới " + result +" ";

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView2.Rows.Clear();
            }
            catch (Exception)
            {
                
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, tods()+"");
        }
    }
}

//private System.Windows.Forms.DataGridViewTextBoxColumn G_STT;
//        private System.Windows.Forms.DataGridViewTextBoxColumn G_HOTEN;
//        private System.Windows.Forms.DataGridViewTextBoxColumn DIACHI;
//        private System.Windows.Forms.DataGridViewTextBoxColumn TLK;
//        private System.Windows.Forms.DataGridViewTextBoxColumn NGAYGAN;
//        private System.Windows.Forms.DataGridViewTextBoxColumn SOTHAN;
//        private System.Windows.Forms.DataGridViewTextBoxColumn HIEU;
//        private System.Windows.Forms.DataGridViewTextBoxColumn CSGAN;
//        private System.Windows.Forms.DataGridViewTextBoxColumn HD1;
//        private System.Windows.Forms.DataGridViewTextBoxColumn HD2;
//        private System.Windows.Forms.DataGridViewTextBoxColumn HD3;
//        private System.Windows.Forms.DataGridViewTextBoxColumn LT1;
//        private System.Windows.Forms.DataGridViewTextBoxColumn LT2;
//        private System.Windows.Forms.DataGridViewTextBoxColumn LT3;
//        private System.Windows.Forms.DataGridViewTextBoxColumn DANHBO;
//        private System.Windows.Forms.DataGridViewTextBoxColumn QUAN;
//        private System.Windows.Forms.DataGridViewTextBoxColumn PHUONG;
//        private System.Windows.Forms.DataGridViewTextBoxColumn GB;
//        private System.Windows.Forms.DataGridViewTextBoxColumn DM;
//        private System.Windows.Forms.DataGridViewTextBoxColumn DOT1;
//        private System.Windows.Forms.DataGridViewTextBoxColumn DOT2;
//        private System.Windows.Forms.DataGridViewTextBoxColumn HIEULUC;
//        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
//        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;