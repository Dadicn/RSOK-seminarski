using EvidencijaAvioKarata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EvidencijaAvioKarata.Controllers
{
    public class DestinacijeController : Controller
    {
        //Instanca DBContext-a(Preko njega pristupamo bazi)
        private ApplicationDbContext _context;
        //Inicijalizacija DBContext-a
        public DestinacijeController()
        {
            _context = new ApplicationDbContext();
        }
        //Izbacivanje resursa iz memorije(Na kraju svake akcije, dolazi do dispose-a)
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //Akcija za vracanje svih destinacija
        public ActionResult Index()
        {
            var destinacije = _context.Destinacije.ToList();

            return View(destinacije);
        }

        //Akcija za usmeravanje na formu za destinaciju
        public ActionResult DodajDestinaciju()
        {
            var destinacija = new Destinacija();

            return View("DestinacijaForma", destinacija);
        }

        //Akcija za usmeravanje za izmenu neke destinacije
        public ActionResult DestinacijaForma(int id)
        {
            //Trazi destinaciju sa poslatim Id-om u bazi.
            var destinacijaUBazi = _context.Destinacije.SingleOrDefault(p => p.Id == id);
            //View model sa podacima te pronadjene destinacije
            var viewModel = new Destinacija
            {
                Naziv = destinacijaUBazi.Naziv,
                ImeAerodroma = destinacijaUBazi.ImeAerodroma,
                Grad = destinacijaUBazi.Grad,
            };
            //Vraca mesto u formu
            return View("DestinacijaForma", viewModel);
        }

        //Akcija za sacuvavanje novog zapisa ili izmenu zapisa
        [HttpPost]
        public ActionResult Sacuvaj(Destinacija destinacija)
        {

            //Provera da li su sva polja u formi popunjena
            if (!ModelState.IsValid)
            {
                var viewModel = new Destinacija();

                return View("DestinacijaForma", viewModel);
            }

            //Ako je id destinacije jednak 0, to znaci da je u pitanju dodavanje nove destinacije, posto joj je id 0, znaci da je nema u bazi.
            if (destinacija.Id == 0)
            {
                _context.Destinacije.Add(destinacija);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            //Ako je u pitanu id koji nije 0, znaci da se radi o izmeni postojeceg zapisa
            else
            {
                //Nalazi zapis sa id-em za izmenu
                var destinacijaUBazi = _context.Destinacije.SingleOrDefault(p => p.Id == destinacija.Id);
                //Provera ako uopste taj zapis uopste postoji u bazi
                if (destinacijaUBazi == null)
                    return HttpNotFound();
                //Menja postojece podatke sa poslatim podacima iz forme
                destinacijaUBazi.Naziv = destinacija.Naziv;
                destinacijaUBazi.ImeAerodroma = destinacija.ImeAerodroma;
                destinacijaUBazi.Grad = destinacija.Grad;
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}
