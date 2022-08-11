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
    public class ProveedoresController : ApiController
    {
        private MVP_ASPContext db = new MVP_ASPContext();

        // GET: api/Proveedores
        public IQueryable<Proveedores> GetProveedores()
        {
            return db.Proveedores;
        }

        // GET: api/Proveedores/5
        [ResponseType(typeof(Proveedores))]
        public async Task<IHttpActionResult> GetProveedores(int id)
        {
            Proveedores proveedores = await db.Proveedores.FindAsync(id);
            if (proveedores == null)
            {
                return NotFound();
            }

            return Ok(proveedores);
        }

        // PUT: api/Proveedores/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProveedores(int id, Proveedores proveedores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != proveedores.Id)
            {
                return BadRequest();
            }

            db.Entry(proveedores).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProveedoresExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(proveedores);
        }

        // POST: api/Proveedores
        [ResponseType(typeof(Proveedores))]
        public async Task<IHttpActionResult> PostProveedores(Proveedores proveedores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Proveedores.Add(proveedores);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = proveedores.Id }, proveedores);
        }

        // DELETE: api/Proveedores/5
        [ResponseType(typeof(Proveedores))]
        public async Task<IHttpActionResult> DeleteProveedores(int id)
        {
            Proveedores proveedores = await db.Proveedores.FindAsync(id);
            if (proveedores == null)
            {
                return NotFound();
            }

            db.Proveedores.Remove(proveedores);
            await db.SaveChangesAsync();

            return Ok(proveedores);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProveedoresExists(int id)
        {
            return db.Proveedores.Count(e => e.Id == id) > 0;
        }
    }
}