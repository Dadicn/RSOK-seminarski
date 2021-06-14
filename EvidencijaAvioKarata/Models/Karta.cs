using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EvidencijaAvioKarata.Models
{
    [Table("Karta")]
    public class Karta
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Tip karte")]
        public string tipKarte { get; set; }
        public Destinacija Destinacija { get; set; }
        [Required]
        [Display(Name = "Destinacija")]
        public int DestinacijaId { get; set; }
        public Kompanija Kompanija { get; set; }
        [Required]
        [Display(Name = "Kompanija")]
        public int KompanijaId { get; set; }
        [Required]
        public DateTime DatumIVreme { get; set; }
        [Required]
        public int Cena { get; set; }
    }
}