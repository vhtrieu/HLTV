using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TTHLTV.DTO;

namespace TTHLTV.DAL
{
    class DAL_DOI_CHUNGCHI : DataProvider
    {
        int gID;
        int errorcode;
        public int insert(DOI_CHUNGCHI doiCC)
        {
            SqlParameter[] prams ={MakeInParam("@DOI_Code",SqlDbType.NVarChar,20,doiCC.DOI_Code),
                            MakeInParam("@DOI_HOVID",SqlDbType.Int,4,doiCC.DOI_HOVID),
                            MakeInParam("@DOI_CHCID",SqlDbType.Int,4,doiCC.DOI_CHCID),
                            MakeInParam("@DOI_SoCC",SqlDbType.NVarChar,20,doiCC.DOI_SoCC ),
                            MakeInParam("@DOI_NgayCap",SqlDbType.Date,4,doiCC.DOI_NgayCap),
                            MakeInParam("@DOI_Ngay_KG",SqlDbType.Date,4,doiCC.DOI_Ngay_KG),
                            MakeInParam("@DOI_Ngay_KT",SqlDbType.Date,4,doiCC.DOI_Ngay_KT),
                            MakeInParam("@DOI_Ngay_QD",SqlDbType.Date,4,doiCC.DOI_Ngay_QD),
                            MakeOutParam("@DOI_ID",SqlDbType.Int,4)
                                  };
            errorcode = RunProc("usp_InsertDOI_CHUNGCHI", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }
            return gID = (int)prams[8].Value;
        }
        public void update(DOI_CHUNGCHI doiCC)
        {
            SqlParameter[] prams ={MakeInParam("@DOI_ID",SqlDbType.Int,4,doiCC.DOI_ID),
                                    //MakeInParam("@DOI_Code",SqlDbType.NVarChar,20,doiCC.DOI_Code),
                                    //MakeInParam("@DOI_HOVID",SqlDbType.Int,4,doiCC.DOI_HOVID),
                                    MakeInParam("@DOI_CHCID",SqlDbType.Int,4,doiCC.DOI_CHCID),
                                    //MakeInParam("@DOI_SoCC",SqlDbType.NVarChar ,20,doiCC.DOI_SoCC ),
                                    MakeInParam("@DOI_NgayCap",SqlDbType.Date,4,doiCC.DOI_NgayCap),
                                    MakeInParam("@DOI_Ngay_KG",SqlDbType.Date,4,doiCC.DOI_Ngay_KG),
                                    MakeInParam("@DOI_Ngay_KT",SqlDbType.Date,4,doiCC.DOI_Ngay_KT),
                                    MakeInParam("@DOI_Ngay_QD",SqlDbType.Date,4,doiCC.DOI_Ngay_QD)
                                    };
            int errorcode = RunProc("usp_UpdateDOI_CHUNGCHI", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }

        }

        public DataTable getCount_Student_DoiCc(int CcId)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@DOI_CHCID",SqlDbType.Int,4,CcId )
            };

            int errorcode = RunProcDS("getCount_Student_DoiCc", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }
            return DS.Tables[0];
        }

        public DataTable getDoi_CC_LastCode()
        {
            connect();
            DataSet DS = new DataSet();
            int errorcode = RunProcDS("usp_SelectDOI_CC_LastCode", out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable getDOI_CHUNGCHI_ByHocCCID(int ChungChi_ID)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@DOI_CHCID ",SqlDbType.Int,4,ChungChi_ID )

            };

            int errorcode = RunProcDS("usp_SelectDOI_CHUNGCHI_ByHocCCID", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        public DataTable vCheckSoChungChi(int vCcID, string vSoCc)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@CCC_CHCID ",SqlDbType.Int,4,vCcID ),
                MakeInParam("@CCC_SoCc ",SqlDbType.NVarChar,50,vSoCc)
            };

            int errorcode = RunProcDS("vCheck_SoChungChi", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        public DataTable vCheckSoChungChi2(int vCcID, string vSoCc)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@CCC_CHCID ",SqlDbType.Int,4,vCcID ),
                MakeInParam("@CCC_SoCc ",SqlDbType.NVarChar,50,vSoCc)

            };

            int errorcode = RunProcDS("vCheck_SoChungChi2", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        /// <summary>
        /// This function incorect to deleted
        /// </summary>
        /// <param name="HovID"></param>
        /// <param name="SoCc"></param>
        public void delete_Doi_CC_byHvID(int HovID, string SoCc)
        {
            SqlParameter[] prams = {
                                       MakeInParam("@DOI_HOVID", SqlDbType.Int, 4, HovID),
                                       MakeInParam("@DOI_SoCc", SqlDbType.NVarChar, 50, SoCc)
                                   };
            int errorcode = RunProc("Delete_DOI_CC_By_HocVienID", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }
        }
        public void deleteDoiChungChiByID(DOI_CHUNGCHI vDto)
        {
            SqlParameter[] prams = {
                                       MakeInParam("@DOI_ID", SqlDbType.Int, 4, vDto.DOI_ID)
                                   };
            int errorcode = RunProc("DeleteHocVienDoiChungChiByID", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }
        }
        /// <summary>
        /// Bad function is not used
        /// </summary>
        /// <param name="cCcID"></param>
        /// <param name="HvID"></param>
        /// <param name="SoCC"></param>
        public void delete_CAP_CC_Doi_byHvID(int cCcID, int HvID, string SoCC)
        {
            SqlParameter[] prams = {
                                       MakeInParam("@CCC_ID", SqlDbType.Int, 4, cCcID),
                                       MakeInParam("@CCC_HOVID", SqlDbType.Int, 4, HvID),
                                       MakeInParam("@CCC_SoCc", SqlDbType.NVarChar, 50, SoCC)

                                   };
            int errorcode = RunProc("Delete_CAP_CC_DOI_By_HocVienID", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }
        }
        public void DeleteHocVienCapChungChiDoiByDoiID(CAP_CHUNGCHI vDto)
        {
            SqlParameter[] prams = {
                                       MakeInParam("@CCC_ID", SqlDbType.Int, 4, vDto.CCC_ID)

                                   };
            int errorcode = RunProc("DeleteHocVienCapChungChiDoiByID", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }
        }
        public DataTable search_DoiCC_byLastName(int ChungChi_ID, string sText, string vSoHieuDoi)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@DOI_CHCID ",SqlDbType.Int,4,ChungChi_ID ),
                MakeInParam("@textSearch ",SqlDbType.NVarChar,50,sText),
                MakeInParam("@txtSoHieuDoi ",SqlDbType.NVarChar,50,vSoHieuDoi)

            };

            int errorcode = RunProcDS("search_DoiCC_byLastName", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        public DataTable search_DoiCC_byFullName(int ChungChi_ID, string sText, string vSoHieuDoi)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@DOI_CHCID ",SqlDbType.Int,4,ChungChi_ID ),
                MakeInParam("@textSearch ",SqlDbType.NVarChar,50,sText),
                MakeInParam("@txtSoHieuDoi ",SqlDbType.NVarChar,50,vSoHieuDoi)

            };

            int errorcode = RunProcDS("search_DoiCC_byFullName", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        protected override object GetDataFromDataRow(DataTable dt, int i)
        {
            DOI_CHUNGCHI obj = new DOI_CHUNGCHI();
            obj.DOI_ID = int.Parse(dt.Rows[i]["DOI_ID"].ToString());
            //some column
            return (object)obj;
        }
        public void update_NgayCap_Doi(int cCcID, DateTime? NgayCap, DateTime? NgayHetHan)
        {
            SqlParameter[] prams ={

                           MakeInParam("@CCC_ID",SqlDbType.Int,4,cCcID),
                            MakeInParam("@CCC_NgayCap",SqlDbType.Date,4,NgayCap),
                            MakeInParam("@CCC_NgayHetHan",SqlDbType.Date,4,NgayHetHan)
                            };
            int errorcode = RunProc("Update_CcDoi_NgayCapLai", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }

        }
        public DataTable Get_DsHV_DuocCapCC_Doi(int cCId, int Status, string SoHieu)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                 MakeInParam("@CCC_CHCID",SqlDbType.Int,4,cCId ),
                 MakeInParam("@CCC_Status",SqlDbType.Int,4,Status ),
                 MakeInParam("@CCC_SoHieu",SqlDbType.NVarChar,50,SoHieu )
            };

            int errorcode = RunProcDS("Get_DsHV_DuocCapCC_Doi", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable getSoHieuDoi_ByCHCID(int cCId)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                 MakeInParam("@CCC_CHCID",SqlDbType.Int,4,cCId )
            };

            int errorcode = RunProcDS("get_SoHieuDoi_ByCHCID", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        public DataTable getLastId_Doi_ChungChi()
        {
            connect();
            DataSet DS = new DataSet();
            int errorcode = RunProcDS("GetLastId_Doi_ChungChi", out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        public DataTable LoadLevelByDoiID(int DoiID)
        {
            connect();
            DataSet DS = new DataSet();
            int errorcode = RunProcDS("ENGLISH_LEVEL_GetByDoiID", out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
    }
}
