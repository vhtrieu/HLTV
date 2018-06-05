using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLHV.Models
{
    [Table("TINH")]
    public class TINH
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TIN_ID { get; set; }
        public string TIN_Code { get; set; }
        public string TIN_Name { get; set; }
        

    }
}