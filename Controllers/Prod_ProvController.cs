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
    public class Prod_ProvController : ApiController
    {
        private MVP_ASPContext db = new MVP_ASPContext();

        // GET: api/Prod_Prov
        public IQueryable<Prod_Prov> GetProd_Prov()
        {
            return db.Prod_Prov;
        }

        // GET: api/Prod_Prov/5
        [ResponseType(typeof(Prod_Prov))]
        public async Task<IHttpActionResult> GetProd_Prov(int id)
        {
            Prod_Prov prod_Prov = await db.Prod_Prov.FindAsync(id);
            if (prod_Prov == null)
            {
                return NotFound();
            }

            return Ok(prod_Prov);
        }

        // PUT: api/Prod_Prov/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProd_Prov(int id, Prod_Prov prod_Prov)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prod_Prov.Id)
            {
                return BadRequest();
            }

            db.Entry(prod_Prov).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Prod_ProvExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(prod_Prov);
        }

        // POST: api/Prod_Prov
        [ResponseType(typeof(Prod_Prov))]
        public async Task<IHttpActionResult> PostProd_Prov(Prod_Prov prod_Prov)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Prod_Prov.Add(prod_Prov);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = prod_Prov.Id }, prod_Prov);
        }

        // DELETE: api/Prod_Prov/5
        [ResponseType(typeof(Prod_Prov))]
        public async Task<IHttpActionResult> DeleteProd_Prov(int id)
        {
            Prod_Prov prod_Prov = await db.Prod_Prov.FindAsync(id);
            if (prod_Prov == null)
            {
                return NotFound();
            }

            db.Prod_Prov.Remove(prod_Prov);
            await db.SaveChangesAsync();

            return Ok(prod_Prov);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Prod_ProvExists(int id)
        {
            return db.Prod_Prov.Count(e => e.Id == id) > 0;
        }
    }
}