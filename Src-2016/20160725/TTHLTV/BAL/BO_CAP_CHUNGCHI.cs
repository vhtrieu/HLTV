using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using TTHLTV;
using TTHLTV.DAL;
using TTHLTV.DTO;
namespace TTHLTV.BAL
{
    class BO_CAP_CHUNGCHI
    {
        DAL_CAP_CHUNGCHI vDao;
        public int insert(CAP_CHUNGCHI vDto)
        {
           vDao = new DAL_CAP_CHUNGCHI();
           return vDao.insert(vDto);
        }

        public void update(CAP_CHUNGCHI vDto)//, int CCC_DOIID)
        {
           vDao = new DAL_CAP_CHUNGCHI();
           vDao.update(vDto);
        }

        public void update_SoCc_ToNull(int? CCC_HOVID, int? CCC_LOPID) //string CCC_SoCC,
        {
            DAL_CAP_CHUNGCHI ccc_dal = new DAL_CAP_CHUNGCHI();
            CAP_CHUNGCHI ccc = new CAP_CHUNGCHI();

            ccc.CCC_HOVID = CCC_HOVID;
            //ccc.CCC_SoCC = CCC_SoCC;
            ccc.CCC_LOPID = CCC_LOPID;
           
            ccc_dal.update_SoCC_ToNull(ccc);
        }

        public void delete(int CCC_ID)
        {
            DAL_CAP_CHUNGCHI ccc_dal = new DAL_CAP_CHUNGCHI();
            CAP_CHUNGCHI ccc = new CAP_CHUNGCHI();
            ccc.CCC_ID = CCC_ID;
            ccc_dal.delete(ccc);
        }

        public DataTable getAll()
        {
            DAL_CAP_CHUNGCHI ccc_dal = new DAL_CAP_CHUNGCHI();
            return ccc_dal.getAll_CAP_CHUNGCHI();
        }

        public DataTable ExportExcel_Phat_CHUNGCHI(int cCIds, int lopID)
        {
            DAL_CAP_CHUNGCHI ccc_dal = new DAL_CAP_CHUNGCHI();
           
            return ccc_dal.ExportExcel_Phat_CHUNGCHI(cCIds, lopID);
        }

        public DataTable ExportExcel_Phat_Doi_CHUNGCHI(int cCIds,int status, string SoHieuDoi)
        {
            DAL_CAP_CHUNGCHI ccc_dal = new DAL_CAP_CHUNGCHI();

            return ccc_dal.ExportExcel_Phat_Doi_CHUNGCHI(cCIds,status, SoHieuDoi);
        }
        public DataTable getLast_SoCc(int ccID)
        {
            DAL_CAP_CHUNGCHI ccc_dal = new DAL_CAP_CHUNGCHI();
           
            return ccc_dal.getLast_SoCc(ccID);
        }
        public DataTable ExportExcel_DsHV_DuocCapCC(int cCIds, int lopID)
        {
            DAL_CAP_CHUNGCHI ccc_dal = new DAL_CAP_CHUNGCHI();
            
            return ccc_dal.ExportExcel_DsHV_DuocCapCC(cCIds,lopID);
        }
        public DataTable ExportExcel_DsHV_DuocCapCC_Doi(int cCIds, int Status, string soHieu)
        {
            DAL_CAP_CHUNGCHI ccc_dal = new DAL_CAP_CHUNGCHI();

            return ccc_dal.ExportExcel_DsHV_DuocCapCC_Doi(cCIds, Status, soHieu);
        }
        public DataTable getCAP_CHUNGCHI_WithName()
        {
            DAL_CAP_CHUNGCHI ccc_dal = new DAL_CAP_CHUNGCHI();
            return ccc_dal.getCAP_CHUNGCHI_WithName();
        }
        public DataTable getByID(int cap_chungchi_ID)
        {
            CAP_CHUNGCHI ccc = new CAP_CHUNGCHI();
            ccc.CCC_ID = cap_chungchi_ID;
            DAL_CAP_CHUNGCHI ccc_dal = new DAL_CAP_CHUNGCHI();
            return ccc_dal.getByID_CAP_CHUNGCHI(ccc);
        }
        public DataTable getCAP_CHUNGCHI_HV_SearchLastName(string lastName)
        {

            HOCVIEN searchLastName = new HOCVIEN();
            searchLastName.HOV_LastName = lastName;
            DAL_CAP_CHUNGCHI dao = new DAL_CAP_CHUNGCHI();
            return dao.getCAP_CHUNGCHI_HV_SearchLastName(searchLastName);

        }
        public DataTable searchHocVien_In_DKH_ByName(int lopID, string lastName) //(int lopID,
        {
            DANG_KI_HOC boDkh = new DANG_KI_HOC();
            boDkh.DKH_LOPID = lopID;
            boDkh.DKH_LastName = lastName;
            DAL_CAP_CHUNGCHI dao = new DAL_CAP_CHUNGCHI();
            return dao.searchHocVien_In_DKH_ByName(boDkh);
        }
        public DataTable searchHocVien_In_CCC_ByName(int lopID, string lastName) //(int lopID,
        {
            DAL_CAP_CHUNGCHI dao = new DAL_CAP_CHUNGCHI();
            return dao.searchHocVien_In_CCC_ByName(lopID, lastName);
        }
        public DataTable searchHocVien_In_CCC_ByFirstName(int lopID, string lastName) //(int lopID,
        {
            DAL_CAP_CHUNGCHI dao = new DAL_CAP_CHUNGCHI();
            return dao.searchHocVien_In_CCC_ByFirstName(lopID, lastName);
        }
        public DataTable searchHocVien_In_CCC_ByBirthday(int lopID, string lastName) //(int lopID,
        {
            DAL_CAP_CHUNGCHI dao = new DAL_CAP_CHUNGCHI();
            return dao.searchHocVien_In_CCC_ByBirthday(lopID, lastName);
        }
        public DataTable getCAP_CHUNG_CHI_By_HocVienID(int hocvienID)
        {
            CAP_CHUNGCHI chungchi_hocvien = new CAP_CHUNGCHI();
            chungchi_hocvien.CCC_HOVID = hocvienID;
            DAL_CAP_CHUNGCHI dao = new DAL_CAP_CHUNGCHI();
            return dao.getCAP_CHUNGCHI_By_HocVien_ID(chungchi_hocvien);
        }
        public DataTable searchCAP_CHUNG_CHI_FILTER_BY_KHOAHOC_LOPHOC_NAME_CONTAIN(int KHOAHOC_ID, int LOP_ID, string lastName)
        {
            DAL_CAP_CHUNGCHI dao = new DAL_CAP_CHUNGCHI();
            return dao.searchCAP_CHUNG_CHI_FILTER_BY_KHOAHOC_LOPHOC_NAME_CONTAIN(KHOAHOC_ID, LOP_ID, lastName);
        }
        public DataTable GetData_For_CAP_CHUNGCHI_ByLopID( int sLOP_ID)
        {
            DAL_CAP_CHUNGCHI dao = new DAL_CAP_CHUNGCHI();
            return dao.GetData_For_CAP_CHUNGCHI_ByLopID(sLOP_ID);
        }
        public void CapLaiChungChi(int? CCC_HOVID, int? CCC_LOPID, DateTime? CCC_NgayCapLai, DateTime? CCC_NgayHetHan, int? CCC_Status)
        {
            DAL_CAP_CHUNGCHI ccc_dal = new DAL_CAP_CHUNGCHI();
            CAP_CHUNGCHI ccc = new CAP_CHUNGCHI();
         
            ccc.CCC_HOVID = CCC_HOVID;
            ccc.CCC_LOPID = CCC_LOPID;
            ccc.CCC_NgayCap = CCC_NgayCapLai;
            ccc.CCC_NgayHetHan = CCC_NgayHetHan;
            ccc.CCC_Status = CCC_Status;
            ccc_dal.CapLaiChungChi(ccc);
        }
        public DataTable Search_CCC_Status(int lopID, int Status)
        {
            DAL_CAP_CHUNGCHI dao = new DAL_CAP_CHUNGCHI();
          return  dao.Search_CCC_Status(lopID, Status);
            
        }
        public DataTable get_SoHieuDoi_Cc(int CcID, int Status)
        {
            DAL_CAP_CHUNGCHI dao = new DAL_CAP_CHUNGCHI();
            return dao.get_SoHieuDoi_Cc(CcID, Status);

        }
        public DataTable get_CccDoi(int CcID, int Status, string soHieu)
        {
            DAL_CAP_CHUNGCHI dao = new DAL_CAP_CHUNGCHI();
            return dao.get_CccDoi(CcID, Status, soHieu);

        }
        public DataTable get_Print_CcDoi(int CcID, int Status, string soHieu)
        {
            DAL_CAP_CHUNGCHI dao = new DAL_CAP_CHUNGCHI();
            return dao.get_Print_CccDoi(CcID, Status, soHieu);

        }
        public void update_SoCc(CAP_CHUNGCHI vDto)
        {
            //int CCC_ID,int? CCC_HOVID, int? CCC_LOPID, string SoCC, DateTime? NgayCap, DateTime? NgayHetHan
            vDao = new DAL_CAP_CHUNGCHI();
            vDao.update_SoCC(vDto);
        }
        public void update_CapChungChi(CAP_CHUNGCHI vDto)
        {
            //int? CCC_HOVID, int? CCC_LOPID, string SoCC, DateTime? NgayCap, DateTime? NgayHetHan
            vDao = new DAL_CAP_CHUNGCHI();
            vDao.update_CapChungChi(vDto);
 
        }
        public DataTable getHocVienCapCC_ByLopID(int vLopID)
        {
            DAL_CAP_CHUNGCHI ccc_dal = new DAL_CAP_CHUNGCHI();
            return ccc_dal.getHovienCapCC_byLopID(vLopID);
        }
        public DataTable vLoadCapChungChi_Next(int vLopId,int vHocVienId)
        {
            DAL_CAP_CHUNGCHI ccc_dal = new DAL_CAP_CHUNGCHI();
            return ccc_dal.vLoadCapChungChi_Next(vLopId, vHocVienId);
        }
        public DataTable vCheckLopDaCapCcByLopMonID(int vLopId, int vMonId, int vLanThi)
        {
            DAL_CAP_CHUNGCHI ccc_dal = new DAL_CAP_CHUNGCHI();
            return ccc_dal.vCheckLopDaCapCcByLopMonID(vLopId, vMonId, vLanThi);
        }
        #region Tool update
        public DataTable ListNeedUpdate()
        {
            DAL_CAP_CHUNGCHI ccc_dal = new DAL_CAP_CHUNGCHI();
            return ccc_dal.loadListNeedUpdate();
        }
        public DataTable ListForUpdate()
        {
            DAL_CAP_CHUNGCHI ccc_dal = new DAL_CAP_CHUNGCHI();
            return ccc_dal.loadListForUpdate();
        }
        public void updateChungChiDoiIDToCapChungChi(int DoiID)
        {
            DAL_CAP_CHUNGCHI da = new DAL_CAP_CHUNGCHI();
            da.updateChungChiDoiIDToCapChungChi(DoiID);
        }
        public DataTable vLoadIdDoi(int vCcID)
        {
            DAL_CAP_CHUNGCHI da = new DAL_CAP_CHUNGCHI();
            return da.vLoadIdDoi(vCcID);
        }
        public void vUpdateDoiID(int vDoiID, int CccID)
        {
            DAL_CAP_CHUNGCHI da = new DAL_CAP_CHUNGCHI();
            da.vUpdateDoiID(vDoiID, CccID);
        }

        #endregion
    }
}
