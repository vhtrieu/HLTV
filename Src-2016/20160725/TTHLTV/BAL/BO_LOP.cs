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

        public DataTable getLOP_ByID(int lopID)
        {
            LOP lop = new LOP();
            lop.LOP_ID = lopID;
            DAL_LOP dao = new DAL_LOP();
           return dao.getDsLop_ByID(lop);
        }

        public DataTable SearchClass_ByName(string sQurey)
        {
            LOP sName = new LOP();
            sName.LOP_Name = sQurey;
            DAL_LOP dao = new DAL_LOP();
            return dao.SearchByClassName(sName);
        }

        public DataTable getLOP_LastCode( )
        {
            CHUNG_CHI cClop = new CHUNG_CHI();
           
            DAL_LOP dao = new DAL_LOP();
            return dao.getDsLop_LastCode();
        }

        public DataTable getLOP_MONHOC_LastCode ()
        {
            CHUNG_CHI cClop = new CHUNG_CHI();

            DAL_LOP dao = new DAL_LOP();
            return dao.getLop_MonHoc_LastCode();
        }

        public DataTable getLOP_LastId()
        {
            CHUNG_CHI cClop = new CHUNG_CHI();

            DAL_LOP dao = new DAL_LOP();
            return dao.getLop_LastId();
        } 

        public DataTable getLOP_ByCcID(int cCId)
        {
            LOP cCid = new LOP();
            cCid.LOP_CHCID = cCId;
            DAL_LOP dao = new DAL_LOP();
            return dao.getDsLop_ByCcID(cCid);
        }

        public DataTable getLOP_ByCcID_NewClass(int cCId)
        {
            LOP cCid = new LOP();
            cCid.LOP_CHCID = cCId;
            DAL_LOP dao = new DAL_LOP();
            return dao.getDsLop_ByCcID_NewClass(cCid);
        }


        public DataTable getCC_MONHOC_BY_CCID(int sCcId)
        {
            CHUNG_CHI cCid = new CHUNG_CHI();
            cCid.CHC_ID = sCcId;
            DAL_LOP dao = new DAL_LOP();
            return dao.getCC_MONHOC_ID_ID_byCcId(cCid);
        }

        public DataTable SelectMONHOC_SoTiet_MonId(int MonId)
        {
            //CHUNG_CHI cCid = new CHUNG_CHI();
            //cCid.CHC_ID = sCcId;
            DAL_LOP dao = new DAL_LOP();
            return dao.SelectMONHOC_SoTiet_MonId(MonId);
        }


        public DataTable getLop_Alls()
        {
            LOP lop = new LOP();
            DAL_LOP dao = new DAL_LOP();
          return  dao.getLop_All();
        }

        public DataTable getLop_Alls_WhithCouresName()
        {
            LOP lop = new LOP();
            DAL_LOP dao = new DAL_LOP();
            return dao.getLop_All_WhithCouresName();
        }

        public DataTable getLopByChungChiIDFromTo(int CC_ID,DateTime from,DateTime to)
        {
            LOP lop = new LOP();
            DAL_LOP dao = new DAL_LOP();
            return dao.getLopByChungChiIDFromTo(CC_ID,from,to);
        }
        public DataTable getLopThongKe(int ccId, DateTime from, DateTime to)
        {
            LOP lop = new LOP();
            DAL_LOP dao = new DAL_LOP();
            return dao.getLopThongKe(ccId, from, to);
        }
        public DataTable getChungChiThongKe(DateTime from, DateTime to)
        {
            LOP lop = new LOP();
            DAL_LOP dao = new DAL_LOP();
            return dao.getChungChiThongKe(from, to);
        }

        public DataTable getHocVienThongKe(int LopId)
        {
            LOP lop = new LOP();
            DAL_LOP dao = new DAL_LOP();
            return dao.getHocVienThongKe(LopId);
        }
        public void insert(string lCode, string lName, string lKhoa, string lShortName, DateTime lNgayKG, DateTime lNgayKT, DateTime lNgayQD, int lChungChiID)
        {
            LOP lop = new LOP();
            lop.LOP_Code = lCode;
            lop.LOP_Name = lName;
            lop.LOP_Khoa = lKhoa;
            lop.LOP_ShortName = lShortName;
            lop.LOP_Ngay_KG = lNgayKG;
            lop.LOP_Ngay_KT = lNgayKT;
            lop.LOP_Ngay_QD = lNgayQD;
            lop.LOP_CHCID = lChungChiID;

            DAL_LOP dao = new DAL_LOP();
            dao.insert(lop);

        }
        public void update(int lID, string lCode, string lName, string lKhoa, string lShortName, DateTime? lNgayKG, DateTime? lNgayKT, DateTime? lNgayQD, int lChungChiID)
        {
            DAL_LOP dao = new DAL_LOP();
            LOP lop = new LOP();
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
            LOP lop = new LOP();
            lop.LOP_ID = lID;

            DAL_LOP dao = new DAL_LOP();
            dao.delete(lop);
        }
    }
}
