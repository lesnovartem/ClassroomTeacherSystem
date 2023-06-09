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
    public class Student_LessonController : ApiController
    {
        private DBCollegeEntities db = new DBCollegeEntities();

        // GET: api/Student_Lesson
        public IQueryable<Student_Lesson> GetStudent_Lesson()
        {
            return db.Student_Lesson;
        }

        // GET: api/Student_Lesson/5
        [ResponseType(typeof(Student_Lesson))]
        public IHttpActionResult GetStudent_Lesson(int id)
        {
            Student_Lesson student_Lesson = db.Student_Lesson.Find(id);
            if (student_Lesson == null)
            {
                return NotFound();
            }

            return Ok(student_Lesson);
        }

        // PUT: api/Student_Lesson/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudent_Lesson(int id, Student_Lesson student_Lesson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != student_Lesson.Id)
            {
                return BadRequest();
            }

            db.Entry(student_Lesson).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Student_LessonExists(id))
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

        // POST: api/Student_Lesson
        [ResponseType(typeof(Student_Lesson))]
        public IHttpActionResult PostStudent_Lesson(Student_Lesson student_Lesson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Student_Lesson.Add(student_Lesson);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = student_Lesson.Id }, student_Lesson);
        }

        // DELETE: api/Student_Lesson/5
        [ResponseType(typeof(Student_Lesson))]
        public IHttpActionResult DeleteStudent_Lesson(int id)
        {
            Student_Lesson student_Lesson = db.Student_Lesson.Find(id);
            if (student_Lesson == null)
            {
                return NotFound();
            }

            db.Student_Lesson.Remove(student_Lesson);
            db.SaveChanges();

            return Ok(student_Lesson);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Student_LessonExists(int id)
        {
            return db.Student_Lesson.Count(e => e.Id == id) > 0;
        }
    }
}