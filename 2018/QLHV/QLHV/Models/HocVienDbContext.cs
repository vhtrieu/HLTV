using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace QLHV.Models
{
    public class HocVienDbContext : DbContext
    {
        public HocVienDbContext()
            : base("HocVienConnection")
        {
        }
        public System.Data.Entity.DbSet<HOCVIEN> HOCVIENs { get; set; }
        public System.Data.Entity.DbSet<HOCVIEN_IMG> HOCVIEN_IMGs { get; set; }
        public System.Data.Entity.DbSet<CAP_CHUNGCHI> CAP_CHUNGCHIs { get; set; }
        public System.Data.Entity.DbSet<CHUNG_CHI> CHUNG_CHIs { get; set; }
        public System.Data.Entity.DbSet<TINH> TINHs { get; set; }
    }
}