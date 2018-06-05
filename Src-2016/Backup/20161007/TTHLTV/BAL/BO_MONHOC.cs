using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using TTHLTV;
using TTHLTV.DAL;
using TTHLTV.DTO;

namespace TTHLTV.BAL
{
    class BO_MONHOC
    {
        DAL_MONHOC dao;
        public DataTable getMonHoc_ByID(int mhID)
        {
            MONHOC mHoc = new MONHOC();
            mHoc.MON_ID = mhID;
            DAL_MONHOC dao = new  DAL_MONHOC();
            return dao.getByID_MONHOC(mHoc);

        }

        public DataTable getMonHoc_ByLopID(int mhID)
        {
             dao = new DAL_MONHOC();
            return dao.getMONHOC_By_LopID(mhID);

        }

        public DataTable getMonHoc_All()
        {
            dao = new DAL_MONHOC();
            return dao.getAll_MONHOC();

        }
        public DataTable getMonHoc_LastCode()
        {
            dao = new DAL_MONHOC();
            return dao.getAll_MONHOC_LastCode();

        }

        public void insert(string mhCode, string mhName, int mhSoTiet)
        {
            MONHOC mHoc = new MONHOC();
            mHoc.MON_Code = mhCode;
            mHoc.MON_Name = mhName;
            mHoc.MON_SoTiet = mhSoTiet;
            dao = new DAL_MONHOC();
            dao.insert(mHoc);
        }

        public void update(int mhID, string mhCode, string mhName, int mhSoTiet)
        {
            MONHOC mHoc = new MONHOC();
            mHoc.MON_ID = mhID;
            mHoc.MON_Code = mhCode;
            mHoc.MON_Name = mhName;
            mHoc.MON_SoTiet = mhSoTiet;

            DAL_MONHOC dao = new DAL_MONHOC();
            dao.update(mHoc);
        }

        public void delete(int mhID)
        {
            MONHOC mHoc = new MONHOC();
            mHoc.MON_ID = mhID;

            DAL_MONHOC dao = new DAL_MONHOC();
            dao.delete(mHoc);
        }

        public DataTable SelectMONHOC_Name_By_CHCID(int sChcID)
        {
            DAL_MONHOC dao = new DAL_MONHOC();
            return dao.SelectMONHOC_Name_By_CHCID(sChcID);

        }
        public DataTable getSubjectName(CHUNG_CHI vDto)
        {
            dao = new DAL_MONHOC();
            return dao.getSubjectName(vDto);
        }

    }
}
