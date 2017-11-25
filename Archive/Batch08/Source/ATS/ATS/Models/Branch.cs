using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ATS.Models
{
    public class Branch
    {
        public Branch()
        {
            CreateDate = DateTime.Now;
            ActionDate = DateTime.Now;
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

       [DisplayName("Company Name")]
        public int CompanyId { get; set; }

        [NotMapped]
        [DisplayName("Company Name")]
        public string CompanyName { get; set; }

        [ForeignKey("CompanyId")]
        public virtual Organization Organization { get; set; }

        [Required]
        [DisplayName("Branch Name")]
        [StringLength(100, MinimumLength = 10)]
        public string Name { get; set; }

        [DisplayName("Phone")]
        public string Phone { get; set; }

        [DisplayName("Fax")]
        public string Fax { get; set; }

        [DisplayName("Email")]
        [EmailAddress]
        public string Email { get; set; }

        [DisplayName("Address")]
        [StringLength(150, MinimumLength = 20)]
        public string Address { get; set; }

       // public string CreateBy { get; set; }
       // public string ModifiedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ActionDate { get; set; }
 
    }
}