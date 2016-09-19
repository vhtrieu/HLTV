using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Xml;
//using TTHLTV.DAL;
using TTHLTV.Utilities;
using EnCryptDecrypt;
using System.Windows.Forms;

namespace TTHLTV.DAL
{
    class DataProvider
    {
        protected static string _connectionString = "";

        protected SqlConnection con;
        //protected SqlDataAdapter adapter;
        protected SqlCommand command;


        public static string ConnectionString
        {
            get
            {
                return _connectionString;
            }
            set
            {
                _connectionString = value;
            }
        }


        #region Get connectionstring from XML 
        public static void ConnectionStringFromXML()
        {
            XmlDocument xmlDoc = XML.XMLReader("Connection.xml");
            XmlElement xmlEle = xmlDoc.DocumentElement;

            try
            {
                if (xmlEle.SelectSingleNode("costatus").InnerText == "true")
                {
                    _connectionString = "Data Source=" + CryptorEngine.Decrypt(xmlEle.SelectSingleNode("servname").InnerText,true) + ";Initial Catalog=" + CryptorEngine.Decrypt(xmlEle.SelectSingleNode("database").InnerText,true) + ";Integrated Security=True;";
                }
                else
                {
                    _connectionString = "Data Source=" + CryptorEngine.Decrypt(xmlEle.SelectSingleNode("servname").InnerText,true) + ";Initial Catalog=" + CryptorEngine.Decrypt(xmlEle.SelectSingleNode("database").InnerText,true) + ";User Id=" + CryptorEngine.Decrypt(xmlEle.SelectSingleNode("username").InnerText,true) + ";Password=" + CryptorEngine.Decrypt(xmlEle.SelectSingleNode("password").InnerText,true) + ";";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public void connect()
        {
            try
            {
                if (_connectionString == "")
                    ConnectionStringFromXML();

                if (con == null)
                    con = new SqlConnection(_connectionString);
                con.Open();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
           
        }
        public void disconnect()
        {
            if (con != null)
                con.Close();
        }
        public IDataReader executeQuery(string sqlString)
        {
            command = new SqlCommand(sqlString, con);
            return command.ExecuteReader();
        }

        public void executeNonQuery(string sqlString)
        {
            command = new SqlCommand(sqlString, con);
            command.ExecuteNonQuery();
        }

        public object executeScalar(string sqlString)
        {
            command = new SqlCommand(sqlString, con);
            return command.ExecuteScalar();
        }

        protected ArrayList ConvertDataSetToArrayList(DataSet dataset)
        {
            ArrayList arr = new ArrayList();
            DataTable dt = dataset.Tables[0];
            int i, n = dt.Rows.Count;
            for (i = 0; i < n; i++)
            {
                object hs = GetDataFromDataRow(dt, i);
                arr.Add(hs);

            }
            return arr;
        }

        protected virtual object GetDataFromDataRow(DataTable dt, int i)
        {
            return null;
        }

        /// <summary>
        /// Run stored procedure.
        /// </summary>
        /// <param name="procName">Name of stored procedure.</param>
        /// <returns>Stored procedure return value.</returns>
        public int RunProc(string procName)
        {
            SqlCommand cmd = CreateCommand(procName, null);
            cmd.ExecuteNonQuery();
            this.Close();
            return (int)cmd.Parameters["ReturnValue"].Value;
        }

        /// <summary>
        /// Run stored procedure.
        /// </summary>
        /// <param name="procName">Name of stored procedure.</param>
        /// <param name="prams">Stored procedure params.</param>
        /// <returns>Stored procedure return value.</returns>
        public int RunProc(string procName, SqlParameter[] prams)
        {
            SqlCommand cmd = CreateCommand(procName, prams);
            cmd.ExecuteNonQuery();
            this.Close();
            return (int)cmd.Parameters["ReturnValue"].Value;
        }

        /// <summary>
        /// Run stored procedure.
        /// </summary>
        /// <param name="procName">Name of stored procedure.</param>
        /// <param name="dataReader">Return result of procedure.</param>
        public void RunProc(string procName, out SqlDataReader dataReader)
        {
            SqlCommand cmd = CreateCommand(procName, null);
            dataReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        }

        /// <summary>
        /// Run stored procedure.
        /// </summary>
        /// <param name="procName">Name of stored procedure.</param>
        /// <param name="prams">Stored procedure params.</param>
        /// <param name="dataReader">Return result of procedure.</param>
        public void RunProc(string procName, SqlParameter[] prams, out SqlDataReader dataReader)
        {
            SqlCommand cmd = CreateCommand(procName, prams);
            dataReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        }

        public int RunProcDS(string procName, SqlParameter[] prams, out DataSet dataSet)
        {
            SqlCommand cmd = CreateCommand(procName, prams);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            DataSet dst = new DataSet();
            dad.Fill(dst, "CurrentItems");
            dataSet = dst;
            this.Close();
            return (int)cmd.Parameters["ReturnValue"].Value;
        }

        public int RunProcDS(string procName, out DataSet dataSet)
        {
            SqlCommand cmd = CreateCommand(procName);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            DataSet dst = new DataSet();
            dad.Fill(dst, "CurrentItems");
            dataSet = dst;
            this.Close();
            return (int)cmd.Parameters["ReturnValue"].Value;
        }

        /// <summary>
        /// Create command object used to call stored procedure.
        /// </summary>
        /// <param name="procName">Name of stored procedure.</param>
        /// <param name="prams">Params to stored procedure.</param>
        /// <returns>Command object.</returns>
        private SqlCommand CreateCommand(string procName, SqlParameter[] prams)
        {
            // make sure connection is open
            Open();

            //command = new SqlCommand( sprocName, new SqlConnection( ConfigManager.DALConnectionString ) );
            SqlCommand cmd = new SqlCommand(procName, con);
            cmd.CommandType = CommandType.StoredProcedure;

            // add proc parameters
            if (prams != null)
            {
                foreach (SqlParameter parameter in prams)
                    cmd.Parameters.Add(parameter);
            }

            // return param
            cmd.Parameters.Add(
                new SqlParameter("ReturnValue", SqlDbType.Int, 4,
                ParameterDirection.ReturnValue, false, 0, 0,
                string.Empty, DataRowVersion.Default, null));

            return cmd;
        }
        private SqlCommand CreateCommand(string procName)
        {
            // make sure connection is open
            Open();

            //command = new SqlCommand( sprocName, new SqlConnection( ConfigManager.DALConnectionString ) );
            SqlCommand cmd = new SqlCommand(procName, con);
            cmd.CommandType = CommandType.StoredProcedure;

            // return param
            cmd.Parameters.Add(
                new SqlParameter("ReturnValue", SqlDbType.Int, 4,
                ParameterDirection.ReturnValue, false, 0, 0,
                string.Empty, DataRowVersion.Default, null));

            return cmd;
        }

        /// <summary>
        /// Open the connection.
        /// </summary>
        private void Open()
        {
            // open connection
            if (con == null)
            {
                con = new SqlConnection(_connectionString);

            }
            if (con.State == ConnectionState.Closed)
                con.Open();
        }

        /// <summary>
        /// Close the connection.
        /// </summary>
        public void Close()
        {
            if (con != null || con.State == ConnectionState.Open)
                con.Close();
        }

        /// <summary>
        /// Release resources.
        /// </summary>
        public void Dispose()
        {
            // make sure connection is closed
            if (con != null)
            {
                con.Dispose();
                con = null;
            }
        }

        /// <summary>
        /// Make input param.
        /// </summary>
        /// <param name="ParamName">Name of param.</param>
        /// <param name="DbType">Param type.</param>
        /// <param name="Size">Param size.</param>
        /// <param name="Value">Param value.</param>
        /// <returns>New parameter.</returns>
        public SqlParameter MakeInParam(string ParamName, SqlDbType DbType, int Size, object Value)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
        }

        /// <summary>
        /// Make input param.
        /// </summary>
        /// <param name="ParamName">Name of param.</param>
        /// <param name="DbType">Param type.</param>
        /// <param name="Size">Param size.</param>
        /// <returns>New parameter.</returns>
        public SqlParameter MakeOutParam(string ParamName, SqlDbType DbType, int Size)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Output, null);
        }

        /// <summary>
        /// Make stored procedure param.
        /// </summary>
        /// <param name="ParamName">Name of param.</param>
        /// <param name="DbType">Param type.</param>
        /// <param name="Size">Param size.</param>
        /// <param name="Direction">Parm direction.</param>
        /// <param name="Value">Param value.</param>
        /// <returns>New parameter.</returns>
        public SqlParameter MakeParam(string ParamName, SqlDbType DbType, Int32 Size, ParameterDirection Direction, object Value)
        {
            SqlParameter param;

            if (Size > 0)
                param = new SqlParameter(ParamName, DbType, Size);
            else
                param = new SqlParameter(ParamName, DbType);

            param.Direction = Direction;
            if (!(Direction == ParameterDirection.Output && Value == null))
                param.Value = Value;

            return param;
        }

        //public string GetErrorMessage(int errorCode)
        //{
        //    DataSet dst = (DataSet)System.Web.HttpContext.Current.Cache["Messages"];
        //    if (dst == null)
        //        CreateErrorMessages();

        //    dst = (DataSet)System.Web.HttpContext.Current.Cache["Messages"];
        //    string filterExpr = "ErrorCode = '" + errorCode.ToString() + "'";
        //    DataTable dtbl = dst.Tables["Messages"];
        //    DataRow[] drows = dtbl.Select(filterExpr);

        //    return drows[0]["ErrorMessage"].ToString();
        //}

        ///// <summary>
        ///// Create a dataset object contains all error 
        ///// messages and push it into application cache.
        ///// </summary>
        //private void CreateErrorMessages()
        //{
        //    DataSet dst = new DataSet();
        //    SqlConnection conn = new SqlConnection(_connectionString);
        //    SqlCommand cmd = new SqlCommand("spGetAllErrorMessage", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    SqlDataAdapter dad = new SqlDataAdapter(cmd);
        //    dad.Fill(dst, "Messages");

        //    //System.Web.HttpContext.Current.Cache.Insert("Messages", dst);
        //}
    }
}
