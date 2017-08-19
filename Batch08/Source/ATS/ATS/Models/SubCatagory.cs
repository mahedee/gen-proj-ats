using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ATS.Models
{
    public class SubCatagory
    {
        public SubCatagory()
        {
            CreateDate = DateTime.Now;
            ActionDate = DateTime.Now;
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 3)]
        public string Name { get; set; }

        [DisplayName("Catagory")]
        public int CateId { get; set; }

        [ForeignKey("CateId")]
        public virtual Catagory Catagory { get; set; }

       // public string CreateBy { get; set; }
      //  public string ModifiedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime  ActionDate { get; set; }
    }
}