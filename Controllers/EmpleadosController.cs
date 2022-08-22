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
    public class EmpleadosController : ApiController
    {
        private MVP_ASPContext db = new MVP_ASPContext();

        // GET: api/Empleados
        public IQueryable<Empleados> GetEmpleados()
        {
            return db.Empleados;
        }

        // GET: api/Empleados/5
        [ResponseType(typeof(Empleados))]
        public async Task<IHttpActionResult> GetEmpleados(int id)
        {
            Empleados empleados = await db.Empleados.FindAsync(id);
            if (empleados == null)
            {
                return NotFound();
            }

            return Ok(empleados);
        }

        // PUT: api/Empleados/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEmpleados(int id, Empleados empleados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != empleados.Id)
            {
                return BadRequest();
            }

            db.Entry(empleados).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Empleados
        [ResponseType(typeof(Empleados))]
        public async Task<IHttpActionResult> PostEmpleados(Empleados empleados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Empleados.Add(empleados);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = empleados.Id }, empleados);
        }

        // DELETE: api/Empleados/5
        [ResponseType(typeof(Empleados))]
        public async Task<IHttpActionResult> DeleteEmpleados(int id)
        {
            Empleados empleados = await db.Empleados.FindAsync(id);
            if (empleados == null)
            {
                return NotFound();
            }

            db.Empleados.Remove(empleados);
            await db.SaveChangesAsync();

            return Ok(empleados);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmpleadosExists(int id)
        {
            return db.Empleados.Count(e => e.Id == id) > 0;
        }
    }
}