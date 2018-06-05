using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using TTHLTV;
//using Entetities;
using TTHLTV.DAL;
using TTHLTV.DTO;

namespace TTHLTV.BAL
{
    class BO_DOI_CHUNGCHI
    {
        DAL_DOI_CHUNGCHI vDao;
        public int insert(DOI_CHUNGCHI vDto)
        {
            vDao = new DAL_DOI_CHUNGCHI();
           return vDao.insert(vDto);
        }
        public void update(DOI_CHUNGCHI vDto)
        {
            vDao= new DAL_DOI_CHUNGCHI();
            vDao.update(vDto);
        }

        public DataTable getCount_Student_DoiCc(int CcId)
        {
            DAL_DOI_CHUNGCHI Dal = new DAL_DOI_CHUNGCHI();
          
            return Dal.getCount_Student_DoiCc(CcId);
        }

        public DataTable getDoiCC_LastCode()
        {
            DAL_DOI_CHUNGCHI DoiDal = new DAL_DOI_CHUNGCHI();
            return DoiDal.getDoi_CC_LastCode();
        }

        public DataTable getDOI_CHUNGCHI_ByHocCCID(int chungchi_ID)
        {
            DAL_DOI_CHUNGCHI dao = new DAL_DOI_CHUNGCHI();
            return dao.getDOI_CHUNGCHI_ByHocCCID(chungchi_ID);
        }

        public DataTable vCheckSoChungChi(int vCcID, string vSoCc)
        {
            DAL_DOI_CHUNGCHI dao = new DAL_DOI_CHUNGCHI();
            return dao.vCheckSoChungChi(vCcID, vSoCc);
        }
        public DataTable vCheckSoChungChi2(int vCcID, string vSoCc)
        {
            DAL_DOI_CHUNGCHI dao = new DAL_DOI_CHUNGCHI();
            return dao.vCheckSoChungChi2(vCcID, vSoCc);
        }
        /// <summary>
        /// This function incorect to deleted data
        /// </summary>
        /// <param name="HovID"></param>
        /// <param name="Socc"></param>
        public void delete_Doi_CC_byHvID(int HovID, string Socc)
        {
            DAL_DOI_CHUNGCHI DalDoiCc = new DAL_DOI_CHUNGCHI();
            DalDoiCc.delete_Doi_CC_byHvID(HovID, Socc);
        }
        public void deleteDoiChungChiByID(DOI_CHUNGCHI vDto)
        {
            DAL_DOI_CHUNGCHI DalDoiCc = new DAL_DOI_CHUNGCHI();
            DalDoiCc.deleteDoiChungChiByID(vDto);
        }
        public void delete_CAP_CC_Doi_byHvID(int cCcID, int HvID, string SoCC)
        {
            DAL_DOI_CHUNGCHI DalDoiCc = new DAL_DOI_CHUNGCHI();
            DalDoiCc.delete_CAP_CC_Doi_byHvID(cCcID, HvID, SoCC);
        }
        public void DeleteHocVienCapChungChiDoiByID(CAP_CHUNGCHI vDto)
        {
            DAL_DOI_CHUNGCHI DalDoiCc = new DAL_DOI_CHUNGCHI();
            DalDoiCc.DeleteHocVienCapChungChiDoiByDoiID(vDto);
        }
        public DataTable search_DoiCC_byLastName(int chungchi_ID, string sText, string vSoHieuDoi)
        {
            DAL_DOI_CHUNGCHI dao = new DAL_DOI_CHUNGCHI();
            return dao.search_DoiCC_byLastName(chungchi_ID, sText,vSoHieuDoi);
        }
        public DataTable search_DoiCC_byFullName(int chungchi_ID, string sText, string vSoHieuDoi)
        {
            DAL_DOI_CHUNGCHI dao = new DAL_DOI_CHUNGCHI();
            return dao.search_DoiCC_byFullName(chungchi_ID, sText,vSoHieuDoi);
        }
        public void update_NgayCap_Doi(int cCcID, DateTime? NgayCap, DateTime? NgayHetHan)
        {
            DAL_DOI_CHUNGCHI ccc_dal = new DAL_DOI_CHUNGCHI();
            ccc_dal.update_NgayCap_Doi(cCcID, NgayCap, NgayHetHan);
        }
        public DataTable Get_DsHV_DuocCapCC_Doi(int cCIds, int Status, string soHieu)
        {
            DAL_DOI_CHUNGCHI ccc_dal = new DAL_DOI_CHUNGCHI();
            return ccc_dal.Get_DsHV_DuocCapCC_Doi(cCIds, Status, soHieu);
        }
        public DataTable Get_SoHieuDoi_ByCHCID(int cCIds)
        {
            DAL_DOI_CHUNGCHI ccc_dal = new DAL_DOI_CHUNGCHI();

            return ccc_dal.getSoHieuDoi_ByCHCID(cCIds);
        }

        public DataTable getLastId_Doi_ChungChi()
        {
            DAL_DOI_CHUNGCHI ccc_dal = new DAL_DOI_CHUNGCHI();

            return ccc_dal.getLastId_Doi_ChungChi();
        }
    }
}
