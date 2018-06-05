using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using TTHLTV;
//using Entetities;
using TTHLTV.DAL;

namespace TTHLTV.BAL
{
    class BO_CC_MONHOC
    {
        public DataTable getCC_MONHOC_ByID(int id )
        {
            CC_MONHOC mhoc = new CC_MONHOC();
            mhoc.CCM_ID = id;
            DAL_CC_MONHOC dao = new DAL_CC_MONHOC();
            return dao.getCC_MH_ByCCID(mhoc);
         }

        public DataTable getCC_MONHOC_All()
        {
            CC_MONHOC mhoc = new CC_MONHOC();
            DAL_CC_MONHOC dao = new DAL_CC_MONHOC();
            return dao.getDsCC_MonHocAll();
             
        }

        public DataTable getCC_MONHOC_ByMhID(int mhID)
        {
            CC_MONHOC mhoc = new CC_MONHOC();
            mhoc.CCM_MONID = mhID;
            DAL_CC_MONHOC dao = new DAL_CC_MONHOC();
          return  dao.getCC_MH_ByMHID(mhoc);
 
        }

        public DataTable getCC_MONHOC_ByCcID(int cCID)
        {
            CC_MONHOC mhoc = new CC_MONHOC();
            mhoc.CCM_CHCID = cCID;
            DAL_CC_MONHOC dao = new DAL_CC_MONHOC();
            return dao.getCC_MH_ByCCID(mhoc);

        }


        public void insert(int mhID, int cCID)
        {
            CC_MONHOC mhoc = new CC_MONHOC();
            DAL_CC_MONHOC dao = new DAL_CC_MONHOC();
            mhoc.CCM_MONID = mhID;
            mhoc.CCM_CHCID = cCID;
            dao.insert(mhoc);                  
        
        }

        public void update(int ccMhID, int mhID, int cCID)
        {
            CC_MONHOC mhoc = new CC_MONHOC();
            DAL_CC_MONHOC dao = new DAL_CC_MONHOC();
            mhoc.CCM_CHCID = ccMhID;
            mhoc.CCM_MONID = mhID;
            mhoc.CCM_CHCID = cCID;
            dao.update(mhoc);

        }

        public void delete(int mHID)
        {
            CC_MONHOC cCMhoc = new CC_MONHOC();
            cCMhoc.CCM_ID = mHID;
            DAL_CC_MONHOC dao = new DAL_CC_MONHOC();
            dao.delete(cCMhoc);
        }


        public void delete_CC_MonHoc_byChcId(int chcID)
        {
            DAL_CC_MONHOC dao = new DAL_CC_MONHOC();
            dao.delete_CC_MonHoc_byChcId(chcID);
        }
        public DataTable getFont_ID(string fontContent)
        {
            DAL_CC_MONHOC dal = new DAL_CC_MONHOC();
           return dal.getIdFont(fontContent);
 
        }
        public void Update_font(int fontID, int fontCCID, string fontName, int fontSize, string fontContent)
        {
            DAL_CC_MONHOC dal = new DAL_CC_MONHOC();
            dal.update_font(fontID, fontCCID, fontName, fontSize, fontContent);
        }
    }
}
