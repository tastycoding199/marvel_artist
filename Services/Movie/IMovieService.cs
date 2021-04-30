using MavelArtist.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MavelArtist.Services.Movie
{
    public interface IMovieService
    {
        Task<List<GetMovieDTO>> getMovie(int ArtistID);
        Task<bool> addMovie(AddMovieDTO movie);
    }
}
