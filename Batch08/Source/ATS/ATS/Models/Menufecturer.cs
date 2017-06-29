﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ATS.Models
{
    public class Menufecturer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string WebAddress { get; set; }


        public string CreateBy { get; set; }
        public string ModifiedBy { get; set; }
        public string CreateDate { get; set; }
        public string ActionDate { get; set; }
    }
}