using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAPNUOCTHUDUC.Forms.DHN.Tab;

namespace CAPNUOCTHUDUC.Forms.DHN
{
    public partial class frm_BaoCaoTongKet : UserControl
    {
        public frm_BaoCaoTongKet()
        {
            InitializeComponent();
            this.splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(new A_tab_ThongKeDHN());
        }

        private void radioThayDinhKy_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
           // this.splitContainer1.Panel2.Controls.Add(new tbTongKetDinhKy());
        }

        private void rtThongKeDHN_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(new A_tab_ThongKeDHN());
        }

        private void rptGanMoi_CheckedChanged(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(new A_tab_ThongKeDHN_GM());
        }
    }
}