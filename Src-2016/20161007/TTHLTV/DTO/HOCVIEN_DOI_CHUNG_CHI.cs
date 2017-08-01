using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TTHLTV.DTO
{
    class HOCVIEN_DOI_CHUNG_CHI
    {
        public HOCVIEN_DOI_CHUNG_CHI() { }
        public virtual int HVD_ID { get; set; }
        public virtual string HVD_Code { get; set; }
        public virtual int HVD_HOVID { get; set; }
        public virtual int HVD_LOPID { get; set; }
        public virtual int HVD_CHCID { get; set; }
        public virtual string HVD_SoCcCu { get; set; }
        public virtual string HVD_SoCcMoi { get; set; }
        public virtual DateTime? HVD_NgayCap { get; set; }
    }
}
