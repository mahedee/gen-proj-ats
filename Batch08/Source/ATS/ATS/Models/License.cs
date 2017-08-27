using ATS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ATS.Models
{
    public class License
    {
        public License()
        {
            CreateDate = DateTime.Now;
            ActionDate = DateTime.Now;
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [DisplayName("Software Name")]
        public string Name { get; set; }

        [DisplayName("Product Key")]
        public string ProductKey { get; set; }

        [DisplayName("Seats")]
        public int Seats { get; set; }

        [DisplayName("Company")]
        public int CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public virtual Organization Organization { get; set; }

        [DisplayName("Manufacturer")]
        public int MenuId { get; set; }

        [ForeignKey("MenuId")]
        public virtual Manufacturer Manufacturer { get; set; }

        [DisplayName("Licensed to Name")]
        public string LicenseName { get; set; }

        [DisplayName("Licensed to Email")]
        [EmailAddress]
        public string LicenseEmail { get; set; }

        [DisplayName("Reassignable")]
        public bool Reassignable { get; set; }

        [DisplayName("Supplier")]
        public int SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }

        [DisplayName("Order Number")]
        public string OrderNumber { get; set; }

        [DisplayName("Purchase Cost")]
        public double PurchaseCost { get; set; }

        [DisplayName("Purchase Date")]
        public DateTime PurchaseDate { get; set; }

        [DisplayName("Expiration Date")]
        public DateTime ExpirationDate { get; set; }

        [DisplayName("Order Number")]
        public string OrderNo { get; set; }

        [DisplayName("Depreciation")]
        public bool Depreciation { get; set; }

        [DisplayName("Maintained")]
        public bool Maintained { get; set; }

        [DisplayName("Notes")]
        public string Notes { get; set; }

        

       // public string CreateBy { get; set; }
       // public string ModifiedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ActionDate { get; set; }
    }
}