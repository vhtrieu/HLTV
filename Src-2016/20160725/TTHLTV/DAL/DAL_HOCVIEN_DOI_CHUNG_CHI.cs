using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TTHLTV.DTO;
namespace TTHLTV.DAL
{
    class DAL_HOCVIEN_DOI_CHUNG_CHI : DataProvider
    {
        public void insert(HOCVIEN_DOI_CHUNG_CHI HV_DOI_CC)
        {
           
            SqlParameter[] prams ={
                            MakeInParam("@HVD_Code ",SqlDbType.NVarChar,50,HV_DOI_CC.HVD_Code),
                            MakeInParam("@HVD_HOVID",SqlDbType.Int,4,HV_DOI_CC.HVD_HOVID),                           
                            MakeInParam("@HVD_LOPID",SqlDbType.Int ,4,HV_DOI_CC.HVD_LOPID),
                            MakeInParam("@HVD_CHCID",SqlDbType.Int ,4,HV_DOI_CC.HVD_CHCID),
                            MakeInParam("@HVD_SoCcCu",SqlDbType.NVarChar ,50,HV_DOI_CC.HVD_SoCcCu),
                            MakeInParam("@HVD_SoCcMoi",SqlDbType.NVarChar ,50,HV_DOI_CC.HVD_SoCcMoi),
                            MakeInParam("@HVD_NgayCap",SqlDbType.Date ,4,HV_DOI_CC.HVD_NgayCap),

                            MakeInParam("@HVD_ID",SqlDbType.Int ,4,HV_DOI_CC.HVD_ID)

                            };
            int errorcode = RunProc("Insert_Doi_Chung_Chi", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }

        }

        public void update(HOCVIEN_DOI_CHUNG_CHI HV_DOI_CC)
        {
            SqlParameter[] prams ={
                                    MakeInParam("@HVD_ID",SqlDbType.Int ,4,HV_DOI_CC.HVD_ID),
                                    MakeInParam("@HVD_Code ",SqlDbType.NVarChar,50,HV_DOI_CC.HVD_Code),
                                    MakeInParam("@HVD_HOVID",SqlDbType.Int,4,HV_DOI_CC.HVD_HOVID),                           
                                    MakeInParam("@HVD_LOPID",SqlDbType.Int ,4,HV_DOI_CC.HVD_LOPID),
                                    MakeInParam("@HVD_CHCID",SqlDbType.Int ,4,HV_DOI_CC.HVD_CHCID),
                                    MakeInParam("@HVD_SoCcCu",SqlDbType.NVarChar ,50,HV_DOI_CC.HVD_SoCcCu),
                                    MakeInParam("@HVD_SoCcMoi",SqlDbType.NVarChar ,50,HV_DOI_CC.HVD_SoCcMoi),
                                    MakeInParam("@HVD_NgayCap",SqlDbType.Date ,4,HV_DOI_CC.HVD_NgayCap)
                           
                            };
            int errorcode = RunProc("Update_Doi_Chung_Chi", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }

        }

        public void delete_BY_HVID(HOCVIEN_DOI_CHUNG_CHI HV_DOI_CC)
        {
            SqlParameter[] prams = { 
                                       MakeInParam("@HVD_HOVID", SqlDbType.Int, 4, HV_DOI_CC.HVD_HOVID) 
                                   };
            int errorcode = RunProc("Delete_Doi_Chung_Chi_by_HocVienID", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }
        }

        public DataTable get_Doi_Chung_Chi_LastCode()
        {
            connect();
            DataSet DS = new DataSet();
            int errorcode = RunProcDS("get_Doi_Chung_Chi_LastCode", out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable get_HocVien_Doi_ChungChi(int ChungChi_ID, int Lop_ID)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@ChungChi_ID",SqlDbType.Int,4,ChungChi_ID ),
                MakeInParam("@Lop_ID",SqlDbType.Int,4,Lop_ID )
            };

            int errorcode = RunProcDS("select_Doi_Chung_Chi_By_CcId_LopId", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }


    }
}
