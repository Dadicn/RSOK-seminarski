using EvidencijaAvioKarata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EvidencijaAvioKarata.Controllers.Api
{
    public class DestinacijeController : ApiController
    {
        private ApplicationDbContext _context;

        public DestinacijeController()
        {
            _context = new ApplicationDbContext();
        }
        //Web servis koji vraca listu destinacija
        [HttpGet]
        public IEnumerable<Destinacija> DajSveDestinacije()
        {
            var destinacijeUBazi = _context.Destinacije.ToList();

            return destinacijeUBazi;
        }


        //Web servis koji brise destinaciju u bazi
        [HttpDelete]
        public IHttpActionResult Obrisi(int id)
        {
            //Destinacija u bazi sa trazenim id-em
            var destinacijaUBazi = _context.Destinacije.SingleOrDefault(p => p.Id == id);

            //Ako ne postoji vraca gresku 404
            if (destinacijaUBazi == null)
                return NotFound();

            //Brise je iz baze ako je prethodno prosla proveru
            _context.Destinacije.Remove(destinacijaUBazi);
            _context.SaveChanges();

            return Ok();
        }
    }
}
