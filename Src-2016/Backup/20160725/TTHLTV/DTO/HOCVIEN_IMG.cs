using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TTHLTV.DTO
{
   public class HOCVIEN_IMG
    {
       public HOCVIEN_IMG() { }
        public virtual int IMG_ID { get; set; }
        public virtual int IMG_HOVID { get; set; }
        public virtual string IMG_Name { get; set; }
        public virtual byte[] IMG_Image { get; set; }
    }
}
