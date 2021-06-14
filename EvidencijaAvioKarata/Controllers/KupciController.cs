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
    public class KupciController : Controller
    {
        // GET: Kupci
        private ApplicationDbContext _context;
        public KupciController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Kompanija
        public ActionResult Index()
        {
            var kupci = _context.Kupci.Include(c => c.Karta).ToList();

            return View(kupci);
        }

        public ActionResult DodajKupca()
        {
            var kupac = new KupacForma
            {
                Kupac = new Kupac
                {
                    DatumRodjenja = new DateTime(2000, 1, 1)
                },
                Karte = _context.Karte.ToList(),
            };

            return View("KupacForma", kupac);
        }


        public ActionResult KupacForma(int id)
        {
            var kupacUBazi = _context.Kupci.SingleOrDefault(c => c.Id == id);
            var viewModel = new KupacForma
            {
                Kupac = kupacUBazi,
                Karte = _context.Karte.ToList(),
            };

            return View("KupacForma", viewModel);
        }

        [HttpPost]
        public ActionResult Sacuvaj(Kupac kupac)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new KupacForma
                {
                    Kupac = new Kupac(),
                    Karte = _context.Karte.ToList(),
                };

                return View("KupacForma", viewModel);
            }

            if (kupac.Id == 0)
            {
                _context.Kupci.Add(kupac);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                var kupacUBazi = _context.Kupci.SingleOrDefault(p => p.Id == kupac.Id);

                if (kupacUBazi == null)
                    return HttpNotFound();

                kupacUBazi.Ime = kupac.Ime;
                kupacUBazi.DatumRodjenja = kupac.DatumRodjenja;
                kupacUBazi.KartaId = kupac.KartaId;
                kupacUBazi.BrojKarata = kupac.BrojKarata;
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}