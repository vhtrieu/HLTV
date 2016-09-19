using System.Collections.Generic; 
using System.Text; 
using System; 


namespace TTHLTV.DAL {
    
    public class MON_LOP {
        public MON_LOP() { }
        public virtual int MOL_ID { get; set; }
        public virtual string MOL_Code { get; set; }
        public virtual int MOL_LOPID { get; set; }
        public virtual int MOL_MONID { get; set; }
        public virtual int MOL_GIVID { get; set; }
        public virtual System.Nullable<int> MOL_SoTiet { get; set; }
    }
}
