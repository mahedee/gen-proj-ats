using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ATS.Models
{
    public class AssetRegister
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string AssetTag { get; set; }
        public virtual AddNewAsset AssetInfo { get; set; }
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