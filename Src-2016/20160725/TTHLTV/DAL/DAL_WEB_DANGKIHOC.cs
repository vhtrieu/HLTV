using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TTHLTV.DTO;

namespace TTHLTV.DAL
{
    class DAL_WEB_DANGKIHOC:DataProvider
    {
        public DataTable vLoadData(WEB_DANGKIHOC vDto)
        {
            connect();
            DataSet DS = new DataSet();
            SqlParameter[] prams ={
                                    MakeInParam("@DKW_Status",SqlDbType.Int,4,vDto.DKW_Status),
                                    MakeInParam("@DKW_Active",SqlDbType.Int,4,vDto.DKW_Active)
                                   };
            int errorcode = RunProcDS("WEB_DANGKIHOC_Select", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        public DataTable vLoadTotalHocVienDangKi(WEB_DANGKIHOC vDto)
        {
            connect();
            DataSet DS = new DataSet();
            SqlParameter[] prams ={
                                    MakeInParam("@DKW_Active",SqlDbType.Int,4,vDto.DKW_Active),
                                    MakeInParam("@DKW_Status",SqlDbType.Int,4,vDto.DKW_Status),
                                    MakeInParam("@DKW_CHCID",SqlDbType.Int,4,vDto.DKW_CHCID)
                                   };
            int errorcode = RunProcDS("WEB_DANGKIHOC_SelectTotalHocVien", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
            
        }
        public DataTable vLoadListHocVienByChungChiID(WEB_DANGKIHOC vDto)
        {
           connect();
            DataSet DS = new DataSet();
            SqlParameter[] prams ={
                                    MakeInParam("@DKW_Active",SqlDbType.Int,4,vDto.DKW_Active),
                                    MakeInParam("@DKW_Status",SqlDbType.Int,4,vDto.DKW_Status),
                                    MakeInParam("@DKW_CHCID",SqlDbType.Int,4,vDto.DKW_CHCID)
                                   };
            int errorcode = RunProcDS("WEB_DANGKIHOC_SelectListHocVienByChungChiID", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
            
            
        }
        public void updateStatus(WEB_DANGKIHOC vDto)
        {
            SqlParameter[] prams ={
                            MakeInParam("@DKW_ID",SqlDbType.Int ,4,vDto.DKW_ID),
                            MakeInParam("@DKW_Status",SqlDbType.Int,4,vDto.DKW_Status)                       
                            };
            int errorcode = RunProc("WEB_DANGKIHOC_UpdateStatus", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }
        }

    }
}
