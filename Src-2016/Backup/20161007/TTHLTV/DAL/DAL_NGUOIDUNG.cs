using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace TTHLTV.DAL
{
     class DAL_NGUOIDUNG : DataProvider
    {

        public void insert(NGUOIDUNG nguoidung)
        {
            SqlParameter[] prams ={
                            MakeInParam("@NGU_Code",SqlDbType.NVarChar,20,nguoidung.NGU_Code),
                            MakeInParam("@NGU_Name",SqlDbType.NVarChar,50,nguoidung.NGU_Name),   
                            MakeInParam("@NGU_UserName",SqlDbType.NVarChar,50,nguoidung.NGU_UserName),
                            MakeInParam("@NGU_Password",SqlDbType.NVarChar,50,nguoidung.NGU_Password),
                            MakeInParam("@NGU_ID",SqlDbType.Int ,4,nguoidung.NGU_ID)
                            };
            int errorcode = RunProc("usp_InsertNGUOIDUNG", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }

        }

        public void update(NGUOIDUNG nguoidung)
        {
            SqlParameter[] prams ={
                            MakeInParam("@NGU_ID",SqlDbType.Int ,4,nguoidung.NGU_ID),
                            MakeInParam("@NGU_Code",SqlDbType.NVarChar,20,nguoidung.NGU_Code),
                            MakeInParam("@NGU_Name",SqlDbType.NVarChar,50,nguoidung.NGU_Name),   
                            MakeInParam("@NGU_UserName",SqlDbType.NVarChar,50,nguoidung.NGU_UserName),
                            MakeInParam("@NGU_Password",SqlDbType.NVarChar,50,nguoidung.NGU_Password)                           
                            };
            int errorcode = RunProc("usp_UpdateNGUOIDUNG", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }

        }

        public void delete(NGUOIDUNG nguoidung)
        {
            SqlParameter[] prams = { 
                                       MakeInParam("@NGU_ID", SqlDbType.Int, 4, nguoidung.NGU_ID) 
                                   };
            int errorcode = RunProc("usp_DeleteNGUOIDUNG", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }
        }

        protected override object GetDataFromDataRow(DataTable dt, int i)
        {
            NGUOIDUNG obj = new NGUOIDUNG();
            obj.NGU_ID = int.Parse(dt.Rows[i]["NGU_ID"].ToString());
            //some column
            return (object)obj;
        }

        public DataTable getAll_NGUOIDUNG()
        {
            connect();
            DataSet DS = new DataSet();
            int errorcode = RunProcDS("usp_SelectNGUOIDUNGsAll", out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable getByID_NGUOIDUNG(NGUOIDUNG nguoidung)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@NGU_ID",SqlDbType.Int,4,nguoidung.NGU_ID )
            };

            int errorcode = RunProcDS("usp_SelectNGUOIDUNG", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable getNguoiDung_byUserName(NGUOIDUNG userName)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@NGU_UserName",SqlDbType.NVarChar,50,userName.NGU_UserName )
            };

            int errorcode = RunProcDS("GetNguoiDung_ByUserName", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable getLastCode_NguoiDung()
        {
            connect();
            DataSet DS = new DataSet();

            int errorcode = RunProcDS("GetLastCode_NguoiDung", out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        public void backupDatabase(string dbName, string path)
        {
            connect();
            DataSet DS = new DataSet();
            SqlParameter[] prams ={
                MakeInParam("@dbName",SqlDbType.NVarChar,20,dbName ),
                 MakeInParam("@path",SqlDbType.NVarChar,50,path )
            };
            int errorcode = RunProcDS("vBackupDB", out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

        }
    }
}
