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
    public class KupciController : ApiController
    {
        private ApplicationDbContext _context;

        public KupciController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: /api/kupci
        [HttpGet]
        public IEnumerable<Kupac> DajSveKupce()
        {
            var kupciUBazi = _context.Kupci.Include(c => c.Karta).ToList();

            return kupciUBazi;
        }

        [HttpDelete]
        public IHttpActionResult Obrisi(int id)
        {
            var kupacUBazi = _context.Kupci.SingleOrDefault(p => p.Id == id);

            if (kupacUBazi == null)
                return NotFound();

            _context.Kupci.Remove(kupacUBazi);
            _context.SaveChanges();

            return Ok();
        }
    }
}
