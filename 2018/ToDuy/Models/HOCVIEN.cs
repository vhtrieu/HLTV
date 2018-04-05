

namespace HLTV.Web.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("HOCVIEN")]
    public class HOCVIEN
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HOV_ID { get; set; }
        public string HOV_Code { get; set; }
        public string HOV_FirstName { get; set; }
        public string HOV_LastName { get; set; }
        public string HOV_FullName { get; set; }
        public string HOV_BirthDay { get; set; }
        public string HOV_QuocTich { get; set; }
        public string HOV_NoiSinh { get; set; }
        public string HOV_Phone { get; set; }
        public string HOV_Address { get; set; }
        public string HOV_DonVi { get; set; }
        public string HOV_ChucDanh { get; set; }
        public string HOV_GhiChu { get; set; }
        [NotMapped]
        public int IMG_ID { get; set; }
        [NotMapped]
        public int IMG_HOVID { get; set; }
        [NotMapped]
        public string IMG_Name { get; set; }
        [NotMapped]
        public byte[] IMG_Image { get; set; }
        [NotMapped]
        public string CCC_SoCC { get; set; }
        [NotMapped]
        public DateTime CCC_NgayCap { get; set; }
        [NotMapped]
        public DateTime CCC_NgayHetHan { get; set; }
        [NotMapped]
        public int CCC_Status { get; set; }
        [NotMapped]
        public string CHC_Name { get; set; }

    }
}