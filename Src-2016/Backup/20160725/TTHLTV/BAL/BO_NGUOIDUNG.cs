using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using TTHLTV;
using TTHLTV.DAL;

//Hoàn chỉnh
namespace TTHLTV.BAL
{
    public class BO_NGUOIDUNG
    {
        public void insert(string NGU_Code,
                        string NGU_Name,
                        string NGU_UserName,
                        string NGU_Password)
        {
            DAL_NGUOIDUNG nguoidung_dal = new DAL_NGUOIDUNG();
            NGUOIDUNG nguoidung = new NGUOIDUNG();
            nguoidung.NGU_ID = 1;
            nguoidung.NGU_Code = NGU_Code;
            nguoidung.NGU_Name = NGU_Name;
            nguoidung.NGU_UserName = NGU_UserName;
            nguoidung.NGU_Password = NGU_Password;
            nguoidung_dal.insert(nguoidung);
        }

        public void update(int NGU_ID,
	        string NGU_Code,
	        string NGU_Name,
	        string NGU_UserName,
	        string NGU_Password
            )
        {
            DAL_NGUOIDUNG nguoidung_dal = new DAL_NGUOIDUNG();
            NGUOIDUNG nguoidung = new NGUOIDUNG();
            nguoidung.NGU_ID = NGU_ID;
            nguoidung.NGU_Code = NGU_Code;
            nguoidung.NGU_Name = NGU_Name;
            nguoidung.NGU_UserName = NGU_UserName;
            nguoidung.NGU_Password = NGU_Password;
            nguoidung_dal.update(nguoidung);
        }

        public void delete(int nguoidung_ID)
        {
            DAL_NGUOIDUNG nguoidung_dal = new DAL_NGUOIDUNG();
            NGUOIDUNG nguoidung = new NGUOIDUNG();
            nguoidung.NGU_ID = nguoidung_ID;
            nguoidung_dal.delete(nguoidung);
        }

        public DataTable getAll()
        {
            DAL_NGUOIDUNG nguoidung_dal = new DAL_NGUOIDUNG();
            return nguoidung_dal.getAll_NGUOIDUNG();
        }

        public DataTable getByID(int nguoidung_ID)
        {
            DAL_NGUOIDUNG nguoidung_dal = new DAL_NGUOIDUNG();
            NGUOIDUNG nguoidung = new NGUOIDUNG();
            nguoidung.NGU_ID = nguoidung_ID;
            return nguoidung_dal.getByID_NGUOIDUNG(nguoidung);
        }
        public DataTable getNguoiDung_ByUserName(string userName)
        {
            DAL_NGUOIDUNG nguoidung_dal = new DAL_NGUOIDUNG();
            NGUOIDUNG nguoidung = new NGUOIDUNG();
            nguoidung.NGU_UserName = userName;
            return nguoidung_dal.getNguoiDung_byUserName(nguoidung);
        }
        public DataTable getLastCodeUser()
        {
            NGUOIDUNG sNgDung = new NGUOIDUNG();

            DAL_NGUOIDUNG dao = new DAL_NGUOIDUNG();
            return dao.getLastCode_NguoiDung();
        }

    }
}
