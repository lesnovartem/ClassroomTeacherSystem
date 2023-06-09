using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebCollege.Entities;

namespace WebCollege.Controllers
{
    public class JournalsController : ApiController
    {
        private DBCollegeEntities db = new DBCollegeEntities();

        // GET: api/Journals
        public IQueryable<Journal> GetJournal()
        {
            return db.Journal;
        }

        // GET: api/Journals/5
        [ResponseType(typeof(Journal))]
        public IHttpActionResult GetJournal(int id)
        {
            Journal journal = db.Journal.Find(id);
            if (journal == null)
            {
                return NotFound();
            }

            return Ok(journal);
        }

        // PUT: api/Journals/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJournal(int id, Journal journal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != journal.Id)
            {
                return BadRequest();
            }

            db.Entry(journal).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JournalExists(id))
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

        // POST: api/Journals
        [ResponseType(typeof(Journal))]
        public IHttpActionResult PostJournal(Journal journal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Journal.Add(journal);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = journal.Id }, journal);
        }

        // DELETE: api/Journals/5
        [ResponseType(typeof(Journal))]
        public IHttpActionResult DeleteJournal(int id)
        {
            Journal journal = db.Journal.Find(id);
            if (journal == null)
            {
                return NotFound();
            }

            db.Journal.Remove(journal);
            db.SaveChanges();

            return Ok(journal);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JournalExists(int id)
        {
            return db.Journal.Count(e => e.Id == id) > 0;
        }
    }
}