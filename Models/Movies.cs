using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MavelArtist.Models
{
    public class Movies
    {
        [Required()]
        public int MovieId { get; set; }

        [StringLength(70)]
        [Required()]
        public string Name { get; set; }

        [Required()]
        public int ReleaseYear { get; set; }

        [StringLength(50)]
        [Required()]
        public string Role { get; set; }

        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}
