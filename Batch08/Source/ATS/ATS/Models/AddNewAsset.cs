using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ATS.Models
{
    public class AddNewAsset
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public int qty { get; set; }
        public string serial { get; set; }
        public string model { get; set; }
        public Double price { get; set; }
        public int warrenty { get; set; }
        public virtual ProductCatagory ProductCatagory { get; set; }
        public virtual SubCatagory SubCatagory { get; set; }
        public virtual Catagory Catagory { get; set; }
        public virtual Menufecturer Menufecture { get; set; }

        public string CreateBy { get; set; }
        public string ModifiedBy { get; set; }
        public string CreateDate { get; set; }
        public string ActionDate { get; set; }
        
    }
}