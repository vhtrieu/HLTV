using System;
using System.Text;
using System.Data;
using System.Xml;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using DevExpress.XtraEditors;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using TTHLTV.BAL;

using System.Collections.Generic;
using System.IO;

namespace TTHLTV.Utilities
{
    public static class Utilities
    {
        public static String DatabaseName;
    }
    #region Các hàm xử lý tập tin XML
    public class XML
    {
        public static XmlDocument XMLReader(String filename)
        {
            XmlDocument xmlR = new XmlDocument();
            try
            {
                xmlR.Load(filename);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return xmlR;
        }

        public static void XMLWriter(String filename, String servname, String database, String costatus)
        {
            XmlTextWriter xmlW = new XmlTextWriter(filename, null);
            xmlW.Formatting = Formatting.Indented;

            xmlW.WriteStartDocument();
            xmlW.WriteComment("\nKhong duoc thay doi noi dung file nay!\n" +
                                "Thong so co ban:\n\t" +
                                "costatus = true : quyen Windows\n\t" +
                                "costatus = false: quyen SQL Server\n\t" +
                                "servname: ten server\n\t" +
                                "username: ten dang nhap he thong\n\t" +
                                "password: mat khau dang nhap he thong\n\t" +
                                "database: ten co so du lieu\n");
            xmlW.WriteStartElement("config");

            xmlW.WriteStartElement("costatus");
            xmlW.WriteString(costatus);
            xmlW.WriteEndElement();

            xmlW.WriteStartElement("servname");
            xmlW.WriteString(servname);
            xmlW.WriteEndElement();

            xmlW.WriteStartElement("username");
            xmlW.WriteString("");
            xmlW.WriteEndElement();

            xmlW.WriteStartElement("password");
            xmlW.WriteString("");
            xmlW.WriteEndElement();

            xmlW.WriteStartElement("database");
            xmlW.WriteString(database);
            xmlW.WriteEndElement();

            xmlW.WriteEndElement();
            xmlW.WriteEndDocument();

            xmlW.Close();
        }

        public static void XMLWriter(String filename, String servname, String username, String password, String database, String costatus)
        {
            XmlTextWriter xmlW = new XmlTextWriter(filename, null);
            xmlW.Formatting = Formatting.Indented;

            xmlW.WriteStartDocument();
            xmlW.WriteComment("\nKhong duoc thay doi noi dung file nay!\n" +
                                "Thong so co ban:\n\t" +
                                "costatus = true : quyen Windows\n\t" +
                                "costatus = false: quyen SQL Server\n\t" +
                                "servname: ten server\n\t" +
                                "username: ten dang nhap he thong\n\t" +
                                "password: mat khau dang nhap he thong\n\t" +
                                "database: ten co so du lieu\n");
            xmlW.WriteStartElement("config");

            xmlW.WriteStartElement("costatus");
            xmlW.WriteString(costatus);
            xmlW.WriteEndElement();

            xmlW.WriteStartElement("servname");
            xmlW.WriteString(servname);
            xmlW.WriteEndElement();

            xmlW.WriteStartElement("username");
            xmlW.WriteString(username);
            xmlW.WriteEndElement();

            xmlW.WriteStartElement("password");
            xmlW.WriteString(password);
            xmlW.WriteEndElement();

            xmlW.WriteStartElement("database");
            xmlW.WriteString(database);
            xmlW.WriteEndElement();

            xmlW.WriteEndElement();
            xmlW.WriteEndDocument();

            xmlW.Close();
        }
    }
    #endregion

    #region ThamSo
    public static class ThamSo
    {
        #region Fields
        public static frmMain m_FrmMain = null;
        public static frmStudent m_frmStudent = null;
        //public static frmTeacher m_frmTeacher = null;
       
        public static frmClassList m_frmClassList = null;
        public static frmCouresList m_frmCouresList = null;
        public static frmSubject m_frmSubject = null;
        public static frmExamResult m_frmExamResult = null;
       // public static frmLichGiang m_frmTeachingCalendar = null;
        public static frmDetailStudentOLD m_frmStudentDetail = null;
       // public static frmCertification  m_frmCerificationList = null;

        public static frmAddNewClass m_frmAddNewClass = null;
        public static frmWebDangKi m_frmWebDangKiHoc = null;

        #endregion

        #region Ham goi hien form

        #region Call form list


        public static void ShowFormCertification()
        {
            //if (m_frmCerificationList == null || m_frmCerificationList.IsDisposed)
            //{
            //    m_frmCerificationList = new frmCertification();
            //    m_frmCerificationList.MdiParent = frmMain.ActiveForm;
            //    m_frmCerificationList.Show();
            //}
            //else
            //    m_frmCerificationList.Activate();
        }

        public static void ShowFormStudent()
        {
            if (m_frmStudent == null || m_frmStudent.IsDisposed)
            {
                m_frmStudent = new frmStudent();
                m_frmStudent.MdiParent = frmMain.ActiveForm;
                m_frmStudent.Show();
            }
            else
                m_frmStudent.Activate();
        }

        public static void ShowFormTeacher()
        {
            //if (m_frmTeacher == null || m_frmTeacher.IsDisposed)
            //{
            //    m_frmTeacher = new frmTeacher();
            //    m_frmTeacher.MdiParent = frmMain.ActiveForm;
            //    m_frmTeacher.Show();
            //}
            //else
            //    m_frmTeacher.Activate();
        }
       
        public static void ShowFormClassList()
        {
            if (m_frmClassList == null || m_frmClassList.IsDisposed)
            {
                m_frmClassList = new frmClassList();
                m_frmClassList.MdiParent = frmMain.ActiveForm;
                m_frmClassList.Show();
            }
            else
                m_frmClassList.Activate();
        }

        public static void ShowFormSubjects()
        {
            if (m_frmSubject == null || m_frmSubject.IsDisposed)
            {
                m_frmSubject = new frmSubject();
                m_frmSubject.MdiParent = frmMain.ActiveForm;
                m_frmSubject.Show();
            }
            else
                m_frmSubject.Activate();
        }

        public static void ShowFormCoures()
        {
            if (m_frmCouresList == null || m_frmCouresList.IsDisposed)
            {
                m_frmCouresList = new frmCouresList();
                m_frmCouresList.MdiParent = frmMain.ActiveForm;
                m_frmCouresList.Show();
            }
            else
                m_frmCouresList.Activate();
        }

        public static void ShowFormExamResult()
        {
            if (m_frmExamResult == null || m_frmExamResult.IsDisposed)
            {
                m_frmExamResult = new frmExamResult();
                m_frmExamResult.MdiParent = frmMain.ActiveForm;
                m_frmExamResult.Show();
            }
            else
                m_frmExamResult.Activate();
        }

        public static void ShowFormTeachingCalendar()
        {
            //if (m_frmTeachingCalendar == null || m_frmTeachingCalendar.IsDisposed)
            //{
            //    m_frmTeachingCalendar = new frmLichGiang();
            //    m_frmTeachingCalendar.MdiParent = frmMain.ActiveForm;
            //    m_frmTeachingCalendar.Show();
            //}
            //else
            //    m_frmTeachingCalendar.Activate();
        }

        public static void showFormAddNewClass()
        {
            if (m_frmAddNewClass == null || m_frmAddNewClass.IsDisposed)
            {
                m_frmAddNewClass = new frmAddNewClass();
                //m_frmAddNewClass.MdiParent = frmMain.ActiveForm;
                m_frmAddNewClass.Show();

            }
            else
                m_frmAddNewClass.Activate();
        }
        public static void showFormWebDangKiHoc()
        {
            if (m_frmWebDangKiHoc == null || m_frmWebDangKiHoc.IsDisposed)
            {
                m_frmWebDangKiHoc = new frmWebDangKi();
                m_frmWebDangKiHoc.MdiParent = frmMain.ActiveForm;
                m_frmWebDangKiHoc.Show();
            }
            else
                m_frmWebDangKiHoc.Activate();
        }
        #endregion
        #region Call details form
        public static void ShowFormStudentDetail(DataRow row)
        {
            if (m_frmStudentDetail == null || m_frmStudentDetail.IsDisposed)
            {
                m_frmStudentDetail = new frmDetailStudentOLD(row);
                //m_frmStudentDetail.MdiParent = frmMain.ActiveForm;
                m_frmStudentDetail.Show();
            }
            else
                m_frmStudentDetail.Activate();
        }

             /// <summary>
        /// Call coures list
        /// </summary>
        /// <param name="row"></param>
        //public static void ShowFormNewCerificationList(DataRow row)
        //{
        //    if (m_frmCerificationList == null || m_frmCerificationList.IsDisposed)
        //    {
        //        m_frmCerificationList = new frmCertificationList(row);
        //        m_frmStudentDetail.Show();
        //    }
        //    else
        //        m_frmCerificationList.Activate();
        //}
            #endregion
        }
        #endregion  
    
    #endregion

    #region Quy định
    public class quydinh
    {
        public static String LaySTT(int autoNum)
        {
            if (autoNum < 10)
                return "0000" + autoNum;

            else if (autoNum >= 10 && autoNum < 100)
                return "000" + autoNum;

            else if (autoNum >= 100 && autoNum < 1000)
                return "00" + autoNum;

            else if (autoNum >= 1000 && autoNum < 10000)
                return "0" + autoNum;

            else if (autoNum >= 10000 && autoNum < 100000)
                return "" + autoNum;

            //else if (autoNum >= 100000 && autoNum < 1000000)
            //    return "" + autoNum;

            else
                return "";
        }
    }
    #endregion

    #region Tool
    public class Tool
    {
        static object syncObj = new object();
        static string pathLog = @"C:\Log\";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mess">thông tin cần log lại</param>
        /// <param name="name">Tên file log</param>
        /// <param name="functionName">Tên function cần log</param>
        public static void Logger(String mess, String name, String functionName)
        {
            lock (syncObj)
            {
                try
                {
                    Directory.CreateDirectory(pathLog + DateTime.Now.ToString("yyyy-MM-dd"));
                    StreamWriter sw = new StreamWriter(pathLog + DateTime.Now.ToString("yyyy-MM-dd") + "\\" + DateTime.Now.ToString("MM-dd-HH") + name + ".txt", true);

                    sw.WriteLine(DateTime.Now.ToString("hh-mm-ss") + " : [" + functionName + "] :: " + mess);

                    sw.Flush();
                    sw.Close();
                }
                catch
                {

                }
            }
        }
        /// <summary>
        /// kiểm tra chuỗi nhập vào có phải số hay không
        /// </summary>
        /// <param name="strText"></param>
        /// <returns></returns>
        public static bool isNumber(string strText)
        {
            string pattern = "0123456789";
            for (int i = 0; i < strText.Length; i++)
            {
                if (pattern.IndexOf(strText[i]) < 0)
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// tách lấy số từ 1 chuỗi nhập vào
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
        public static string getNumber(string strInput)
        {

            string strOutput = string.Empty;
            string pattern = "0123456789";
            for (int i = 0; i < strInput.Length; i++)
            {
                if (pattern.IndexOf(strInput[i]) >= 0)
                {
                    strOutput += strInput[i] + "";
                }
            }
            return strOutput;
        }
        public static DateTime ConvertToDate(string Date, string Format)
        {
            DateTime date = DateTime.MinValue;
            try
            {
                string[] s = Date.Split(new char[] { '/', '-' });
                int d = date.Day;
                int m = date.Month;
                int y = date.Year;
                //for (int i = 0; i < s.Length; i++)
                //{
                if (Format == "dd/MM/yyyy" || Format == "dd-MM-yyyy")
                {
                    if (s.Length == 2)
                    {
                        int.TryParse(s[0], out m);
                        int.TryParse(s[1], out y);
                    }
                    else if (s.Length == 3)
                    {
                        int.TryParse(s[0], out m);
                        int.TryParse(s[1], out d);
                        int.TryParse(s[2], out y);
                    }
                    else if (s.Length == 1)
                    {
                        int.TryParse(s[0], out y);
                    }
                }
                else if (Format == "MM/dd/yyyy" || Format == "MM-dd-yyyy")
                {
                    if (s.Length == 2)
                    {
                        int.TryParse(s[0], out m);
                        int.TryParse(s[1], out y);
                    }
                    else if (s.Length == 3)
                    {
                        int.TryParse(s[0], out m);
                        int.TryParse(s[1], out d);
                        int.TryParse(s[2], out y);
                    }
                    else if (s.Length == 1)
                    {
                        int.TryParse(s[0], out y);
                    }
                }


                //}

                date = DateTime.Parse(new DateTime(d, m, y).ToShortDateString());
            }
            catch { }
            return date;
        }
    }
    #endregion
#region Set font size on Grid
    public class setFontSize
    {
        public static void SetGridFont(DevExpress.XtraGrid.Views.Base.BaseView baseView, Font sFont)
        {
            foreach (AppearanceObject ap in baseView.Appearance)
            {
                ap.Font = sFont;
            }

        }

    }
#endregion
}