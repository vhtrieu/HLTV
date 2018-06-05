using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TTHLTV.DTO;
namespace TTHLTV.DAL
{
    class DAL_HOCVIEN : DataProvider
    {
        int errorcode;
        int gId;
        public int insert(HOCVIEN hocvien)
        {
            SqlParameter[] prams ={
                            MakeInParam("@HOV_Code",SqlDbType.NVarChar,50,hocvien.HOV_Code),
                            MakeInParam("@HOV_FirstName",SqlDbType.NVarChar,50,hocvien.HOV_FirstName),                           
                            MakeInParam("@HOV_LastName",SqlDbType.NVarChar,20,hocvien.HOV_LastName),
                            MakeInParam("@HOV_FullName",SqlDbType.NVarChar,20,hocvien.HOV_FullName),
                            MakeInParam("@HOV_BirthDay",SqlDbType.NVarChar,50,hocvien.HOV_BirthDay),
                            MakeInParam("@HOV_QuocTich",SqlDbType.NVarChar,50,hocvien.HOV_QuocTich),
                            MakeInParam("@HOV_NoiSinh",SqlDbType.NVarChar,50,hocvien.HOV_NoiSinh),
                            MakeInParam("@HOV_Phone",SqlDbType.NVarChar,12,hocvien.HOV_Phone),
                            MakeInParam("@HOV_Address",SqlDbType.NVarChar,200,hocvien.HOV_Address),
                            MakeInParam("@HOV_DonVi",SqlDbType.NVarChar,100,hocvien.HOV_DonVi),
                            //MakeInParam("@HOV_ChucDanh",SqlDbType.NVarChar,50,hocvien.HOV_ChucDanh),
                            MakeInParam("@HOV_GhiChu",SqlDbType.NVarChar,2000,hocvien.HOV_GhiChu),
                            //MakeInParam("@HOV_ID",SqlDbType.Int ,4,hocvien.HOV_ID)
                            MakeOutParam("@HOV_ID",SqlDbType.Int,4)
                            };
            errorcode = RunProc("usp_InsertHOCVIEN", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }
            else
                return gId = (int)prams[11].Value;

        }
        public void update(HOCVIEN hocvien)
        {
            SqlParameter[] prams ={
                            MakeInParam("@HOV_ID",SqlDbType.Int ,4,hocvien.HOV_ID),
                            MakeInParam("@HOV_Code",SqlDbType.NVarChar,50,hocvien.HOV_Code),
                            MakeInParam("@HOV_FirstName",SqlDbType.NVarChar,50,hocvien.HOV_FirstName),                           
                            MakeInParam("@HOV_LastName",SqlDbType.NVarChar,20,hocvien.HOV_LastName),
                            MakeInParam("@HOV_FullName",SqlDbType.NVarChar,20,hocvien.HOV_FullName),
                            MakeInParam("@HOV_BirthDay",SqlDbType.NVarChar,50,hocvien.HOV_BirthDay),
                            MakeInParam("@HOV_QuocTich",SqlDbType.NVarChar,50,hocvien.HOV_QuocTich),
                            MakeInParam("@HOV_NoiSinh",SqlDbType.NVarChar,50,hocvien.HOV_NoiSinh),
                            MakeInParam("@HOV_Phone",SqlDbType.NVarChar,12,hocvien.HOV_Phone),
                            MakeInParam("@HOV_Address",SqlDbType.NVarChar,200,hocvien.HOV_Address),
                            MakeInParam("@HOV_DonVi",SqlDbType.NVarChar,100,hocvien.HOV_DonVi),
                            //MakeInParam("@HOV_ChucDanh",SqlDbType.NVarChar,50,hocvien.HOV_ChucDanh),
                            MakeInParam("@HOV_GhiChu",SqlDbType.NVarChar,2000,hocvien.HOV_GhiChu)                       
                            };
            int errorcode = RunProc("usp_UpdateHOCVIEN", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }

        }
        public void delete(HOCVIEN hocvien)
        {
            SqlParameter[] prams = { 
                                       MakeInParam("@HOV_ID", SqlDbType.Int, 4, hocvien.HOV_ID) 
                                   };
            int errorcode = RunProc("usp_DeleteHOCVIEN", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }
        }
        public void Delete_DiemHocVien_by_HvId(int hocvienID)
        {
            SqlParameter[] prams = { 
                                       MakeInParam("@DIE_HOVID", SqlDbType.Int, 4, hocvienID) 
                                   };
            int errorcode = RunProc("Delete_DIEM_HOCVIEN_by_HOVID", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }
        }
        protected override object GetDataFromDataRow(DataTable dt, int i)
        {
            HOCVIEN obj = new HOCVIEN();
            obj.HOV_ID = int.Parse(dt.Rows[i]["HOV_ID"].ToString());
            //some column
            return (object)obj;
        }
        public DataTable get_HOCVIEN_LastCode()
        {
            connect();
            DataSet DS = new DataSet();
            int errorcode = RunProcDS("usp_SelectHOCVIEN_LastCode", out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        public DataTable getAll_HOCVIEN()
        {
            connect();
            DataSet DS = new DataSet();
            int errorcode = RunProcDS("SelectHOCVIEN", out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        public DataTable ExportExcel_DsHocVien_ByLopID(int lopID)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@Lop_ID",SqlDbType.Int,4,lopID )
            };

            int errorcode = RunProcDS("ExportExcel_DsLop", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        public DataTable ExportExcel_DiemThi(int lopID, int mHocId, int lanthi)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@Lop_ID",SqlDbType.Int,4,lopID ),
                 MakeInParam("@MonHocId",SqlDbType.Int,4,mHocId ),
                 MakeInParam("@Lanthi ",SqlDbType.Int,4,lanthi )
            };

            int errorcode = RunProcDS("ExportExcel_PhieuThi", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        public DataTable ExportExcel_DiemDanh(int lopID, int monID)
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
        public DataTable getHocVienByID(HOCVIEN hocvien)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@HOV_ID",SqlDbType.Int,4,hocvien.HOV_ID )
            };
            errorcode = RunProcDS("SelectHOCVIEN_ByID", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }
            return DS.Tables[0];
        }
        public DataTable searchHocVienByFullName(string firstName)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@FullName",SqlDbType.NVarChar,50,firstName )
            };

            int errorcode = RunProcDS("Search_HovVien_FullName", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        public DataTable searchHocVienByFirstName(string firstName)//, string lastname)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@FirstName",SqlDbType.NVarChar,50,firstName )
               // MakeInParam("@LastName",SqlDbType.NVarChar,50,lastname)
            };

            int errorcode = RunProcDS("Search_HovVien_FirstName", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        public DataTable searchHocVienByLasrName(string textSearch)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@textSearch",SqlDbType.NVarChar,50,textSearch )
            };

            int errorcode = RunProcDS("Search_HovVien_LastName", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        public DataTable searchHocVienByBirthDay(string textSearch)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@textSearch",SqlDbType.NVarChar,50,textSearch )
            };

            int errorcode = RunProcDS("Search_HovVien_byBirthDay", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        public DataTable searchHocVienByNoiSinh(string textSearch)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@textSearch",SqlDbType.NVarChar,50,textSearch )
            };

            int errorcode = RunProcDS("Search_HovVien_byNoiSinh", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        public DataTable searchHocVienByDienThoai(string textSearch)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@textSearch",SqlDbType.NVarChar,50,textSearch )
            };

            int errorcode = RunProcDS("Search_HovVien_byDienThoai", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        public DataTable searchHocVienBySoCC(string textSearch)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@textSearch",SqlDbType.NVarChar,50,textSearch )
            };

            int errorcode = RunProcDS("Search_HovVien_bySoCC", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        public DataTable search_DiemThi_ByHocVienID(int HvId)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@HvId",SqlDbType.Int,4,HvId )
            };

            int errorcode = RunProcDS("Search_DiemThi_ByHovVienID", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        public DataTable search_CCC_ByHocVienID(int HvId)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@HvId",SqlDbType.Int,4,HvId )
            };

            int errorcode = RunProcDS("Search_CapChungChi_ByHovVienID", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        public DataTable vCheck_Delete_HvDoi(int HvId)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@DOI_HOVID",SqlDbType.Int,4,HvId )
            };

            int errorcode = RunProcDS("vCheck_iDHv_Cap_Doi", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        public DataTable vCheck_Delete_Hv_Dang_Ki_Hoc (int HvId)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@DKH_HOVID",SqlDbType.Int,4,HvId )
            };

            int errorcode = RunProcDS("vCheck_iDHv_Dang_Ki_Hoc", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        public void updateFullName(string HvID, string FullName)
        {
            SqlParameter[] prams ={
                            MakeInParam("@HOV_ID",SqlDbType.NVarChar,50,HvID),
                            MakeInParam("@HOV_FullName",SqlDbType.NVarChar,100,FullName)
                            };
            int errorcode = RunProc("UpdateHOCVIEN_FullName_1", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }

        }
        public DataTable getAll_HOCVIEN_1()
        {
            connect();
            DataSet DS = new DataSet();
            int errorcode = RunProcDS("SelectHOCVIENsAll_1", out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        #region Search old
        public DataTable searchHocVienByFullName_1(string firstName)//, string lastname)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@FullName",SqlDbType.NVarChar,50,firstName )
               // MakeInParam("@LastName",SqlDbType.NVarChar,50,lastname)
            };

            int errorcode = RunProcDS("Search_HovVien_FullName_1", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        public DataTable searchHocVienByFirstName_1(string firstName)//, string lastname)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@FirstName",SqlDbType.NVarChar,50,firstName )
               // MakeInParam("@LastName",SqlDbType.NVarChar,50,lastname)
            };

            int errorcode = RunProcDS("Search_HovVien_FirstName_1", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        public DataTable searchHocVienByLastName_1(string textSearch)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@LasrtName",SqlDbType.NVarChar,50,textSearch )
            };

            int errorcode = RunProcDS("Search_HovVien_LastName_1", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        public DataTable searchHocVienBySoCC_1(string textSearch)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@textSearch",SqlDbType.NVarChar,50,textSearch )
            };

            int errorcode = RunProcDS("Search_HovVien_bySoCC_1", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        public DataTable search_DiemThi_ByHocVienID(string HvId)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@HvId",SqlDbType.NVarChar,20,HvId )
            };

            int errorcode = RunProcDS("Search_DiemThi_ByHovVienID_1", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        public DataTable searchLop_By_MaHocVien_1(string maHocVien)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@HvId",SqlDbType.NVarChar,20,maHocVien )
            };

            int errorcode = RunProcDS("Search_Lop_By_HocVienID_1", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable searchHocVienByFirstName_1_Doi(string firstName)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@FirstName",SqlDbType.NVarChar,50,firstName )
               // MakeInParam("@LastName",SqlDbType.NVarChar,50,lastname)
            };

            int errorcode = RunProcDS("Search_HovVien_FirstName_1_Doi", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        public DataTable searchHocVienByFullName_1_Doi(string firstName)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@FullName",SqlDbType.NVarChar,50,firstName )
               // MakeInParam("@LastName",SqlDbType.NVarChar,50,lastname)
            };

            int errorcode = RunProcDS("Search_HovVien_FullName_1_Doi", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        public DataTable searchHocVienByLastName_1_Doi(string textSearch)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@LastName",SqlDbType.NVarChar,50,textSearch )
            };

            int errorcode = RunProcDS("Search_HovVien_LastName_1_Doi", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        public DataTable searchHocVienBySoCC_1_Doi(string textSearch)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@textSearch",SqlDbType.NVarChar,50,textSearch )
            };

            int errorcode = RunProcDS("Search_HovVien_bySoCC_1_Doi", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        public DataTable searchLop_By_MaHocVien_1_Doi(string maHocVien)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@HvId",SqlDbType.NVarChar,50,maHocVien )
            };

            int errorcode = RunProcDS("Search_Lop_By_HocVienID_1_Doi", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        #endregion
    }
}
