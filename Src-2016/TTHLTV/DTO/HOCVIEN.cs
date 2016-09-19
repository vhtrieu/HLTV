using System.Collections.Generic; 
using System.Text; 
using System; 


namespace TTHLTV.DTO {
    
    public class HOCVIEN {
        public HOCVIEN() { }
        public virtual int HOV_ID { get; set; }
        public virtual string HOV_Code { get; set; }
        public virtual string HOV_FirstName { get; set; }
        public virtual string HOV_LastName { get; set; }
        public virtual string HOV_FullName { get; set; }
        public virtual string HOV_BirthDay { get; set; }
        public virtual string HOV_QuocTich { get; set; }
        public virtual string HOV_NoiSinh { get; set; }
        public virtual string HOV_Phone { get; set; }
        public virtual string HOV_Address { get; set; }
        public virtual string HOV_DonVi { get; set; }
        public virtual string HOV_ChucDanh { get; set; }
        public virtual string HOV_GhiChu { get; set; }
    }
}
