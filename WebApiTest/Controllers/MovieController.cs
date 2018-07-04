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
using WebApiTest.Models;

namespace WebApiTest.Controllers
{
    public class MovieController : ApiController
    {
        private MovieModelDb db = new MovieModelDb();

        // GET: api/Movie
        public IQueryable<MovieModel> GetMovies()
        {
            return db.Movies;
        }

        // GET: api/Movie/5
        [ResponseType(typeof(MovieModel))]
        public IHttpActionResult GetMovieModel(int id)
        {
            MovieModel movieModel = db.Movies.Find(id);
            if (movieModel == null)
            {
                return NotFound();
            }

            return Ok(movieModel);
        }

        // PUT: api/Movie/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMovieModel(int id, MovieModel movieModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movieModel.id)
            {
                return BadRequest();
            }

            db.Entry(movieModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieModelExists(id))
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

        // POST: api/Movie
        [ResponseType(typeof(MovieModel))]
        public IHttpActionResult PostMovieModel(MovieModel movieModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Movies.Add(movieModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = movieModel.id }, movieModel);
        }

        // DELETE: api/Movie/5
        [ResponseType(typeof(MovieModel))]
        public IHttpActionResult DeleteMovieModel(int id)
        {
            MovieModel movieModel = db.Movies.Find(id);
            if (movieModel == null)
            {
                return NotFound();
            }

            db.Movies.Remove(movieModel);
            db.SaveChanges();

            return Ok(movieModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MovieModelExists(int id)
        {
            return db.Movies.Count(e => e.id == id) > 0;
        }
    }
}