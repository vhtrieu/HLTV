using System.Collections.Generic; 
using System.Text; 
using System; 


namespace TTHLTV.DTO {
    
    public class CAP_CHUNGCHI {
        public CAP_CHUNGCHI() { }
        public virtual int CCC_ID { get; set; }
        public virtual string CCC_Code { get; set; }
        public virtual System.Nullable<int> CCC_HOVID { get; set; }
        public virtual System.Nullable<int> CCC_LOPID { get; set; }
        public virtual string CCC_SoCC { get; set; }
        public virtual System.Nullable<System.DateTime> CCC_NgayCap { get; set; }
        public virtual System.Nullable<System.DateTime> CCC_NgayHetHan { get; set; }
        public virtual System.Nullable<System.DateTime> CCC_NgayCapLai { get; set; }
        public virtual System.Nullable<int> CCC_CHCID { get; set; }
        public virtual System.Nullable<int> CCC_Status { get; set; }
        public virtual string CCC_SoHieuDoi { get; set; }
        public virtual int CCC_DOIID { get; set; }

       // public virtual System.Nullable<int> CCC_StatusCapLai { get; set; }

    }
}
