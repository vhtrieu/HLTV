using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TTHLTV.DTO;
using TTHLTV.DAL;

namespace TTHLTV.BAL
{
   public class BO_WEB_DANGKIHOC
    {
       DataTable vtb;
       DAL_WEB_DANGKIHOC dal;
       public DataTable vLoadData(WEB_DANGKIHOC vDto)
       {
           vtb = new DataTable();
           dal = new DAL_WEB_DANGKIHOC();
           return vtb = dal.vLoadData(vDto);
       }
       public DataTable vLoadTotalHocVienDangKi(WEB_DANGKIHOC vDto)
       {
           vtb = new DataTable();
           dal = new DAL_WEB_DANGKIHOC();
           return vtb = dal.vLoadTotalHocVienDangKi(vDto);
       }
       public DataTable vLoadListHocVienByChungChiID(WEB_DANGKIHOC vDto)
       {
           vtb = new DataTable();
           dal = new DAL_WEB_DANGKIHOC();
           return vtb = dal.vLoadListHocVienByChungChiID(vDto);
       }
       public void updateStatus(WEB_DANGKIHOC vDto)
       {
           dal = new DAL_WEB_DANGKIHOC();
           dal.updateStatus(vDto);
       }
    }
}
