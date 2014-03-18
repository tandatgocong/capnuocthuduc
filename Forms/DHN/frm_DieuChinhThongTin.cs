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
using CrystalDecisions.CrystalReports.Engine;


namespace CAPNUOCTHUDUC.Forms.DHN
{
    public partial class frm_DieuChinhThongTin : UserControl
    {
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_DieuChinhThongTin).Name);
        public frm_DieuChinhThongTin()
        {
            InitializeComponent();

            DataTable table = DAL.LinQConnection.getDataTable("SELECT TENDONGHO FROM TB_HIEUDONGHO");
            foreach (var item in table.Rows)
            {
                DataRow r = (DataRow)item;
                namesCollection.Add(r["TENDONGHO"].ToString());
            }
            HIEUDH.AutoCompleteMode = AutoCompleteMode.Suggest;
            HIEUDH.AutoCompleteSource = AutoCompleteSource.CustomSource;
            HIEUDH.AutoCompleteCustomSource = namesCollection;

        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                LoadThongTinDB();
            }
        }
        TB_DULIEUKHACHHANG khachhang = null;
        void LoadThongTinDB()
        {
            string sodanhbo = this.txtDanhBo.Text.Replace("-", "");
            if (sodanhbo.Length == 11)
            {
                khachhang = DAL.DULIEUKH.C_DuLieuKhachHang.finByDanhBo(sodanhbo);
                if (khachhang != null)
                {
                    LOTRINH.Text = khachhang.LOTRINH;
                    DOT.Text = khachhang.DOT;
                    HOPDONG.Text = khachhang.HOPDONG;
                    HOTEN.Text = khachhang.HOTEN;
                    SONHA.Text = khachhang.SONHA;
                    TENDUONG.Text = khachhang.TENDUONG;
                    txtDienThoai.Text = khachhang.DIENTHOAI;
                    try
                    {
                        LinQ.TB_QUAN q = DAL.SYS.C_Quan.finByMaQuan(khachhang.QUAN);
                        if (q != null)
                        {
                            QUAN.Text = q.TENQUAN;
                            LinQ.TB_PHUONG ph = DAL.SYS.C_Phuong.finbyPhuong(q.MAQUAN, khachhang.PHUONG.Trim());
                            PHUONGT.Text = ph.TENPHUONG;
                        }
                    }
                    catch (Exception)
                    {
                    }
                    txtHieuLuc.Text = String.Format("{0:00}", khachhang.KY) + "/" + khachhang.NAM;
                    GIABIEU.Text = khachhang.GIABIEU;
                    DINHMUC.Text = khachhang.DINHMUC;
                    NGAYGAN.ValueObject = khachhang.NGAYTHAY;
                    KIEMDINH.ValueObject = khachhang.NGAYKIEMDINH;
                    HIEUDH.Text = khachhang.HIEUDH;
                    CO.Text = khachhang.CODH;
                    CAP.Text = khachhang.CAP;
                    SOTHAN.Text = khachhang.SOTHANDH;
                    VITRI.Text = khachhang.VITRIDHN;
                    CHITHAN.Text = khachhang.CHITHAN;
                    CHIGOC.Text = khachhang.CHIGOC;
                    
                    btCapNhatThongTin.Enabled = true;
                    
                    
                    loadghichu(khachhang.DANHBO);
                    txtGhiChu.Text = "";
                }
                else
                {
                    TB_DULIEUKHACHHANG_HUYDB khachhanghuy = DAL.DULIEUKH.C_DuLieuKhachHang.finByDanhBoHuy(sodanhbo);
                    if (khachhanghuy != null)
                    {
                        LOTRINH.Text = khachhanghuy.LOTRINH;
                        DOT.Text = khachhanghuy.DOT;
                        HOPDONG.Text = khachhanghuy.HOPDONG;
                        HOTEN.Text = khachhanghuy.HOTEN;
                        SONHA.Text = khachhanghuy.SONHA;
                        TENDUONG.Text = khachhanghuy.TENDUONG;
                        try
                        {
                            LinQ.TB_QUAN q = DAL.SYS.C_Quan.finByMaQuan(khachhanghuy.QUAN);
                            if (q != null)
                            {
                                QUAN.Text = q.TENQUAN;
                                LinQ.TB_PHUONG ph = DAL.SYS.C_Phuong.finbyPhuong(q.MAQUAN, khachhanghuy.PHUONG.Trim());
                                PHUONGT.Text = ph.TENPHUONG;
                            }
                        }
                        catch (Exception)
                        {
                        }
                        txtHieuLuc.Text = "Hết HL " + khachhanghuy.HIEULUCHUY;
                        GIABIEU.Text = khachhanghuy.GIABIEU;
                        DINHMUC.Text = khachhanghuy.DINHMUC;
                        NGAYGAN.ValueObject = khachhanghuy.NGAYTHAY;
                        KIEMDINH.ValueObject = khachhanghuy.NGAYKIEMDINH;
                        HIEUDH.Text = khachhanghuy.HIEUDH;
                        CO.Text = khachhanghuy.CODH;
                        CAP.Text = khachhanghuy.CAP;
                        SOTHAN.Text = khachhanghuy.SOTHANDH;
                        VITRI.Text = khachhanghuy.VITRIDHN;
                        CHITHAN.Text = khachhanghuy.CHITHAN;
                        CHIGOC.Text = khachhanghuy.CHIGOC;
                        btCapNhatThongTin.Enabled = false;

                        loadghichu(khachhanghuy.DANHBO);
                    }
                    else
                    {

                        MessageBox.Show(this, "Không Tìm Thấy Thông Tin !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Refesh();
                    }
                }
            }
        }

        public void loadghichu(string danhbo) {
            lichsuGhiCHu.DataSource = DAL.DULIEUKH.C_DuLieuKhachHang.lisGhiChu(danhbo);
            for (int i = 0; i < lichsuGhiCHu.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    lichsuGhiCHu.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(217)))));
                }
                else
                {
                    lichsuGhiCHu.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                }
            }
        }
        public void Refesh() {
            LOTRINH.Text ="";
            DOT.Text = "";
            HOPDONG.Text = "";
            HOTEN.Text = "";
            SONHA.Text = "";
            TENDUONG.Text = "";
            QUAN.Text = "";           
            PHUONGT.Text = "";
            GIABIEU.Text = "";
            DINHMUC.Text = "";
            NGAYGAN.ValueObject = DateTime.Now.Date;
            KIEMDINH.ValueObject = DateTime.Now.Date;
            HIEUDH.Text =  "";
            CO.Text =  "";
            CAP.Text =  "";
            SOTHAN.Text  = "";
            VITRI.Text = "";
            CHITHAN.Text = "";
            CHIGOC.Text = "";
          
            txtDanhBo.Focus();
        
        }
        private void btCapNhatThongTin_Click(object sender, EventArgs e)
        {
            if (khachhang != null)
            {
                khachhang.HOPDONG = HOPDONG.Text.ToUpper();
                khachhang.HOTEN = HOTEN.Text.ToUpper();               
                khachhang.SONHA = SONHA.Text.ToUpper();
                khachhang.TENDUONG = TENDUONG.Text.ToUpper();
                khachhang.DIENTHOAI = txtDienThoai.Text;
                if (!"".Equals(this.NGAYGAN.ValueObject + ""))
                {
                    khachhang.NGAYTHAY = this.NGAYGAN.Value;
                }
                if (!"".Equals(this.KIEMDINH.ValueObject + ""))
                {
                    khachhang.NGAYKIEMDINH = this.KIEMDINH.Value;
                }
                khachhang.HIEUDH = HIEUDH.Text.ToUpper();
                khachhang.GIABIEU = GIABIEU.Text;
                khachhang.DINHMUC = DINHMUC.Text;
                khachhang.CODH = CO.Text;
                khachhang.CAP = CAP.Text;
                khachhang.SOTHANDH = SOTHAN.Text;
                khachhang.VITRIDHN = VITRI.Text;
                khachhang.CHITHAN = CHITHAN.Text;
                khachhang.CHIGOC = CHIGOC.Text;
                khachhang.MODIFYBY = "";
                khachhang.MODIFYDATE = DateTime.Now;
                if (DAL.DULIEUKH.C_DuLieuKhachHang.Update())
                {
                    //cap nhat handheld
                   // DAL.DULIEUKH.C_PhienLoTrinh.CapNhatThongTinHandHeld(this.txtDanhBo.Text.Replace("-", ""), HIEUDH.Text.Substring(0, 3), SOTHAN.Text, CHITHAN.Text.ToUpper(), CHIGOC.Text.ToUpper(), VITRI.Text);
                    //cap nhat ghi chu
                    if ("".Equals(txtGhiChu.Text.Replace(" ",""))==false) {
                        TB_GHICHU ghichu = new TB_GHICHU();
                        ghichu.DANHBO = khachhang.DANHBO;
                        ghichu.NOIDUNG = txtGhiChu.Text;
                        ghichu.DONVI = "QLDHN";
                        ghichu.CREATEDATE = DateTime.Now.Date;
                        ghichu.CREATEBY = "";
                        DAL.DULIEUKH.C_DuLieuKhachHang.InsertGHICHU(ghichu);
                        loadghichu(khachhang.DANHBO);
                        // CAPNHAT GHICU HANDHELD
                      //  DAL.DULIEUKH.C_PhienLoTrinh.CapNhatGhiChu(this.txtDanhBo.Text.Replace("-", ""), txtGhiChu.Text);

                    }
                    //
                    MessageBox.Show(this, "Cập Nhật Thông Tin Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtGhiChu.Text = "";
                    txtDanhBo.Focus();
                }
                else
                {
                    MessageBox.Show(this, "Cập Nhật Thông Tin Thất Bại !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }


        private void lichsuGhiCHu_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(lichsuGhiCHu, new Point(e.X, e.Y));
            }
        }

        private void menuCapNhatKetQua_Click(object sender, EventArgs e)
        {
            string ID_ = this.lichsuGhiCHu.Rows[lichsuGhiCHu.CurrentRow.Index].Cells["ID"].Value + "";
            DAL.LinQConnection.ExecuteCommand_("DELETE FROM TB_GHICHU WHERE ID='"+ID_+"'");
            string sodanhbo = this.txtDanhBo.Text.Replace("-", "");
            loadghichu(sodanhbo);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //string ID_ = this.lichsuGhiCHu.Rows[lichsuGhiCHu.CurrentRow.Index].Cells["ID"].Value + "";
            //frm_CapNhatGhiChu frm = new frm_CapNhatGhiChu(ID_);
            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    string sodanhbo = this.txtDanhBo.Text.Replace("-", "");
            //    loadghichu(sodanhbo);
            //}
        }

  
    }
}