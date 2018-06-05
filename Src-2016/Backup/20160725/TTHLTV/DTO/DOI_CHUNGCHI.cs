using System.Collections.Generic; 
using System.Text; 
using System; 


namespace TTHLTV.DAL {
    
    public class DOI_CHUNGCHI {
        public DOI_CHUNGCHI() { }
        public virtual int DOI_ID { get; set; }
        public virtual string DOI_Code { get; set; }
        public virtual int DOI_HOVID { get; set; }
        public virtual int DOI_CHCID { get; set; }
        public virtual string DOI_SoCC { get; set; }
        public virtual System.DateTime? DOI_NgayCap { get; set; }
        public virtual System.DateTime? DOI_Ngay_KG { get; set; }
        public virtual System.DateTime? DOI_Ngay_KT { get; set; }
        public virtual System.DateTime? DOI_Ngay_QD { get; set; }
    }
}
