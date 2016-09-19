using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
//using Entetities;

namespace TTHLTV.DAL
{
    class DAL_CHUCDANH : DataProvider
    {       

        public void insert(CHUCDANH chucdanh)
        {
            SqlParameter[] prams ={
                            MakeInParam("@CHU_Code",SqlDbType.NVarChar,20,chucdanh.CHU_Code),
                            MakeInParam("@CHU_Name",SqlDbType.NVarChar,50,chucdanh.CHU_Name),                           
                            MakeInParam("@CHU_ID",SqlDbType.Int ,4,chucdanh.CHU_ID)
                            };
            int errorcode = RunProc("usp_InsertCHUCDANH", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }

        }

        public void update(CHUCDANH chucdanh)
        {
            SqlParameter[] prams ={
                            MakeInParam("@CHU_ID",SqlDbType.Int ,4,chucdanh.CHU_ID),
                            MakeInParam("@CHU_Code",SqlDbType.NVarChar,20,chucdanh.CHU_Code),
                            MakeInParam("@CHU_Name",SqlDbType.NVarChar,50,chucdanh.CHU_Name)                            
                            };
            int errorcode = RunProc("usp_UpdateCHUCDANH", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }

        }

        public void delete(CHUCDANH chucdanh)
        {
            SqlParameter[] prams = { 
                                       MakeInParam("@CHU_ID", SqlDbType.Int, 4, chucdanh.CHU_ID) 
                                   };
            int errorcode = RunProc("usp_DeleteCHUCDANH", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }
        }

        protected override object GetDataFromDataRow(DataTable dt, int i)
        {
            CHUCDANH obj = new CHUCDANH();
            obj.CHU_ID = int.Parse(dt.Rows[i]["CHU_ID"].ToString());
            //some column
            return (object)obj;
        }

        public DataTable getAll_CHUCDANH()
        {
            connect();
            DataSet DS = new DataSet();
            int errorcode = RunProcDS("usp_SelectCHUCDANHsAll", out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable getByID_CHUCDANH(CHUCDANH chucdanh)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@CHU_ID",SqlDbType.Int,4,chucdanh.CHU_ID )
            };

            int errorcode = RunProcDS("usp_SelectCHUCDANH", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }


        public DataTable getChucDanh_LastCode()
        {
            connect();
            DataSet DS = new DataSet();

            int errorcode = RunProcDS("GetLastCode_ChucDanh", out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
    }
}
