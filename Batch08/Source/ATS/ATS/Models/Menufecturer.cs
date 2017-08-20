using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ATS.Models
{
    public class Menufecturer
    {
        public Menufecturer()
        {
            CreateDate = DateTime.Now;
            ActionDate = DateTime.Now;
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Address")]
        public string Address { get; set; }

        [DisplayName("City")]
        public string City { get; set; }

        [DisplayName("Country")]
        public string Country { get; set; }

        [DisplayName("Email")]
        [EmailAddress]
        public string Email { get; set; }

        [DisplayName("Phone")]
        public string Phone { get; set; }

        [DisplayName("Web")]
        public string WebAddress { get; set; }


       // public string CreateBy { get; set; }
       // public string ModifiedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ActionDate { get; set; }
    }
}