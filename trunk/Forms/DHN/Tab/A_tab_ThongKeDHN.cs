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
    public partial class A_tab_ThongKeDHN : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(A_tab_ThongKeDHN).Name);
        public A_tab_ThongKeDHN()
        {
            InitializeComponent();
            this.txtNam.Text = DateTime.Now.Year.ToString();
            cbKyDS.SelectedIndex = DateTime.Now.Month - 1;
            cbLoaiBC.SelectedIndex = 0;

        }

        private void btThem_Click(object sender, EventArgs e)
        {
            int ky = int.Parse(cbKyDS.Items[cbKyDS.SelectedIndex].ToString());
            int nam = int.Parse(txtNam.Text.Trim());
            string quanphuong = DAL.ThaoTac.getDuLieu(DoiCheck, TDcheck, Q9check, Q2check, BDcheck);
             string sql = "";
            if (cbLoaiBC.SelectedIndex == 0)
            {
                reportHieuDHN.Visible = true;
                reportQP.Visible = false;
                reportNamLD.Visible = false;

                sql = "SELECT LEFT(HIEUDH,3) AS HIEU, ";
                sql += " COUNT(CASE WHEN CODH=15 THEN 1 ELSE NULL END) AS CO15, ";
                sql += " COUNT(CASE WHEN CODH=20 THEN 1 ELSE NULL END) AS CO20,";
                sql += " COUNT(CASE WHEN CODH=25 THEN 1 ELSE NULL END) AS CO25,";
                sql += " COUNT(CASE WHEN CODH=30 THEN 1 ELSE NULL END) AS CO30,";
                sql += " COUNT(CASE WHEN CODH=40 THEN 1 ELSE NULL END) AS CO40,";
                sql += " COUNT(CASE WHEN CODH=50 THEN 1 ELSE NULL END) AS CO50,";
                sql += " COUNT(CASE WHEN CODH=75 THEN 1 ELSE NULL END) AS CO75,";
                sql += " COUNT(CASE WHEN CODH=80 THEN 1 ELSE NULL END) AS CO80,";
                sql += " COUNT(CASE WHEN CODH=100 THEN 1 ELSE NULL END) AS CO100,";
                sql += " COUNT(CASE WHEN CODH=150 THEN 1 ELSE NULL END) AS CO150,";
                sql += " COUNT(CASE WHEN CODH=200 THEN 1 ELSE NULL END) AS CO200,";
                sql += " COUNT(CASE WHEN CODH=300 THEN 1 ELSE NULL END) AS CO300,";
                sql += " COUNT(CASE WHEN CODH=400 THEN 1 ELSE NULL END) AS CO400 ";
                sql += " FROM dbo.TB_DULIEUKHACHHANG kh  ";
                sql += " WHERE kh.NAM<=" + nam + " AND kh.KY_<=" + ky + quanphuong;
                sql += " GROUP BY  LEFT(HIEUDH,3)";
                DataTable bang = DAL.LinQConnection.getDataTable(sql);
                this.reportHieuDHN.LocalReport.DataSources.Clear();
               
                ReportParameter p1 = new ReportParameter("hl", " KỲ " + ky + "/" + nam);
                ReportParameter p2 = new ReportParameter("tods", DAL.ThaoTac.getToDS(DoiCheck, TDcheck, Q9check, Q2check, BDcheck));
                this.reportHieuDHN.LocalReport.SetParameters(new ReportParameter[] { p1,p2 });
                this.reportHieuDHN.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DHN_HIEUDHN", bang));

                this.reportHieuDHN.RefreshReport();
                //MessageBox.Show(this, reportViewer1.LocalReport.ReportPath.ToString());
            }
            else if (cbLoaiBC.SelectedIndex == 1)
            {
                reportHieuDHN.Visible = false;              
                reportNamLD.Visible = false;
                reportQP.Visible = true;
                sql = " SELECT q.MAQUAN,q.TENQUAN,p.MAPHUONG,p.TENPHUONG, ";
		        sql += " COUNT(CASE WHEN CODH=15 THEN 1 ELSE NULL END) AS CO15, ";
                sql += " COUNT(CASE WHEN CODH=20 THEN 1 ELSE NULL END) AS CO20, ";
		        sql += " COUNT(CASE WHEN CODH=25 THEN 1 ELSE NULL END) AS CO25, "; 
		        sql += " COUNT(CASE WHEN CODH=30 THEN 1 ELSE NULL END) AS CO30, ";
		        sql += " COUNT(CASE WHEN CODH=40 THEN 1 ELSE NULL END) AS CO40, ";
		        sql += " COUNT(CASE WHEN CODH=50 THEN 1 ELSE NULL END) AS CO50, ";
		        sql += " COUNT(CASE WHEN CODH=75 THEN 1 ELSE NULL END) AS CO75, ";
		        sql += " COUNT(CASE WHEN CODH=80 THEN 1 ELSE NULL END) AS CO80, ";
		        sql += " COUNT(CASE WHEN CODH=100 THEN 1 ELSE NULL END) AS CO100, ";
		        sql += " COUNT(CASE WHEN CODH=150 THEN 1 ELSE NULL END) AS CO150, ";
		        sql += " COUNT(CASE WHEN CODH=200 THEN 1 ELSE NULL END) AS CO200, ";
		        sql += " COUNT(CASE WHEN CODH=300 THEN 1 ELSE NULL END) AS CO300, ";
		        sql += " COUNT(CASE WHEN CODH=400 THEN 1 ELSE NULL END) AS CO400 ";
	            sql += " FROM dbo.TB_DULIEUKHACHHANG kh ,TB_QUAN q, TB_PHUONG p ";
	            sql += " WHERE kh.QUAN=q.MAQUAN AND kh.PHUONG=p.MAPHUONG AND q.MAQUAN=p.MAQUAN  ";
                sql += " AND  kh.NAM<=" + nam + " AND kh.KY_<=" + ky + quanphuong;
	            sql += " GROUP BY q.MAQUAN,q.TENQUAN,p.MAPHUONG,p.TENPHUONG ";
                sql += " ORDER BY q.MAQUAN ASC, p.MAPHUONG ASC ";
                DataTable bang = DAL.LinQConnection.getDataTable(sql);
                reportQP.LocalReport.DataSources.Clear();
                ReportParameter p1 = new ReportParameter("hl", " KỲ " + ky + "/" + nam);
                ReportParameter p2 = new ReportParameter("tods", DAL.ThaoTac.getToDS(DoiCheck, TDcheck, Q9check, Q2check, BDcheck));
                this.reportQP.LocalReport.SetParameters(new ReportParameter[] { p1, p2 });
                reportQP.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DHN_QUANPHUONG", bang));
                this.reportQP.RefreshReport();
            }
            else{
                reportHieuDHN.Visible = false;              
                reportNamLD.Visible = true;
                reportQP.Visible = false;
                sql = " SELECT YEAR(NGAYTHAY) , ";
                sql += " COUNT(CASE WHEN CODH=15 THEN 1 ELSE NULL END) AS CO15, ";
                sql += " COUNT(CASE WHEN CODH=20 THEN 1 ELSE NULL END) AS CO20, ";
                sql += " COUNT(CASE WHEN CODH=25 THEN 1 ELSE NULL END) AS CO25, ";
                sql += " COUNT(CASE WHEN CODH=30 THEN 1 ELSE NULL END) AS CO30, ";
                sql += " COUNT(CASE WHEN CODH=40 THEN 1 ELSE NULL END) AS CO40, ";
                sql += " COUNT(CASE WHEN CODH=50 THEN 1 ELSE NULL END) AS CO50, ";
                sql += " COUNT(CASE WHEN CODH=75 THEN 1 ELSE NULL END) AS CO75, ";
                sql += " COUNT(CASE WHEN CODH=80 THEN 1 ELSE NULL END) AS CO80, ";
                sql += " COUNT(CASE WHEN CODH=100 THEN 1 ELSE NULL END) AS CO100, ";
                sql += " COUNT(CASE WHEN CODH=150 THEN 1 ELSE NULL END) AS CO150, ";
                sql += " COUNT(CASE WHEN CODH=200 THEN 1 ELSE NULL END) AS CO200, ";
                sql += " COUNT(CASE WHEN CODH=300 THEN 1 ELSE NULL END) AS CO300, ";
                sql += " COUNT(CASE WHEN CODH=400 THEN 1 ELSE NULL END) AS CO400 ";
                sql += " FROM dbo.TB_DULIEUKHACHHANG kh  ";
                sql += " WHERE  kh.NAM<=" + nam + " AND kh.KY_<=" + ky + quanphuong;
                sql += " GROUP BY YEAR(NGAYTHAY)  ";
                sql += " ORDER BY YEAR(NGAYTHAY)  ASC ";
                DataTable bang = DAL.LinQConnection.getDataTable(sql);
                reportNamLD.LocalReport.DataSources.Clear();
                ReportParameter p1 = new ReportParameter("hl", " KỲ " + ky + "/" + nam);
                ReportParameter p2 = new ReportParameter("tods", DAL.ThaoTac.getToDS(DoiCheck, TDcheck, Q9check, Q2check, BDcheck));
                this.reportNamLD.LocalReport.SetParameters(new ReportParameter[] { p1, p2 });
                reportNamLD.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DHN_NAMLD", bang));
                this.reportNamLD.RefreshReport();

            }
            


        }

        private void TDcheck_CheckedChanged(object sender, EventArgs e)
        {
            this.DoiCheck.Checked = false;
        }

        private void DoiCheck_CheckedChanged(object sender, EventArgs e)
        {
            this.TDcheck.Checked = false;
            this.BDcheck.Checked = false;
            this.Q2check.Checked = false;
            this.Q9check.Checked = false;
        }

    }
}
