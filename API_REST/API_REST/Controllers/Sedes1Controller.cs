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
using API_REST.Models;

namespace API_REST.Controllers
{
    public class Sedes1Controller : ApiController
    {
        private Prueba2Entities2 db = new Prueba2Entities2();

        // GET: api/Sedes1
        public IQueryable<Sede> GetSedes()
        {
            return db.Sedes;
        }

        // GET: api/Sedes1/5
        [ResponseType(typeof(Sede))]
        public async Task<IHttpActionResult> GetSede(int id)
        {
            Sede sede = await db.Sedes.FindAsync(id);
            if (sede == null)
            {
                return NotFound();
            }

            return Ok(sede);
        }

        // PUT: api/Sedes1/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSede(int id, Sede sede)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sede.Id)
            {
                return BadRequest();
            }

            db.Entry(sede).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SedeExists(id))
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

        // POST: api/Sedes1
        [ResponseType(typeof(Sede))]
        public async Task<IHttpActionResult> PostSede(Sede sede)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sedes.Add(sede);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SedeExists(sede.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sede.Id }, sede);
        }

        // DELETE: api/Sedes1/5
        [ResponseType(typeof(Sede))]
        public async Task<IHttpActionResult> DeleteSede(int id)
        {
            Sede sede = await db.Sedes.FindAsync(id);
            if (sede == null)
            {
                return NotFound();
            }

            db.Sedes.Remove(sede);
            await db.SaveChangesAsync();

            return Ok(sede);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SedeExists(int id)
        {
            return db.Sedes.Count(e => e.Id == id) > 0;
        }
    }
}