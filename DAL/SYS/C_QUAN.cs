using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CAPNUOCTHUDUC.LinQ;

namespace CAPNUOCTHUDUC.DAL.SYS
{
    public class C_Quan
    {
        public static List<TB_QUAN> getList(){
            ThuDucDataContext data = new ThuDucDataContext();
            var quan = from p in data.TB_QUANs select p;
           return quan.ToList();
        }
        public static TB_QUAN finByMaQuan(string maquan)
        { 
             ThuDucDataContext data = new ThuDucDataContext();
             var quan = from q in data.TB_QUANs where q.MAQUAN == maquan select q;
             return quan.SingleOrDefault();
        }
        public static TB_QUAN finbyTenQuan(string tenquan)
        {
            ThuDucDataContext data = new ThuDucDataContext();
            var quan = from q in data.TB_QUANs where q.TENQUAN == tenquan select q;
            return quan.SingleOrDefault();
        }
    }
}
