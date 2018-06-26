using System.Collections.Generic; 
using System.Text; 
using System; 


namespace TTHLTV.DTO {
    
    public class CHUNG_CHI {
        public CHUNG_CHI() { }
        public virtual int CHC_ID { get; set; }
        public virtual string CHC_Code { get; set; }
        public virtual string CHC_Name { get; set; }
        public virtual string CHC_Content1 { get; set; }
        public virtual string CHC_Content2 { get; set; }
        public virtual string CHC_Content3 { get; set; }
        public virtual string CHC_Content4 { get; set; }
        public virtual string CHC_Content5 { get; set; }
        public virtual string CHC_QuyTac { get; set; }
        public virtual string CHC_ModleCode { get; set; }
        public virtual int CHC_Status { get; set; }
        public virtual string CHC_QuyDinh { get; set; }
        public virtual string CHC_QuyDinhEngl { get; set; }
        public virtual int CHC_FontSize1 { get; set; }
        public virtual int CHC_FontSize2 { get; set; }
        public virtual int CHC_FontSize3 { get; set; }
        public virtual int CHC_FontSize4 { get; set; }
        public virtual int CHC_FontSize5 { get; set; }
        //public virtual string CHC_QuyTac { get; set; }
    }
}
