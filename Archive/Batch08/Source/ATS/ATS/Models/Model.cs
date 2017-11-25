using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ATS.Models
{
    public class Model
    {
        public Model()
        {
            CreateDate = DateTime.Now;
            ActionDate = DateTime.Now;
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Asset Model Name")]
        public string Name { get; set; }

        [DisplayName("Manufacturer")]
        public int MenuId { get; set; }

        [ForeignKey("MenuId")]
        public virtual Manufacturer Manufacturer { get; set; }

        [DisplayName("Category")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Catagory Category { get; set; }

        [DisplayName("Model No.")]
        public string ModelNo { get; set; }

        [DisplayName("Depreciation")]
        public bool Depreciation { get; set; }

        [DisplayName("EOL")]
        public int Eol { get; set; }

        [DisplayName("Fieldset")]
        public int FieldsetId  { get; set; }
        [ForeignKey("FieldsetId")]
        public virtual Fieldset Fieldset{ get; set; }

        [DisplayName("Note")]
        public string Note { get; set; }

        // public string CreateBy { get; set; }
        // public string ModifiedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ActionDate { get; set; }

    }
}