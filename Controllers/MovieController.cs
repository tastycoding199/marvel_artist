using MavelArtist.DTOs;
using MavelArtist.Errors;
using MavelArtist.Models;
using MavelArtist.Services.Movie;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MavelArtist.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }



        [HttpGet("{id}")]
        public async Task<DataRespone<List<GetMovieDTO>>> GetMovies(int id)
        {
            if (id == 0)
            {
                throw new MyBadRequestException(HttpStatusCode.BadRequest, "ArtistID is required.");
            }
            List<GetMovieDTO> movies = await _movieService.getMovie(id);

            if (movies == null)
            {
                throw new MyNotFoundException(HttpStatusCode.NotFound, "Movies have not found.");
            }
            return new DataRespone<List<GetMovieDTO>>() { Ok = true, data = movies, error = "" };
        }


        [HttpPost]
        public async Task<DataRespone<string>> Add(AddMovieDTO movie)
        {
            bool result = await _movieService.addMovie(movie);
            if (result) return new DataRespone<string>() { Ok = true, data = "The movie was added." ,error=""};
            return new DataRespone<string>() { Ok = false, data = "Something went wrong", error = "The movie was not added." };
        }
    }
}
