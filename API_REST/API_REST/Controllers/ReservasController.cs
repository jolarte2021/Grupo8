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
    public class ReservasController : ApiController
    {
        private Prueba2Entities2 db = new Prueba2Entities2();

        // GET: api/Reservas/GetReservas
        public IQueryable<Reserva> GetReservas()
        {
            return db.Reservas;
        }


        // GET: api/Reservas/GetReservaById
        [ResponseType(typeof(Reserva))]
        public async Task<IHttpActionResult> GetReserva(int id)
        {
            Reserva reserva = await db.Reservas.FindAsync(id);

            if (reserva == null)
            {
                return NotFound();
            }

            return Ok(reserva);
        }

        // PUT: api/Reservas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutReserva(int id, Reserva reserva)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reserva.Cod_Reserva)
            {
                return BadRequest();
            }

            db.Entry(reserva).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservaExists(id))
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

        // POST: api/Reservas
        [ResponseType(typeof(Reserva))]
        public async Task<IHttpActionResult> PostReserva(Reserva reserva)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Reservas.Add(reserva);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ReservaExists(reserva.Cod_Reserva))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = reserva.Cod_Reserva }, reserva);
        }

        // DELETE: api/Reservas/5
        [ResponseType(typeof(Reserva))]
        public async Task<IHttpActionResult> DeleteReserva(int id)
        {
            Reserva reserva = await db.Reservas.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }

            db.Reservas.Remove(reserva);
            await db.SaveChangesAsync();

            return Ok(reserva);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReservaExists(int id)
        {
            return db.Reservas.Count(e => e.Cod_Reserva == id) > 0;
        }
    }
}