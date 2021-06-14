using EvidencijaAvioKarata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvidencijaAvioKarata.ViewModels
{
    public class KupacForma
    {
        public Kupac Kupac { get; set; }
        public IEnumerable<Karta> Karte { get; set; }
    }
}