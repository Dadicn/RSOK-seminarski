using EvidencijaAvioKarata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvidencijaAvioKarata.ViewModels
{
    public class KompanijaForma
    {
        public Kompanija Kompanija { get; set; }
        public IEnumerable<Klasa> Klase { get; set; }
    }
}