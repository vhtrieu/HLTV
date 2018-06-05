using System.Collections.Generic; 
using System.Text; 
using System; 


namespace TTHLTV.DAL {
    
    public class GIANGVIEN {
        public GIANGVIEN() { }
        public virtual int GIV_ID { get; set; }
        public virtual string GIV_Code { get; set; }
        public virtual string GIV_Name { get; set; }
        public virtual string GIV_Phone { get; set; }
        public virtual string GIV_Address { get; set; }
        public virtual string GIV_Khoa { get; set; }
    }
}
