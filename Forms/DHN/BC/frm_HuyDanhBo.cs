using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace CAPNUOCTHUDUC.Forms.DHN.BC
{
    public partial class frm_HuyDanhBo : Form
    {
        public frm_HuyDanhBo(string tods, string hieulucky, string tento)
        {
            InitializeComponent();

            string sql = "SELECT ROW_NUMBER() OVER (ORDER BY DANHBO  DESC) [STT],SOPHIEU,DANHBO,HOPDONG,HOTEN,(SONHA + ' ' + TENDUONG) AS DIACHI,NGUYENNHAN ";
            sql += " FROM TB_DULIEUKHACHHANG_HUYDB ";
            if ("".Equals(tods))
            {
                sql += " WHERE  (TAILAPDB IS NULL OR TAILAPDB='False') AND HIEULUCHUY=N'" + hieulucky + "'";
            }
            else
            {
                sql += " WHERE LEFT(HOPDONG,2)='" + tods + "' AND (TAILAPDB IS NULL OR TAILAPDB='False') AND HIEULUCHUY=N'" + hieulucky + "'";
            }
            sql += " ORDER BY DANHBO ASC";

            DataTable bang = DAL.LinQConnection.getDataTable(sql);
            this.reportViewer1.LocalReport.DataSources.Clear();

            ReportParameter p1 = new ReportParameter("hl", " KỲ " + hieulucky);
            ReportParameter p2 = new ReportParameter("tods", tento);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2 });

            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("HUYDB", bang));

            this.reportViewer1.RefreshReport();

        }

        private void frm_HuyDanhBo_Load(object sender, EventArgs e)
        {

            
        }
    }
}
