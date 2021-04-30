using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MavelArtist.Models
{
    public class MavelCharacter
    {
        [Required()]
        public int CharacterId { get; set; }
        [StringLength(30)]
        [Required()]
        public string Name { get; set; }

        [StringLength(20)]
        [Required()]
        public string HeroName { get; set; }
        public string Power { get; set; }


        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}
