using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading;
using System.Web;

namespace ATS.Models
{
    public class Department
    {
        public Department()
        {
            CreateDate=DateTime.Now;
            ActionDate=DateTime.Now;
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Company Name")]
        public int CompanyId { get; set; }

     [ForeignKey("CompanyId")]
        public virtual Organization Organization { get; set; }

        [DisplayName("Branch")]
        public int BranchId { get; set; }

       [ForeignKey("BranchId")]
        public virtual Branch Branch { get; set; }

        [Required]
        [DisplayName("Dept Name")]
        [StringLength(80, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [DisplayName("Dept Code")]
        [StringLength(6, MinimumLength = 2)]
        public string Code { get; set; }
        


       // public string CreateBy { get; set; }
       // public string ModifiedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ActionDate { get; set; }
    }
}