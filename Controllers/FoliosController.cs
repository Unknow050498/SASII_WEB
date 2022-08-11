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
    public class FoliosController : ApiController
    {
        private MVP_ASPContext db = new MVP_ASPContext();

        // GET: api/Folios
        public IQueryable<Folios> GetFolios()
        {
            return db.Folios;
        }

        // GET: api/Folios/5
        [ResponseType(typeof(Folios))]
        public async Task<IHttpActionResult> GetFolios(int id)
        {
            Folios folios = await db.Folios.FindAsync(id);
            if (folios == null)
            {
                return NotFound();
            }

            return Ok(folios);
        }

        // PUT: api/Folios/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFolios(int id, Folios folios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != folios.Id)
            {
                return BadRequest();
            }

            db.Entry(folios).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoliosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(folios);
        }

        // POST: api/Folios
        [ResponseType(typeof(Folios))]
        public async Task<IHttpActionResult> PostFolios(Folios folios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Folios.Add(folios);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = folios.Id }, folios);
        }

        // DELETE: api/Folios/5
        [ResponseType(typeof(Folios))]
        public async Task<IHttpActionResult> DeleteFolios(int id)
        {
            Folios folios = await db.Folios.FindAsync(id);
            if (folios == null)
            {
                return NotFound();
            }

            db.Folios.Remove(folios);
            await db.SaveChangesAsync();

            return Ok(folios);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FoliosExists(int id)
        {
            return db.Folios.Count(e => e.Id == id) > 0;
        }
    }
}