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
    public class VentasController : ApiController
    {
        private MVP_ASPContext db = new MVP_ASPContext();

        // GET: api/Ventas
        public IQueryable<Ventas> GetVentas()
        {
            return db.Ventas;
        }

        // GET: api/Ventas/5
        [ResponseType(typeof(Ventas))]
        public async Task<IHttpActionResult> GetVentas(int id)
        {
            Ventas ventas = await db.Ventas.FindAsync(id);
            if (ventas == null)
            {
                return NotFound();
            }

            return Ok(ventas);
        }

        // PUT: api/Ventas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVentas(int id, Ventas ventas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ventas.Id)
            {
                return BadRequest();
            }

            db.Entry(ventas).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentasExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(ventas);
        }

        // POST: api/Ventas
        [ResponseType(typeof(Ventas))]
        public async Task<IHttpActionResult> PostVentas(Ventas ventas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ventas.Add(ventas);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = ventas.Id }, ventas);
        }

        // DELETE: api/Ventas/5
        [ResponseType(typeof(Ventas))]
        public async Task<IHttpActionResult> DeleteVentas(int id)
        {
            Ventas ventas = await db.Ventas.FindAsync(id);
            if (ventas == null)
            {
                return NotFound();
            }

            db.Ventas.Remove(ventas);
            await db.SaveChangesAsync();

            return Ok(ventas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VentasExists(int id)
        {
            return db.Ventas.Count(e => e.Id == id) > 0;
        }
    }
}