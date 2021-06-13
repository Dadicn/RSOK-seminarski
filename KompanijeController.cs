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
    public class KompanijeController : Controller
    {
        private ApplicationDbContext _context;
        public KompanijeController()
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
            var kompanija = _context.Kompanije.Include(p => p.Klasa).ToList();

            return View(kompanija);
        }

        public ActionResult DodajKompaniju()
        {
            //Pravi novi objekat kompanija i salje ga na view
            var kompanija = new KompanijaForma
            {
                Kompanija = new Kompanija(),
                Klase = _context.Klase.ToList()
            };

            return View("KompanijaForma", kompanija);
        }
        //Salje na formu za izmenu
        public ActionResult KompanijaForma(int id)
        {
            var kompanijaUBazi = _context.Kompanije.SingleOrDefault(p => p.Id == id);
            var viewModel = new KompanijaForma
            {
                Kompanija = kompanijaUBazi,
                Klase = _context.Klase.ToList()
            };

            return View("KompanijaForma", viewModel);
        }

        [HttpPost]
        public ActionResult Sacuvaj(Kompanija kompanija)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new KompanijaForma
                {
                    Kompanija = kompanija,
                    Klase = _context.Klase.ToList()
                };

                return View("KompanijaForma", viewModel);
            }
            //Dodavanje nove kompanije u bazu
            if (kompanija.Id == 0)
            {
                _context.Kompanije.Add(kompanija);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            //Izmena postojece kompanije iz baze
            else
            {
                var kompanijaUBazi = _context.Kompanije.SingleOrDefault(p => p.Id == kompanija.Id);

                if (kompanijaUBazi == null)
                    return HttpNotFound();

                kompanijaUBazi.Ime = kompanija.Ime;
                kompanijaUBazi.Drzava = kompanija.Drzava;
                kompanijaUBazi.KlasaId = kompanija.KlasaId;
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}