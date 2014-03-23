
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CAPNUOCTHUDUC.DAL
{
    class ThaoTac
    {
        public static string getDuLieu(CheckBox doi, CheckBox td, CheckBox q9, CheckBox q2, CheckBox bd) 
        {
            string result = "";
            if (doi.Checked)
            {
                return "";
            }
            doi.Checked = false;
            result = " AND (";
            if (td.Checked)
            {
                result += " OR (QUAN='26') ";
            }
            if (q9.Checked)
            {
                result += " OR (QUAN='09') ";
            }
            if (q2.Checked)
            {
                result += " OR (QUAN='02') ";
            }
            if (bd.Checked)
            {
                result += " OR (QUAN='21') ";
            }

            result += " )";
            result = result.Replace(" AND ( OR", " AND ( ").Replace(" AND ( )","");
            return result;
        }

        public static string getToDS(CheckBox doi, CheckBox td, CheckBox q9, CheckBox q2, CheckBox bd)
        {
            string result = "";
            if (doi.Checked)
            {
                return " ĐỘI QUẢN LÝ ĐỒNG HỒ NƯỚC";
            }
            doi.Checked = false;
            result = " TỔ ";
            if (td.Checked)
            {
                result += " THỦ ĐỨC ";
            }
            if (q9.Checked)
            {
                result += "- QUẬN 9 ";
            }
            if (q2.Checked)
            {
                result += "- QUẬN 2 ";
            }
            if (bd.Checked)
            {
                result += "- BÌNH DƯƠNG ";
            }

            result = result.Replace(" TỔ -", " TỔ ");
            return result;
        }
    }
}
