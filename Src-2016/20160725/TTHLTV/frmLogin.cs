using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TTHLTV.BAL;
using TTHLTV.Utilities;
using System.Threading;
namespace TTHLTV
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        BO_NGUOIDUNG boNgDung = new BO_NGUOIDUNG();

        public frmLogin()
        {
            InitializeComponent();
        }
        #region Events
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtLoginName.Focus();
            sGeneralCodeUsers();
            txtPassWord.Properties.PasswordChar = '*';
            //txtLoginName.Text = "tt";
            //txtPassWord.Text = "tt2";
        }
        private void btnLongIn_Click(object sender, EventArgs e)
        {
                if (sLogIn())
                {
                    frmMain f = new frmMain();
                    this.Hide();
                    //MessageBox.Show("Đăng nhập thành công", "THÔNG BÁO");
                    f.Show();
                }
                else
                {
                    MessageBox.Show("Đăng nhập không thành công", "THÔNG BÁO");
                }

        }
        private void loadMainForm()
        {
            Application.Run(new frmMain());
        }
        private Boolean sLogIn()
        {
            DataTable tb = new DataTable();
            if (txtLoginName.Text == string.Empty || txtPassWord.Text == string.Empty)
            {
                MessageBox.Show("Tên đăng nhập và mật khẩu không được để trống", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                tb = boNgDung.getNguoiDung_ByUserName(txtLoginName.Text);
                if (tb.Rows.Count > 0)
                {
                    if (txtPassWord.Text == tb.Rows[0]["NGU_Password"].ToString())
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu đăng nhập không đúng", "THÔNG BÁO");
                        txtPassWord.Focus();
                        return false;
                    }
                }
                else
                    if (tb.Rows.Count < 0)
                    {
                        MessageBox.Show("Tên đăng nhập không đúng", "THÔNG BÁO");
                        txtLoginName.Focus();
                        return false;
                    }
                    else

                        return true;
 
            }
            

        }
        #endregion


        #region Register tab
        private void exitNew_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            string messages = " Bạn chắc chắn muốn thêm người quản lý này ";
            string caption = " THÔNG BÁO ";
            MessageBoxButtons button = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(messages, caption, button);
            if (result == DialogResult.Yes)
            {
                insetNew();
                MessageBox.Show("Thêm thành công ", "THÔNG BÁO");
            }

            clearText();
        }
        private void insetNew()
        {
            string sCode = string.Empty;
            string fullName = string.Empty;
            string sUserName = string.Empty;
            string sPassWord = string.Empty;

            sCode = txtCode.Text;
            fullName = txtFullName.Text;
            sUserName = txtUserNew.Text;
            sPassWord = txtPassNew.Text;
            boNgDung.insert(sCode, fullName, sUserName, sPassWord);

        }
        private void clearText()
        {
            txtCode.Text = string.Empty;
            txtFullName.Text = string.Empty;
            txtUserNew.Text = string.Empty;
            txtPassNew.Text = string.Empty;
        }
        private void sGeneralCodeUsers()
        {
            DataTable tb = new DataTable();
            tb = boNgDung.getLastCodeUser();
            string lCode = String.Empty;
            if (tb.Rows.Count == 0)
            {
                lCode = "000000000";
            }
            else
                if (tb.Rows.Count > 0)
                {
                    lCode = tb.Rows[0]["NGU_Code"].ToString();
                }
            lCode = lCode.Substring(3, 5).ToString();
            txtCode.Text = ("USE" + quydinh.LaySTT(int.Parse(lCode.ToString()) + 1)).ToString();

        }

        #endregion



    }
}