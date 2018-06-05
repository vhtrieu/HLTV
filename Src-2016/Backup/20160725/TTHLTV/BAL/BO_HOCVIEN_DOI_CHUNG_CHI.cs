using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TTHLTV;
using TTHLTV.DAL;
using TTHLTV.DTO;
using System.Data;
namespace TTHLTV.BAL
{
    class BO_HOCVIEN_DOI_CHUNG_CHI
    {
        DAL.DAL_HOCVIEN_DOI_CHUNG_CHI daoHvDoiCc = new DAL_HOCVIEN_DOI_CHUNG_CHI();
        HOCVIEN_DOI_CHUNG_CHI hvDoiCc = new HOCVIEN_DOI_CHUNG_CHI();
        public void insert(string HVD_Code,
                        int HVD_HOVID,
                        int HVD_LOPID,
                        int HVD_CHCID,
                        string HVD_SoCcCu,
                        string HVD_SoCcMoi,
                       DateTime? HVD_NgayCap

                        )
        {
            
            hvDoiCc.HVD_Code = HVD_Code;
            hvDoiCc.HVD_HOVID = HVD_HOVID;
            hvDoiCc.HVD_LOPID = HVD_LOPID;
            hvDoiCc.HVD_CHCID = HVD_CHCID;
            hvDoiCc.HVD_SoCcCu = HVD_SoCcCu;
            hvDoiCc.HVD_SoCcMoi = HVD_SoCcMoi;
            hvDoiCc.HVD_NgayCap = HVD_NgayCap;
          
            hvDoiCc.HVD_ID = 1;
            daoHvDoiCc.insert(hvDoiCc);
        }

        public void update_DiemThi_Into_DIEM(int DIE_ID,
                    int DIE_Diem,
                    int DIE_LanThi,
                    DateTime? DIE_NgayNhapDiem
                    )
        {
            DAL_DIEM daoDiem = new DAL_DIEM();
            DIEM diem = new DIEM();
            diem.DIE_ID = DIE_ID;
            diem.DIE_Diem = DIE_Diem;
            diem.DIE_LanThi = DIE_LanThi;
            diem.DIE_NgayNhapDiem = DIE_NgayNhapDiem;
            daoDiem.update_DiemThi_Into_DIEM(diem);
        }

        public DataTable get_Doi_Chung_Chi_LastCode()
        {
            DAL_HOCVIEN_DOI_CHUNG_CHI daoDoCc = new DAL_HOCVIEN_DOI_CHUNG_CHI();
            return daoDoCc.get_Doi_Chung_Chi_LastCode();
        }

        public DataTable get_HocVien_Doi_ChungChi(int chungchi_ID, int lopID)
        {
            return daoHvDoiCc.get_HocVien_Doi_ChungChi(chungchi_ID, lopID);
        }
    }
}
