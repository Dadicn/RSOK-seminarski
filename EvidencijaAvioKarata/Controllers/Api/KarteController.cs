using EvidencijaAvioKarata.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EvidencijaAvioKarata.Controllers.Api
{
    public class KarteController : ApiController
    {
        private ApplicationDbContext _context;

        public KarteController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: /api/tickets
        [HttpGet]
        public IEnumerable<Karta> DajSveKarte()
        {
            var karteUBazi = _context.Karte.
                Include(t => t.Kompanija).
                Include(t => t.Destinacija).ToList();

            return karteUBazi;
        }

        [HttpDelete]
        public IHttpActionResult Obrisi(int id)
        {
            var kartaUBazi = _context.Karte.SingleOrDefault(p => p.Id == id);

            if (kartaUBazi == null)
                return NotFound();

            _context.Karte.Remove(kartaUBazi);
            _context.SaveChanges();

            return Ok();
        }
    }
}
