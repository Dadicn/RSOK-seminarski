using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EvidencijaAvioKarata.Models
{
    [Table("Klasa")]
    public class Klasa
    {
        public byte Id { get; set; }
        public string Naziv { get; set; }
    }
}