using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EvidencijaAvioKarata.Models
{
    [Table("Destinacija")]
    public class Destinacija
    {
        public int Id { get; set; }
        [Required]
        public string Naziv { get; set; }
        [Required]
        public string ImeAerodroma { get; set; }
        [Required]
        public string Grad { get; set; }
    }
}