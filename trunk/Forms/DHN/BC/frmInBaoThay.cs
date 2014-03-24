using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CAPNUOCTHUDUC.Forms.DHN.BC
{
    public partial class frmInBaoThay : Form
    {
        public frmInBaoThay( string danhbo, string sobk)
        {
            InitializeComponent();
            if (!danhbo.Equals(""))
            {
                string sql = "	SELECT kh.HOPDONG,kh.LOTRINH,kh.HOTEN,kh.SONHA,kh.TENDUONG,ID_BAOTHAY, DHN_LANTHAY, DHN_LOAIBANGKE, DHN_SOBANGKE, DHN_STT, DHN_DANHBO, DHN_NGAYBAOTHAY, DHN_DOT, DHN_TODS, DHN_NGAYGAN, DHN_CHITHAN, DHN_CHIGOC, DHN_HIEUDHN, DHN_CODH,CONVERT(varchar(10),kh.NGAYKIEMDINH,3) as  'DHN_CAP', DHN_SOTHAN, DHN_CHISO, DHN_LYDOTHAY, DHN_GHICHU, DHN_NGAYCHUYEN, DHN_CREATEDATE, DHN_CREATEBY, DHN_MODIFYDATE, DHN_MODIFYBY, HCT_CHISOGO, HCT_SOTHANGO, HCT_HIEUDHNGAN, HCT_CODHNGAN, HCT_CAP, HCT_SOTHANGAN, HCT_CHISOGAN, HCT_LOAIDHGAN, HCT_NGAYGAN, HCT_NGAYKIEMDINH, HCT_CHITHAN, HCT_CHIGOC, HCT_TRONGAI, HCT_LYDOTRONGAI, HCT_CREATEDATE, HCT_CREATEBY, HCT_MODIFYDATE, HCT_MODIFYBY, XLT_XULY, XLT_CHUYENXL, XLT_NGAYCHUYEN, XLT_TRAKQ, XLT_KETQUA, XLT_NGAYCAPNHAT, XLT_CREATEDATE, XLT_CREATEBY ";
                sql += " FROM TB_THAYDHN thay, TB_DULIEUKHACHHANG kh ";
                sql += " WHERE thay.DHN_DANHBO=kh.DANHBO";
                sql += " AND DHN_DANHBO IN (" + danhbo + ") ";
                sql += " ORDER BY DHN_DANHBO ASC";

                DataTable bang = DAL.LinQConnection.getDataTable(sql);
                this.reportViewer1.LocalReport.DataSources.Clear();

                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("RP_THAYDHN", bang));

                this.reportViewer1.RefreshReport();
            }
            else {
                string sql = "	SELECT kh.HOPDONG,kh.LOTRINH,kh.HOTEN,kh.SONHA,kh.TENDUONG,ID_BAOTHAY, DHN_LANTHAY, DHN_LOAIBANGKE, DHN_SOBANGKE, DHN_STT, DHN_DANHBO, DHN_NGAYBAOTHAY, DHN_DOT, DHN_TODS, DHN_NGAYGAN, DHN_CHITHAN, DHN_CHIGOC, DHN_HIEUDHN, DHN_CODH,CONVERT(varchar(10),kh.NGAYKIEMDINH,3) as  'DHN_CAP', DHN_SOTHAN, DHN_CHISO, DHN_LYDOTHAY, DHN_GHICHU, DHN_NGAYCHUYEN, DHN_CREATEDATE, DHN_CREATEBY, DHN_MODIFYDATE, DHN_MODIFYBY, HCT_CHISOGO, HCT_SOTHANGO, HCT_HIEUDHNGAN, HCT_CODHNGAN, HCT_CAP, HCT_SOTHANGAN, HCT_CHISOGAN, HCT_LOAIDHGAN, HCT_NGAYGAN, HCT_NGAYKIEMDINH, HCT_CHITHAN, HCT_CHIGOC, HCT_TRONGAI, HCT_LYDOTRONGAI, HCT_CREATEDATE, HCT_CREATEBY, HCT_MODIFYDATE, HCT_MODIFYBY, XLT_XULY, XLT_CHUYENXL, XLT_NGAYCHUYEN, XLT_TRAKQ, XLT_KETQUA, XLT_NGAYCAPNHAT, XLT_CREATEDATE, XLT_CREATEBY ";
                sql += " FROM TB_THAYDHN thay, TB_DULIEUKHACHHANG kh ";
                sql += " WHERE thay.DHN_DANHBO=kh.DANHBO";
                sql += " AND DHN_SOBANGKE ='" + sobk + "' ";
                sql += " ORDER BY DHN_DANHBO ASC";

                DataTable bang = DAL.LinQConnection.getDataTable(sql);
                this.reportViewer1.LocalReport.DataSources.Clear();

                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("RP_THAYDHN", bang));

                this.reportViewer1.RefreshReport();
            }
          

        }

        private void frmInBaoThay_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
