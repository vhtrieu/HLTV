using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TTHLTV.DTO;
namespace TTHLTV.DAL
{
    class DAL_CC_MONHOC :DataProvider
    {
        public DataTable getDsCC_MonHoc(string procName)
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
        /// get all chung chi mon hoc
        /// </summary>
        /// <returns></returns>
        public DataTable getDsCC_MonHocAll()
        {
            connect();
            DataSet DS = new DataSet();

            int errorcode = RunProcDS("usp_SelectCC_MONHOCsAll", out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }


        /// <summary>
        /// Get Chung chi mon hoc by ID chung chi mon hoc
        /// </summary>
        /// <param name="cC_MH"></param>
        /// <returns></returns>
        public DataTable getCC_MH_ByID(CC_MONHOC cC_MH)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={ 
            MakeInParam("@CCM_ID", SqlDbType.Int,4, cC_MH.CCM_ID)
        };

            int errorcode = RunProcDS("usp_SelectCC_MONHOC",
                prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        /// <summary>
        /// Get chung chi mon hoc by mon hoc ID
        /// </summary>
        /// <param name="Course"></param>
        /// 

        public DataTable getCC_MH_ByMHID(CC_MONHOC mHId)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={ 
            MakeInParam("@CCM_MONID", SqlDbType.Int,4, mHId.CCM_MONID)
        };

            int errorcode = RunProcDS("usp_SelectCC_MONHOC_ByMhID",
                prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        /// <summary>
        /// Get chung chi mon hoc by Chung chi ID
        /// </summary>
        /// <param name="Course"></param>
        /// 

        public DataTable getCC_MH_ByCCID(CC_MONHOC cCId)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={ 
            MakeInParam("@CCM_CHCID", SqlDbType.Int,4, cCId.CCM_CHCID)
        };

            int errorcode = RunProcDS("usp_SelectCC_MONHOC_BycCID",
                prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public void insert(CC_MONHOC cc_mh)
        {
            SqlParameter[] prams ={
                            MakeInParam("@CCM_CHCID",SqlDbType.Int ,4,cc_mh.CCM_CHCID),
                            MakeInParam("@CCM_MONID",SqlDbType.Int,4,cc_mh.CCM_MONID),
                            MakeInParam("@CCM_ID",SqlDbType.Int,4,cc_mh.CCM_ID)
                          
                            };
            int errorcode = RunProc("usp_InsertCC_MONHOC", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }

        }

        public void update(CC_MONHOC cc_mh)
        {
            SqlParameter[] prams ={MakeInParam("@CCM_ID",SqlDbType.Int,4,cc_mh.CCM_ID),
                            MakeInParam("@CCM_CHCID",SqlDbType.Int ,4,cc_mh.CCM_CHCID),
                            MakeInParam("@CCM_MONID",SqlDbType.Int,4,cc_mh.CCM_MONID)
                          
                            };
            int errorcode = RunProc("usp_UpdateCC_MONHOC", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }

        }

        public void delete(CC_MONHOC cc_mh)
        {
            SqlParameter[] prams = { MakeInParam("@CCM_ID", SqlDbType.Int, 4, cc_mh.CCM_ID) };
            int errorcode = RunProc("usp_DeleteCC_MONHOC", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }
        }

        protected override object GetDataFromDataRow(DataTable dt, int i)
        {
            MONHOC obj = new MONHOC();
            obj.MON_ID = int.Parse(dt.Rows[i][""].ToString());
            //some column
            return (object)obj;
        }

        public void delete_CC_MonHoc_byChcId(int chcId)
        {
            SqlParameter[] prams = { MakeInParam("@CCM_CHCID", SqlDbType.Int, 4, chcId) };
            int errorcode = RunProc("usp_DeleteCC_MONHOC_By_CHCID", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }
        }
        public void update_font(int fontID, int fontCcID, string fontName, int fontSize, string fontContent)
        {
            SqlParameter[] prams ={MakeInParam("@FON_ID",SqlDbType.Int,4,fontID),
                                   MakeInParam("@FON_CHCID",SqlDbType.Int,4,fontCcID ),
                                   MakeInParam("@FON_Name",SqlDbType.NVarChar,200,fontName),
                                   MakeInParam("@FON_Size",SqlDbType.Int,4,fontSize),
                                   MakeInParam("@FON_CHCContent",SqlDbType.NVarChar,200,fontContent),
                                  };
            int errorcode = RunProc("Update_Font", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }

        }
        public DataTable getIdFont(string fontContent)
        {
            connect();
            DataSet DS = new DataSet();
            SqlParameter[] prams ={
            MakeInParam("@FON_Content",SqlDbType.NVarChar,200,fontContent)
           };
            int errorcode = RunProcDS("getID_Font",prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
    }
}
