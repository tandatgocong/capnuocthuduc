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

        }

        private void btThem_Click(object sender, EventArgs e)
        {
            int ky = int.Parse(cbKyDS.Items[cbKyDS.SelectedIndex].ToString());
            int nam = int.Parse(txtNam.Text.Trim());
            string quanphuong = DAL.ThaoTac.getDuLieu(DoiCheck, TDcheck, Q9check, Q2check, BDcheck);
            //ReportDocument rp = new rpt_ThongKeDongHoNuoc_();
            //rp.SetDataSource(DAL.QLDHN.C_QuanLyDongHoNuoc.getThongKeDHN(ky, nam, DAL.SYS.C_USERS._toDocSo));
            //rp.SetParameterValue("KY", ky);
            //rp.SetParameterValue("NAM", nam);
            //crystalReportViewer1.ReportSource = rp;
        }

    }
}
