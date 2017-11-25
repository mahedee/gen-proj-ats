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
    public class Accessory
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Company")]
        public int CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public virtual Organization Organization { get; set; }

        [DisplayName("Accessory Name")]
        public string Name { get; set; }

        [DisplayName("Category")]
        public int CateId { get; set; }
        [ForeignKey("CateId")]
        public virtual Catagory Category { get; set; }

        [DisplayName("Manufacturer")]
        public int ManuId { get; set; }
        [ForeignKey("ManuId")]
        public virtual Manufacturer Manufacturer { get; set; }

        [DisplayName("Location")]
        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public virtual Branch Branch { get; set; }

        [DisplayName("Model No.")]
        public string ModelNo { get; set; }

        [DisplayName("Order Number")]
        public string OrderNo { get; set; }

        [DisplayName("Purchase Cost")]
        public double PurchaseCost { get; set; }

        [DisplayName("Purchase Date")]
        public DateTime PurchaseDate { get; set; }

        [DisplayName("Quantity")]
        public int Quantity { get; set; }

       // public string CreateBy { get; set; }
      //  public string ModifiedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ActionDate { get; set; }
        
    }
}