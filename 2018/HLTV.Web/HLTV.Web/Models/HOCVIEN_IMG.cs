
namespace HLTV.Web.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("HOCVIEN_IMG")]
    public class HOCVIEN_IMG
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IMG_ID { get; set; }
        public int IMG_HOVID { get; set; }
        public string IMG_Name { get; set; }
        public byte[] IMG_Image { get; set; }
    }
}