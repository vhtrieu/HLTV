using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TTHLTV.DAL;
using TTHLTV.DTO;
namespace TTHLTV.BAL
{
   public class BO_HOCVIEN_IMG
    {
       DAL_HOCVIEN_IMG Dal;
       public int insert(HOCVIEN_IMG vDto)
       {
           Dal = new DAL_HOCVIEN_IMG();
          return Dal.insert(vDto);
       }
       public void update(HOCVIEN_IMG vDto)
       {
           Dal = new DAL_HOCVIEN_IMG();
           Dal.update(vDto);
       }
    }
}
