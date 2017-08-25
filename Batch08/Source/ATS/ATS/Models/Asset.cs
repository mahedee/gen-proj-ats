using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ATS.Models
{
    public class Asset
    {
        public Asset()
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

        [Required]
        [DisplayName("Asset Tag")]
        public string AssetTag { get; set; }

        [DisplayName("Model")]
        public int ModelId { get; set; }
        [ForeignKey("ModelId")]
        public virtual Model Model { get; set; }

        [DisplayName("Status")]
        public  int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public virtual Status Status { get; set; }

        [DisplayName("Serial")]
        public string Serial { get; set; }

        [Required]
        [DisplayName("Asset Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Purchase Date")]
        public DateTime PurchaseDate { get; set; }

        [DisplayName("Supplier")]
        public int SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }

        [DisplayName("Order Number")]
        public string OrderNumber { get; set; }

        [DisplayName("Purchase Cost")]
        public double Cost { get; set; }

        [DisplayName("Warranty")]
        public string Warranty { get; set; }

        [DisplayName("Default Location")]
        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public virtual  Branch Branch { get; set; }

        [DisplayName("Note")]
        public string Note { get; set; }
        //public string CreateBy { get; set; }
        // public string ModifiedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ActionDate { get; set; }
    }
}