﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using DevComponents.DotNetBar.Controls;
namespace CAPNUOCTHUDUC.Utilities
{
    public class DataGridV
    {
        public static void formatRows(DataGridView dview) {
            for (int i = 0; i < dview.Rows.Count; i++) {
                if (i % 2 == 0)
                {
                    dview.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(217)))));
                }
                else {
                    dview.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                }
                try
                {
                    dview.Rows[i].Cells["G_DANHBO"].Value = dview.Rows[i].Cells["G_DANHBO"].Value != null ? Utilities.FormatSoHoSoDanhBo.sodanhbo(dview.Rows[i].Cells["G_DANHBO"].Value + "") : dview.Rows[i].Cells["G_DANHBO"].Value;
                }
                catch (Exception)
                {
                    
                }
               
            }
        }
        public static void formatRows(DataGridView dview,string rows)
        {
            for (int i = 0; i < dview.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    dview.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(217)))));
                }
                else
                {
                    dview.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                }
                try
                {
                    dview.Rows[i].Cells[rows].Value = dview.Rows[i].Cells[rows].Value != null ? Utilities.FormatSoHoSoDanhBo.sodanhbo(dview.Rows[i].Cells[rows].Value + "") : dview.Rows[i].Cells[rows].Value;
                }
                catch (Exception)
                {

                }

            }
        }
        public static void formatRowsSTT(DataGridView dview, string rows,string STT)
        {
            for (int i = 0; i < dview.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    dview.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(217)))));
                }
                else
                {
                    dview.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                }
                try
                {
                    dview.Rows[i].Cells[rows].Value = dview.Rows[i].Cells[rows].Value != null ? Utilities.FormatSoHoSoDanhBo.sodanhbo(dview.Rows[i].Cells[rows].Value + "") : dview.Rows[i].Cells[rows].Value;
                }
                catch (Exception)
                {
                }

                try
                {
                     dview.Rows[i].Cells[STT].Value = i + 1;
                }
                catch (Exception)
                {
                }
            }
        }
        public static void formatRows(DataGridView dview, string rows, string lotrinh)
        {
            for (int i = 0; i < dview.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    dview.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(217)))));
                }
                else
                {
                    dview.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                }
                try
                {
                    dview.Rows[i].Cells[rows].Value = dview.Rows[i].Cells[rows].Value != null ? Utilities.FormatSoHoSoDanhBo.sodanhbo(dview.Rows[i].Cells[rows].Value + "") : dview.Rows[i].Cells[rows].Value;
                }
                catch (Exception)
                {

                }
                try
                {
                    dview.Rows[i].Cells[lotrinh].Value = dview.Rows[i].Cells[lotrinh].Value != null ? Utilities.FormatSoHoSoDanhBo.phienlotrinh (dview.Rows[i].Cells[lotrinh].Value + "",".") : dview.Rows[i].Cells[lotrinh].Value;
                }
                catch (Exception)
                {

                }

            }
        }
        public static void setSTT(DataGridView dview, string rows)
        {
            for (int i = 0; i < dview.Rows.Count; i++)
            {
                dview.Rows[i].Cells[rows].Value = i + 1;
            }
        }
        public static string sohoso(string _sohoso) {
            try
            {
                _sohoso = _sohoso.Insert(4, ".");
                _sohoso = _sohoso.Insert(9, ".");
            }
            catch (Exception)
            {
                
            }
            
            return _sohoso;
        }
        public static void formatSoHoSo(DataGridView dview) {
            for (int i = 0; i < dview.Rows.Count; i++)
            {
                dview.Rows[i].Cells["G_SOHOSO"].Value = sohoso(dview.Rows[i].Cells["G_SOHOSO"].Value + ""); ;
            }
        }
        public static void formatSoHoSo(DataGridViewX dview)
        {
            for (int i = 0; i < dview.Rows.Count; i++)
            {
                dview.Rows[i].Cells["G_SOHOSO"].Value = sohoso(dview.Rows[i].Cells["G_SOHOSO"].Value + ""); ;
            }
        }
        public static void formatSoHoSoDanhBo(DataGridView dview)
        {
            for (int i = 0; i < dview.Rows.Count; i++)
            {
                dview.Rows[i].Cells["G_SOHOSO"].Value = sohoso(dview.Rows[i].Cells["G_SOHOSO"].Value + "");
                dview.Rows[i].Cells["G_DANHBO"].Value = dview.Rows[i].Cells["G_DANHBO"].Value != null ? Utilities.FormatSoHoSoDanhBo.sodanhbo(dview.Rows[i].Cells["G_DANHBO"].Value + "") : dview.Rows[i].Cells["G_DANHBO"].Value;
            }
        }
        public static void formatSoHoSoDanhBo(DataGridViewX dview)
        {
            for (int i = 0; i < dview.Rows.Count; i++)
            {
                dview.Rows[i].Cells["G_SOHOSO"].Value = sohoso(dview.Rows[i].Cells["G_SOHOSO"].Value + "");
                dview.Rows[i].Cells["G_DANHBO"].Value = dview.Rows[i].Cells["G_DANHBO"].Value != null ? Utilities.FormatSoHoSoDanhBo.sodanhbo(dview.Rows[i].Cells["G_DANHBO"].Value + "") : dview.Rows[i].Cells["G_DANHBO"].Value;
            }
        }
      
        
    }
}

