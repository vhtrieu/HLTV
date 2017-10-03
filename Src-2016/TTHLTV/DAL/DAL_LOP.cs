using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TTHLTV.DTO;

namespace TTHLTV.DAL
{
    class DAL_LOP : DataProvider
    {
        public DataTable getDsTrainingCalenda(string procName)
        {
            connect();
            DataSet DS = new DataSet();
            int errorcode = RunProcDS(procName, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable getDsLop_ByID(LOP lop)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
            MakeInParam("@LOP_ID",SqlDbType.Int,4,lop.LOP_ID)
        };

            int errorcode = RunProcDS("usp_SelectLOP",
                prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable getDsLop_LastCode()
        {
            connect();
            DataSet DS = new DataSet();

            int errorcode = RunProcDS("usp_SelectLOP_LastCode", out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable getLop_MonHoc_LastCode()
        {
            connect();
            DataSet DS = new DataSet();

            int errorcode = RunProcDS("usp_SelectLOP_MonHoc_LastCode", out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable getLop_LastId()
        {
            connect();
            DataSet DS = new DataSet();

            int errorcode = RunProcDS("usp_SelectLOP_LastId", out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }


        public DataTable getDsLop_ByCcID(LOP ccID)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
            MakeInParam("@CHC_ID",SqlDbType.Int,4,ccID.LOP_CHCID)
        };

            int errorcode = RunProcDS("usp_SelectLOP_ByCcId",
                prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable getDsLop_ByCcID_NewClass(LOP ccID)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
            MakeInParam("@CHC_ID",SqlDbType.Int,4,ccID.LOP_CHCID)
        };

            int errorcode = RunProcDS("usp_SelectLOP_ByCcId_NewClass",
                prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable getCC_MONHOC_ID_ID_byCcId(CHUNG_CHI ccID)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
            MakeInParam("@CHC_ID",SqlDbType.Int,4,ccID.CHC_ID)
        };

            int errorcode = RunProcDS("usp_SelectMONHOC_ID_byCcId",
                prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable SelectMONHOC_SoTiet_MonId(int monId)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
            MakeInParam("@MON_ID",SqlDbType.Int,4,monId)
        };

            int errorcode = RunProcDS("SelectMONHOC_SoTiet_MonId",
                prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }


        public DataTable SearchByClassName(LOP sQuery)
        {

            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
            MakeInParam("@ClassName",SqlDbType.NVarChar,50,sQuery.LOP_Name)
             };

            int errorcode = RunProcDS("Search_Lop_ByName",
                prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];

        }

        public DataTable getLop_All()
        {
            connect();
            DataSet DS = new DataSet();
            int errorcode = RunProcDS("usp_SelectLOPsAll", out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable getLop_All_WhithCouresName()
        {
            connect();
            DataSet DS = new DataSet();
            int errorcode = RunProcDS("usp_SelectLOPsAll_WithCouresName", out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        //[usp_SelectLOP_ByCcId_from_to]
        public DataTable getLopByChungChiIDFromTo(int CC_ID, DateTime from, DateTime to)
        {
            connect();
            DataSet DS = new DataSet();
            SqlParameter[] prams ={MakeInParam("@CHC_ID",SqlDbType.Int,4,CC_ID),
                            MakeInParam("@LOP_Ngay_KG",SqlDbType.DateTime,4,from),
                            MakeInParam("@LOP_Ngay_KT",SqlDbType.DateTime,4,to)
                                  };
            int errorcode = RunProcDS("usp_SelectLOP_ByCcId_from_to", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }

            return DS.Tables[0];
        }

        public DataTable getLopThongKe(int CcId, DateTime from, DateTime to)
        {
            connect();
            DataSet DS = new DataSet();
            SqlParameter[] prams ={MakeInParam("@CHC_ID",SqlDbType.Int,4,CcId),
                                   MakeInParam("@LOP_Ngay_KG",SqlDbType.DateTime,4,from),
                                   MakeInParam("@LOP_Ngay_KT",SqlDbType.DateTime,4,to)
                                  };
            int errorcode = RunProcDS("GetLop_ThongKe", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }

            return DS.Tables[0];
        }

        public DataTable getChungChiThongKe(DateTime from, DateTime to)
        //public DataTable getChungChiThongKe(DateTime from, DateTime to, int iLoaiCc)
        {
            connect();
            DataSet DS = new DataSet();
            SqlParameter[] prams ={MakeInParam("@LOP_Ngay_KG",SqlDbType.DateTime,4,from),
                                   MakeInParam("@LOP_Ngay_KT",SqlDbType.DateTime,4,to)
                                  // MakeInParam("@iLoaiCc",SqlDbType.Int,4,iLoaiCc)
                                  };
            int errorcode = RunProcDS("GetChungChi_ThongKe", prams, out DS);
            //int errorcode = RunProcDS("GetChungChi_ThongKeWithLoaiCc", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }

            return DS.Tables[0];
        }
       
        public DataTable getChungChiThongKe(DateTime from, DateTime to, int iLoaiCc)
        {
            connect();
            DataSet DS = new DataSet();
            SqlParameter[] prams ={MakeInParam("@LOP_Ngay_KG",SqlDbType.DateTime,4,from),
                                   MakeInParam("@LOP_Ngay_KT",SqlDbType.DateTime,4,to),
                                   MakeInParam("@iLoaiCc",SqlDbType.Int,4,iLoaiCc)
                                  };
            int errorcode = RunProcDS("GetChungChi_ThongKeWithLoaiCc", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }

            return DS.Tables[0];
        }
        public DataTable getHocVienThongKe(int LopId)
        {
            connect();
            DataSet DS = new DataSet();
            SqlParameter[] prams ={
                                   MakeInParam("@LOP_ID",SqlDbType.Int,4,LopId)
                                  };
            int errorcode = RunProcDS("GetHocVien_ThongKe", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }

            return DS.Tables[0];
        }
        public int insert(LOP lop)
        {
            SqlParameter[] prams ={MakeInParam("@LOP_Code",SqlDbType.NVarChar,50,lop.LOP_Code),
                            MakeInParam("@LOP_Name",SqlDbType.NVarChar,200,lop.LOP_Name),
                            MakeInParam("@LOP_Khoa",SqlDbType.NVarChar,10,lop.LOP_Khoa),
                            MakeInParam("@LOP_ShortName",SqlDbType.NVarChar ,20,lop.LOP_ShortName),
                            MakeInParam("@LOP_Ngay_KG",SqlDbType.Date,4,lop.LOP_Ngay_KG),
                            MakeInParam("@LOP_Ngay_KT",SqlDbType.Date ,4,lop.LOP_Ngay_KT),
                            MakeInParam("@LOP_Ngay_QD",SqlDbType.Date ,4,lop.LOP_Ngay_QD),
                            MakeInParam("@LOP_CHCID",SqlDbType.Int,4,lop.LOP_CHCID),
                          
                            MakeOutParam("@OutID",SqlDbType.Int,4)
                                  };
            RunProc("usp_InsertLOP", prams);
            return (int.Parse(prams[8].Value.ToString()));
        }

        public void update(LOP lop)
        {
            SqlParameter[] prams ={
                            MakeInParam("@LOP_ID",SqlDbType.Int,4,lop.LOP_ID),
                            MakeInParam("@LOP_Code",SqlDbType.NVarChar,50,lop.LOP_Code),
                            MakeInParam("@LOP_Name",SqlDbType.NVarChar,200,lop.LOP_Name),
                            MakeInParam("@LOP_Khoa",SqlDbType.NVarChar,10,lop.LOP_Khoa),
                            MakeInParam("@LOP_ShortName",SqlDbType.NVarChar ,20,lop.LOP_ShortName),
                            MakeInParam("@LOP_Ngay_KG",SqlDbType.Date,4,lop.LOP_Ngay_KG),
                            MakeInParam("@LOP_Ngay_KT",SqlDbType.Date ,4,lop.LOP_Ngay_KT),
                            MakeInParam("@LOP_Ngay_QD",SqlDbType.Date ,4,lop.LOP_Ngay_QD),
                            MakeInParam("@LOP_CHCID",SqlDbType.Int,4,lop.LOP_CHCID)


                                  };
            int errorcode = RunProc("usp_UpdateLOP", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }

        }

        public void delete(LOP lop)
        {
            SqlParameter[] prams = { MakeInParam("@LOP_ID", SqlDbType.Int, 4, lop.LOP_ID)

                                   };
            int errorcode = RunProc("usp_DeleteLOP", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }
        }

        protected override object GetDataFromDataRow(DataTable dt, int i)
        {
            LOP obj = new LOP();
            obj.LOP_ID = int.Parse(dt.Rows[i]["LOP_ID"].ToString());
            //some column
            return (object)obj;
        }
        public DataTable getChungChiThongKeWithCcID(DateTime from, DateTime to, int iLoaiCc, int CcID)
        {
            connect();
            DataSet DS = new DataSet();
            SqlParameter[] prams ={MakeInParam("@LOP_Ngay_KG",SqlDbType.DateTime,4,from),
                                   MakeInParam("@LOP_Ngay_KT",SqlDbType.DateTime,4,to),
                                   MakeInParam("@iLoaiCc",SqlDbType.Int,4,iLoaiCc),
                                   MakeInParam("@CHC_ID",SqlDbType.Int,4,CcID)
                                  };
            //int errorcode = RunProcDS("GetChungChi_ThongKe", prams, out DS);
            int errorcode = RunProcDS("GetChungChi_ThongKeWithLoaiCcAndCcID", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }

            return DS.Tables[0];
        }
        public void SaveLevel(int LevelID, int LopID, int LevelNumber,int DoiID)
        {
            connect();
            DataSet DS = new DataSet();
            SqlParameter[] prams ={MakeInParam("@LevelID",SqlDbType.Int,4,LevelID),
                                   MakeInParam("@LopID",SqlDbType.Int,4,LopID),
                                   MakeInParam("@LevelNumber",SqlDbType.Int,4,LevelNumber),
                                   MakeInParam("@DoiID",SqlDbType.Int,4,DoiID)

                                  };
            RunProc("ENGLISH_LEVEL_Save", prams);
        }
        public DataTable LoadLevelByLopID(int LopID)
        {
            connect();
            DataSet DS = new DataSet();
            SqlParameter[] prams ={MakeInParam("@LopID",SqlDbType.Int,4,LopID)
                                  };
            RunProcDS("ENGLISH_LEVEL_GetByLopID", prams, out DS);
            return DS.Tables[0];
        }
        public void DeleteLevel(int LevelID)
        {
            connect();
            DataSet DS = new DataSet();
            SqlParameter[] prams ={MakeInParam("@LevelID",SqlDbType.Int,4,LevelID)
                                  };
            RunProc("ENGLISH_LEVEL_Delete", prams);
        }
    }
}
