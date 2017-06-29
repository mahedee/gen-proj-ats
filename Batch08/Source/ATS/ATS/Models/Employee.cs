using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ATS.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public virtual Department Department { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual Organization Organization { get; set; }

        public string CreateBy { get; set; }
        public string ModifiedBy { get; set; }
        public string CreateDate { get; set; }
        public string ActionDate { get; set; }



    }
}