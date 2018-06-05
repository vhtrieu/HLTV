using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TTHLTV.DTO;
namespace TTHLTV.DAL
{
    class DAL_DIEM:DataProvider
    {
        int errorcode;
        int gID;
        public int insert(DIEM dtoDiem)
        {
            SqlParameter[] prams ={
                            MakeInParam("@DIE_CHCID",SqlDbType.Int,4,dtoDiem.DIE_CHCID),
                            MakeInParam("@DIE_MONID",SqlDbType.Int,4,dtoDiem.DIE_MONID),                           
                            MakeInParam("@DIE_LOPID",SqlDbType.Int ,4,dtoDiem.DIE_LOPID),
                            MakeInParam("@DIE_HOVID",SqlDbType.Int ,4,dtoDiem.DIE_HOVID),
                            MakeInParam("@DIE_Diem",SqlDbType.Int ,4,dtoDiem.DIE_Diem),
                            MakeInParam("@DIE_LanThi",SqlDbType.Int ,4,dtoDiem.DIE_LanThi),
                            MakeInParam("@DIE_NgayNhapDiem",SqlDbType.Date ,4,dtoDiem.DIE_NgayNhapDiem),
                            MakeOutParam("@DIE_ID",SqlDbType.Int,4)

                            };
            errorcode = RunProc("usp_InsertDIEM", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }
            return gID = (int)prams[7].Value;
        }

        public void update(DIEM sDiem)
        {
            SqlParameter[] prams ={
                            MakeInParam("@DIE_ID",SqlDbType.Int ,4,sDiem.DIE_ID),
                            MakeInParam("@DIE_CHCID",SqlDbType.Int,20,sDiem.DIE_CHCID),
                            MakeInParam("@DIE_MONID",SqlDbType.Int,4,sDiem.DIE_MONID),                           
                            MakeInParam("@DIE_LOPID",SqlDbType.Int ,4,sDiem.DIE_LOPID),
                            MakeInParam("@DIE_HOVID",SqlDbType.Int ,4,sDiem.DIE_HOVID),
                            MakeInParam("@DIE_Diem",SqlDbType.Int ,4,sDiem.DIE_Diem),
                            MakeInParam("@DIE_LanThi",SqlDbType.NVarChar ,50,sDiem.DIE_LanThi),
                            MakeInParam("@DIE_NgayNhapDiem",SqlDbType.Date ,4,sDiem.DIE_NgayNhapDiem)
                            };
            int errorcode = RunProc("usp_UpdateDIEM", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }

        }

        public void delete_DIEM_By_HVID(int LopID, int HvID)
        {
            SqlParameter[] prams = { 
                                       MakeInParam("@DIE_LOPID", SqlDbType.Int, 4, LopID), 
                                       MakeInParam("@DIE_HOVID", SqlDbType.Int, 4, HvID) 
                                   };
            int errorcode = RunProc("usp_Delete_DIEM_By_HOCVIEN_ID", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }
        }

        public void Delete_DIEM_By_Whith_LanThi(int HvID, int sLanThi)
        {
            SqlParameter[] prams = { 
                                       MakeInParam("@DIE_HOVID", SqlDbType.Int, 4, HvID) ,
                                       MakeInParam("@sLanThi", SqlDbType.Int, 4, sLanThi)
                                   };
            int errorcode = RunProc("Delete_DIEM_By_Whith_LanThi", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }
        }

        public void update_DiemThi_Into_DIEM(DIEM sDiem)
        {
            SqlParameter[] prams ={
                            MakeInParam("@DIE_ID",SqlDbType.Int ,4,sDiem.DIE_ID),
                            MakeInParam("@DIE_Diem",SqlDbType.Int ,4,sDiem.DIE_Diem),
                            MakeInParam("@DIE_LanThi",SqlDbType.Int ,4,sDiem.DIE_LanThi),
                            MakeInParam("@DIE_NgayNhapDiem",SqlDbType.Date,4,sDiem.DIE_NgayNhapDiem)
                            
                            };
            int errorcode = RunProc("usp_Update_DiemThi_Into_DIEM", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }

        }

        public void update_LanThi_Into_DIEM(DIEM sDiem)
        {
            SqlParameter[] prams ={
                            MakeInParam("@DIE_MONID",SqlDbType.Int ,4,sDiem.DIE_MONID),
                            MakeInParam("@DIE_LanThi",SqlDbType.Int ,4,sDiem.DIE_LanThi)
                            
                            };
            int errorcode = RunProc("usp_Update_LanThi_Into_DIEM", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }

        }

        public DataTable selectDANG_KI_HOC_EntryScores(int sMonid)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@DIE_MONID",SqlDbType.Int,4,sMonid )
            };

            int errorcode = RunProcDS("usp_SelectDANG_KI_HOC_EntryScores", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable select_Diem_by_Lanthi(int LopID, int sMonid, int lanthi)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                                      MakeInParam("@LopID",SqlDbType.Int,4,LopID ),
                                      MakeInParam("@DIE_MONID",SqlDbType.Int,4,sMonid ),
                                      MakeInParam("@Lanthi",SqlDbType.Int,4,lanthi )
            };

            int errorcode = RunProcDS("Select_Diem_By_MonID_and_LanThi", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        public DataTable select_Diem_by_Lop_Mon(int LopID, int sMonid,int sLanThi)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                                      MakeInParam("@LopID",SqlDbType.Int,4,LopID ),
                                      MakeInParam("@DIE_MONID",SqlDbType.Int,4,sMonid ),
                                      MakeInParam("@DIE_LanThi",SqlDbType.Int,4,sLanThi )
            };

            int errorcode = RunProcDS("Select_Diem_By_Lop_MonID", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable get_GeneralMark (int LopID, int lanthi)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                                      MakeInParam("@DIE_LOPID",SqlDbType.Int,4,LopID ),
                                      //MakeInParam("@DIE_MONID",SqlDbType.Int,4,sMonid ),
                                      MakeInParam("@DIE_LanThi",SqlDbType.Int,4,lanthi )
            };

            int errorcode = RunProcDS("GetData_For_GeneralMark", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable searchHocVien_GeneralMark_ByName(string LastName)//int Lop_ID, int lanThi,
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                //MakeInParam("@DIE_LOPID",SqlDbType.Int,4,Lop_ID ),
                //MakeInParam("@DIE_LanThi",SqlDbType.Int,4,Lop_ID ),
                MakeInParam("@DIE_HOVLASTNAME",SqlDbType.NVarChar,50,LastName )
            };

            int errorcode = RunProcDS("searchHocVien_GeneralMark_ByName", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable LanThi(int vLopID,int sMonid)
        {
            connect();
            DataSet DS = new DataSet();
            SqlParameter[] prams ={
                                    MakeInParam("@DIE_LOPID",SqlDbType.Int,4,vLopID ),
                                    MakeInParam("@DIE_MONID",SqlDbType.Int,4,sMonid )
                                };
            int errorcode = RunProcDS("LanThi", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }
            return DS.Tables[0];
        }

        public DataTable LanThi_GenarelMark(int sLopId)
        {
            connect();
            DataSet DS = new DataSet();
            SqlParameter[] prams ={
                MakeInParam("@DIE_LOPID",SqlDbType.Int,4,sLopId)
                 //MakeInParam("@DIE_LanThi",SqlDbType.Int,4,lanThi)
            };
            int errorcode = RunProcDS("LanThi_GeneralMark", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }
            return DS.Tables[0];
        }
    }
}
