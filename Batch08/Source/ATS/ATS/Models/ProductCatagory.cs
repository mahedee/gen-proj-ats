using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ATS.Models
{
    public class ProductCatagory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual Catagory Catagory { get; set; }
        public virtual SubCatagory SubCatagory { get; set; }

        public string CreateBy { get; set; }
        public string ModifiedBy { get; set; }
        public string CreateDate { get; set; }
        public string ActionDate { get; set; }
    }
}