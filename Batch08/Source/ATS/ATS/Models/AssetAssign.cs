using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATS.Models
{
    public class AssetAssign
    {
        public int Id { get; set; }
        public string AssetTag { get; set; }
        public int assignTo { get; set; }
        public int assignId { get; set; }
        public virtual AssetRegister Asset { get; set; }
        public virtual Department Department { get; set; }
        public virtual Employee Employee { get; set; }


        public string CreateBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ActionDate { get; set; }
    }
}