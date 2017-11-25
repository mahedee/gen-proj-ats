using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace ATS.Models
{
    public class Employee
    {
        public Employee()
        {
            CreateDate = DateTime.Now;
            ActionDate = DateTime.Now;
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Company")]
        public int CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public virtual Organization Organization { get; set; }

        [DisplayName("Branch")]
        public int BranchId { get; set; }

        [ForeignKey("BranchId")]
        public virtual Branch Branch { get; set; }

        [DisplayName("Department")]
        public int DeptId { get; set; }

        [ForeignKey("DeptId")]
        public virtual Department Department { get; set; }

       
        [Required]
        [StringLength(80, MinimumLength = 6)]
        public string Name { get; set; }

        [Required]
        [DisplayName("Designation")]
        public string Designation { get; set; }


        [Required]
        [StringLength(4, MinimumLength = 2)]
        public string Code { get; set; }
        
       
        

        //public string CreateBy { get; set; }
        //public string ModifiedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ActionDate { get; set; }



    }
}