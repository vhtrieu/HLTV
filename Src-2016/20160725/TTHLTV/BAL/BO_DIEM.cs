using System;
using System.Collections.Generic;
using System.Linq;
using TTHLTV;
using TTHLTV.DAL;
using System.Data;
using TTHLTV.DTO;
namespace TTHLTV.BAL
{
    public class BO_DIEM
    {
        DAL_DIEM daoDiem;
        public void insert(DIEM dtoDiem)
        {
           daoDiem = new DAL_DIEM();
            daoDiem.insert(dtoDiem);
        }

        public void delete_DIEM_By_HVID(int LopID, int HvID)
        {
            DAL_DIEM daoDiem = new DAL_DIEM();
                        
            daoDiem.delete_DIEM_By_HVID(LopID, HvID);
        }

        public void Delete_DIEM_By_Whith_LanThi(int HvId, int sLanThi)
        {
            DAL_DIEM daoDiem = new DAL_DIEM();
            //DIEM diem = new DIEM();
           // diem.DIE_HOVID = sDiemHvID;
            daoDiem.Delete_DIEM_By_Whith_LanThi(HvId, sLanThi);
        }

        public void update_DiemThi_Into_DIEM(DIEM vDto)
        {//int DIE_ID,int DIE_Diem,int DIE_LanThi, DateTime? DIE_NgayNhapDiem
            daoDiem = new DAL_DIEM();
            daoDiem.update_DiemThi_Into_DIEM(vDto);
        }

        public void update_LanThi_Into_DIEM(int DIE_MONID,
                      int DIE_LanThi
                      )
        {
            DAL_DIEM daoDiem = new DAL_DIEM();
            DIEM diem = new DIEM();
            diem.DIE_ID = DIE_MONID;
            diem.DIE_LanThi = DIE_LanThi;
            daoDiem.update_LanThi_Into_DIEM(diem);
        }

        public DataTable selectDANG_KI_HOC_EntryScores( int sMonId)
        {
            DAL_DIEM dao = new DAL_DIEM();
            return dao.selectDANG_KI_HOC_EntryScores(sMonId);
        }

        public DataTable select_Diem_by_LanThi(int LopID, int sMonId, int sLanthi)
        {
            DAL_DIEM dao = new DAL_DIEM();
            return dao.select_Diem_by_Lanthi(LopID, sMonId,sLanthi);
        }
        public DataTable select_Diem_by_Lop_Mon(int LopID, int sMonId,int sLanThi)
        {
            DAL_DIEM dao = new DAL_DIEM();
            return dao.select_Diem_by_Lop_Mon(LopID, sMonId,sLanThi);
        }
        public DataTable get_GeneralMark(int LopID,  int lanthi)
        {
            DAL_DIEM dao = new DAL_DIEM();
            return dao.get_GeneralMark(LopID,  lanthi);
        }

        public DataTable searchHocVien_GeneralMark_ByName(string lastName) //int lopID, int lanThi,
        {
            //DANG_KI_HOC boDkh = new DANG_KI_HOC();
            //boDkh.DKH_LOPID = lopID;
            //boDkh.DKH_LastName = lastName;
            DAL_DIEM dao = new DAL_DIEM();
            return dao.searchHocVien_GeneralMark_ByName(lastName);
        }

        public DataTable lanThi( int vLopID, int sMonId)
        {
            DAL_DIEM dao = new DAL_DIEM();
            return dao.LanThi(vLopID, sMonId);
        }

        public DataTable LanThi_generalMark(int lopId)
        {
            DAL_DIEM dao = new DAL_DIEM();
            return dao.LanThi_GenarelMark(lopId);
        }
    }
}
