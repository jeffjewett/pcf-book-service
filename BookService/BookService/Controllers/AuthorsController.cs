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
using System.Web.Http.Controllers;
using System.Web.Http.Description;
using System.Reflection;

using BookService.Models;

namespace BookService.Controllers
{
    public class AuthorsController : ApiController
    {
        private BookServiceContext db = new BookServiceContext();

        // GET: api/Authors
        /// <summary>
        /// Get all authors.
        /// </summary>
        public IQueryable<Author> GetAuthors()
        {
            Uri uri = Request.RequestUri;
            SimpleLog.WriteStdOut(uri.ToString());

            return db.Authors;
        }

        // GET: api/Authors/5
        /// <summary>
        /// Get an author by ID.
        /// </summary>
        [ResponseType(typeof(Author))]
        public async Task<IHttpActionResult> GetAuthor(int id)
        {
            Uri uri = Request.RequestUri;
            SimpleLog.WriteStdOut(uri.ToString());

            Author author = await db.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        // PUT: api/Authors/5
        /// <summary>
        /// Update an existing author.
        /// </
        /// summary>
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAuthor(int id, Author author)
        {
            Uri uri = Request.RequestUri;
            SimpleLog.WriteStdOut(uri.ToString());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != author.Id)
            {
                return BadRequest();
            }

            db.Entry(author).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(id))
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

        // POST: api/Authors
        /// <summary>
        /// Create a new author.
        /// </summary>
        [ResponseType(typeof(Author))]
        public async Task<IHttpActionResult> PostAuthor(Author author)
        {
            Uri uri = Request.RequestUri;
            SimpleLog.WriteStdOut(uri.ToString());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Authors.Add(author);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = author.Id }, author);
        }

        // DELETE: api/Authors/5
        /// <summary>
        /// Delete an author.
        /// </summary>
        [ResponseType(typeof(Author))]
        public async Task<IHttpActionResult> DeleteAuthor(int id)
        {
            Uri uri = Request.RequestUri;
            SimpleLog.WriteStdOut(uri.ToString());

            Author author = await db.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            db.Authors.Remove(author);
            await db.SaveChangesAsync();

            return Ok(author);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AuthorExists(int id)
        {
            return db.Authors.Count(e => e.Id == id) > 0;
        }
    }
}