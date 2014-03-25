using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using CAPNUOCTHUDUC.LinQ;
using Microsoft.Reporting.WinForms;

namespace CAPNUOCTHUDUC.Forms.DHN.Tab
{
    public partial class A_tab_PhanTichDHN : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(A_tab_ThongKeDHN).Name);
        public A_tab_PhanTichDHN()
        {
            InitializeComponent();
            this.txtNam.Text = DateTime.Now.Year.ToString();
            cbKyDS.SelectedIndex = DateTime.Now.Month - 1;

        }

        private void btThem_Click(object sender, EventArgs e)
        {
            int ky = int.Parse(cbKyDS.Items[cbKyDS.SelectedIndex].ToString());
            int nam = int.Parse(txtNam.Text.Trim());
            string quanphuong = DAL.ThaoTac.getDuLieu(rDoi, rThuDuc, rQuan9, rQuan2);
            string sql = "";
            reportHieuDHN.Visible = true;

            sql += " SELECT hdn.TENDONGHO,  ";
			sql += " 	COUNT(CASE WHEN CODH=15 THEN 1 ELSE NULL END) AS CO15,  ";
			sql += " 	COUNT(CASE WHEN CODH=20 THEN 1 ELSE NULL END) AS CO20,  ";
			sql += " 	COUNT(CASE WHEN CODH=25 THEN 1 ELSE NULL END) AS CO25,  ";
			sql += " 	COUNT(CASE WHEN CODH=30 THEN 1 ELSE NULL END) AS CO30,  ";
			sql += " 	COUNT(CASE WHEN CODH=40 THEN 1 ELSE NULL END) AS CO40, ";
			sql += " 	COUNT(CASE WHEN CODH=50 THEN 1 ELSE NULL END) AS CO50, ";
			sql += " 	COUNT(CASE WHEN (CODH=75 OR  CODH= 80) THEN 1 ELSE NULL END) AS CO80, ";
			sql += " 	COUNT(CASE WHEN CODH=100 THEN 1 ELSE NULL END) AS CO100, ";
			sql += " 	COUNT(CASE WHEN CODH=150 THEN 1 ELSE NULL END) AS CO150, ";
			sql += " 	COUNT(CASE WHEN CODH=200 THEN 1 ELSE NULL END) AS CO200, ";
			sql += " 	COUNT(CASE WHEN CODH=300 THEN 1 ELSE NULL END) AS CO300, ";
			sql += " 	COUNT(CASE WHEN CODH=400 THEN 1 ELSE NULL END) AS CO400, ";
			sql += " 	COUNT(CASE WHEN CODH=15 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) < 5) THEN 1 ELSE NULL END) AS NHOCO15, ";
			sql += " 	COUNT(CASE WHEN CODH=20 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) < 5) THEN 1 ELSE NULL END) AS NHOCO20, ";
			sql += " 	COUNT(CASE WHEN CODH=25 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) < 5) THEN 1 ELSE NULL END) AS NHOCO25, ";
			sql += " 	COUNT(CASE WHEN CODH=30 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) < 5) THEN 1 ELSE NULL END) AS NHOCO30, ";
			sql += " 	COUNT(CASE WHEN CODH=40 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) < 5) THEN 1 ELSE NULL END) AS NHOCO40, ";
			sql += " 	COUNT(CASE WHEN CODH=50 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) < 5) THEN 1 ELSE NULL END) AS NHOCO50, ";
			sql += " 	COUNT(CASE WHEN (CODH=75 OR  CODH= 80) AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) < 5)  THEN 1 ELSE NULL END) AS NHOCO80, ";
			sql += " 	COUNT(CASE WHEN CODH=100 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) < 5) THEN 1 ELSE NULL END) AS NHOCO100, ";
			sql += " 	COUNT(CASE WHEN CODH=150 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) < 5) THEN 1 ELSE NULL END) AS NHOCO150, ";
			sql += " 	COUNT(CASE WHEN CODH=200 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) < 5) THEN 1 ELSE NULL END) AS NHOCO200, ";
			sql += " 	COUNT(CASE WHEN CODH=300 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) < 5) THEN 1 ELSE NULL END) AS NHOCO300, ";
			sql += " 	COUNT(CASE WHEN CODH=400 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) < 5) THEN 1 ELSE NULL END) AS NHOCO400, ";
			sql += " 	COUNT(CASE WHEN CODH=15 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >=5) THEN 1 ELSE NULL END) AS LONCO15, ";
			sql += " 	COUNT(CASE WHEN CODH=20 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >=5) THEN 1 ELSE NULL END) AS LONCO20, ";
			sql += " 	COUNT(CASE WHEN CODH=25 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >=5) THEN 1 ELSE NULL END) AS LONCO25, ";
			sql += " 	COUNT(CASE WHEN CODH=30 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >=5) THEN 1 ELSE NULL END) AS LONCO30, ";
			sql += " 	COUNT(CASE WHEN CODH=40 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >=5) THEN 1 ELSE NULL END) AS LONCO40, ";
			sql += " 	COUNT(CASE WHEN CODH=50 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >=5) THEN 1 ELSE NULL END) AS LONCO50, ";
			sql += " 	COUNT(CASE WHEN (CODH=75 OR  CODH= 80) AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >=5)  THEN 1 ELSE NULL END) AS LONCO80, ";
			sql += " 	COUNT(CASE WHEN CODH=100 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >=5) THEN 1 ELSE NULL END) AS LONCO100, ";
			sql += " 	COUNT(CASE WHEN CODH=150 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >=5) THEN 1 ELSE NULL END) AS LONCO150, ";
			sql += " 	COUNT(CASE WHEN CODH=200 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >=5) THEN 1 ELSE NULL END) AS LONCO200, ";
			sql += " 	COUNT(CASE WHEN CODH=300 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >=5) THEN 1 ELSE NULL END) AS LONCO300, ";
			sql += " 	COUNT(CASE WHEN CODH=400 AND ((YEAR(CURRENT_TIMESTAMP) -YEAR(NGAYTHAY)) >=5) THEN 1 ELSE NULL END) AS LONCO400	 ";
            sql += " FROM dbo.TB_DULIEUKHACHHANG kh, TB_HIEUDONGHO hdn ";
            sql += " WHERE LEFT(kh.HIEUDH,3)=hdn.HIEUDH AND kh.NAM<=" + nam + " AND kh.KY_<=" + ky + quanphuong;
            sql += " GROUP BY  hdn.TENDONGHO ";
            DataTable bang = DAL.LinQConnection.getDataTable(sql);
            this.reportHieuDHN.LocalReport.DataSources.Clear();

            ReportParameter p1 = new ReportParameter("hl", " KỲ " + ky + "/" + nam);
            ReportParameter p2 = new ReportParameter("tods", DAL.ThaoTac.getToDS(rDoi, rThuDuc, rQuan9, rQuan2));
            this.reportHieuDHN.LocalReport.SetParameters(new ReportParameter[] { p1, p2 });
            this.reportHieuDHN.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("TB_HIEUDONGHO", bang));

            this.reportHieuDHN.RefreshReport();
            //MessageBox.Show(this, reportViewer1.LocalReport.ReportPath.ToString());
        }
    }
}