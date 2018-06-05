using System;
using System.Data;
using System.Data.SqlClient;
using TTHLTV.DTO;
namespace TTHLTV.DAL
{
    class DAL_DANG_KI_HOC : DataProvider
    {
        int errorcode;
        int gID;
        public int insert(DANG_KI_HOC dkhoc)
        {
            SqlParameter[] prams ={
                            MakeInParam("@DKH_Code",SqlDbType.NVarChar,20,dkhoc.DKH_Code),
                            MakeInParam("@DKH_HOVID",SqlDbType.Int,4,dkhoc.DKH_HOVID),                           
                            MakeInParam("@DKH_LOPID",SqlDbType.Int ,4,dkhoc.DKH_LOPID),
                            MakeInParam("@DKH_Diem",SqlDbType.Int ,4,dkhoc.DKH_Diem),
                            MakeInParam("@DKH_LanThi",SqlDbType.Int ,4,dkhoc.DKH_LanThi),
                            MakeInParam("@DKH_BienLai",SqlDbType.NVarChar ,50,dkhoc.DKH_BienLai),
                            MakeOutParam("@DKH_ID",SqlDbType.Int,4)

                            };
            errorcode = RunProc("usp_InsertDANG_KI_HOC", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }
            return gID = (int)prams[6].Value;
        }

        public void update(DANG_KI_HOC dkhoc)
        {
            SqlParameter[] prams ={
                            MakeInParam("@DKH_ID",SqlDbType.Int ,4,dkhoc.DKH_ID),
                            //MakeInParam("@DKH_Code",SqlDbType.NVarChar,20,Certificate.DKH_Code),
                            //MakeInParam("@DKH_HOVID",SqlDbType.Int,4,Certificate.DKH_HOVID),                           
                            MakeInParam("@DKH_LOPID",SqlDbType.Int ,4,dkhoc.DKH_LOPID),
                            MakeInParam("@DKH_Diem",SqlDbType.Int ,4,dkhoc.DKH_Diem),
                            MakeInParam("@DKH_LanThi",SqlDbType.Int ,4,dkhoc.DKH_LanThi),
                             MakeInParam("@DKH_BienLai",SqlDbType.NVarChar ,50,dkhoc.DKH_BienLai)
                            };
            int errorcode = RunProc("usp_UpdateDANG_KI_HOC", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }

        }

        public void update_diem(DANG_KI_HOC Certificate)
        {
            SqlParameter[] prams ={
                            MakeInParam("@DKH_ID",SqlDbType.Int ,4,Certificate.DKH_ID),
                            MakeInParam("@DKH_Diem",SqlDbType.Int ,4,Certificate.DKH_Diem),
                            MakeInParam("@DKH_LanThi",SqlDbType.Int ,4,Certificate.DKH_LanThi)
                            
                            };
            int errorcode = RunProc("usp_UpdateDANG_KI_HOC_DIEM", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }

        }

        public void delete(DANG_KI_HOC Certificate)
        {
            SqlParameter[] prams = { 
                                       MakeInParam("@DKH_ID", SqlDbType.Int, 4, Certificate.DKH_ID) 
                                   };
            int errorcode = RunProc("usp_DeleteDANG_KI_HOC", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }
        }

        public void delete_By_HVID(int LopId, int HvId )
        {
            SqlParameter[] prams = { 
                                       MakeInParam("@DKH_LOPID", SqlDbType.Int, 4, LopId), 
                                       MakeInParam("@DKH_HOVID", SqlDbType.Int, 4, HvId) 
                                   };
            int errorcode = RunProc("usp_DeleteDANG_KI_HOC_By_HOCVIEN_ID", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }
        }
        public void vDeletedHvInDangKiHoc(int vDkhID)
        {
            SqlParameter[] prams = { 
                                       MakeInParam("@DKH_ID", SqlDbType.Int, 4, vDkhID) 
                                   };
            int errorcode = RunProc("vDeleteHvInDangKiHoc", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }
           
        }
        public void DeleteCAP_CHUNGCHI_By_HovID(int LopID, int HviD)
        {
            SqlParameter[] prams = { 
                                       MakeInParam("@CCC_LOPID", SqlDbType.Int, 4, LopID), 
                                       MakeInParam("@CCC_HOVID", SqlDbType.Int, 4, HviD) 
                                   };
            int errorcode = RunProc("usp_DeleteCAP_CHUNGCHI_By_HovID", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }
        }

        protected override object GetDataFromDataRow(DataTable dt, int i)
        {
            DANG_KI_HOC obj = new DANG_KI_HOC();
            obj.DKH_ID = int.Parse(dt.Rows[i]["DKH_ID"].ToString());
            //some column
            return (object)obj;
        }

        public DataTable getAll_DANG_KI_HOC()
        {
            connect();
            DataSet DS = new DataSet();
            int errorcode = RunProcDS("usp_SelectDANG_KI_HOCsAll", out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable getAll_DANG_KI_HOC_LastCode()
        {
            connect();
            DataSet DS = new DataSet();
            int errorcode = RunProcDS("usp_SelectDANG_KI_HOC_LastCode", out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        public DataTable getByID_DANG_KI_HOC(DANG_KI_HOC Certificate)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@DKH_ID",SqlDbType.Int,4,Certificate.DKH_ID )
            };

            int errorcode = RunProcDS("usp_SelectDANG_KI_HOC", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable getDangKiHoc_NameAlls()
        {
            connect();
            DataSet DS = new DataSet();
            int errorcode = RunProcDS("usp_SelectCAP_CHUNGCHI_NameAlls", out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable getHVID_In_DKH(int vLopId)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@LopID",SqlDbType.Int,4,vLopId )
            };

            int errorcode = RunProcDS("usp_Select_HVID_IN_DANG_KI_HOC", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];

            //connect();
            //DataSet DS = new DataSet();
            //int errorcode = RunProcDS("usp_Select_HVID_IN_DANG_KI_HOC", out DS);
            //if (errorcode > 0)
            //{
            //    throw new Exception("Error!");
            //}

            //return DS.Tables[0];
        }
        /// <summary>
        /// load data befor cerification
        /// </summary>
        /// <param name="dKhoc"></param>
        /// <returns></returns>
        public DataTable getDangKiHoc_ByLopID(DANG_KI_HOC dKhoc)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@DKH_LOPID",SqlDbType.Int,4,dKhoc.DKH_LOPID )
            };

            int errorcode = RunProcDS("usp_SelectDANG_KI_HOC_ByLopID", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable getDangKiHoc_Name_ByLopID (int LopID, int LanThi)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@CCC_LOPID",SqlDbType.Int,4,LopID ),
                MakeInParam("@DIE_LanThi",SqlDbType.Int,4,LanThi )
            };

            int errorcode = RunProcDS("vGetDa_CapChungChi_Name_ByLopID", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable getDataInGCN(int sLopID, int vLanThi)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@CCC_LOPID",SqlDbType.Int,4,sLopID),
                MakeInParam("@DIE_LanThi",SqlDbType.Int,4,vLanThi)
            };

            int errorcode = RunProcDS("getPrintGCN", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        public DataTable getDataInGCN_English(int sLopID)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@CCC_LOPID",SqlDbType.Int,4,sLopID)
               
            };

            int errorcode = RunProcDS("getPrintGCN_English", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable Get_HOVID_In_CAP_CHUNGCHI_ByLopID(int LopId)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@CCC_LOPID",SqlDbType.Int,4,LopId )
            };

            int errorcode = RunProcDS("Get_HOVID_In_CAP_CHUNGCHI_ByLopID", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable getCAP_CHUNGCHI_HV_ByLastNameContrain(DANG_KI_HOC dKhocSearch)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@HOV_LastName",SqlDbType.NVarChar,20,dKhocSearch.DKH_LastName )
            };

            int errorcode = RunProcDS("usp_SelectCAP_CHUNGCHI_HV_ByLastNameContrain", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable getDANG_KI_HOC_By_HocVien_ID(DANG_KI_HOC dKhoc)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@DKH_HocVienID",SqlDbType.Int,4,dKhoc.DKH_HOVID )
            };

            int errorcode = RunProcDS("usp_SelectDANG_KI_HOC_By_HocVien_ID", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
       
        public DataTable getCAP_CHUNG_CHI_FILTER_BY_KHOAHOC_LOPHOC(DANG_KI_HOC dkHoc)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@Lop_ID",SqlDbType.Int,4,dkHoc.DKH_LOPID )
            };

            int errorcode = RunProcDS("GetHocVien_DangKiHoc", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }
            return DS.Tables[0];
        }
       
        public DataTable search_StudentLastName_In_DKH_New( int Lop_ID, string LastName)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@sLop_ID",SqlDbType.Int,4,Lop_ID ),
                MakeInParam("@sQlLastName",SqlDbType.NVarChar,50,LastName )
            };

            int errorcode = RunProcDS("search_StudentLastName_InDKH_New", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        public DataTable search_StudentLastName_In_DKH( int Lop_ID, int Mon_ID, string LastName)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@sLop_ID",SqlDbType.Int,4,Lop_ID ),
                 MakeInParam("@Mon_ID",SqlDbType.Int,4,Mon_ID ),
                MakeInParam("@sQlLastName",SqlDbType.NVarChar,50,LastName )
            };

            int errorcode = RunProcDS("search_StudentLastName_In_DKH", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
               
        public DataTable getCount_Student_In_Class(int sLopID)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@LOP_ID",SqlDbType.Int,4,sLopID )
            };

            int errorcode = RunProcDS("getCount_Student_In_Class", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }
            return DS.Tables[0];
        }

        public DataTable getSubjectName(CHUNG_CHI sCcID)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@CHC_ID",SqlDbType.Int,4,sCcID.CHC_ID )
            };

            int errorcode = RunProcDS("usp_SelectSubjectName_ByCouresID", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }
            return DS.Tables[0];
        }

        public DataTable ExportExcel_Info_DiemDanh(int lopID, int monID)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@Lop_ID",SqlDbType.Int,4,lopID ),
                MakeInParam("@Mon_ID",SqlDbType.Int,4,monID )
            };

            int errorcode = RunProcDS("ExportExcel_Info_DiemDanh", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }
            return DS.Tables[0];
        }

        public DataTable getHocVienByLopID(int lopID)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@LOP_ID",SqlDbType.Int,4,lopID ),
            };

            int errorcode = RunProcDS("getHocvienByLOPID", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }
            return DS.Tables[0];
        }

        public DataTable get_DKH_By_HvID(int HvID)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@HvId",SqlDbType.Int,4,HvID ),
            };

            int errorcode = RunProcDS("Search_DKH_ByHovVienID", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }
            return DS.Tables[0];
        }

        public DataTable Search_MonHoc_By_Lop_HvienID(int vLopID, int vHvID)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@LopId",SqlDbType.Int,4,vLopID ),
                 MakeInParam("@HvId",SqlDbType.Int,4,vHvID )
            };

            int errorcode = RunProcDS("Search_MonHoc_By_Lop_HvienID", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
    }
}
