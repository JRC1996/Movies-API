using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies_API.Models.Viewmodels;
using Movies_API.Models;
using Movies_API.Models.Response;
using Microsoft.AspNetCore.Authorization;

namespace Movies_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MoviesRatingController : ControllerBase
    {
        
        private readonly MoviesContext _context;

        public MoviesRatingController(MoviesContext context)
        {

            this._context = context;


        }

        [HttpGet]
        public IActionResult Get()
        {
            var response = new Response();

            try
            {
                var list = _context.MovieRatings.ToList();
                response.Success = 1;
                response.Message = "All ok";
                response.Data = list;


            }
            catch (Exception ex)
            {


                response.Message = ex.Message;
            }

            return Ok(response);
        }


        [HttpPost]

        public IActionResult Post(MovieRatingViewmodel moviesRatingsVM)
        {

            var response = new Response();

            try
            {
                MovieRating movieRating = new MovieRating();

                movieRating.Rating = moviesRatingsVM.Rating;
                _context.MovieRatings.Add(movieRating);
                _context.SaveChanges();
                response.Success = 1;
                response.Message = "All ok";






            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }


            return Ok(response);
        }

        [HttpPut]

        public IActionResult Put(MovieRatingViewmodel moviesRatingsVM)
        {

            var response = new Response();

            try
            {

                var movieRating = _context.MovieRatings.Find(moviesRatingsVM.Id);

                movieRating.Rating = moviesRatingsVM.Rating;
                _context.Entry(movieRating).State = EntityState.Modified;
                _context.SaveChanges();
                response.Success = 1;
                response.Message = "All ok";






            }
            catch (Exception ex)
            {
                response.Message = ex.Message;

            }


            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {

            var response = new Response();

            try
            {

                var movieRating = _context.MovieRatings.Find(Id);


                _context.Remove(movieRating);
                _context.SaveChanges();
                response.Success = 1;
                response.Message = "All ok";





            }
            catch (Exception ex)
            {
                response.Message = ex.Message;

            }



            return Ok(response);
        }
        
    }

}

