using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TTHLTV.DTO;

namespace TTHLTV.DAL
{
    class DAL_MONHOC:DataProvider
    {
        public void insert(MONHOC monhoc)
        {
            SqlParameter[] prams ={
                            MakeInParam("@MON_Code",SqlDbType.NVarChar,20,monhoc.MON_Code),
                            MakeInParam("@MON_Name",SqlDbType.NVarChar,200,monhoc.MON_Name),  
                            MakeInParam("@MON_SoTiet",SqlDbType.Int,4,monhoc.MON_SoTiet),                           
                            MakeInParam("@MON_ID",SqlDbType.Int ,4,monhoc.MON_ID)
                            };
            int errorcode = RunProc("usp_InsertMONHOC", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }

        }

        public void update(MONHOC monhoc)
        {
            SqlParameter[] prams ={
                            MakeInParam("@MON_ID",SqlDbType.Int ,4,monhoc.MON_ID),
                            MakeInParam("@MON_Code",SqlDbType.NVarChar,20,monhoc.MON_Code),
                            MakeInParam("@MON_Name",SqlDbType.NVarChar,200,monhoc.MON_Name),  
                            MakeInParam("@MON_SoTiet",SqlDbType.Int,4,monhoc.MON_SoTiet)                            
                            };
            int errorcode = RunProc("usp_UpdateMONHOC", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }

        }

        public void delete(MONHOC monhoc)
        {
            SqlParameter[] prams = { 
                                       MakeInParam("@MON_ID", SqlDbType.Int, 4, monhoc.MON_ID) 
                                   };
            int errorcode = RunProc("usp_DeleteMONHOC", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }
        }

        protected override object GetDataFromDataRow(DataTable dt, int i)
        {
            MONHOC obj = new MONHOC();
            obj.MON_ID = int.Parse(dt.Rows[i]["MON_ID"].ToString());
            //some column
            return (object)obj;
        }

        public DataTable getAll_MONHOC()
        {
            connect();
            DataSet DS = new DataSet();
            int errorcode = RunProcDS("usp_SelectMONHOCsAll", out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable getAll_MONHOC_LastCode()
        {
            connect();
            DataSet DS = new DataSet();
            int errorcode = RunProcDS("usp_SelectMONHOC_LastCode", out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable getByID_MONHOC(MONHOC monhoc)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@MON_ID",SqlDbType.Int,4,monhoc.MON_ID )
            };

            int errorcode = RunProcDS("usp_SelectMONHOC", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable getMONHOC_By_LopID(int lopID)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@Lop_ID",SqlDbType.Int,4,lopID)
            };

            int errorcode = RunProcDS("usp_SelectMONHOC_By_LopID", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }


        public DataTable SelectMONHOC_Name_By_CHCID(int sChcID)
        {
            connect();
            DataSet DS = new DataSet();
            SqlParameter[] prams ={
                MakeInParam("@CHC_ID",SqlDbType.Int,4,sChcID)
            };
            int errorcode = RunProcDS("usp_SelectMONHOC_Name_By_CHCID", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }
            return DS.Tables[0];
        }
        public DataTable getSubjectName(CHUNG_CHI vDto)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@CHC_ID",SqlDbType.Int,4,vDto.CHC_ID )
            };

            int errorcode = RunProcDS("usp_SelectSubjectName_ByCouresID", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }
            return DS.Tables[0];
        }

    }
}
