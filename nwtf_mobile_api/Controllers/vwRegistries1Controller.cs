using nwtf_mobile_api.Data;
using nwtf_mobile_api.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace nwtf_mobile_api.Controllers
{
    public class vwRegistries1Controller : ApiController
    {
        private nwtf_mobile_apidbContext db = new nwtf_mobile_apidbContext();

        // GET: api/vwRegistries1
        public IQueryable<vwRegistry> GetvwRegistries()
        {
            return db.vwRegistries;
        }

        // GET: api/vwRegistries1/5
        [ResponseType(typeof(vwRegistry))]
        public IHttpActionResult GetvwRegistry(Guid id)
        {
            vwRegistry vwRegistry = db.vwRegistries.Find(id);
            if (vwRegistry == null)
            {
                return NotFound();
            }

            return Ok(vwRegistry);
        }

        // PUT: api/vwRegistries1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutvwRegistry(Guid id, vwRegistry vwRegistry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vwRegistry.id)
            {
                return BadRequest();
            }

            db.Entry(vwRegistry).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!vwRegistryExists(id))
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

        // POST: api/vwRegistries1
        [ResponseType(typeof(vwRegistry))]
        public IHttpActionResult PostvwRegistry(vwRegistry vwRegistry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.vwRegistries.Add(vwRegistry);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (vwRegistryExists(vwRegistry.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = vwRegistry.id }, vwRegistry);
        }

        // DELETE: api/vwRegistries1/5
        [ResponseType(typeof(vwRegistry))]
        public IHttpActionResult DeletevwRegistry(Guid id)
        {
            vwRegistry vwRegistry = db.vwRegistries.Find(id);
            if (vwRegistry == null)
            {
                return NotFound();
            }

            db.vwRegistries.Remove(vwRegistry);
            db.SaveChanges();

            return Ok(vwRegistry);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool vwRegistryExists(Guid id)
        {
            return db.vwRegistries.Count(e => e.id == id) > 0;
        }
    }
}