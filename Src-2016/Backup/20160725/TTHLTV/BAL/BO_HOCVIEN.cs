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
    class BO_HOCVIEN
    {
        DAL_HOCVIEN hocvien_dal;
        HOCVIEN hocvien;
        public int insert( HOCVIEN hocvien)
        {
            DAL_HOCVIEN hocvien_dal = new DAL_HOCVIEN();
            return hocvien_dal.insert(hocvien);
        }

        public void update(HOCVIEN hocvien)
        {
            DAL_HOCVIEN hocvien_dal = new DAL_HOCVIEN();
            hocvien_dal.update(hocvien);
        }

        public void delete(int hocvien_ID)
        {
            DAL_HOCVIEN hocvien_dal = new DAL_HOCVIEN();
            HOCVIEN hocvien = new HOCVIEN();
            hocvien.HOV_ID = hocvien_ID;
            hocvien_dal.delete(hocvien);
        }

        public void Delete_DiemHocVien_by_HvId(int hocvienID)
        {
            DAL_HOCVIEN hocvien_dal = new DAL_HOCVIEN();
            //HOCVIEN hocvien = new HOCVIEN();
            //hocvien.HOV_ID = hocvien_ID;
            hocvien_dal.Delete_DiemHocVien_by_HvId(hocvienID);
        }
        public DataTable getAll()
        {
            DAL_HOCVIEN hocvien_dal = new DAL_HOCVIEN();
            return hocvien_dal.getAll_HOCVIEN();
        }
        public DataTable get_HocCVien_LastCode()
        {
            DAL_HOCVIEN hocvien_dal = new DAL_HOCVIEN();
            return hocvien_dal.get_HOCVIEN_LastCode();
        }
        public DataTable getHocVienByID(HOCVIEN vDto)
        {
            hocvien_dal = new DAL_HOCVIEN();
            return hocvien_dal.getHocVienByID(vDto);
        }
        public DataTable ExportExcel_DsHocVien_ByLopID(int lopID)
        {
            DAL_HOCVIEN hocvien_dal = new DAL_HOCVIEN();
            return hocvien_dal.ExportExcel_DsHocVien_ByLopID(lopID);
        }
        public DataTable ExportExcel_DiemThi(int lopID, int mHocId, int lanthi)
        {
            DAL_HOCVIEN hocvien_dal = new DAL_HOCVIEN();
            return hocvien_dal.ExportExcel_DiemThi(lopID, mHocId, lanthi);
        }
        public DataTable ExportExcel_DiemDanh(int lopID, int monID)
        {
            DAL_HOCVIEN hocvien_dal = new DAL_HOCVIEN();
            //HOCVIEN hocvien = new HOCVIEN();
            //hocvien.HOV_ID = hocvien_ID;
            return hocvien_dal.ExportExcel_DiemDanh(lopID, monID);
        }
        public DataTable searchHocVienByFullName(string fullName)//, string lastname)
        {
            DAL_HOCVIEN hocvien_dal = new DAL_HOCVIEN();
            return hocvien_dal.searchHocVienByFullName(fullName);//, lastname);
        }
        public DataTable searchHocVienByFirstName(string firstName)//, string lastname)
        {
            DAL_HOCVIEN hocvien_dal = new DAL_HOCVIEN();
            return hocvien_dal.searchHocVienByFirstName(firstName);//, lastname);
        }
        public DataTable searchHocVienByLastName(string textSearch)
        {
            DAL_HOCVIEN hocvien_dal = new DAL_HOCVIEN();
            return hocvien_dal.searchHocVienByLasrName(textSearch);
        }
        public DataTable searchHocVienByBirthday(string textSearch)
        {
            DAL_HOCVIEN hocvien_dal = new DAL_HOCVIEN();
            return hocvien_dal.searchHocVienByBirthDay(textSearch);
        }
        public DataTable searchHocVienByNoiSinh(string textSearch)
        {
            DAL_HOCVIEN hocvien_dal = new DAL_HOCVIEN();
            return hocvien_dal.searchHocVienByNoiSinh(textSearch);
        }
        public DataTable searchHocVienByDienThoai(string textSearch)
        {
            DAL_HOCVIEN hocvien_dal = new DAL_HOCVIEN();
            return hocvien_dal.searchHocVienByDienThoai(textSearch);
        }
        public DataTable searchHocVienBySoCC(string textSearch)
        {
            DAL_HOCVIEN hocvien_dal = new DAL_HOCVIEN();
            return hocvien_dal.searchHocVienBySoCC(textSearch);
        }
        public DataTable search_Diem_ByHocVienId(int HvId)
        {
            DAL_HOCVIEN hocvien_dal = new DAL_HOCVIEN();
            return hocvien_dal.search_DiemThi_ByHocVienID(HvId);
        }
        public DataTable search_CCC_ByHocVienId(int HvId)
        {
            DAL_HOCVIEN hocvien_dal = new DAL_HOCVIEN();
            return hocvien_dal.search_CCC_ByHocVienID(HvId);
        }
        public DataTable vCheck_Delete_HvDoi(int HvId)
        {
            DAL_HOCVIEN hocvien_dal = new DAL_HOCVIEN();
            return hocvien_dal.vCheck_Delete_HvDoi(HvId);
        }
        public DataTable vCheck_Delete_Hv_Dang_Ki_Hoc(int HvId)
        {
            DAL_HOCVIEN hocvien_dal = new DAL_HOCVIEN();
            return hocvien_dal.vCheck_Delete_Hv_Dang_Ki_Hoc(HvId);
        }

        #region Tra cứu chứng chỉ củ
        public DataTable searchHocVienByFullName_1(string fullName)//, string lastname)
        {
            DAL_HOCVIEN hocvien_dal = new DAL_HOCVIEN();
            return hocvien_dal.searchHocVienByFullName_1(fullName);//, lastname);
        }
        public DataTable searchHocVienByFirstName_1(string firstName)//, string lastname)
        {
            DAL_HOCVIEN hocvien_dal = new DAL_HOCVIEN();
            return hocvien_dal.searchHocVienByFirstName_1(firstName);//, lastname);
        }
        public DataTable searchHocVienByLastName_1(string textSearch)
        {
            DAL_HOCVIEN hocvien_dal = new DAL_HOCVIEN();
            return hocvien_dal.searchHocVienByLastName_1(textSearch);
        }
        public DataTable searchHocVienBySoCC_1(string textSearch)
        {
            DAL_HOCVIEN hocvien_dal = new DAL_HOCVIEN();
            return hocvien_dal.searchHocVienBySoCC_1(textSearch);
        }
        public DataTable search_Diem_ByHocVienId_1(string HvId)
        {
            DAL_HOCVIEN hocvien_dal = new DAL_HOCVIEN();
            return hocvien_dal.search_DiemThi_ByHocVienID(HvId);
        }
        public DataTable searchHocVienByFullName_1_Doi(string fullName)
        {
            DAL_HOCVIEN hocvien_dal = new DAL_HOCVIEN();
            return hocvien_dal.searchHocVienByFullName_1_Doi(fullName);
        }
        public DataTable searchHocVienByFirstName_1_Doi(string firstName)
        {
            DAL_HOCVIEN hocvien_dal = new DAL_HOCVIEN();
            return hocvien_dal.searchHocVienByFirstName_1_Doi(firstName);
        }
        public DataTable searchHocVienByLastName_1_Doi(string textSearch)
        {
            DAL_HOCVIEN hocvien_dal = new DAL_HOCVIEN();
            return hocvien_dal.searchHocVienByLastName_1_Doi(textSearch);
        }
        public DataTable searchHocVienBySoCC_1_Doi(string textSearch)
        {
            DAL_HOCVIEN hocvien_dal = new DAL_HOCVIEN();
            return hocvien_dal.searchHocVienBySoCC_1_Doi(textSearch);
        }
        public DataTable search_Diem_ByHocVienId_1_Doi(string HvId)
        {
            DAL_HOCVIEN hocvien_dal = new DAL_HOCVIEN();
            return hocvien_dal.searchLop_By_MaHocVien_1_Doi(HvId);
        }
        #endregion
    }
}
