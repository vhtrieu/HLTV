using System.Collections.Generic; 
using System.Text; 
using System; 


namespace TTHLTV.DAL {
    
    public class NGUOIDUNG {
        public NGUOIDUNG() { }
        public virtual int NGU_ID { get; set; }
        public virtual string NGU_Code { get; set; }
        public virtual string NGU_Name { get; set; }
        public virtual string NGU_UserName { get; set; }
        public virtual string NGU_Password { get; set; }
    }
}
