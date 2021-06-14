using EvidencijaAvioKarata.Models;
using EvidencijaAvioKarata.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EvidencijaAvioKarata.Controllers
{
    public class KarteController : Controller
    {
        private ApplicationDbContext _context;
        //KONSTRUKTOR - INICIJALIZACIJA CONTEKSTA
        public KarteController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //POCETNA FUNKCIJA - INDEX
        public ActionResult Index()
        {
            var karta = _context.Karte.Include(t => t.Destinacija).Include(t => t.Kompanija).ToList();

            return View(karta);
        }

        public ActionResult DodajKartu()
        {
            var karta = new KartaForma
            {
                Karta = new Karta(),
                Destinacije = _context.Destinacije.ToList(),
                Kompanije = _context.Kompanije.ToList()
            };

            return View("KartaForma", karta);
        }

        public ActionResult KartaForma(int id)
        {
            var kartaUBazi = _context.Karte.SingleOrDefault(p => p.Id == id);
            var viewModel = new KartaForma
            {
                Karta = kartaUBazi,
                Destinacije = _context.Destinacije.ToList(),
                Kompanije = _context.Kompanije.ToList()
            };

            return View("KartaForma", viewModel);
        }

        [HttpPost]
        public ActionResult Sacuvaj(Karta karta)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new KartaForma
                {
                    Karta = karta,
                    Destinacije = _context.Destinacije.ToList(),
                    Kompanije = _context.Kompanije.ToList()
                };

                return View("KartaForma", viewModel);
            }
            //DODAVANJE NOVOG ZAPISA
            if (karta.Id == 0)
            {
                _context.Karte.Add(karta);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            //AZURIRANJE
            else
            {
                var kartaUBazi = _context.Karte.SingleOrDefault(p => p.Id == karta.Id);

                if (kartaUBazi == null)
                    return HttpNotFound();

                kartaUBazi.Id = karta.Id;
                kartaUBazi.tipKarte = karta.tipKarte;
                kartaUBazi.KompanijaId = karta.KompanijaId;
                kartaUBazi.DestinacijaId = karta.DestinacijaId;
                kartaUBazi.DatumIVreme = karta.DatumIVreme;
                kartaUBazi.Cena = karta.Cena;
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}