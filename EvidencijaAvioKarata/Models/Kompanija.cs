using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EvidencijaAvioKarata.Models
{
    [Table("Kompanija")]
    public class Kompanija
    {
        public int Id { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Drzava { get; set; }
        public Klasa Klasa { get; set; }
        [Required]
        [Display(Name = "Klasa")]
        public byte KlasaId { get; set; }
    }
}