
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
                result += " OR (LEFT(GIAOUOC,2)='TD') ";
            }
            if (q9.Checked)
            {
                 result += " OR (LEFT(GIAOUOC,2)='Q9') ";
            }
            if (q2.Checked)
            {
                result += " OR (LEFT(GIAOUOC,2)='Q2') ";
            }
            if (bd.Checked)
            {
                result += " OR (LEFT(GIAOUOC,2)='BD') ";
            }

            result += " )";
            result = result.Replace(" AND ( OR", " AND ( ");
            return result;
        }
    }
}
