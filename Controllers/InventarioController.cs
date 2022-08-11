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
    public class InventarioController : ApiController
    {
        private MVP_ASPContext db = new MVP_ASPContext();

        // GET: api/Inventario
        public IQueryable<Inventario> GetInventarios()
        {
            return db.Inventario;
        }

        // GET: api/Inventario/5
        [ResponseType(typeof(Inventario))]
        public async Task<IHttpActionResult> GetInventario(int id)
        {
            Inventario inventario = await db.Inventario.FindAsync(id);
            if (inventario == null)
            {
                return NotFound();
            }

            return Ok(inventario);
        }

        // PUT: api/Inventario/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutInventario(int id, Inventario inventario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inventario.Id)
            {
                return BadRequest();
            }

            db.Entry(inventario).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
                
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(inventario);
        }

        // POST: api/Inventario
        [ResponseType(typeof(Inventario))]
        public async Task<IHttpActionResult> PostInventario(Inventario inventario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Inventario.Add(inventario);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = inventario.Id }, inventario);
        }

        // DELETE: api/Inventario/5
        [ResponseType(typeof(Inventario))]
        public async Task<IHttpActionResult> DeleteInventario(int id)
        {
            Inventario inventario = await db.Inventario.FindAsync(id);
            if (inventario == null)
            {
                return NotFound();
            }

            db.Inventario.Remove(inventario);
            await db.SaveChangesAsync();

            return Ok(inventario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InventarioExists(int id)
        {
            return db.Inventario.Count(e => e.Id == id) > 0;
        }
    }
}