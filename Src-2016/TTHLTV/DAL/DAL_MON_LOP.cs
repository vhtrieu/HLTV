using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
//using Entetities;

namespace TTHLTV.DAL
{
    class DAL_MON_LOP:DataProvider 
    {
        public void insert(MON_LOP mon_lop)
        {
            SqlParameter[] prams ={
                            MakeInParam("@MOL_Code",SqlDbType.NVarChar,20,mon_lop.MOL_Code),
                            MakeInParam("@MOL_LOPID",SqlDbType.Int,4,mon_lop.MOL_LOPID),  
                            MakeInParam("@MOL_MONID",SqlDbType.Int,4,mon_lop.MOL_MONID),
                            MakeInParam("@MOL_GIVID",SqlDbType.Int,4,mon_lop.MOL_GIVID),
                            MakeInParam("@MOL_SoTiet",SqlDbType.Int,4,mon_lop.MOL_SoTiet),
                            MakeInParam("@MOL_ID",SqlDbType.Int ,4,mon_lop.MOL_ID)
                            };
            int errorcode = RunProc("usp_InsertMON_LOP", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }

        }

        public void update(MON_LOP mon_lop)
        {
            SqlParameter[] prams ={
                            MakeInParam("@MOL_ID",SqlDbType.Int ,4,mon_lop.MOL_ID),
                            MakeInParam("@MOL_Code",SqlDbType.NVarChar,20,mon_lop.MOL_Code),
                            MakeInParam("@MOL_LOPID",SqlDbType.Int,4,mon_lop.MOL_LOPID),  
                            MakeInParam("@MOL_MONID",SqlDbType.Int,4,mon_lop.MOL_MONID),
                            MakeInParam("@MOL_GIVID",SqlDbType.Int,4,mon_lop.MOL_GIVID),
                            MakeInParam("@MOL_SoTiet",SqlDbType.Int,4,mon_lop.MOL_SoTiet)
                            };
            int errorcode = RunProc("usp_InsertUpdateMON_LOP", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }

        }

        public void update_By_LopId_MonId(MON_LOP mon_lop)
        { 
            SqlParameter[] prams ={
                            //MakeInParam("@MOL_ID",SqlDbType.Int ,4,mon_lop.MOL_ID),
                            //MakeInParam("@MOL_Code",SqlDbType.NVarChar,20,mon_lop.MOL_Code),
                            MakeInParam("@MOL_LOPID",SqlDbType.Int,4,mon_lop.MOL_LOPID),  
                            MakeInParam("@MOL_MONID",SqlDbType.Int,4,mon_lop.MOL_MONID),
                            MakeInParam("@MOL_GIVID",SqlDbType.Int,4,mon_lop.MOL_GIVID)
                            //MakeInParam("@MOL_SoTiet",SqlDbType.Int,4,mon_lop.MOL_SoTiet)
                            };
            int errorcode = RunProc("Update_Ma_GiangVien_To_Mon_Lop", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }

        }

        public void delete(MON_LOP mon_lop)
        {
            SqlParameter[] prams = { 
                                       MakeInParam("@MOL_ID", SqlDbType.Int, 4, mon_lop.MOL_ID) 
                                   };
            int errorcode = RunProc("usp_DeleteMON_LOP", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }
        }

        protected override object GetDataFromDataRow(DataTable dt, int i)
        {
            MON_LOP obj = new MON_LOP();
            obj.MOL_ID = int.Parse(dt.Rows[i]["MOL_ID"].ToString());
            //some column
            return (object)obj;
        }

        public DataTable getAll_MON_LOP()
        {
            connect();
            DataSet DS = new DataSet();
            int errorcode = RunProcDS("usp_SelectMON_LOPsAll", out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable Get_Lop_GiangVien(MON_LOP mon_lop)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@MOL_LOPID",SqlDbType.Int,4,mon_lop.MOL_LOPID ),
                MakeInParam("@MOL_MONID",SqlDbType.Int,4,mon_lop.MOL_MONID )
            };

            int errorcode = RunProcDS("get_Lop_GiangVien", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable getByID_MON_LOP(MON_LOP mon_lop)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@MOL_ID",SqlDbType.Int,4,mon_lop.MOL_ID )
            };

            int errorcode = RunProcDS("usp_SelectMON_LOP", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable Select_LichGiang_All()
        {
            connect();
            DataSet DS = new DataSet();
            int errorcode = RunProcDS("Select_LichGiang_All", out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable select_LichGiang_ByLopId(int lopId)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@MOL_LOPID",SqlDbType.Int,4,lopId )
            };

            int errorcode = RunProcDS("Select_LichGiang_ByLopId", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
    }
}
