using AutoMapper;
using MavelArtist.Data;
using MavelArtist.DTOs;
using MavelArtist.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MavelArtist.Services.Movie
{
    public class MovieService : IMovieService
    {
        private readonly ArtistContext _db;
        private readonly IMapper _mapper;

        public MovieService(ArtistContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        
        public async Task<List<GetMovieDTO>> getMovie(int ArtistID)
        {
            List<GetMovieDTO> movies = await _db.Movies.Where(p=>p.ArtistId==ArtistID)
                .Select(p => _mapper.Map<GetMovieDTO>(p))
                .AsNoTracking().ToListAsync();

            return movies;
        }

        public async Task<bool> addMovie(AddMovieDTO movie)
        {
            Movies Movie = _mapper.Map<Movies>(movie);

            _db.Movies.Add(Movie);
            return await _db.SaveChangesAsync() > 0;
        }

    }
}
