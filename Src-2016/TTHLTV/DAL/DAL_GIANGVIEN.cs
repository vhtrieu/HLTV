using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
//using Entetities;

namespace TTHLTV.DAL
{
    class DAL_GIANGVIEN:DataProvider 
    {
        public DataTable getDsTeacher(string procName)
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
        /// <summary>
        /// GET TEACHER BY ID
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        public DataTable getDsTeacher_ByID(GIANGVIEN teacher)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
            MakeInParam("@GIV_ID",SqlDbType.Int,4,teacher.GIV_ID )
        };

            int errorcode = RunProcDS("usp_SelectGIANGVIEN",
                prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        /// <summary>
        /// GET TEACHER BY NAME
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        public DataTable getDsTeacher_ByName(GIANGVIEN teacher)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
            MakeInParam("@GIV_ID",SqlDbType.Int,4,teacher.GIV_ID )
        };

            int errorcode = RunProcDS("usp_SelectGIANGVIEN",
                prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        /// <summary>
        /// get all teacher 
        /// </summary>
        /// <param name="proName"></param>
        /// <returns></returns>
       
        public DataTable getTeacher_All()
        {
            connect();
            DataSet ds = new DataSet();
            int errorCode = RunProcDS("usp_SelectGIANGVIENsAll", out ds);
            if (errorCode > 0)
            {
                throw new Exception(" Error!");

            }
            return ds.Tables[0];
            
         }

        public DataTable getGingVien_LastCode()
        {
            connect();
            DataSet ds = new DataSet();
            int errorCode = RunProcDS("usp_SelectGIANGVIEN_LastCode", out ds);
            if (errorCode > 0)
            {
                throw new Exception(" Error!");

            }
            return ds.Tables[0];

        }

        public void insert(GIANGVIEN teacher)
        {
            SqlParameter[] prams ={MakeInParam("@GIV_Code",SqlDbType.NVarChar,50,teacher.GIV_Code ),
                            MakeInParam("@GIV_Name",SqlDbType.NVarChar,50,teacher.GIV_Name),
                            MakeInParam("@GIV_Phone",SqlDbType.VarChar ,12,teacher.GIV_Phone ),
                            MakeInParam("@GIV_Address",SqlDbType.NVarChar  ,100,teacher.GIV_Address ),
                            MakeInParam("@GIV_Khoa",SqlDbType.NVarChar ,50,teacher.GIV_Khoa),
                            MakeInParam("@GIV_ID",SqlDbType.Int ,4,teacher.GIV_ID)
                            //MakeInParam("@Address",SqlDbType.NVarChar ,250,teacher.TRE_Address ),
                            //MakeInParam("@GraduatedSpeciality",SqlDbType.NVarChar,150,teacher.TRE_GraduatedSpeciality),
                            //MakeInParam("@GraduatedYear",SqlDbType.DateTime,0,Trainee.TRE_GraduatedYear ),
                            //MakeInParam("@Certificates",SqlDbType.NVarChar,250,Trainee.TRE_Certificates ),
                            //MakeInParam("@ActionOpt",SqlDbType.Bit,0,1)
                                  };
            int errorcode = RunProc("usp_InsertGIANGVIEN", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }
        }

        public void update(GIANGVIEN teacher)
        {
            SqlParameter[] prams ={
                            MakeInParam("@GIV_ID",SqlDbType.Int ,4,teacher.GIV_ID),
                            MakeInParam("@GIV_Code",SqlDbType.NVarChar,50,teacher.GIV_Code ),
                            MakeInParam("@GIV_Name",SqlDbType.NVarChar,50,teacher.GIV_Name),
                            MakeInParam("@GIV_Phone",SqlDbType.VarChar ,12,teacher.GIV_Phone ),
                            MakeInParam("@GIV_Address",SqlDbType.NVarChar  ,100,teacher.GIV_Address ),
                            MakeInParam("@GIV_Khoa",SqlDbType.NVarChar ,50,teacher.GIV_Khoa)
                            //MakeInParam("@Address",SqlDbType.NVarChar ,250,Trainee.TRE_Address ),
                            //MakeInParam("@GraduatedSpeciality",SqlDbType.NVarChar,150,Trainee.TRE_GraduatedSpeciality),
                            //MakeInParam("@GraduatedYear",SqlDbType.DateTime,0,Trainee.TRE_GraduatedYear ),
                            //MakeInParam("@Certificates",SqlDbType.NVarChar,250,Trainee.TRE_Certificates ),
                            //MakeInParam("@ActionOpt",SqlDbType.Bit,0,0)
                                  };
            int errorcode = RunProc("usp_UpdateGIANGVIEN", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }

        }

        public void delete(GIANGVIEN teacher)
        {
            SqlParameter[] prams = { MakeInParam("@GIV_ID", SqlDbType.Int, 4, teacher.GIV_ID) };
            int errorcode = RunProc("usp_DeleteGIANGVIEN", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }
        }

        /// <summary>
        /// Get teacher by full name ( chua co store )
        /// </summary>
        /// <param name="strFullName"></param>
        /// <param name="SearchOpt"></param>
        /// <returns></returns>
        public DataTable searchTeacherByFullname(string strFullName, int SearchOpt)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
            MakeInParam("@FullName",SqlDbType.NVarChar,150,strFullName),
            MakeInParam("@SearchOption",SqlDbType.Bit,0,SearchOpt)
        };

            int errorcode = RunProcDS("spTrainees_searchByFullName", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        


        protected override object GetDataFromDataRow(DataTable dt, int i)
        {
            GIANGVIEN obj = new GIANGVIEN();
            obj.GIV_ID = int.Parse(dt.Rows[i]["GIV_ID"].ToString());
            //some column
            return (object)obj;
        }
    }
}
