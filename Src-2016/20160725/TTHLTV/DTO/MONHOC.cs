using System.Collections.Generic; 
using System.Text; 
using System; 


namespace TTHLTV.DTO {
    
    public class MONHOC {
        public MONHOC() { }
        public virtual int MON_ID { get; set; }
        public virtual string MON_Code { get; set; }
        public virtual string MON_Name { get; set; }
        public virtual int MON_SoTiet { get; set; }
    }
}
