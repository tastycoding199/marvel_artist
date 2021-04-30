using MavelArtist.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MavelArtist.DTOs
{
    public class GetArtistDTO
    {

        public int ArtistId { get; set; }

        public string Name { get; set; }

        public DateTime DayOfBirth { get; set; }

        
        public string Education { get; set; }

       
        public string Hometown { get; set; }
    }
}
