using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EvidencijaAvioKarata.Models
{
    [Table("Kupci")]
    public class Kupac
    {
        public int Id { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        [PoslovnoPravilo]
        [Display(Name = "Datum Rodjenja")]
        public DateTime DatumRodjenja { get; set; }
        public Karta Karta { get; set; }
        [Required]
        [Display(Name = "Karta")]
        public int KartaId { get; set; }
        [Required]
        [Range(1, 5)]
        public int BrojKarata { get; set; }

        public int Godine = 18;
    }
}