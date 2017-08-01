using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TTHLTV.DTO;
namespace TTHLTV.DAL
{
    class DAL_HOCVIEN_IMG : DataProvider
    {
        int errorcode;
        int gId;
        public int insert(HOCVIEN_IMG vDto)
        {
            SqlParameter[] prams ={
                            MakeInParam("@IMG_HOVID",SqlDbType.Int,4,vDto.IMG_HOVID),
                            MakeInParam("@IMG_Name",SqlDbType.NVarChar,100,vDto.IMG_Name),
                            MakeInParam("@IMG_Image",SqlDbType.Image,999999999,vDto.IMG_Image),
                            MakeOutParam("@IMG_ID",SqlDbType.Int,4)
                            };
            errorcode = RunProc("Insert_HOCVIEN_IMG", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }
            else
                return gId = (int)prams[3].Value;
        }
        public void update(HOCVIEN_IMG vDto)
        {
            SqlParameter[] prams ={
                            MakeInParam("@IMG_Name",SqlDbType.NVarChar,100,vDto.IMG_Name),
                            MakeInParam("@IMG_Image",SqlDbType.Image,999999999,vDto.IMG_Image),
                            MakeInParam("@IMG_ID",SqlDbType.Int,4,vDto.IMG_ID)
                            };
            errorcode = RunProc("Update_HOCVIEN_IMG", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }
        }

    }
}
