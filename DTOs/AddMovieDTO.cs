using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MavelArtist.DTOs
{
    public class AddMovieDTO
    {
        public string Name { get; set; }


        public int ReleaseYear { get; set; }


        public string Role { get; set; }

        public int ArtistId { get; set; }
    }
}
