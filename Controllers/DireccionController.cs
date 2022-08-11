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
    public class DireccionController : ApiController
    {
        private MVP_ASPContext db = new MVP_ASPContext();

        // GET: api/Direccion
        public IQueryable<Direccion> GetDireccion()
        {
            return db.Direccion;
        }

        // GET: api/Direccion/5
        [ResponseType(typeof(Direccion))]
        public async Task<IHttpActionResult> GetDireccion(int id)
        {
            Direccion direccion = await db.Direccion.FindAsync(id);
            if (direccion == null)
            {
                return NotFound();
            }

            return Ok(direccion);
        }

        // PUT: api/Direccion/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDireccion(int id, Direccion direccion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != direccion.Id)
            {
                return BadRequest();
            }

            db.Entry(direccion).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DireccionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(direccion);
        }

        // POST: api/Direccion
        [ResponseType(typeof(Direccion))]
        public async Task<IHttpActionResult> PostDireccion(Direccion direccion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Direccion.Add(direccion);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = direccion.Id }, direccion);
        }

        // DELETE: api/Direccion/5
        [ResponseType(typeof(Direccion))]
        public async Task<IHttpActionResult> DeleteDireccion(int id)
        {
            Direccion direccion = await db.Direccion.FindAsync(id);
            if (direccion == null)
            {
                return NotFound();
            }

            db.Direccion.Remove(direccion);
            await db.SaveChangesAsync();

            return Ok(direccion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DireccionExists(int id)
        {
            return db.Direccion.Count(e => e.Id == id) > 0;
        }
    }
}