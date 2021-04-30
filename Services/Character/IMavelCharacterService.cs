using MavelArtist.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MavelArtist.Services.Character
{
    public interface IMavelCharacterService
    {
        Task<GetMavelCharacterDTO> getCharacter(int artistId);
        Task<bool> addCharacter(AddMavelCharacterDTO character);
    }
}
