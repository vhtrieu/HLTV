using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using TTHLTV;
//using Entetities;
using TTHLTV.DAL;

namespace TTHLTV.BAL
{
    class BO_GIANGVIEN
    {
        public DataTable getGianngVien_ByID(int gVId)
        {
            GIANGVIEN gVien = new GIANGVIEN();

            gVien.GIV_ID = gVId;
            DAL_GIANGVIEN dao = new DAL_GIANGVIEN();
          return  dao.getDsTeacher_ByID(gVien);
 
        }

        public DataTable getGianngVien_ByName(string gVName)
        {
            GIANGVIEN gVien = new GIANGVIEN();

            gVien.GIV_Name = gVName;
            DAL_GIANGVIEN dao = new DAL_GIANGVIEN();
            return dao.getDsTeacher_ByID(gVien);

        }

        public DataTable getGianngVien_All()
        {
            GIANGVIEN gVien = new GIANGVIEN();

            DAL_GIANGVIEN dao = new DAL_GIANGVIEN();
            return dao.getTeacher_All();

        }

        public DataTable getGianngVien_LastCode()
        {
            GIANGVIEN gVien = new GIANGVIEN();

            DAL_GIANGVIEN dao = new DAL_GIANGVIEN();
            return dao.getGingVien_LastCode();

        }

        public void insert(string gVCode, string gVName, string gVPhone, string gVAddress, string gVKhoa)
        {
            GIANGVIEN gVien = new GIANGVIEN();
            gVien.GIV_Code = gVCode;
            gVien.GIV_Name = gVName;
            gVien.GIV_Phone = gVPhone;
            gVien.GIV_Address = gVAddress;
            gVien.GIV_Khoa = gVKhoa;

            DAL_GIANGVIEN dao = new DAL_GIANGVIEN();
            dao.insert(gVien);
        }

        public void update(int gVID, string gVCode, string gVName, string gVPhone, string gVAddress, string gVKhoa)
        {
            GIANGVIEN gVien = new GIANGVIEN();
            gVien.GIV_ID = gVID;
            gVien.GIV_Code = gVCode;
            gVien.GIV_Name = gVName;
            gVien.GIV_Phone = gVPhone;
            gVien.GIV_Address = gVAddress;
            gVien.GIV_Khoa = gVKhoa;

            DAL_GIANGVIEN dao = new DAL_GIANGVIEN();
            dao.update(gVien);
        }

        public void delete(int gVID)
        {
            GIANGVIEN gVien = new GIANGVIEN();
            gVien.GIV_ID = gVID;

            DAL_GIANGVIEN dao = new DAL_GIANGVIEN();
            dao.delete(gVien);
        }
    }

}
