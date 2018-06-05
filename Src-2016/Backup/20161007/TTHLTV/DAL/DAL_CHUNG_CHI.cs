using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TTHLTV.DTO;

namespace TTHLTV.DAL
{
    class DAL_CHUNG_CHI :DataProvider
    {
        DataSet DS;
        int errorcode;
        public DataTable getDsCerificate(string procName)
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

        public DataTable getDsCerificate_ByID(CHUNG_CHI Cerificate)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
            MakeInParam("@CHC_ID",SqlDbType.Int,4,Cerificate.CHC_ID )
        };

            int errorcode = RunProcDS("usp_SelectCHUNG_CHI",
                prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        
        /// <summary>
        /// get all chung chi
        /// </summary>
        /// <returns></returns>
        public DataTable getDsCerificateAll( )
        {
            connect();
            DS = new DataSet();
            errorcode = RunProcDS("usp_SelectCHUNG_CHIsAll",out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        public DataTable getNewCode()
        {
            connect();
            DataSet DS = new DataSet();

            int errorcode = RunProcDS("usp_getNewCode", out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable getDsCHUNG_CHI_LastCode()
        {
            connect();
            DataSet DS = new DataSet();

            int errorcode = RunProcDS("usp_SelectCHUNG_CHI_LastCode", out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable getData_ThongKe_Lop(int idChungChi, string fromDate, string endDate)
        {
            connect();
            DataSet DS = new DataSet();
            SqlParameter[] prams ={
            MakeInParam("@CHC_ID",SqlDbType.Int,4,idChungChi),
            MakeInParam("@LOP_Ngay_KG",SqlDbType.NVarChar,50,fromDate),
            MakeInParam("@LOP_Ngay_KG",SqlDbType.NVarChar,50,endDate)
                                  };
            int errorcode = RunProcDS("getData_ThongKe_Lop", out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable getData_ThongKe_Lop_Mon(int idChungChi, string fromDate, string endDate)
        {
            connect();
            DataSet DS = new DataSet();
            SqlParameter[] prams ={
            MakeInParam("@CHC_ID",SqlDbType.Int,4,idChungChi),
            MakeInParam("@LOP_Ngay_KG",SqlDbType.NVarChar,50,fromDate),
            MakeInParam("@LOP_Ngay_KG",SqlDbType.NVarChar,50,endDate)
                                  };
            int errorcode = RunProcDS("getData_ThongKe_Lop_Mon", out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
        public DataTable getData_ThongKe_Lop_Hocvien(int idChungChi, string fromDate, string endDate)
        {
            connect();
            DataSet DS = new DataSet();
            SqlParameter[] prams ={
            MakeInParam("@CHC_ID",SqlDbType.Int,4,idChungChi),
            MakeInParam("@LOP_Ngay_KG",SqlDbType.NVarChar,50,fromDate),
            MakeInParam("@LOP_Ngay_KG",SqlDbType.NVarChar,50,endDate)
                                  };
            int errorcode = RunProcDS("getData_ThongKe_Lop_Hocvien", out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public void insert(CHUNG_CHI Cerificate)
        {
            SqlParameter[] prams ={MakeInParam("@CHC_Code",SqlDbType.NVarChar,50,Cerificate.CHC_Code ),
                                   MakeInParam("@CHC_Name",SqlDbType.NVarChar,200,Cerificate.CHC_Name),
                                   MakeInParam("@CHC_Content1",SqlDbType.NVarChar,200,Cerificate.CHC_Content1),
                                   MakeInParam("@CHC_Content2",SqlDbType.NVarChar,200,Cerificate.CHC_Content2),
                                   MakeInParam("@CHC_Content3",SqlDbType.NVarChar,200,Cerificate.CHC_Content3),
                                   MakeInParam("@CHC_Content4",SqlDbType.NVarChar,200,Cerificate.CHC_Content4),
                                   MakeInParam("@CHC_QuyTac",SqlDbType.NVarChar,50,Cerificate.CHC_QuyTac),
                                   MakeInParam("@CHC_ModleCode",SqlDbType.NVarChar,50,Cerificate.CHC_ModleCode),
                                   MakeInParam("@CHC_Status",SqlDbType.Int,4,Cerificate.CHC_Status),
                                   MakeInParam("@CHC_QuyDinh",SqlDbType.NVarChar,50,Cerificate.CHC_QuyDinh),
                                   MakeInParam("@CHC_QuyDinhEng",SqlDbType.NVarChar,50,Cerificate.CHC_QuyDinhEngl),
                                   MakeInParam("@CHC_FontSize1",SqlDbType.Int,4,Cerificate.CHC_FontSize1),
                                   MakeInParam("@CHC_FontSize2",SqlDbType.Int,4,Cerificate.CHC_FontSize2),
                                   MakeInParam("@CHC_FontSize3",SqlDbType.Int,4,Cerificate.CHC_FontSize3),
                                   MakeInParam("@CHC_FontSize4",SqlDbType.Int,4,Cerificate.CHC_FontSize4),
                                   MakeInParam("@CHC_ID",SqlDbType.Int,4,Cerificate.CHC_ID)
                           
                              };
            int errorcode = RunProc("usp_InsertCHUNG_CHI", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }
        }

        public DataTable getChungChiByNhomCcID(int nhomCcID)
        {
            connect();
            DataSet DS = new DataSet();
            SqlParameter[] prams ={
            MakeInParam("@CHC_Static",SqlDbType.Int,4,nhomCcID)
            //MakeInParam("@LOP_Ngay_KG",SqlDbType.NVarChar,50,fromDate),
            //MakeInParam("@LOP_Ngay_KG",SqlDbType.NVarChar,50,endDate)
                                  };
            int errorcode = RunProcDS("getChungChiByNhomChungChi", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public void update(CHUNG_CHI Cerificate)
        {
            SqlParameter[] prams ={MakeInParam("@CHC_ID",SqlDbType.Int,4,Cerificate.CHC_ID),
                                   MakeInParam("@CHC_Code",SqlDbType.NVarChar,50,Cerificate.CHC_Code ),
                                   MakeInParam("@CHC_Name",SqlDbType.NVarChar,200,Cerificate.CHC_Name),
                                   MakeInParam("@CHC_Content1",SqlDbType.NVarChar,200,Cerificate.CHC_Content1),
                                   MakeInParam("@CHC_Content2",SqlDbType.NVarChar,200,Cerificate.CHC_Content2),
                                   MakeInParam("@CHC_Content3",SqlDbType.NVarChar,200,Cerificate.CHC_Content3),
                                   MakeInParam("@CHC_Content4",SqlDbType.NVarChar,200,Cerificate.CHC_Content4),
                                   MakeInParam("@CHC_QuyTac",SqlDbType.NVarChar,50,Cerificate.CHC_QuyTac),
                                   MakeInParam("@CHC_ModleCode",SqlDbType.NVarChar,50,Cerificate.CHC_ModleCode),
                                   MakeInParam("@CHC_Status",SqlDbType.Int,4,Cerificate.CHC_Status),
                                   MakeInParam("@CHC_QuyDinh",SqlDbType.NVarChar,50,Cerificate.CHC_QuyDinh),
                                   MakeInParam("@CHC_QuyDinhEng",SqlDbType.NVarChar,50,Cerificate.CHC_QuyDinhEngl)
                            
                            //MakeInParam("@ActionOpt",SqlDbType.Bit,0,0)
                                  };
            int errorcode = RunProc("usp_UpdateCHUNG_CHI", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }

        }

        public void delete(CHUNG_CHI Cerificate)
        {
            SqlParameter[] prams = {MakeInParam("@CHC_ID",SqlDbType.Int,4,Cerificate.CHC_ID),
                                    };
            int errorcode = RunProc("usp_DeleteCHUNG_CHI", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }
        }

        public void vUpdate_Fontsize_1(int vCcID, int vFontSize)
        {
            SqlParameter[] prams ={MakeInParam("@CHC_ID",SqlDbType.Int,4, vCcID),
                                  
                                   MakeInParam("@CHC_FontSize1",SqlDbType.Int,4,vFontSize)
                            
                            //MakeInParam("@ActionOpt",SqlDbType.Bit,0,0)
                                  };
            int errorcode = RunProc("Update_FontSize_1", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }

        }
        public void vUpdate_Fontsize_2(int vCcID, int vFontSize)
        {
            SqlParameter[] prams ={MakeInParam("@CHC_ID",SqlDbType.Int,4, vCcID),
                                  
                                   MakeInParam("@CHC_FontSize2",SqlDbType.Int,4,vFontSize)
                            
                            //MakeInParam("@ActionOpt",SqlDbType.Bit,0,0)
                                  };
            int errorcode = RunProc("Update_FontSize_2", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }

        }
        public void vUpdate_Fontsize_3(int vCcID, int vFontSize)
        {
            SqlParameter[] prams ={MakeInParam("@CHC_ID",SqlDbType.Int,4, vCcID),
                                  
                                   MakeInParam("@CHC_FontSize3",SqlDbType.Int,4,vFontSize)
                            
                            //MakeInParam("@ActionOpt",SqlDbType.Bit,0,0)
                                  };
            int errorcode = RunProc("Update_FontSize_3", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }

        }
        public void vUpdate_Fontsize_4(int vCcID, int vFontSize)
        {
            SqlParameter[] prams ={MakeInParam("@CHC_ID",SqlDbType.Int,4, vCcID),
                                  
                                   MakeInParam("@CHC_FontSize4",SqlDbType.Int,4,vFontSize)
                            
                            //MakeInParam("@ActionOpt",SqlDbType.Bit,0,0)
                                  };
            int errorcode = RunProc("Update_FontSize_4", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }

        }

        protected override object GetDataFromDataRow(DataTable dt, int i)
        {
            CHUNG_CHI obj = new CHUNG_CHI();
            obj.CHC_ID = int.Parse(dt.Rows[i]["CHC_ID"].ToString());
            //some column
            return (object)obj;
        }

        public DataTable vGetCapChungChiGeneral(CHUNG_CHI vDto, DateTime dateFrom, DateTime dateTo)
        {
            connect();
            DS = new DataSet();
            SqlParameter[] prams ={
                                    MakeInParam("@CHC_ID",SqlDbType.Int,4,vDto.CHC_ID),
                                    MakeInParam("@DateFrom",SqlDbType.Date,4,dateFrom),
                                    MakeInParam("@DateTo",SqlDbType.Date,4,dateTo),
                                  };
            errorcode = RunProcDS("CAPCHUNGCHI_ThongKeByIDAndDate", prams,out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }
            return DS.Tables[0];
        }
    }
}
