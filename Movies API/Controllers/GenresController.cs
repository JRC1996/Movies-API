﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies.Models.ViewModels;
using Movies_API.Models;
using Movies_API.Models.Response;

namespace Movies_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class GenresController : ControllerBase
    {
        
        private readonly MoviesContext _context;

        public GenresController(MoviesContext context)
        {

            this._context = context;


        }

        [HttpGet]
        public IActionResult Get()
        {
            var response = new Response();

            try
            {
                var list = _context.Genres.ToList();
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
        [Authorize]
        public IActionResult Post(GenreViewModel genresVM)
        {

            var response = new Response();

            try
            {
                Genre genre = new Genre();

                genre.Genre1 = genresVM.Genre;
                _context.Genres.Add(genre);
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
        [Authorize]
        public IActionResult Put(GenreViewModel genreVM)
        {

            var response = new Response();

            try
            {

                var genre = _context.Genres.Find(genreVM.Id);

                genre.Genre1 = genreVM.Genre;
                _context.Entry(genre).State = EntityState.Modified;
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
        [Authorize]
        public IActionResult Delete(int Id)
        {

            var response = new Response();

            try
            {

                var genre = _context.Genres.Find(Id);


                _context.Remove(genre);
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
