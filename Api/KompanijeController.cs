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
    public class KompanijeController : ApiController
    {
        private ApplicationDbContext _context;

        public KompanijeController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IEnumerable<Kompanija> DajSveKompanije()
        {
            var kompanijeUBazi = _context.Kompanije.Include(p => p.Klasa).ToList();

            return kompanijeUBazi;
        }

        [HttpDelete]
        public IHttpActionResult Obrisi(int id)
        {
            var kompanijaUBazi = _context.Kompanije.SingleOrDefault(p => p.Id == id);

            if (kompanijaUBazi == null)
                return NotFound();

            _context.Kompanije.Remove(kompanijaUBazi);
            _context.SaveChanges();

            return Ok();
        }
    }
}
