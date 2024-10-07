using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies_API.Models;
using Movies_API.Models.Response;
using Movies_API.Models.Viewmodels;

namespace Movies_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {


        private readonly MoviesContext _context;
        public MoviesController(MoviesContext context)
        {
            this._context = context;

        }

        [HttpGet]

        public IActionResult Get()
        {
            Response response = new Response();


            try
            {
                using (_context)
                {
                    var list = _context.Movies.Include(g => g.IdGenreNavigation)
                        .Include(r => r.IdAgeRatingNavigation).Select(m => new MovieViewmodel
                        {
                            Id = m.Id,
                            Name = m.Name,
                            IdGenre = m.IdGenreNavigation.Id,
                            Genre = m.IdGenreNavigation.Genre1,
                            IdAgeRating = m.IdAgeRatingNavigation.Id,
                            Rating = m.IdAgeRatingNavigation.Rating,
                            ReleaseDate = m.ReleaseDate,
                        }).ToList();

                    response.Success = 1;
                    response.Data = list;



                }



            }
            catch (Exception ex)
            {

                response.Message = ex.Message;


            }
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Add(MovieViewmodel moviesVm)
        {
            Response response = new Response();

            using (var transaction = _context.Database.BeginTransaction())
            {

                try
                {


                    Movie movies = new Movie();


                    movies.Name = moviesVm.Name;
                    movies.IdGenre = moviesVm.IdGenre;
                    movies.IdAgeRating = moviesVm.IdAgeRating;
                    movies.ReleaseDate = moviesVm.ReleaseDate;

                    _context.Movies.Add(movies);
                    _context.SaveChanges();
                    transaction.Commit();



                    response.Success = 1;


                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    response.Message = ex.Message;


                }



            }
            return Ok(response);
        }

        [HttpPut]


        public IActionResult Put(MovieViewmodel moviesVm)
        {
            Response response = new Response();

            using (var transaction = _context.Database.BeginTransaction())
            {

                try
                {


                    var movies = _context.Movies.Find(moviesVm.Id);

                    movies.Name = moviesVm.Name;
                    movies.IdGenre = moviesVm.IdGenre;
                    movies.IdAgeRating = moviesVm.IdAgeRating;
                    movies.ReleaseDate = moviesVm.ReleaseDate;
                    _context.Entry(movies).State = EntityState.Modified;
                    _context.SaveChanges();



                    transaction.Commit();
                    response.Success = 1;


                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    response.Message = ex.Message;


                }


            }


            return Ok(response);
        }


        [HttpDelete("{Id}")]

        public IActionResult Delete(int Id)
        {
            Response response = new Response();

            using (var transaction = _context.Database.BeginTransaction())
            {

                try
                {


                    var movies = _context.Movies.Find(Id);

                    _context.Remove(movies);
                    _context.SaveChanges();



                    transaction.Commit();
                    response.Success = 1;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    response.Message = ex.Message;

                }


            }


            return Ok(response);
        }


    }


}

