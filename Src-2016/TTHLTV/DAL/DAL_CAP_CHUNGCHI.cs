using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TTHLTV.DTO;

namespace TTHLTV.DAL
{
    class DAL_CAP_CHUNGCHI : DataProvider
    {
        int gID;
        int errorcode;
        public int insert(CAP_CHUNGCHI vDto)
        {
            SqlParameter[] prams ={
                            MakeInParam("@CCC_Code",SqlDbType.NVarChar,50,vDto.CCC_Code),
                            MakeInParam("@CCC_HOVID",SqlDbType.Int,4,vDto.CCC_HOVID),
                            MakeInParam("@CCC_LOPID",SqlDbType.Int,4,vDto.CCC_LOPID),
                            MakeInParam("@CCC_SoCC",SqlDbType.NVarChar,50,vDto.CCC_SoCC),
                            MakeInParam("@CCC_NgayCap",SqlDbType.Date,4,vDto.CCC_NgayCap),
                            MakeInParam("@CCC_NgayHetHan",SqlDbType.Date,4,vDto.CCC_NgayHetHan),
                            MakeInParam("@CCC_NgayCapLai",SqlDbType.Date,4,vDto.CCC_NgayCapLai),
                            MakeInParam("@CCC_CHCID",SqlDbType.Int,4,vDto.CCC_CHCID),
                            MakeInParam("@CCC_Status",SqlDbType.Int,4,vDto.CCC_Status),
                            MakeInParam("@CCC_SoHieuDoi",SqlDbType.NVarChar,50,vDto.CCC_SoHieuDoi),
                            MakeInParam("@CCC_DOIID",SqlDbType.NVarChar,50,vDto.CCC_DOIID),
                            MakeOutParam("@CCC_ID",SqlDbType.Int,4)
                            };
            errorcode = RunProc("usp_InsertCAP_CHUNGCHI", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }
            else
                return gID = (int)prams[11].Value;
        }

        public void update(CAP_CHUNGCHI vDto)
        {
            SqlParameter[] prams ={
                            MakeInParam("@CCC_ID",SqlDbType.Int,4,vDto.CCC_ID),
                            //MakeInParam("@CCC_Code",SqlDbType.NVarChar,50,vDto.CCC_Code),
                            //MakeInParam("@CCC_HOVID",SqlDbType.Int,4,vDto.CCC_HOVID),
                            //MakeInParam("@CCC_LOPID",SqlDbType.Int ,4,vDto.CCC_LOPID),
                            //MakeInParam("@CCC_SoCC",SqlDbType.NVarChar,50,vDto.CCC_SoCC),
                            MakeInParam("@CCC_NgayCap",SqlDbType.Date,4,vDto.CCC_NgayCap),
                            MakeInParam("@CCC_NgayHetHan",SqlDbType.Date ,4,vDto.CCC_NgayHetHan),
                            MakeInParam("@CCC_NgayCapLai",SqlDbType.Date ,4,vDto.CCC_NgayCapLai),
                            MakeInParam("@CCC_CHCID",SqlDbType.Int,4,vDto.CCC_CHCID),
                            MakeInParam("@CCC_Status",SqlDbType.Int,4,vDto.CCC_Status),
                            MakeInParam("@CCC_SoHieuDoi",SqlDbType.NVarChar,50,vDto.CCC_SoHieuDoi)
                            //MakeInParam("@CCC_DOIID",SqlDbType.NVarChar,50,Certificate.CCC_DOIID)
                            };
            int errorcode = RunProc("usp_UpdateCAP_CHUNGCHI", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }

        }

        public void update_SoCC_ToNull(CAP_CHUNGCHI Certificate)
        {
            SqlParameter[] prams ={

                           MakeInParam("@CCC_HOVID",SqlDbType.Int,4,Certificate.CCC_HOVID),
                            //MakeInParam("@CCC_SoCC",SqlDbType.NVarChar,50,Certificate.CCC_SoCC),
                            MakeInParam("@CCC_LOPID",SqlDbType.Int,4,Certificate.CCC_LOPID)
                            };
            int errorcode = RunProc("usp_UpdateCAP_CHUNGCHI_SoCC_ToNull", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }

        }

        public void delete(CAP_CHUNGCHI Certificate)
        {
            SqlParameter[] prams = {
                                       MakeInParam("@CCC_ID", SqlDbType.Int, 4, Certificate.CCC_ID)
                                   };
            int errorcode = RunProc("usp_DeleteCAP_CHUNGCHI", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }
        }

        public DataTable getAll_CAP_CHUNGCHI()
        {
            connect();
            DataSet DS = new DataSet();
            int errorcode = RunProcDS("usp_SelectCAP_CHUNGCHIsAll", out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable ExportExcel_Phat_CHUNGCHI(int CcIds, int lopID)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@CHC_ID",SqlDbType.Int,4,CcIds ),
                MakeInParam("@Lop_ID",SqlDbType.Int,4,lopID )
            };

            int errorcode = RunProcDS("ExportExcel_Phat_CHUNGCHI", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];


        }

        public DataTable ExportExcel_Phat_Doi_CHUNGCHI(int CcIds, int status, string SoHieuDoi)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@CCC_CHCID",SqlDbType.Int,4,CcIds ),
                 MakeInParam("@CCC_Status",SqlDbType.Int,4,status ),
                MakeInParam("@CCC_SoHieuDoi",SqlDbType.NVarChar,50,SoHieuDoi )
            };

            int errorcode = RunProcDS("ExportExcel_Phat_Doi_CHUNGCHI", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];


        }
        public DataTable getLast_SoCc(int ccId)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@CCC_CHCID",SqlDbType.Int,4,ccId )
            };

            int errorcode = RunProcDS("getLast_SoCc", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];


        }

        public DataTable ExportExcel_DsHV_DuocCapCC(int cCId, int lopID)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                 MakeInParam("@CHC_ID",SqlDbType.Int,4,cCId ),
                 MakeInParam("@Lop_ID",SqlDbType.Int,4,lopID )
            };

            int errorcode = RunProcDS("ExportExcel_DsHV_DuocCapCC", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];


        }

        public DataTable ExportExcel_DsHV_DuocCapCC_Doi(int cCId, int Status, string SoHieu)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                 MakeInParam("@CCC_CHCID",SqlDbType.Int,4,cCId ),
                 MakeInParam("@CCC_Status",SqlDbType.Int,4,Status ),
                 MakeInParam("@CCC_SoHieu",SqlDbType.NVarChar,50,SoHieu )
            };

            int errorcode = RunProcDS("ExportExcel_DsHV_DuocCapCC_Doi", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];


        }

        public DataTable getCAP_CHUNGCHI_WithName()
        {
            connect();
            DataSet DS = new DataSet();
            int errorcode = RunProcDS("usp_SelectCAP_CHUNGCHI_WithName", out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable getByID_CAP_CHUNGCHI(CAP_CHUNGCHI Certificate)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@CCC_ID",SqlDbType.Int,4,Certificate.CCC_ID )
            };

            int errorcode = RunProcDS("usp_SelectCAP_CHUNGCHI", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable getCAP_CHUNGCHI_HV_SearchLastName(HOCVIEN cccSearch)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@HOV_LastName",SqlDbType.NVarChar,20,cccSearch.HOV_LastName )
            };

            int errorcode = RunProcDS("usp_SelectCAP_CHUNGCHI_SearchLastName", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable searchHocVien_In_DKH_ByName(DANG_KI_HOC dKhSearch)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@DIE_LOPID",SqlDbType.Int,4,dKhSearch.DKH_LOPID ),
                MakeInParam("@StudentName",SqlDbType.NVarChar,20,dKhSearch.DKH_LastName )
            };

            int errorcode = RunProcDS("searchHocVien_In_DKH_ByName", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable getCAP_CHUNGCHI_By_HocVien_ID(CAP_CHUNGCHI cccSearch)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@HocVien_ID",SqlDbType.Int,4,cccSearch.CCC_HOVID )
            };

            int errorcode = RunProcDS("usp_SelectCAP_CHUNGCHI_ByHocVienID", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable searchCAP_CHUNG_CHI_FILTER_BY_KHOAHOC_LOPHOC_NAME_CONTAIN(int KHOAHOC_ID, int LOP_ID, string lastName)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@ChungChi_ID",SqlDbType.Int,4,KHOAHOC_ID ),
                MakeInParam("@Lop_ID",SqlDbType.Int,4,LOP_ID ),
                MakeInParam("@HOV_LastName",SqlDbType.NVarChar,20,lastName)
            };

            int errorcode = RunProcDS("searchCAP_CHUNG_CHI_FILTER_BY_KHOAHOC_LOPHOC_NAME_CONTAIN", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable GetData_For_CAP_CHUNGCHI_ByLopID(int sLOP_ID)
        {
            connect();
            DataSet DS = new DataSet();
            SqlParameter[] prams ={
                MakeInParam("@DIE_LOPID",SqlDbType.Int,4,sLOP_ID )
            };

            int errorcode = RunProcDS("GetData_For_CAP_CHUNGCHI_ByLopID", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }
            return DS.Tables[0];
        }

        public DataTable searchHocVien_In_CCC_ByName(int Lop_ID, string LastName)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@CCC_LOPID",SqlDbType.Int,4,Lop_ID ),
                MakeInParam("@StudentName",SqlDbType.NVarChar,50,LastName )
            };

            int errorcode = RunProcDS("searchHocVien_In_CCC_ByName", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable searchHocVien_In_CCC_ByFirstName(int Lop_ID, string LastName)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@CCC_LOPID",SqlDbType.Int,4,Lop_ID ),
                MakeInParam("@StudentName",SqlDbType.NVarChar,50,LastName )
            };

            int errorcode = RunProcDS("searchHocVien_In_CCC_ByFirstName", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable searchHocVien_In_CCC_ByBirthday(int Lop_ID, string LastName)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@CCC_LOPID",SqlDbType.Int,4,Lop_ID ),
                MakeInParam("@StudentName",SqlDbType.NVarChar,50,LastName )
            };

            int errorcode = RunProcDS("searchHocVien_In_CCC_ByBirthday", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        protected override object GetDataFromDataRow(DataTable dt, int i)
        {
            CAP_CHUNGCHI obj = new CAP_CHUNGCHI();
            obj.CCC_ID = int.Parse(dt.Rows[i]["CCC_ID"].ToString());
            //some column
            return (object)obj;
        }

        public void CapLaiChungChi(CAP_CHUNGCHI Certificate)
        {
            SqlParameter[] prams ={

                            MakeInParam("@CCC_HOVID",SqlDbType.Int,4,Certificate.CCC_HOVID),
                            MakeInParam("@CCC_LOPID",SqlDbType.Int,4,Certificate.CCC_LOPID),
                            MakeInParam("@CCC_NgayCap",SqlDbType.Date,4,Certificate.CCC_NgayCap),
                            MakeInParam("@CCC_NgayHetHan",SqlDbType.Date,4,Certificate.CCC_NgayHetHan),
                            MakeInParam("@CCC_Status",SqlDbType.Int,4,Certificate.CCC_Status)
                            };
            int errorcode = RunProc("CapLai_ChungChi", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }

        }

        public DataTable Search_CCC_Status(int LopID, int Status)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@CCC_LOPID",SqlDbType.Int,4,LopID ),
                MakeInParam("@Status",SqlDbType.Int,4,Status )
            };

            int errorcode = RunProcDS("Search_CAP_CHUNGCHI_By_Status", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable get_SoHieuDoi_Cc(int CcID, int Status)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@CCC_CHCID",SqlDbType.Int,4,CcID ),
                MakeInParam("@Status",SqlDbType.Int,4,Status )
            };

            int errorcode = RunProcDS("get_SoHieuDoi_Cc", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable get_CccDoi(int CcID, int Status, string soHieu)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@CCC_CHCID",SqlDbType.Int,4,CcID ),
                MakeInParam("@CCC_Status",SqlDbType.Int,4,Status ),
                MakeInParam("@CCC_SoHieuDoi",SqlDbType.NVarChar,50,soHieu )
            };

            int errorcode = RunProcDS("get_Ccc_Doi_By_SoHieuDoi", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable get_Print_CccDoi(int CcID, int Status, string soHieu)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@CCC_CHCID",SqlDbType.Int,4,CcID ),
                MakeInParam("@CCC_Status",SqlDbType.Int,4,Status ),
                MakeInParam("@CCC_SoHieuDoi",SqlDbType.NVarChar,50,soHieu )
            };

            int errorcode = RunProcDS("getPrint_CcDoi", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        public DataTable get_Print_CccDoi_English(int CcID, int Status, string soHieu)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@CCC_CHCID",SqlDbType.Int,4,CcID ),
                MakeInParam("@CCC_Status",SqlDbType.Int,4,Status ),
                MakeInParam("@CCC_SoHieuDoi",SqlDbType.NVarChar,50,soHieu )
            };

            int errorcode = RunProcDS("getPrint_CcDoi_English", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        public void update_SoCC(CAP_CHUNGCHI Certificate)
        {
            SqlParameter[] prams ={

                            MakeInParam("@CCC_ID",SqlDbType.Int,4,Certificate.CCC_ID),
                            //MakeInParam("@CCC_HOVID",SqlDbType.Int,4,Certificate.CCC_HOVID),
                            //MakeInParam("@CCC_LOPID",SqlDbType.Int,4,Certificate.CCC_LOPID),
                            MakeInParam("@CCC_SoCC",SqlDbType.NVarChar,20,Certificate.CCC_SoCC),
                            MakeInParam("@CCC_NgayCap",SqlDbType.Date,4,Certificate.CCC_NgayCap),
                            MakeInParam("@CCC_NgayHetHan",SqlDbType.Date,4,Certificate.CCC_NgayHetHan)
                            };
            int errorcode = RunProc("Update_SoCC_ToNull", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }

        }

        public void update_CapChungChi(CAP_CHUNGCHI vDto)
        {
            SqlParameter[] prams ={
                           
                            //MakeInParam("@CCC_HOVID",SqlDbType.Int,4,vDto.CCC_HOVID),
                            //MakeInParam("@CCC_LOPID",SqlDbType.Int,4,vDto.CCC_LOPID),
                            MakeInParam("@CCC_ID",SqlDbType.Int,4,vDto.CCC_ID),
                            MakeInParam("@CCC_SoCC",SqlDbType.NVarChar,20,vDto.CCC_SoCC),
                            MakeInParam("@CCC_NgayCap",SqlDbType.Date,4,vDto.CCC_NgayCap),
                            MakeInParam("@CCC_NgayHetHan",SqlDbType.Date,4,vDto.CCC_NgayHetHan)
                            };
            int errorcode = RunProc("Update_SoCC_New", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }

        }
        public DataTable getHovienCapCC_byLopID(int vLopID)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@CCC_LOPID",SqlDbType.Int,4,vLopID )

            };

            int errorcode = RunProcDS("Get_HOVID_In_CAP_CHUNGCHI_ByLopID", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];

        }
        public DataTable vLoadCapChungChi_Next(int vLopId, int vHocVienId)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@DIE_LOPID",SqlDbType.Int,4,vLopId ),
                MakeInParam("@DIE_HOVID",SqlDbType.Int,4,vHocVienId )
                //MakeInParam("@DIE_LanThi",SqlDbType.Int,4,vLanThi )
               
            };

            int errorcode = RunProcDS("vLoadCapChungChi_Next", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        public DataTable vCheckLopDaCapCcByLopMonID(int vLopId, int vMonId, int vLanThi)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@CCC_LOPID",SqlDbType.Int,4,vLopId ),
                MakeInParam("@DIE_MONID",SqlDbType.Int,4,vMonId ),
                MakeInParam("@DIE_LanThi",SqlDbType.Int,4,vLanThi )

            };

            int errorcode = RunProcDS("vGetDa_CapChungChi_ByLopMonHocID", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        #region Tool update
        public DataTable loadListNeedUpdate()
        {
            connect();
            DataSet DS = new DataSet();

            //SqlParameter[] prams ={
            //    MakeInParam("@CCC_LOPID",SqlDbType.Int,4,vLopId ),
            //    MakeInParam("@DIE_MONID",SqlDbType.Int,4,vMonId ),
            //    MakeInParam("@DIE_LanThi",SqlDbType.Int,4,vLanThi )

            //};

            int errorcode = RunProcDS("vLoadListNeedUpdte", out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        public DataTable loadListForUpdate()
        {
            connect();
            DataSet DS = new DataSet();

            //SqlParameter[] prams ={
            //    MakeInParam("@CCC_LOPID",SqlDbType.Int,4,vLopId ),
            //    MakeInParam("@DIE_MONID",SqlDbType.Int,4,vMonId ),
            //    MakeInParam("@DIE_LanThi",SqlDbType.Int,4,vLanThi )

            //};

            int errorcode = RunProcDS("vLoadListForUpdte", out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        public void updateChungChiDoiIDToCapChungChi(int DoiID)
        {
            SqlParameter[] prams ={
                            MakeInParam("@CCC_DOIID",SqlDbType.Int ,4,DoiID),

                            };
            int errorcode = RunProc("updateChungChiDoiIDToCapChungChi", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }
        }
        public DataTable vLoadIdDoi(int vCcID)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@ChungChiID",SqlDbType.Int,4,vCcID )

            };

            int errorcode = RunProcDS("vLoadDoiID", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];

        }
        public void vUpdateDoiID(int vDoiID, int CccID)
        {
            SqlParameter[] prams ={
                            MakeInParam("@DoiID",SqlDbType.Int ,4,vDoiID),
                            MakeInParam("@CccID",SqlDbType.Int ,4,CccID)

                            };
            int errorcode = RunProc("vUpdate_DoiIDtoCapChungChi", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }
        }
        #endregion

        public DataTable vLoadDataCapChungChiByDate(DateTime fromDate, DateTime toDate)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@DateFrom",SqlDbType.Date,4,fromDate ),
                MakeInParam("@DateTo",SqlDbType.Date,4,toDate )
            };

            int errorcode = RunProcDS("vLoadDataCapChungChiByDate", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        public DataTable vLoadDataCapChungChiByCHCID(int vChcID, DateTime fromDate, DateTime toDate)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@CHC_ID",SqlDbType.Int,4,vChcID ),
                MakeInParam("@DateFrom",SqlDbType.Date,4,fromDate ),
                MakeInParam("@DateTo",SqlDbType.Date,4,toDate )
            };

            int errorcode = RunProcDS("vLoadDataCapChungChiByChungChiID", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }
            return DS.Tables[0];
        }
        public DataTable vLoadDataCapChungChiByChcIDWithStatus(int vStatus, int vChcID, DateTime fromDate, DateTime toDate)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@CCC_Status",SqlDbType.Int,4,vStatus ),
                MakeInParam("@CHC_ID",SqlDbType.Int,4,vChcID ),
                MakeInParam("@DateFrom",SqlDbType.Date,4,fromDate ),
                MakeInParam("@DateTo",SqlDbType.Date,4,toDate )
            };

            int errorcode = RunProcDS("vLoadDataCapChungChiByChungChiIDWithStatus", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }
            return DS.Tables[0];
        }
        public DataTable vLoadDataCapChungChiByDateWithStatus(int vStatus, DateTime fromDate, DateTime toDate)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@CCC_Status",SqlDbType.Int,4,vStatus ),
                MakeInParam("@DateFrom",SqlDbType.Date,4,fromDate ),
                MakeInParam("@DateTo",SqlDbType.Date,4,toDate )
            };

            int errorcode = RunProcDS("vLoadDataCapChungChiByDateWithStatus", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }
            return DS.Tables[0];
        }
    }
}
