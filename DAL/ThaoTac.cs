
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CAPNUOCTHUDUC.DAL
{
    class ThaoTac
    {
        public static string getDuLieu(RadioButton rDoi, RadioButton rThuDuc, RadioButton rQuan9, RadioButton rQuan2) 
        {
            string result = "";
           
            if (rThuDuc.Checked)
            {
                return DAL.LinQConnection.getDataTable("SELECT GIOIHAN FROM TB_GIOIHAN WHERE TODS='TD' ").Rows[0][0].ToString();
            }
            if (rQuan9.Checked)
            {
                return DAL.LinQConnection.getDataTable("SELECT GIOIHAN FROM TB_GIOIHAN WHERE TODS='Q9' ").Rows[0][0].ToString();
            }
            if (rQuan2.Checked)
            {
                return DAL.LinQConnection.getDataTable("SELECT GIOIHAN FROM TB_GIOIHAN WHERE TODS='Q2' ").Rows[0][0].ToString();
            }
            
            return result;
        }

        public static string getToDS(RadioButton rDoi, RadioButton rThuDuc, RadioButton rQuan9, RadioButton rQuan2) 
        {
            string result = "";
            if (rDoi.Checked)
            {
                return " ĐỘI QUẢN LÝ ĐỒNG HỒ NƯỚC";
            }
            result = " TỔ ";
            if (rThuDuc.Checked)
            {
                result += " THỦ ĐỨC ";
            }
            if (rQuan9.Checked)
            {
                result += "- QUẬN 9 ";
            }
            if (rQuan2 .Checked)
            {
                result += "- QUẬN 2 + BÌNH DƯƠNG";
            }
            

            result = result.Replace(" TỔ -", " TỔ ");
            return result;
        }
    }
}
