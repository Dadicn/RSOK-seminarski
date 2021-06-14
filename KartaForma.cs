using EvidencijaAvioKarata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvidencijaAvioKarata.ViewModels
{
    public class KartaForma
    {
        public Karta Karta { get; set; }
        public IEnumerable<Destinacija> Destinacije { get; set; }
        public IEnumerable<Kompanija> Kompanije { get; set; }
    }
}