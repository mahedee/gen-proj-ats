using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ATS.Models
{
    public class ProductCatagory
    {
        public ProductCatagory()
        {
            CreateDate = DateTime.Now;
            ActionDate = DateTime.Now;
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Catagory")]
        public int CateId { get; set; }
        [ForeignKey("CateId")]
        public virtual Catagory Catagory { get; set; }

        [DisplayName("Sub Catagory")]
        public int SCateId { get; set; }
        [ForeignKey("SCateId")]
        public virtual SubCatagory SubCatagory { get; set; }

        [Required]
        [DisplayName("Product Catagory")]
        public string Name { get; set; }
        


     //   public string CreateBy { get; set; }
      //  public string ModifiedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ActionDate { get; set; }
    }
}