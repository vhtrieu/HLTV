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
    class BO_CHUNG_CHI
    {
        DAL_CHUNG_CHI vDal;
        CHUNG_CHI vDto;
        DataTable tbl;
        public DataTable getChungChi_ByID(int cCID)
        {
            CHUNG_CHI cChi = new CHUNG_CHI();
            cChi.CHC_ID = cCID;
            DAL_CHUNG_CHI dao = new DAL_CHUNG_CHI();
            return dao.getDsCerificate_ByID(cChi);
        }

        public DataTable getChungChi_All()
        {
            CHUNG_CHI cChi = new CHUNG_CHI();
            DAL_CHUNG_CHI dao = new DAL_CHUNG_CHI();
            return dao.getDsCerificateAll();
        }
        public DataTable getNewCode()
        {
            CHUNG_CHI cChi = new CHUNG_CHI();
            DAL_CHUNG_CHI dao = new DAL_CHUNG_CHI();
            return dao.getNewCode();
        }

        public DataTable getDsCHUNG_CHI_LastCode()
        {
            CHUNG_CHI cChi = new CHUNG_CHI();
            DAL_CHUNG_CHI dao = new DAL_CHUNG_CHI();
            return dao.getDsCHUNG_CHI_LastCode();
        }

        public DataTable getDataThongKe_Lop(int idChungChi, string fromDate, string endDate)
        {
            //CHUNG_CHI cChi = new CHUNG_CHI();
            DAL_CHUNG_CHI dao = new DAL_CHUNG_CHI();
            return dao.getData_ThongKe_Lop(idChungChi, fromDate, endDate);
        }

        public DataTable getDataThongKe_Lop_Mon(int idChungChi, string fromDate, string endDate)
        {
            //CHUNG_CHI cChi = new CHUNG_CHI();
            DAL_CHUNG_CHI dao = new DAL_CHUNG_CHI();
            return dao.getData_ThongKe_Lop_Mon(idChungChi, fromDate, endDate);
        }

        public DataTable getDataThongKe_Lop_Hocvien(int idChungChi, string fromDate, string endDate)
        {
            //CHUNG_CHI cChi = new CHUNG_CHI();
            DAL_CHUNG_CHI dao = new DAL_CHUNG_CHI();
            return dao.getData_ThongKe_Lop_Hocvien(idChungChi, fromDate, endDate);
        }

        public void insert(string cCCode, string cCName, string vNdung1, string vNdung2, string vNdung3, string vNdung4, string vQtac, string vModleCode, int vStatus, string vQDinh, string vQDinhEng, int vFontSize1, int vFontSize2, int vFontSize3, int vFontSize4)
        {
            CHUNG_CHI cChi = new CHUNG_CHI();
            cChi.CHC_Code = cCCode;
            cChi.CHC_Name = cCName;
            cChi.CHC_Content1 = vNdung1;
            cChi.CHC_Content2 = vNdung2;
            cChi.CHC_Content3 = vNdung3;
            cChi.CHC_Content4 = vNdung4;
            cChi.CHC_QuyTac = vQtac;
            cChi.CHC_ModleCode = vModleCode;
            cChi.CHC_Status = vStatus;
            cChi.CHC_QuyDinh = vQDinh;
            cChi.CHC_QuyDinhEngl = vQDinhEng;
            cChi.CHC_FontSize1 = vFontSize1;
            cChi.CHC_FontSize2 = vFontSize2;
            cChi.CHC_FontSize3 = vFontSize3;
            cChi.CHC_FontSize4 = vFontSize4;
            cChi.CHC_ID = 1;
            DAL_CHUNG_CHI dao = new DAL_CHUNG_CHI();
            dao.insert(cChi);


        }

        public void update(string cCCode, string cCName, string vNdung1, string vNdung2, string vNdung3, string vNdung4, string vQtac, string vModleCode, int vStatus, int cCID, string vQDinh, string vQDinhEng)
        {
            CHUNG_CHI cChi = new CHUNG_CHI();
            cChi.CHC_Code = cCCode;
            cChi.CHC_Name = cCName;
            cChi.CHC_Content1 = vNdung1;
            cChi.CHC_Content2 = vNdung2;
            cChi.CHC_Content3 = vNdung3;
            cChi.CHC_Content4 = vNdung4;
            cChi.CHC_QuyTac = vQtac;
            cChi.CHC_ModleCode = vModleCode;
            cChi.CHC_Status = vStatus;
            cChi.CHC_QuyDinh = vQDinh;
            cChi.CHC_QuyDinhEngl = vQDinhEng;
            cChi.CHC_ID = cCID;
            DAL_CHUNG_CHI dao = new DAL_CHUNG_CHI();
            dao.update(cChi);


        }

        public void delete(int cCID)
        {
            CHUNG_CHI cChi = new CHUNG_CHI();
            cChi.CHC_ID = cCID;
            DAL_CHUNG_CHI dao = new DAL_CHUNG_CHI();
            dao.delete(cChi);
 

        }
        public void vUpdate_Fontsize_1(int vCcID, int vFontSize)
        {
            DAL_CHUNG_CHI dao = new DAL_CHUNG_CHI();
            dao.vUpdate_Fontsize_1(vCcID, vFontSize);
        }
        public void vUpdate_Fontsize_2(int vCcID, int vFontSize)
        {
            DAL_CHUNG_CHI dao = new DAL_CHUNG_CHI();
            dao.vUpdate_Fontsize_2(vCcID, vFontSize);
        }
        public void vUpdate_Fontsize_3(int vCcID, int vFontSize)
        {
            DAL_CHUNG_CHI dao = new DAL_CHUNG_CHI();
            dao.vUpdate_Fontsize_3(vCcID, vFontSize);
        }
        public void vUpdate_Fontsize_4(int vCcID, int vFontSize)
        {
            DAL_CHUNG_CHI dao = new DAL_CHUNG_CHI();
            dao.vUpdate_Fontsize_4(vCcID, vFontSize);
        }

        public DataTable vGetCapChungChiGeneral(CHUNG_CHI vDto, DateTime dateFrom, DateTime dateTo)
        {
            vDal = new DAL_CHUNG_CHI();
            tbl = new DataTable();
            tbl = vDal.vGetCapChungChiGeneral(vDto, dateFrom, dateTo);
            return tbl;
        }
    }
}
