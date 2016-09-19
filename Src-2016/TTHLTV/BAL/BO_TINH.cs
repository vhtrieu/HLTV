using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using TTHLTV;
//using Entetities;
using TTHLTV.DAL;

//Hoàn chỉnh
namespace TTHLTV.BAL
{
    public class BO_TINH
    {
        DAL_TINH dao = new DAL_TINH();
        public DataTable getTinh_ByID(int tID)
        {
            TINH tinh = new TINH();
            tinh.TIN_ID = tID;
            //DAL_TINH dao = new DAL_TINH();

            return dao.getByID_TINH(tinh);
        }

        public DataTable getTinh_All()
        {
            TINH tinh = new TINH();
            
           // DAL_TINH dao = new DAL_TINH();

            return dao.getAll_TINH();
        }

        public void insert(string tCode, string tName)
        {
            TINH tinh = new TINH();
            tinh.TIN_Code  = tCode;
            tinh.TIN_Name =tName;

            //DAL_TINH dao = new DAL_TINH();
            dao.insert(tinh);
        }

          public void update(int tID, string tCode, string tName)
        {
            TINH tinh = new TINH();
            tinh.TIN_ID = tID;
            tinh.TIN_Code  = tCode;
            tinh.TIN_Name =tName;

          //  DAL_TINH dao = new DAL_TINH();
            dao.update(tinh);
        }

          public void delete(int tID)
          {
              TINH tinh = new TINH();
              tinh.TIN_ID = tID;

            
              dao.delete(tinh);
          }

          public DataTable getTinh_LastCode()
          {
              return dao.getTinh_LastCode();
          }
    }
}
