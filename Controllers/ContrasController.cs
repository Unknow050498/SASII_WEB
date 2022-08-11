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
    public class ContrasController : ApiController
    {
        private MVP_ASPContext db = new MVP_ASPContext();

        // GET: api/Contras
        public IQueryable<Contras> GetContras()
        {
            return db.Contras;
        }

        // GET: api/Contras/5
        [ResponseType(typeof(Contras))]
        public async Task<IHttpActionResult> GetContras(int id)
        {
            Contras contras = await db.Contras.FindAsync(id);
            if (contras == null)
            {
                return NotFound();
            }

            return Ok(contras);
        }

        // PUT: api/Contras/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutContras(int id, Contras contras)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contras.Id)
            {
                return BadRequest();
            }

            db.Entry(contras).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContrasExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(contras);
        }

        // POST: api/Contras
        [ResponseType(typeof(Contras))]
        public async Task<IHttpActionResult> PostContras(Contras contras)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Contras.Add(contras);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = contras.Id }, contras);
        }

        // DELETE: api/Contras/5
        [ResponseType(typeof(Contras))]
        public async Task<IHttpActionResult> DeleteContras(int id)
        {
            Contras contras = await db.Contras.FindAsync(id);
            if (contras == null)
            {
                return NotFound();
            }

            db.Contras.Remove(contras);
            await db.SaveChangesAsync();

            return Ok(contras);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContrasExists(int id)
        {
            return db.Contras.Count(e => e.Id == id) > 0;
        }
    }
}