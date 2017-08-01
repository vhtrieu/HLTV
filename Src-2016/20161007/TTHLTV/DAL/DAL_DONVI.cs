using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
//using Entetities;

namespace TTHLTV.DAL
{
    class DAL_DONVI:DataProvider
    {
        public void insert(DONVI donvi)
        {
            SqlParameter[] prams ={
                            MakeInParam("@DON_Code",SqlDbType.NVarChar,20,donvi.DON_Code),
                            MakeInParam("@DON_Name",SqlDbType.NVarChar,200,donvi.DON_Name),                           
                            MakeInParam("@DON_DiaChi",SqlDbType.NVarChar ,200,donvi.DON_DiaChi),
                            MakeInParam("@DON_Phone",SqlDbType.NVarChar,12,donvi.DON_Phone),
                            MakeInParam("@DON_Fax",SqlDbType.NVarChar,12,donvi.DON_Fax),                           
                            MakeInParam("@DON_GhiChu",SqlDbType.NVarChar,2000,donvi.DON_GhiChu),
                            MakeInParam("@DON_ID",SqlDbType.Int ,4,donvi.DON_ID)

                            };
            int errorcode = RunProc("usp_InsertDONVI", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }

        }

        public void update(DONVI donvi)
        {
            SqlParameter[] prams ={
                            MakeInParam("@DON_ID",SqlDbType.Int ,4,donvi.DON_ID),
                            MakeInParam("@DON_Code",SqlDbType.NVarChar,20,donvi.DON_Code),
                            MakeInParam("@DON_Name",SqlDbType.NVarChar,200,donvi.DON_Name),                           
                            MakeInParam("@DON_DiaChi",SqlDbType.NVarChar ,200,donvi.DON_DiaChi),
                            MakeInParam("@DON_Phone",SqlDbType.NVarChar,12,donvi.DON_Phone),
                            MakeInParam("@DON_Fax",SqlDbType.NVarChar,12,donvi.DON_Fax),                           
                            MakeInParam("@DON_GhiChu",SqlDbType.NVarChar,2000,donvi.DON_GhiChu)                           
                            };
            int errorcode = RunProc("usp_UpdateDONVI", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }

        }

        public void delete(DONVI donvi)
        {
            SqlParameter[] prams = { 
                                       MakeInParam("@DON_ID", SqlDbType.Int, 4, donvi.DON_ID) 
                                   };
            int errorcode = RunProc("usp_DeleteDONVI", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }
        }

        protected override object GetDataFromDataRow(DataTable dt, int i)
        {
            DONVI obj = new DONVI();
            obj.DON_ID = int.Parse(dt.Rows[i]["DON_ID"].ToString());
            //some column
            return (object)obj;
        }

        public DataTable getAll_DONVI()
        {
            connect();
            DataSet DS = new DataSet();
            int errorcode = RunProcDS("usp_SelectDONVIsAll", out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable getByID_DONVI(DONVI donvi)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@DON_ID",SqlDbType.Int,4,donvi.DON_ID )
            };

            int errorcode = RunProcDS("usp_SelectDONVI", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable getDonVi_LastCode()
        {
            connect();
            DataSet DS = new DataSet();

            int errorcode = RunProcDS("GetLastCode_DonVi", out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
    }
}
