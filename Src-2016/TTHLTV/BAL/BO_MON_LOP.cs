using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using TTHLTV;
using TTHLTV.DAL;

namespace TTHLTV.BAL
{
    class BO_MON_LOP
    {
        public int insert(string MOL_Code,
                    int MOL_LOPID,
                    int MOL_MONID,
                    int MOL_GIVID,
                    int? MOL_SoTiet)
        {
            DAL_MON_LOP mon_lop_dal = new DAL_MON_LOP();
            MON_LOP mon_lop = new MON_LOP();
            mon_lop.MOL_ID = 1;
            mon_lop.MOL_Code = MOL_Code;
            mon_lop.MOL_LOPID = MOL_LOPID;
            mon_lop.MOL_MONID = MOL_MONID;
            mon_lop.MOL_GIVID = MOL_GIVID;
            mon_lop.MOL_SoTiet = MOL_SoTiet;
          return  mon_lop_dal.insert(mon_lop);
        }

        public void update(
                    int MOL_ID,
	                string MOL_Code,
	                int MOL_LOPID,
	                int MOL_MONID,
	                int MOL_GIVID,
	                int? MOL_SoTiet
            )
        {
            DAL_MON_LOP mon_lop_dal = new DAL_MON_LOP();
            MON_LOP mon_lop = new MON_LOP();
            mon_lop.MOL_ID = MOL_ID;
            mon_lop.MOL_Code = MOL_Code;
            mon_lop.MOL_LOPID = MOL_LOPID;
            mon_lop.MOL_MONID = MOL_MONID;
            mon_lop.MOL_GIVID = MOL_GIVID;
            mon_lop.MOL_SoTiet = MOL_SoTiet;
            mon_lop_dal.update(mon_lop);
        }

        public void update_By_LopId_MonId(
                  //int MOL_ID,
                  //string MOL_Code,
                  int MOL_LOPID,
                  int MOL_MONID,
                  int MOL_GIVID
                 // int? MOL_SoTiet
          )
        {
            DAL_MON_LOP mon_lop_dal = new DAL_MON_LOP();
            MON_LOP mon_lop = new MON_LOP();
            //mon_lop.MOL_ID = MOL_ID;
            //mon_lop.MOL_Code = MOL_Code;
            mon_lop.MOL_LOPID = MOL_LOPID;
            mon_lop.MOL_MONID = MOL_MONID;
            mon_lop.MOL_GIVID = MOL_GIVID;
           // mon_lop.MOL_SoTiet = MOL_SoTiet;
            mon_lop_dal.update_By_LopId_MonId(mon_lop);
        }

        public void delete(int mon_lop_ID)
        {
            DAL_MON_LOP mon_lop_dal = new DAL_MON_LOP();
            MON_LOP mon_lop = new MON_LOP();
            mon_lop.MOL_ID = mon_lop_ID;
            mon_lop_dal.delete(mon_lop);
        }

        public DataTable getAll()
        {
            DAL_MON_LOP mon_lop_dal = new DAL_MON_LOP();
            return mon_lop_dal.getAll_MON_LOP();
        }


        public DataTable Get_Lop_GiangVien(int lopId, int monId)
        {
            DAL_MON_LOP mon_lop_dal = new DAL_MON_LOP();
            MON_LOP mon_lop = new MON_LOP();
            mon_lop.MOL_LOPID = lopId;
            mon_lop.MOL_MONID = monId;
            return mon_lop_dal.Get_Lop_GiangVien(mon_lop);
        }

        public DataTable getByID(int mon_lop_ID)
        {
            DAL_MON_LOP mon_lop_dal = new DAL_MON_LOP();
            MON_LOP mon_lop = new MON_LOP();
            mon_lop.MOL_ID = mon_lop_ID;
            return mon_lop_dal.getByID_MON_LOP(mon_lop);
        }

        public DataTable Select_LichGiang_All()
        {
            DAL_MON_LOP mon_lop_dal = new DAL_MON_LOP();
            return mon_lop_dal.Select_LichGiang_All();
        }

        public DataTable Select_LichGiang_ByLopId(int LopId)
        {
            DAL_MON_LOP mon_lop_dal = new DAL_MON_LOP();
            return mon_lop_dal.select_LichGiang_ByLopId(LopId);
        }
    }
}
