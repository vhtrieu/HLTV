using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TTHLTV.DTO
{
    public class DIEM
    {
        public DIEM() { }
        public virtual int DIE_ID { get; set; }
        public virtual int DIE_CHCID { get; set; }
        public virtual int DIE_MONID { get; set; }
        public virtual int DIE_LOPID { get; set; }
        public virtual int DIE_HOVID { get; set; }
        public virtual int? DIE_Diem  { get; set; }
        public virtual int? DIE_LanThi { get; set; }
        public virtual DateTime? DIE_NgayNhapDiem { get; set; }
        public virtual string DIE_MONName { get; set; }
        public virtual string DIE_CCCSoCC { get; set; }
        public virtual DateTime? DIE_CCCNgayCap { get; set; }


       
    }
}
