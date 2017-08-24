using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ATS.Models
{
    public class Catagory
    {
        public Catagory()
        {
            CreateDate = DateTime.Now;
            ActionDate = DateTime.Now;
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [DisplayName("Type")]
        public int CateTypeId { get; set; }
        [ForeignKey("CateTypeId")]
        public virtual CateType CateType { get; set; }
        
       // public string CreateBy { get; set; }
      //  public string ModifiedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ActionDate { get; set; }
    }
}