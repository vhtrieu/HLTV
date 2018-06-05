

namespace TTHLTV.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    public class backupDB
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        string srvName = string.Empty;
        string dbName = string.Empty;
        string saveTo = string.Empty;
        public void serverName(string str)
        {
            con = new SqlConnection("Data Source=" + str + ";Database=Master;data source=.; uid=sa; pwd=12345;");
            con.Open();
            cmd = new SqlCommand("select *  from sysservers  where srvproduct='SQL Server'", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                srvName = dr[2].ToString();
            }
            dr.Close();
        }
        public void Createconnection()
        {
            con = new SqlConnection("Data Source=" + srvName + ";Database=QLHK;data source=.; uid=sa; pwd=12345;");
            con.Open();
            //ComboBoxDatabaseName.Items.Clear();
            cmd = new SqlCommand("select * from sysdatabases where name = 'QLHK'", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                dbName = dr[0].ToString();
            }
            dr.Close();
        }
        public void blank(string str)
        {
            serverName(".");
            Createconnection();
            if (string.IsNullOrEmpty(srvName) | string.IsNullOrEmpty(dbName))
            {

                // label3.Visible = true;
                //MessageBox.Show("Server Name & Database can not be Blank");
                return;

            }
            else
            {
                if (str == "backup")
                {
                    //SaveFileDialog1.FileName = ComboBoxDatabaseName.Text;
                    //SaveFileDialog1.ShowDialog();
                    //string s = null;
                    //s = SaveFileDialog1.FileName;
                    saveTo = "D:\\";
                    query("Backup database " + dbName + " to disk='" + saveTo + "'");
                    //label3.Visible = true;
                    // label3.Text = "Database BackUp has been created successful";
                    DAL.DAL_NGUOIDUNG dal = new DAL.DAL_NGUOIDUNG();
                    dal.backupDatabase(dbName, saveTo);
                }
            }
        }
        public void query(string que)
        {
            // ERROR: Not supported in C#: OnErrorStatement

            cmd = new SqlCommand(que, con);
            cmd.ExecuteNonQuery();
        }
    }
}
