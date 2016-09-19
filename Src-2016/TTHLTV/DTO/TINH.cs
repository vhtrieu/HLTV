using System.Collections.Generic; 
using System.Text; 
using System; 


namespace TTHLTV.DAL {
    
    public class TINH {
        public TINH() { }
        public virtual int TIN_ID { get; set; }
        public virtual string TIN_Code { get; set; }
        public virtual string TIN_Name { get; set; }
    }
}
