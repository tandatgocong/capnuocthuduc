using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;

namespace CAPNUOCTHUDUC.Forms.DHN
{
    public partial class frm_KiemTraThayDinhKy : UserControl
    {
        public frm_KiemTraThayDinhKy()
        {
            InitializeComponent();
            LoadDataToGird();
            cbCoDH.SelectedIndex = 0;
            cbDot.SelectedIndex = 0;
            dateTime.Value = DateTime.Now;
        }

        private void LoadDataToGird()
        {
            //dataGrid.DataSource = DAL.QLDHN.C_BaoThay.getBaoThayDinhKy();
            //Utilities.DataGridV.formatRows(dataGrid);

            DataTable table = DAL.LinQConnection.getDataTable("SELECT HIEUDH,TENDONGHO FROM TB_HIEUDONGHO");
            cbHieuDongHo.DataSource = table;
            cbHieuDongHo.DisplayMember = "TENDONGHO";
            cbHieuDongHo.ValueMember = "HIEUDH";

            table = DAL.LinQConnection.getDataTable("SELECT CODHN FROM TB_CODHN");
            cbCoDH.DataSource = table;
            cbCoDH.DisplayMember = "CODHN";
            cbCoDH.ValueMember = "CODHN";

            table = DAL.LinQConnection.getDataTable("SELECT YEAR(NGAYTHAY) AS 'NT' FROM TB_DULIEUKHACHHANG GROUP BY YEAR(NGAYTHAY) ORDER BY YEAR(NGAYTHAY)  ASC");
            cbNamLD.DataSource = table;
            cbNamLD.DisplayMember = "NT";
            cbNamLD.ValueMember = "NT";


        }
        int currentPageIndex = 1;
        int pageSize = 200;
        int pageNumber = 0;
        int FirstRow, LastRow;
        int rows;

        public string Search()
        {

            DateTime date = dateTime.Value;
            date = date.AddMonths(1);
            string codh = "=" + cbCoDH.Text;
            if (int.Parse(cbCoDH.Text) < 40)
            {
                date = date.AddYears(-5);
            }
            else
            {
                date = date.AddYears(-4);
            }

            string sql = "";

            string quan = DAL.ThaoTac.getDuLieu(rDoi, rThuDuc, rQuan9, rQuan2);
            //if (DAL.SYS.C_USERS._toDocSo.Equals("TP"))
            //{
            //    quan = " = 31";
            //}
            string dot = "";
            if (!"00".Equals(cbDot.Text))
            {
                dot = " AND DOT='" + cbDot.Text + "'";
            }

            if (this.checHieu.Checked && this.nldCheck.Checked)
            {
                sql = "SELECT CODE,CHISOKYTRUOC, DANHBO,LOTRINH,DOT, HOTEN, (SONHA +' '+ TENDUONG) AS 'DIACHI',NGAYTHAY,LEFT(HIEUDH,3) as 'HIEUDH',SOTHANDH,CODH,' ' as GBAOTHAY FROM  TB_DULIEUKHACHHANG WHERE (BAOTHAY!=1 OR BAOTHAY IS NULL) " + quan + " AND CODH" + codh;
                sql += " AND (HIEUDH='" + cbHieuDongHo.SelectedValue + "' OR HIEUDH='" + cbHieuDongHo.Text + "')  " + " AND YEAR(NGAYTHAY) ='" + cbNamLD.SelectedValue + "' " + dot;
            }
            else
                if (this.ckNgayThay.Checked && this.checHieu.Checked)
                {
                    sql = "SELECT CODE,CHISOKYTRUOC, DANHBO,LOTRINH,DOT, HOTEN, (SONHA +' '+ TENDUONG) AS 'DIACHI',NGAYTHAY,LEFT(HIEUDH,3) as 'HIEUDH',SOTHANDH,CODH,' ' as GBAOTHAY FROM  TB_DULIEUKHACHHANG WHERE (BAOTHAY!=1 OR BAOTHAY IS NULL) " + quan + " AND CODH" + codh + " AND NGAYTHAY <= '" + date.ToShortDateString() + "'  ";
                    sql += " AND (HIEUDH='" + cbHieuDongHo.SelectedValue + "' OR HIEUDH='" + cbHieuDongHo.Text + "')  " + dot;
                    //DataTable table = DAL.LinQConnection.getDataTable(sql);
                    //dataGrid.DataSource = table;
                    //Utilities.DataGridV.formatRows(dataGrid);
                }
                else if (this.ckNgayThay.Checked)
                {
                    sql = "SELECT CODE,CHISOKYTRUOC, DANHBO,LOTRINH,DOT, HOTEN, (SONHA +' '+ TENDUONG) AS 'DIACHI',NGAYTHAY,LEFT(HIEUDH,3) as 'HIEUDH',SOTHANDH,CODH,' ' as GBAOTHAY FROM  TB_DULIEUKHACHHANG WHERE (BAOTHAY!=1 OR BAOTHAY IS NULL)  " + quan + " AND CODH" + codh + "  AND NGAYTHAY <= '" + date.ToShortDateString() + "'  " + dot;
                    //DataTable table = DAL.LinQConnection.getDataTable(sql);
                    //dataGrid.DataSource = table;
                    //Utilities.DataGridV.formatRows(dataGrid);
                }
                else if (this.checHieu.Checked)
                {
                    sql = "SELECT CODE,CHISOKYTRUOC, DANHBO,LOTRINH,DOT, HOTEN, (SONHA +' '+ TENDUONG) AS 'DIACHI',NGAYTHAY,LEFT(HIEUDH,3) as 'HIEUDH',SOTHANDH,CODH,' ' as GBAOTHAY FROM  TB_DULIEUKHACHHANG WHERE (BAOTHAY!=1 OR BAOTHAY IS NULL) " + quan + " AND CODH" + codh + " AND (HIEUDH='" + cbHieuDongHo.SelectedValue + "' OR HIEUDH='" + cbHieuDongHo.Text + "')  " + dot;

                }
                else if (this.nldCheck.Checked)
                {
                    sql = "SELECT CODE,CHISOKYTRUOC, DANHBO,LOTRINH,DOT, HOTEN, (SONHA +' '+ TENDUONG) AS 'DIACHI',NGAYTHAY,LEFT(HIEUDH,3) as 'HIEUDH',SOTHANDH,CODH,' ' as GBAOTHAY FROM  TB_DULIEUKHACHHANG WHERE (BAOTHAY!=1 OR BAOTHAY IS NULL) " + quan + " AND CODH" + codh + " AND YEAR(NGAYTHAY) ='" + cbNamLD.SelectedValue + "'  " + dot;

                }

            sql += " ORDER BY DANHBO  ASC ";
            return sql;

        }
        public void setBaoThay()
        {

            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {
                string sql = "SELECT CASE WHEN HCT_TRONGAI='True' THEN N'TRỞ NGẠI :' + HCT_LYDOTRONGAI + N' - BẢNG KÊ ' + CONVERT(VARCHAR(10),DHN_SOBANGKE) + N' NGÀY '+ CONVERT(VARCHAR(20),DHN_NGAYBAOTHAY,103) ELSE   N'LẦN ' + CONVERT(VARCHAR(10),DHN_LANTHAY) + N' BẢNG KÊ ' + CONVERT(VARCHAR(10),DHN_SOBANGKE) + N' NGÀY '+ CONVERT(VARCHAR(20),DHN_NGAYBAOTHAY,103)  END ";
                sql += " FROM TB_THAYDHN  WHERE DHN_DANHBO='" + (dataGrid.Rows[i].Cells["G_DANHBO"].Value + "").Replace(" ", "") + "' GROUP BY DHN_LANTHAY,DHN_SOBANGKE,DHN_NGAYBAOTHAY ,HCT_TRONGAI,HCT_NGAYGAN,HCT_LYDOTRONGAI HAVING DHN_NGAYBAOTHAY=MAX(DHN_NGAYBAOTHAY)";
                DataTable table = DAL.LinQConnection.getDataTable(sql);
                if (table.Rows.Count > 0)
                {
                    dataGrid.Rows[i].Cells["BAOTHAY"].Value = "" + table.Rows[0][0];
                }

            }


        }

        public void UpDateCSNuoc(string dot, string ky, string nam)
        {
            string sql = "  UPDATE TB_DULIEUKHACHHANG SET  CHISOKYTRUOC= CSMOI, TB_DULIEUKHACHHANG.CODE=DocSo_PHT.dbo.DS" + nam + ".CODE,SODHN=TIEUTHU ";
            sql += " FROM DocSo_PHT.dbo.DS" + nam + " ";
            sql += " WHERE TB_DULIEUKHACHHANG.DANHBO = DocSo_PHT.dbo.DS" + nam + ".DANHBA ";
            sql += "		AND DocSo_PHT.dbo.DS" + nam + ".KY ='" + int.Parse(ky) + "'  AND DocSo_PHT.dbo.DS" + nam + ".DOT = " + int.Parse(dot) + "";
            DAL.LinQConnection.ExecuteCommand_(sql);
        }

        private void btXemThongTin_Click(object sender, EventArgs e)
        {
            currentPageIndex = 1;
            pageSize = 200;
            pageNumber = 0;
            FirstRow = 0;
            LastRow = 0;

            string sqlCount = Search().Replace("CODE,CHISOKYTRUOC, DANHBO,LOTRINH,DOT, HOTEN, (SONHA +' '+ TENDUONG) AS 'DIACHI',NGAYTHAY,LEFT(HIEUDH,3) as 'HIEUDH',SOTHANDH,CODH,' ' as GBAOTHAY", " COUNT(*) ").Replace("ORDER BY DANHBO  ASC", " ");
            rows = DAL.LinQConnection.ExecuteCommand(sqlCount);
            lbTongDHN.Text = "Tổng Số " + rows + " ĐHN.";
            try
            {
                PageTotal();
                DataTable table = DAL.LinQConnection.getDataTable(Search(), FirstRow, pageSize);
                dataGrid.DataSource = table;
                Utilities.DataGridV.formatRows(dataGrid);
                setBaoThay();
            }
            catch (Exception)
            {
                // MessageBox.Show(this, ex.Message);
            }

        }

        private void dataGrid_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //ContextMenu m = new ContextMenu();
                //m.MenuItems.Add(new MenuItem("Cut"));
                //m.MenuItems.Add(new MenuItem("Copy"));
                //m.MenuItems.Add(new MenuItem("Paste"));

                //int currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                //if (currentMouseOverRow >= 0)
                //{
                //    m.MenuItems.Add(new MenuItem(string.Format("Do something to row {0}", currentMouseOverRow.ToString())));
                //}

                contextMenuStrip1.Show(dataGrid, new Point(e.X, e.Y));

            }
        }
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_KiemTraThayDinhKy).Name);
        private void dafaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string listDanhBa = "";
                //try
                //{

                int flag = 0;
                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if ("True".Equals(this.dataGrid.Rows[i].Cells["checkChon"].Value + ""))
                    {
                        flag++;
                        listDanhBa += ("'" + (this.dataGrid.Rows[i].Cells["G_DANHBO"].Value + "").Replace(" ", "") + "',");
                    }
                }
                if (flag <= int.Parse(Utilities.Files.numberRecord))
                {
                    frm_Option_BT frm = new frm_Option_BT(listDanhBa.Remove(listDanhBa.Length - 1, 1));
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        btXemThongTin_Click(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Bảng Kê Báo Thay <= " + Utilities.Files.numberRecord + " Danh Bộ", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //  MessageBox.Show(this,listDanhBa.Remove(listDanhBa.Length-1,1)+ "--" +flag);


                //}
                //catch (Exception)
                //{


                //}
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

        }


        private void PageTotal()
        {
            try
            {
                pageNumber = rows % pageSize != 0 ? rows / pageSize + 1 : rows / pageSize;
                lbPaing.Text = (currentPageIndex < 10 ? ("0" + currentPageIndex) : currentPageIndex + "") + "/" + (pageNumber < 10 ? ("0" + pageNumber) : pageNumber + "");
            }
            catch (Exception)
            {
            }

        }

        private void next_Click(object sender, EventArgs e)
        {
            if (currentPageIndex < pageNumber)
            {
                currentPageIndex = currentPageIndex + 1;
                FirstRow = pageSize * (currentPageIndex - 1);
                LastRow = pageSize * (currentPageIndex);
                PageTotal();
                DataTable table = DAL.LinQConnection.getDataTable(Search(), FirstRow, pageSize);
                dataGrid.DataSource = table;
                Utilities.DataGridV.formatRows(dataGrid);
                setBaoThay();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentPageIndex > 1)
                {
                    currentPageIndex = currentPageIndex - 1;
                    FirstRow = pageSize * (currentPageIndex - 1);
                    LastRow = pageSize * (currentPageIndex);
                    PageTotal();
                    DataTable table = DAL.LinQConnection.getDataTable(Search(), FirstRow, pageSize);
                    dataGrid.DataSource = table;
                    Utilities.DataGridV.formatRows(dataGrid);
                    setBaoThay();
                }
            }
            catch (Exception)
            {

            }
        }

        private void dataGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Utilities.DataGridV.formatRows(dataGrid);
        }

        private void dataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            //int flag = 0;
            //for (int i = 0; i < dataGrid.Rows.Count; i++)
            //{
            //    if ("True".Equals(this.dataGrid.Rows[i].Cells["checkChon"].Value + ""))
            //    {
            //        flag++;
            //    }
            //}
            //if (flag >= int.Parse(Utilities.Files.numberRecord))
            //{
            //    MessageBox.Show(this, "Bảng Kê Báo Thay <= " + Utilities.Files.numberRecord + " Danh Bộ", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGrid.CurrentCell.OwningColumn.Name == "checkChon")
            {
                int flag = 0;
                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if ("True".Equals(this.dataGrid.Rows[i].Cells["checkChon"].Value + ""))
                    {
                        flag++;
                    }
                }
                if (flag >= int.Parse(Utilities.Files.numberRecord))
                {
                    MessageBox.Show(this, "Bảng Kê Báo Thay <= " + Utilities.Files.numberRecord + " Danh Bộ", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}