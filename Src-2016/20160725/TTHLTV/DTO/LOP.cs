using System.Collections.Generic; 
using System.Text; 
using System; 


namespace TTHLTV.DTO {
    
    public class LOP {
        public LOP() { }
        public virtual int LOP_ID { get; set; }
        public virtual string LOP_Code { get; set; }
        public virtual string LOP_Name { get; set; }
        public virtual string LOP_Khoa { get; set; }
        public virtual string LOP_ShortName { get; set; }
        public virtual System.Nullable<System.DateTime> LOP_Ngay_KG { get; set; }
        public virtual System.Nullable<System.DateTime> LOP_Ngay_KT { get; set; }
        public virtual System.Nullable<System.DateTime> LOP_Ngay_QD { get; set; }
        public virtual int LOP_CHCID { get; set; }
    }
}
