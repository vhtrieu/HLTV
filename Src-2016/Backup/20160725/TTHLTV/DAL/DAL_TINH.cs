using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace TTHLTV.DAL
{
    #region comment lay thong tin nguoi dung
    //public class UserData
    //{
    //    DataService m_NguoiDungData = new DataService();

    //    public DataTable LayDsNguoiDung()
    //    {
    //        SqlCommand cmd = new SqlCommand("SELECT * FROM NGUOIDUNG");
    //        m_NguoiDungData.Load(cmd);
    //        return m_NguoiDungData;
    //    }

    //    public DataTable LayDsNguoiDung(String m_Username)
    //    {
    //        SqlCommand cmd = new SqlCommand("SELECT * FROM NGUOIDUNG WHERE TenDNhap = @ten");
    //        cmd.Parameters.Add("ten", SqlDbType.VarChar).Value = m_Username;

    //        m_NguoiDungData.Load(cmd);
    //        return m_NguoiDungData;
    //    }

    //    public DataRow ThemDongMoi()
    //    {
    //        return m_NguoiDungData.NewRow();
    //    }

    //    public void ThemNguoiDung(DataRow m_Row)
    //    {
    //        m_NguoiDungData.Rows.Add(m_Row);
    //    }

    //    public bool LuuNguoiDung()
    //    {
    //        return m_NguoiDungData.ExecuteNoneQuery() > 0;
    //    }

    //    public void ChangePassword(String userName, String newPassword)
    //    {
    //        m_NguoiDungData.ChangePassword(userName, newPassword);
    //    }
    //}
    #endregion

     class DAL_TINH : DataProvider
    {

        public void insert(TINH tinh)
        {
            SqlParameter[] prams ={
                            MakeInParam("@TIN_Code",SqlDbType.NVarChar,10,tinh.TIN_Code),
                            MakeInParam("@TIN_Name",SqlDbType.NVarChar,20,tinh.TIN_Name),                           
                            MakeInParam("@TIN_ID",SqlDbType.Int ,4,tinh.TIN_ID)
                            };
            int errorcode = RunProc("usp_InsertTINH", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }

        }

        public void update(TINH tinh)
        {
            SqlParameter[] prams ={
                            MakeInParam("@TIN_ID",SqlDbType.Int ,4,tinh.TIN_ID),
                            MakeInParam("@TIN_Code",SqlDbType.NVarChar,10,tinh.TIN_Code),
                            MakeInParam("@TIN_Name",SqlDbType.NVarChar,20,tinh.TIN_Name)                          
                            };
            int errorcode = RunProc("usp_UpdateTINH", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }

        }

        public void delete(TINH tinh)
        {
            SqlParameter[] prams = { 
                                       MakeInParam("@TIN_ID", SqlDbType.Int, 4, tinh.TIN_ID) 
                                   };
            int errorcode = RunProc("usp_DeleteTINH", prams);
            if (errorcode > 0)
            {
                throw new Exception("Error");
            }
        }

        protected override object GetDataFromDataRow(DataTable dt, int i)
        {
            TINH obj = new TINH();
            obj.TIN_ID = int.Parse(dt.Rows[i]["TIN_ID"].ToString());
            //some column
            return (object)obj;
        }

        public DataTable getAll_TINH()
        {
            connect();
            DataSet DS = new DataSet();
            int errorcode = RunProcDS("usp_SelectTINHsAll", out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }

        public DataTable getByID_TINH(TINH tinh)
        {
            connect();
            DataSet DS = new DataSet();

            SqlParameter[] prams ={
                MakeInParam("@TIN_ID",SqlDbType.Int,4,tinh.TIN_ID )
            };

            int errorcode = RunProcDS("usp_SelectTINH", prams, out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }


        public DataTable getTinh_LastCode()
        {
            connect();
            DataSet DS = new DataSet();

            int errorcode = RunProcDS("GetLastCode_Tinh", out DS);
            if (errorcode > 0)
            {
                throw new Exception("Error!");
            }

            return DS.Tables[0];
        }
    }
}
