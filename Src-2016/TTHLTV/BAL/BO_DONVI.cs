using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using TTHLTV;
using TTHLTV.DAL;

namespace TTHLTV.BAL
{
    class BO_DONVI
    {
        public void insert(string DON_Code,
	                    string DON_Name,
	                    string DON_DiaChi,
	                    string DON_Phone ,
	                    string DON_Fax,
	                    string DON_GhiChu)
        {
            DAL_DONVI donvi_dal = new DAL_DONVI();
            DONVI donvi = new DONVI();
            donvi.DON_Code = DON_Code;
            donvi.DON_Name = DON_Name;
            donvi.DON_DiaChi = DON_DiaChi;
            donvi.DON_Phone = DON_Phone;
            donvi.DON_Fax = DON_Fax;
            donvi.DON_GhiChu = DON_GhiChu;
            donvi.DON_ID = 1;
            donvi_dal.insert(donvi);
        }

        public void update(int DON_ID,
                        string DON_Code,
                        string DON_Name,
                        string DON_DiaChi,
                        string DON_Phone,
                        string DON_Fax,
                        string DON_GhiChu
            )
        {
            DAL_DONVI donvi_dal = new DAL_DONVI();
            DONVI donvi = new DONVI();
            donvi.DON_ID = DON_ID;
            donvi.DON_Code = DON_Code;
            donvi.DON_Name = DON_Name;
            donvi.DON_DiaChi = DON_DiaChi;
            donvi.DON_Phone = DON_Phone;
            donvi.DON_Fax = DON_Fax;
            donvi.DON_GhiChu = DON_GhiChu;
            donvi_dal.update(donvi);
        }

        public void delete(int donvi_ID)
        {
            DAL_DONVI donvi_dal = new DAL_DONVI();
            DONVI donvi = new DONVI();
            donvi.DON_ID = donvi_ID;
            donvi_dal.delete(donvi);
        }

        public DataTable getAll()
        {
            DAL_DONVI donvi_dal = new DAL_DONVI();
            return donvi_dal.getAll_DONVI();
        }

        public DataTable getByID(int donvi_ID)
        {
            DAL_DONVI donvi_dal = new DAL_DONVI();
            DONVI donvi = new DONVI();
            donvi.DON_ID = donvi_ID;
            return donvi_dal.getByID_DONVI(donvi);
        }

        public DataTable getDonVi_LastCode()
        {
            DAL_DONVI dao = new DAL_DONVI();
            return dao.getDonVi_LastCode();
        }
    }
}
