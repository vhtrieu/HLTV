using System.Collections.Generic; 
using System.Text; 
using System; 


namespace TTHLTV.DAL {
    
    public class sysdiagram {
        public sysdiagram() { }
        public virtual int diagram_id { get; set; }
        public virtual string name { get; set; }
        public virtual int principal_id { get; set; }
        public virtual System.Nullable<int> version { get; set; }
        public virtual byte[] definition { get; set; }
    }
}
