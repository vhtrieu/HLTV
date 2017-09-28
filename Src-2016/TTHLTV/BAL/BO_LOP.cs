using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using TTHLTV;
using TTHLTV.DTO;
using TTHLTV.DAL;

namespace TTHLTV.BAL
{
    class BO_LOP
    {
        LOP lop;
        DAL_LOP dao;
        CHUNG_CHI cClop;
        public DataTable getLOP_ByID(int lopID)
        {
            lop = new LOP();
            lop.LOP_ID = lopID;
            dao = new DAL_LOP();
            return dao.getDsLop_ByID(lop);
        }

        public DataTable SearchClass_ByName(string sQurey)
        {
            LOP sName = new LOP();
            sName.LOP_Name = sQurey;
            DAL_LOP dao = new DAL_LOP();
            return dao.SearchByClassName(sName);
        }

        public DataTable getLOP_LastCode()
        {
            cClop = new CHUNG_CHI();
            dao = new DAL_LOP();
            return dao.getDsLop_LastCode();
        }

        public DataTable getLOP_MONHOC_LastCode()
        {
            cClop = new CHUNG_CHI();
            dao = new DAL_LOP();
            return dao.getLop_MonHoc_LastCode();
        }

        public DataTable getLOP_LastId()
        {
            cClop = new CHUNG_CHI();
            dao = new DAL_LOP();
            return dao.getLop_LastId();
        }

        public DataTable getLOP_ByCcID(int cCId)
        {
            lop = new LOP();
            lop.LOP_CHCID = cCId;
            dao = new DAL_LOP();
            return dao.getDsLop_ByCcID(lop);
        }

        public DataTable getLOP_ByCcID_NewClass(int cCId)
        {
            lop = new LOP();
            lop.LOP_CHCID = cCId;
            dao = new DAL_LOP();
            return dao.getDsLop_ByCcID_NewClass(lop);
        }


        public DataTable getCC_MONHOC_BY_CCID(int sCcId)
        {
            cClop = new CHUNG_CHI();
            cClop.CHC_ID = sCcId;
            DAL_LOP dao = new DAL_LOP();
            return dao.getCC_MONHOC_ID_ID_byCcId(cClop);
        }

        public DataTable SelectMONHOC_SoTiet_MonId(int MonId)
        {
            //CHUNG_CHI cCid = new CHUNG_CHI();
            //cCid.CHC_ID = sCcId;
            dao = new DAL_LOP();
            return dao.SelectMONHOC_SoTiet_MonId(MonId);
        }


        public DataTable getLop_Alls()
        {
            lop = new LOP();
            dao = new DAL_LOP();
            return dao.getLop_All();
        }

        public DataTable getLop_Alls_WhithCouresName()
        {
            lop = new LOP();
            dao = new DAL_LOP();
            return dao.getLop_All_WhithCouresName();
        }

        public DataTable getLopByChungChiIDFromTo(int CC_ID, DateTime from, DateTime to)
        {
            lop = new LOP();
            dao = new DAL_LOP();
            return dao.getLopByChungChiIDFromTo(CC_ID, from, to);
        }
        public DataTable getLopThongKe(int ccId, DateTime from, DateTime to)
        {
            lop = new LOP();
            dao = new DAL_LOP();
            return dao.getLopThongKe(ccId, from, to);
        }
        //public DataTable getChungChiThongKe(DateTime from, DateTime to)
        public DataTable getChungChiThongKe(DateTime from, DateTime to, int iLoaiCc)
        {
            lop = new LOP();
            dao = new DAL_LOP();
            //return dao.getChungChiThongKe(from, to);
            return dao.getChungChiThongKe(from, to, iLoaiCc);
        }

        public DataTable getHocVienThongKe(int LopId)
        {
            lop = new LOP();
            dao = new DAL_LOP();
            return dao.getHocVienThongKe(LopId);
        }
        public int insert(string lCode, string lName, string lKhoa, string lShortName, DateTime lNgayKG, DateTime lNgayKT, DateTime lNgayQD, int lChungChiID)
        {
            lop = new LOP();
            lop.LOP_Code = lCode;
            lop.LOP_Name = lName;
            lop.LOP_Khoa = lKhoa;
            lop.LOP_ShortName = lShortName;
            lop.LOP_Ngay_KG = lNgayKG;
            lop.LOP_Ngay_KT = lNgayKT;
            lop.LOP_Ngay_QD = lNgayQD;
            lop.LOP_CHCID = lChungChiID;

            dao = new DAL_LOP();
          return  dao.insert(lop);

        }
        public void update(int lID, string lCode, string lName, string lKhoa, string lShortName, DateTime? lNgayKG, DateTime? lNgayKT, DateTime? lNgayQD, int lChungChiID)
        {
            dao = new DAL_LOP();
            lop = new LOP();
            lop.LOP_ID = lID;
            lop.LOP_Code = lCode;
            lop.LOP_Name = lName;
            lop.LOP_Khoa = lKhoa;
            lop.LOP_ShortName = lShortName;
            lop.LOP_Ngay_KG = lNgayKG;
            lop.LOP_Ngay_KT = lNgayKT;
            lop.LOP_Ngay_QD = lNgayQD;
            lop.LOP_CHCID = lChungChiID;

            dao.update(lop);

        }

        public void delete(int lID)
        {
            lop = new LOP();
            lop.LOP_ID = lID;
            dao = new DAL_LOP();
            dao.delete(lop);
        }

        public DataTable getChungChiThongKeWithCcID(DateTime fromDate, DateTime toDate, int _nhomCcID, int _ChcID)
        {
            lop = new LOP();
            dao = new DAL_LOP();
            return dao.getChungChiThongKeWithCcID(fromDate, toDate, _nhomCcID, _ChcID);
        }
        public void SaveLevel(int LevelID, int LopID, int LevelNumber,int DoiID)
        {
            dao = new DAL_LOP();
            dao.SaveLevel(LevelID, LopID, LevelNumber,DoiID);
        }
        public DataTable LoadLevelByLopID(int LopID)
        {
            dao = new DAL_LOP();
            return dao.LoadLevelByLopID(LopID);
        }
        public void DeleteLevel(int LevelID)
        {
            dao = new DAL_LOP();
            dao.DeleteLevel(LevelID);
        }
    }
}
