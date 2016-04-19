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
using System.Reflection;
using BookService.Models;

namespace BookService.Controllers
{
    public class BooksController : ApiController
    {
        private BookServiceContext db = new BookServiceContext();

        // GET: api/Books
        /// <summary>
        /// Get all books.
        /// </summary>
        public IQueryable<Book> GetBooks()
        {
            Uri uri = Request.RequestUri;
            SimpleLog.WriteStdOut(uri.ToString());

            return db.Books.Include(b => b.Author);
        }


        // GET: api/Books/5
        /// <summary>
        /// Get book by ID.
        /// </summary>
        [ResponseType(typeof(Book))]
        public async Task<IHttpActionResult> GetBook(int id)
        {
            Uri uri = Request.RequestUri;
            SimpleLog.WriteStdOut(uri.ToString());

            Book book = await db.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }
 

        // PUT: api/Books/5
        /// <summary>
        /// Update an existing book.
        /// </summary>
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBook(int id, Book book)
        {
            Uri uri = Request.RequestUri;
            SimpleLog.WriteStdOut(uri.ToString());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != book.Id)
            {
                return BadRequest();
            }

            db.Entry(book).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
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

        // POST: api/Books
        /// <summary>
        /// Create a new book.
        /// </summary>
        [ResponseType(typeof(Book))]
        public async Task<IHttpActionResult> PostBook(Book book)
        {
            Uri uri = Request.RequestUri;
            SimpleLog.WriteStdOut(uri.ToString());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Books.Add(book);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = book.Id }, book);
        }

        // DELETE: api/Books/5
        /// <summary>
        /// Delete a book.
        /// </summary>
        [ResponseType(typeof(Book))]
        public async Task<IHttpActionResult> DeleteBook(int id)
        {
            Uri uri = Request.RequestUri;
            SimpleLog.WriteStdOut(uri.ToString());

            Book book = await db.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            db.Books.Remove(book);
            await db.SaveChangesAsync();

            return Ok(book);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookExists(int id)
        {
            return db.Books.Count(e => e.Id == id) > 0;
        }
    }
}