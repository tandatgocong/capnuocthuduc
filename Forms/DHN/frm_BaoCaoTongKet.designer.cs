﻿namespace CAPNUOCTHUDUC.Forms.DHN
{
    partial class frm_BaoCaoTongKet
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.expandablePanel1 = new DevComponents.DotNetBar.ExpandablePanel();
            this.rptPhanTichDHN = new System.Windows.Forms.RadioButton();
            this.rptGanMoi = new System.Windows.Forms.RadioButton();
            this.rtThongKeDHN = new System.Windows.Forms.RadioButton();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.expandablePanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.expandablePanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Size = new System.Drawing.Size(1238, 550);
            this.splitContainer1.SplitterDistance = 189;
            this.splitContainer1.TabIndex = 0;
            // 
            // expandablePanel1
            // 
            this.expandablePanel1.CanvasColor = System.Drawing.Color.AliceBlue;
            this.expandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.expandablePanel1.Controls.Add(this.rptPhanTichDHN);
            this.expandablePanel1.Controls.Add(this.rptGanMoi);
            this.expandablePanel1.Controls.Add(this.rtThongKeDHN);
            this.expandablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expandablePanel1.Location = new System.Drawing.Point(0, 0);
            this.expandablePanel1.Name = "expandablePanel1";
            this.expandablePanel1.Size = new System.Drawing.Size(189, 550);
            this.expandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.Sunken;
            this.expandablePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel1.Style.GradientAngle = 90;
            this.expandablePanel1.TabIndex = 4;
            this.expandablePanel1.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel1.TitleStyle.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expandablePanel1.TitleStyle.ForeColor.Color = System.Drawing.Color.Firebrick;
            this.expandablePanel1.TitleStyle.GradientAngle = 90;
            this.expandablePanel1.TitleText = "Danh Mục Báo Cáo";
            // 
            // rptPhanTichDHN
            // 
            this.rptPhanTichDHN.AutoSize = true;
            this.rptPhanTichDHN.Location = new System.Drawing.Point(10, 84);
            this.rptPhanTichDHN.Name = "rptPhanTichDHN";
            this.rptPhanTichDHN.Size = new System.Drawing.Size(138, 23);
            this.rptPhanTichDHN.TabIndex = 3;
            this.rptPhanTichDHN.Text = "Phân Tích ĐHN ";
            this.rptPhanTichDHN.UseVisualStyleBackColor = true;
            this.rptPhanTichDHN.CheckedChanged += new System.EventHandler(this.rptPhanTichDHN_CheckedChanged);
            // 
            // rptGanMoi
            // 
            this.rptGanMoi.AutoSize = true;
            this.rptGanMoi.Location = new System.Drawing.Point(10, 58);
            this.rptGanMoi.Name = "rptGanMoi";
            this.rptGanMoi.Size = new System.Drawing.Size(161, 23);
            this.rptGanMoi.TabIndex = 2;
            this.rptGanMoi.Text = "Thống Kê  Gắn Mới";
            this.rptGanMoi.UseVisualStyleBackColor = true;
            this.rptGanMoi.CheckedChanged += new System.EventHandler(this.rptGanMoi_CheckedChanged);
            // 
            // rtThongKeDHN
            // 
            this.rtThongKeDHN.AutoSize = true;
            this.rtThongKeDHN.Checked = true;
            this.rtThongKeDHN.Location = new System.Drawing.Point(10, 33);
            this.rtThongKeDHN.Name = "rtThongKeDHN";
            this.rtThongKeDHN.Size = new System.Drawing.Size(133, 23);
            this.rtThongKeDHN.TabIndex = 1;
            this.rtThongKeDHN.TabStop = true;
            this.rtThongKeDHN.Text = "Thống Kê ĐHN";
            this.rtThongKeDHN.UseVisualStyleBackColor = true;
            this.rtThongKeDHN.Click += new System.EventHandler(this.rtThongKeDHN_Click);
            // 
            // frm_BaoCaoTongKet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Times New Roman", 12.75F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_BaoCaoTongKet";
            this.Size = new System.Drawing.Size(1238, 550);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.expandablePanel1.ResumeLayout(false);
            this.expandablePanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanel1;
        private System.Windows.Forms.RadioButton rtThongKeDHN;
        private System.Windows.Forms.RadioButton rptGanMoi;
        private System.Windows.Forms.RadioButton rptPhanTichDHN;
        //<<<<<<< .mine
        //=======
//>>>>>>> .r275

    }
}
