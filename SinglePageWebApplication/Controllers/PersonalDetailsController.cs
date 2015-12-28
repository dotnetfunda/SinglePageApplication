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
using SinglePageWebApplication.Models;
using WebApplication1.Models;

namespace SinglePageWebApplication.Controllers
{
    public class PersonalDetailsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/PersonalDetails
        public IQueryable<PersonalDetail> GetPersonalDetails()
        {
            return db.PersonalDetails;
        }

        // GET: api/PersonalDetails/5
        [ResponseType(typeof(PersonalDetail))]
        public async Task<IHttpActionResult> GetPersonalDetail(int id)
        {
            PersonalDetail personalDetail = await db.PersonalDetails.FindAsync(id);
            if (personalDetail == null)
            {
                return NotFound();
            }

            return Ok(personalDetail);
        }

        // PUT: api/PersonalDetails/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPersonalDetail(int id, PersonalDetail personalDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personalDetail.AutoId)
            {
                return BadRequest();
            }

            db.Entry(personalDetail).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalDetailExists(id))
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

        // POST: api/PersonalDetails
        [ResponseType(typeof(PersonalDetail))]
        public async Task<IHttpActionResult> PostPersonalDetail(PersonalDetail personalDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PersonalDetails.Add(personalDetail);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = personalDetail.AutoId }, personalDetail);
        }

        // DELETE: api/PersonalDetails/5
        [ResponseType(typeof(PersonalDetail))]
        public async Task<IHttpActionResult> DeletePersonalDetail(int id)
        {
            PersonalDetail personalDetail = await db.PersonalDetails.FindAsync(id);
            if (personalDetail == null)
            {
                return NotFound();
            }

            db.PersonalDetails.Remove(personalDetail);
            await db.SaveChangesAsync();

            return Ok(personalDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonalDetailExists(int id)
        {
            return db.PersonalDetails.Count(e => e.AutoId == id) > 0;
        }
    }
}