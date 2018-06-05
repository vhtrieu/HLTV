

namespace QLHV.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CAP_CHUNGCHI
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CCC_ID { get; set; }
        public string CCC_Code { get; set; }
        public int CCC_HOVID { get; set; }
        public int CCC_LOPID { get; set; }
        public string CCC_SoCC { get; set; }
        public DateTime CCC_NgayCap { get; set; }
        public DateTime CCC_NgayHetHan { get; set; }
        public DateTime CCC_NgayCapLai { get; set; }
        public int CCC_CHCID { get; set; }
        public int CCC_Status { get; set; }
        public string CCC_SoHieuDoi { get; set; }
        public int CCC_DOIID { get; set; }
    }
}