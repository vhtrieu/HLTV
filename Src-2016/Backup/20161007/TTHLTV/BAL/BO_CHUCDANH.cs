using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TTHLTV;
using TTHLTV.DAL;
using System.Data;

namespace TTHLTV.BAL
{
    class BO_CHUCDANH
    {
        DAL_CHUCDANH chucdanh_dal = new DAL_CHUCDANH();

        public void insert(string CHU_Code, string CHU_Name)
        {
            //DAL_CHUCDANH chucdanh_dal = new DAL_CHUCDANH();
            CHUCDANH chucdanh = new CHUCDANH();
            chucdanh.CHU_Code = CHU_Code;
            chucdanh.CHU_Name = CHU_Name;
            chucdanh.CHU_ID = 1;
            chucdanh_dal.insert(chucdanh);
        }

        public void update(int CHU_ID,string CHU_Code,string CHU_Name)
        {
            //DAL_CHUCDANH chucdanh_dal = new DAL_CHUCDANH();
            CHUCDANH chucdanh = new CHUCDANH();
            chucdanh.CHU_ID = CHU_ID;
            chucdanh.CHU_Code = CHU_Code;
            chucdanh.CHU_Name = CHU_Name;
            chucdanh_dal.update(chucdanh);
        }

        public void delete(int chucdanh_ID)
        {
            //DAL_CHUCDANH chucdanh_dal = new DAL_CHUCDANH();
            CHUCDANH chucdanh = new CHUCDANH();
            chucdanh.CHU_ID = chucdanh_ID;
            chucdanh_dal.delete(chucdanh);
        }

        public DataTable getAll()
        {
           
            return chucdanh_dal.getAll_CHUCDANH();
        }

        public DataTable getByID(int chucdanh_ID)
        {
            //DAL_CHUCDANH chucdanh_dal = new DAL_CHUCDANH();
            CHUCDANH chucdanh = new CHUCDANH();
            chucdanh.CHU_ID = chucdanh_ID;
            return chucdanh_dal.getByID_CHUCDANH(chucdanh);
        }

        public DataTable getChucDanh_LastCode()
        {
            //DAL_CHUCDANH dao = new DAL_CHUCDANH();
            return chucdanh_dal.getChucDanh_LastCode();
        }
    }
}
