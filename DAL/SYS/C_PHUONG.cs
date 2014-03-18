using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CAPNUOCTHUDUC.LinQ;
using System.Collections;
using CAPNUOCTHUDUC.Utilities;
namespace CAPNUOCTHUDUC.DAL.SYS
{
    public class C_Phuong
    {
        public static List<TB_PHUONG> getListByQuan(string maquan) {
            ThuDucDataContext data = new ThuDucDataContext();
            var lisPhuong = from phuong in data.TB_PHUONGs where phuong.MAQUAN == maquan select phuong;
            return lisPhuong.ToList();
        }
        public static List<TB_PHUONG> getListPhuongAdmin()
        {
            ThuDucDataContext data = new ThuDucDataContext();
            var lisPhuong = from phuong in data.TB_PHUONGs select phuong;
            return lisPhuong.ToList();
        }
        public static TB_PHUONG finbyPhuong(string maquan, string maphuong)
        {
            ThuDucDataContext data = new ThuDucDataContext();
            var phuong = from p in data.TB_PHUONGs where p.MAQUAN == maquan && p.MAPHUONG == maphuong select p;
            return phuong.SingleOrDefault();
        }
        public static TB_PHUONG finbyTenPhuong(string maquan, string tenPhuong)
        {
            ThuDucDataContext data = new ThuDucDataContext();
            var phuong = from p in data.TB_PHUONGs where p.MAQUAN == maquan && p.TENPHUONG == tenPhuong select p;
            return phuong.SingleOrDefault();
        }
        
        public static ArrayList getListPhuong()
        {
            ArrayList list = new ArrayList();
            ThuDucDataContext data = new ThuDucDataContext();
            var lisPhuong = from phuong in data.TB_PHUONGs select phuong;
            foreach (var a in lisPhuong)
            {
                list.Add(new AddValueCombox(a.TENPHUONG, a.MAPHUONG));
            }
            return list;
        }
        public static List<TB_PHUONG> ListPhuongByTenPhuong(string tenPhuong)
        {
            ThuDucDataContext data = new ThuDucDataContext();
            var lisPhuong = from phuong in data.TB_PHUONGs where phuong.TENPHUONG == tenPhuong select phuong;
            return lisPhuong.ToList();
        }
    }
}
