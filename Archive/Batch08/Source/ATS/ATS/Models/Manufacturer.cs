using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ATS.Models
{
    public class Manufacturer
    {
        public Manufacturer()
        {
            CreateDate = DateTime.Now;
            ActionDate = DateTime.Now;
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [DisplayName("Manufacturer Name")]
        public string Name { get; set; }

       
       // public string CreateBy { get; set; }
       // public string ModifiedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ActionDate { get; set; }
    }
}