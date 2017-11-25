using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ATS.Models
{
    public class Organization
    {
        public Organization()
        {
            CreateDate = DateTime.Now;
            ActionDate = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100,MinimumLength = 10)]
        [DisplayName("Organization Name")]
        public string Name { get; set; }

        [DisplayName("Organization Phone")]
        public string Phone { get; set; }

        [DisplayName("Organization Fax")]
        public string Fax { get; set; }

        [DisplayName("Organization Email")]
        public string Email { get; set; }

        [DisplayName("Web Address")]
        public string WebAddress { get; set; }

        [DisplayName("Address")]
        public string Address { get; set; }

        [DisplayName("About Organization")]
        public string About { get; set; }
     //   public string CreateBy { get; set; }
       // public string ModifiedBy { get; set; }

           
        public DateTime CreateDate { get; set; }

        public DateTime ActionDate { get; set; }
    }
}