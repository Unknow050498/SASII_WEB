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
    public class VendedoresController : ApiController
    {
        private MVP_ASPContext db = new MVP_ASPContext();

        // GET: api/Vendedores
        public IQueryable<Vendedores> GetVendedores()
        {
            return db.Vendedores;
        }

        // GET: api/Vendedores/5
        [ResponseType(typeof(Vendedores))]
        public async Task<IHttpActionResult> GetVendedores(int id)
        {
            Vendedores vendedores = await db.Vendedores.FindAsync(id);
            if (vendedores == null)
            {
                return NotFound();
            }

            return Ok(vendedores);
        }

        // PUT: api/Vendedores/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVendedores(int id, Vendedores vendedores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vendedores.Id)
            {
                return BadRequest();
            }

            db.Entry(vendedores).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendedoresExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(vendedores);
        }

        // POST: api/Vendedores
        [ResponseType(typeof(Vendedores))]
        public async Task<IHttpActionResult> PostVendedores(Vendedores vendedores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Vendedores.Add(vendedores);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = vendedores.Id }, vendedores);
        }

        // DELETE: api/Vendedores/5
        [ResponseType(typeof(Vendedores))]
        public async Task<IHttpActionResult> DeleteVendedores(int id)
        {
            Vendedores vendedores = await db.Vendedores.FindAsync(id);
            if (vendedores == null)
            {
                return NotFound();
            }

            db.Vendedores.Remove(vendedores);
            await db.SaveChangesAsync();

            return Ok(vendedores);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VendedoresExists(int id)
        {
            return db.Vendedores.Count(e => e.Id == id) > 0;
        }
    }
}