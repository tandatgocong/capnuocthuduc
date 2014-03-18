using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using System.Configuration;
using CAPNUOCTHUDUC.Forms.DHN;
namespace CAPNUOCTHUDUC
{
    public partial class frm_Main : Form
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_Main).Name);
        public frm_Main()
        {
            InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();
            Utilities.Files.getFileOnServer();
        }


        private void frm_Main_Load(object sender, EventArgs e)
        {
          

        }

        private void caculator_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void microsoftWord_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("WINWORD.EXE");
        }

        private void microsoftAccess_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("MSACCESS.EXE");
        }

        private void microsoftExcel_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("EXCEL.EXE");
        }





        private void frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void baocaoTongKet_Click(object sender, EventArgs e)
        {
            PanelContent.Controls.Clear();
            frm_BaoCaoTongKet baothay = new frm_BaoCaoTongKet();
            baothay.Height = PanelContent.Size.Height - 20;
            baothay.Width = PanelContent.Size.Width - 20;
            PanelContent.Controls.Add(baothay);
        }

        private void menuHeThong_Click(object sender, EventArgs e)
        {
            PanelContent.Controls.Clear();
            PanelContent.Controls.Add(panelHome);
        }

        private void menuTCTB_Click(object sender, EventArgs e)
        {
            //PanelContent.Controls.Clear();
            //frm_BaoCaoTCTB baothay = new frm_BaoCaoTCTB();
            //baothay.Height = PanelContent.Size.Height - 20;
            //baothay.Width = PanelContent.Size.Width - 20;
            //PanelContent.Controls.Add(baothay);
        }

        private void hcThayThuDHN_Click(object sender, EventArgs e)
        {

        }

        private void menuLayDuLieuGanMoi_Click(object sender, EventArgs e)
        {
            //PanelContent.Controls.Clear();
            //frm_GetDataGanMoi baothay = new frm_GetDataGanMoi();
            //baothay.Height = PanelContent.Size.Height - 20;
            //baothay.Width = PanelContent.Size.Width - 20;
            //PanelContent.Controls.Add(baothay);
        }

        private void btChuyenBK_Click(object sender, EventArgs e)
        {
            //PanelContent.Controls.Clear();
            //frm_LoTrinhDocSo baothay = new frm_LoTrinhDocSo();
            //baothay.Height = PanelContent.Size.Height - 20;
            //baothay.Width = PanelContent.Size.Width - 20;
            //PanelContent.Controls.Add(baothay);
        }

        private void chiso_Click(object sender, EventArgs e)
        {
            //frm_SoDocSo frm = new frm_SoDocSo();
            //frm.ShowDialog();
        }

        private void menuDieuChinhKH_Click(object sender, EventArgs e)
        {
            PanelContent.Controls.Clear();
            frm_KiemTraThayDinhKy baothay = new frm_KiemTraThayDinhKy();
            //baothay.Height = PanelContent.Size.Height - 20;
            //baothay.Width = PanelContent.Size.Width - 20;
            baothay.Height = PanelContent.Size.Height - 5;
            baothay.Width = PanelContent.Size.Width - 5;
            PanelContent.Controls.Add(baothay);
        }

        private void tbTraCuuThongTin_Click(object sender, EventArgs e)
        {
            //PanelContent.Controls.Clear();
            //// frm_LayDuLieuGanMoi_Ky baothay = new frm_LayDuLieuGanMoi_Ky();
            //frmPhieuChepTieuThu baothay = new frmPhieuChepTieuThu();
            ////baothay.Height = PanelContent.Size.Height - 20;
            ////baothay.Width = PanelContent.Size.Width - 20;
            //baothay.Height = PanelContent.Size.Height - 5;
            //baothay.Width = PanelContent.Size.Width - 5;
            //PanelContent.Controls.Add(baothay);
        }

        private void yeucaukiemtra_Click(object sender, EventArgs e)
        {
            //PanelContent.Controls.Clear();
            //// frm_LayDuLieuGanMoi_Ky baothay = new frm_LayDuLieuGanMoi_Ky();
            //frm_PhieuKiemTra baothay = new frm_PhieuKiemTra();
            ////baothay.Height = PanelContent.Size.Height - 20;
            ////baothay.Width = PanelContent.Size.Width - 20;
            //baothay.Height = PanelContent.Size.Height - 5;
            //baothay.Width = PanelContent.Size.Width - 5;
            //PanelContent.Controls.Add(baothay);
        }

        private void menuKiemTra_Click(object sender, EventArgs e)
        {
            PanelContent.Controls.Clear();
            // frm_LayDuLieuGanMoi_Ky baothay = new frm_LayDuLieuGanMoi_Ky();
            frm_DieuChinhThongTin baothay = new frm_DieuChinhThongTin();
            //baothay.Height = PanelContent.Size.Height - 20;
            //baothay.Width = PanelContent.Size.Width - 20;
            baothay.Height = PanelContent.Size.Height - 5;
            baothay.Width = PanelContent.Size.Width - 5;
            PanelContent.Controls.Add(baothay);
        }
    }
}