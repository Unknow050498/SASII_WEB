using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MVP_ASP.Models;

namespace MVP_ASP.Controllers
{
    public class ProvedoresController : ApiController
    {
        private MVP_ASPContext db = new MVP_ASPContext();

        // GET: api/Provedores
        public IQueryable<Provedores> GetProvedores()
        {
            return db.Provedores;
        }

        // GET: api/Provedores/5
        [ResponseType(typeof(Provedores))]
        public async Task<IHttpActionResult> GetProvedores(int id)
        {
            Provedores provedores = await db.Provedores.FindAsync(id);
            if (provedores == null)
            {
                return NotFound();
            }

            return Ok(provedores);
        }

        // PUT: api/Provedores/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProvedores(int id, Provedores provedores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != provedores.Id)
            {
                return BadRequest();
            }

            db.Entry(provedores).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProvedoresExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(provedores);
        }

        // POST: api/Provedores
        [ResponseType(typeof(Provedores))]
        public async Task<IHttpActionResult> PostProvedores(Provedores provedores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Provedores.Add(provedores);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = provedores.Id }, provedores);
        }

        // DELETE: api/Provedores/5
        [ResponseType(typeof(Provedores))]
        public async Task<IHttpActionResult> DeleteProvedores(int id)
        {
            Provedores provedores = await db.Provedores.FindAsync(id);
            if (provedores == null)
            {
                return NotFound();
            }

            db.Provedores.Remove(provedores);
            await db.SaveChangesAsync();

            return Ok(provedores);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProvedoresExists(int id)
        {
            return db.Provedores.Count(e => e.Id == id) > 0;
        }
    }
}