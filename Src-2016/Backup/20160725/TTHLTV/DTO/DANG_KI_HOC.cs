using System.Collections.Generic; 
using System.Text; 
using System; 


namespace TTHLTV.DTO {
    
    public class DANG_KI_HOC {
        public DANG_KI_HOC() { }
        public virtual int DKH_ID { get; set; }
        public virtual string DKH_Code { get; set; }
        public virtual int DKH_HOVID { get; set; }
        public virtual int DKH_LOPID { get; set; }
        public virtual int? DKH_Diem { get; set; }
        public virtual int? DKH_LanThi { get; set; }
        public virtual string  DKH_BienLai { get; set; }
        public virtual string DKH_LastName { get; set; }

    }
}
