using System.Collections.Generic; 
using System.Text; 
using System; 


namespace TTHLTV.DAL {
    
    public class DONVI {
        public DONVI() { }
        public virtual int DON_ID { get; set; }
        public virtual string DON_Code { get; set; }
        public virtual string DON_Name { get; set; }
        public virtual string DON_DiaChi { get; set; }
        public virtual string DON_Phone { get; set; }
        public virtual string DON_Fax { get; set; }
        public virtual string DON_GhiChu { get; set; }
    }
}
