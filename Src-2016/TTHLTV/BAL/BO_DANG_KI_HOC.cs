using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TTHLTV;
using TTHLTV.DAL;
using System.Data;
using TTHLTV.DTO;
namespace TTHLTV.BAL
{
    public class BO_DANG_KI_HOC
    {
        DAL_DANG_KI_HOC vDao;
        public void insert(DANG_KI_HOC dkhoc)
        {
            vDao= new DAL_DANG_KI_HOC();
            vDao.insert(dkhoc);
        }

        public void update( DANG_KI_HOC dkhoc)
        {
           vDao = new DAL_DANG_KI_HOC();
           vDao.update(dkhoc);
        }

        public void update_diem(int DKH_ID,
                       int DKH_Diem,
                       int DKH_LanThi
                       )
        {
            DAL_DANG_KI_HOC dangki_dal = new DAL_DANG_KI_HOC();
            DANG_KI_HOC dangki = new DANG_KI_HOC();
            dangki.DKH_ID = DKH_ID;
            dangki.DKH_Diem = DKH_Diem;
            dangki.DKH_LanThi = DKH_LanThi;
            dangki_dal.update_diem(dangki);
        }

        public void delete(int dangki_ID)
        {
            DAL_DANG_KI_HOC dangki_dal = new DAL_DANG_KI_HOC();
            DANG_KI_HOC dangki = new DANG_KI_HOC();
            dangki.DKH_ID = dangki_ID;
            dangki_dal.delete(dangki);
        }

        public void delete_By_HVID(int lopID, int HvId)
        {
            DAL_DANG_KI_HOC dangki_dal = new DAL_DANG_KI_HOC();
           
           
            dangki_dal.delete_By_HVID(lopID, HvId);
        }
        public void vDeletedHvInDangKiHoc(int vDkhID)
        {
            DAL_DANG_KI_HOC dangki_dal = new DAL_DANG_KI_HOC();
            dangki_dal.vDeletedHvInDangKiHoc(vDkhID);
        }
        public void DeleteCAP_CHUNGCHI_By_HovID( int lopId, int HvID)
        {
            DAL_DANG_KI_HOC dangki_dal = new DAL_DANG_KI_HOC();
            //DANG_KI_HOC dangki = new DANG_KI_HOC();
            //dangki.DKH_HOVID = dangki_ID;
            dangki_dal.DeleteCAP_CHUNGCHI_By_HovID(lopId, HvID);
        }

        public DataTable getAll()
        {
            DAL_DANG_KI_HOC dangki_dal = new DAL_DANG_KI_HOC();
            return dangki_dal.getAll_DANG_KI_HOC();
        }

        public DataTable getHVID_In_DKH(int vLopID)
        {
            DAL_DANG_KI_HOC dangki_dal = new DAL_DANG_KI_HOC();
            return dangki_dal.getHVID_In_DKH(vLopID);
        }

        public DataTable getDanKiHoc_LastCode()
        {
            DAL_DANG_KI_HOC dangki_dal = new DAL_DANG_KI_HOC();
            return dangki_dal.getAll_DANG_KI_HOC_LastCode();
        }
        public DataTable getByID(int dangki_ID)
        {
            DAL_DANG_KI_HOC dangki_dal = new DAL_DANG_KI_HOC();
            DANG_KI_HOC dangki = new DANG_KI_HOC();
            dangki.DKH_ID = dangki_ID;
            return dangki_dal.getByID_DANG_KI_HOC(dangki);
        }

        public DataTable getDangKiHoc_ByLopID(int lopID)
        {
            DANG_KI_HOC dkLopID = new DANG_KI_HOC();
            dkLopID.DKH_LOPID = lopID;
            DAL_DANG_KI_HOC dao = new DAL_DANG_KI_HOC();
            return dao.getDangKiHoc_ByLopID(dkLopID);

        }

        public DataTable getDangKiHoc_Name_ByLopID(int lopID, int Lanthi)
        {
            
            //DANG_KI_HOC dkLopID = new DANG_KI_HOC();
            //dkLopID.DKH_LOPID = lopID;
            DAL_DANG_KI_HOC dao = new DAL_DANG_KI_HOC();
            return dao.getDangKiHoc_Name_ByLopID(lopID, Lanthi);

        }

        public DataTable getDataInGCN(int lopID, int vLanThi)
        {
            DAL_DANG_KI_HOC dao = new DAL_DANG_KI_HOC();
            return dao.getDataInGCN(lopID,vLanThi);
        }

        public DataTable Get_HOVID_In_CAP_CHUNGCHI_ByLopID(int lopID)
        {
            DAL_DANG_KI_HOC dao = new DAL_DANG_KI_HOC();
            return dao.Get_HOVID_In_CAP_CHUNGCHI_ByLopID(lopID);

        }

        public DataTable getCAP_CHUNGCHI_HV_ByLastNameContrain(string  lastName)
        {

            DANG_KI_HOC searchLastName = new DANG_KI_HOC();
            searchLastName.DKH_LastName = lastName;
            DAL_DANG_KI_HOC dao = new DAL_DANG_KI_HOC();
            return dao.getCAP_CHUNGCHI_HV_ByLastNameContrain(searchLastName);

        }

        public DataTable getDANG_KI_HOC_By_HocVien_ID(int hocvien_ID)
        {

            DANG_KI_HOC dkhoc = new DANG_KI_HOC();
            dkhoc.DKH_HOVID = hocvien_ID;
            DAL_DANG_KI_HOC dao = new DAL_DANG_KI_HOC();
            return dao.getDANG_KI_HOC_By_HocVien_ID(dkhoc);
        }

        public DataTable getCAP_CHUNG_CHI_FILTER_BY_KHOAHOC_LOPHOC(DANG_KI_HOC dkHoc)
        {                        
            DAL_DANG_KI_HOC dao = new DAL_DANG_KI_HOC();
            return dao.getCAP_CHUNG_CHI_FILTER_BY_KHOAHOC_LOPHOC(dkHoc);
        }

        public DataTable search_StudentLastName_In_DKH_New(int lopID, string LastName)
        {
            DAL_DANG_KI_HOC dao = new DAL_DANG_KI_HOC();
            return dao.search_StudentLastName_In_DKH_New(lopID, LastName);
        }

        public DataTable search_StudentLastName_In_DKH( int lopID, int Mon_Id, string LastName)
        {
            DAL_DANG_KI_HOC dao = new DAL_DANG_KI_HOC();
            return dao.search_StudentLastName_In_DKH(lopID, Mon_Id, LastName);
        }

        public DataTable getCount_Student_In_Class(int sLopID)
        {
            DAL_DANG_KI_HOC dangki_dal = new DAL_DANG_KI_HOC();
            //CHUNG_CHI sCchi = new CHUNG_CHI();
            //sCchi.CHC_ID = sCcId;
            return dangki_dal.getCount_Student_In_Class(sLopID);
        }

        // Trieu add new 
        public DataTable getSubjectName(int sCcId)
        {
            DAL_DANG_KI_HOC dangki_dal = new DAL_DANG_KI_HOC();
            CHUNG_CHI sCchi = new CHUNG_CHI();
            sCchi.CHC_ID = sCcId;
            return dangki_dal.getSubjectName(sCchi);
        }

        public DataTable ExportExcel_Info_DiemDanh(int sLopID, int sMonID)
        {
            DAL_DANG_KI_HOC dangki_dal = new DAL_DANG_KI_HOC();
            //CHUNG_CHI sCchi = new CHUNG_CHI();
            //sCchi.CHC_ID = sCcId;
            return dangki_dal.ExportExcel_Info_DiemDanh(sLopID, sMonID);
        }
        public DataTable getHocvienByLopID(int lopID)
        {
            DAL_DANG_KI_HOC dangki_Dal = new DAL_DANG_KI_HOC();
            return dangki_Dal.getHocVienByLopID(lopID);
        }

        public DataTable get_DKH_By_HvID(int HvID)
        {
            DAL_DANG_KI_HOC dangki_Dal = new DAL_DANG_KI_HOC();
            return dangki_Dal.get_DKH_By_HvID(HvID);
        }
        public DataTable Search_MonHoc_By_Lop_HvienID(int vLopID, int vHvID)
        {
            DAL_DANG_KI_HOC dao = new DAL_DANG_KI_HOC();
            return dao.Search_MonHoc_By_Lop_HvienID(vLopID, vHvID);
        }
    }
}
