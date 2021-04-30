using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MavelArtist.DTOs
{
    public class GetMavelCharacterDTO
    {
        public int CharacterId { get; set; }

        public string Name { get; set; }

        public string HeroName { get; set; }
        public string Power { get; set; }


        public int ArtistId { get; set; }
    }
}
