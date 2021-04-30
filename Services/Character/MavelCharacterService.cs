using AutoMapper;
using MavelArtist.Data;
using MavelArtist.DTOs;
using MavelArtist.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MavelArtist.Services.Character
{
    public class MavelCharacterService : IMavelCharacterService
    {
        private readonly ArtistContext _db;
        private readonly IMapper _mapper;

        public MavelCharacterService(ArtistContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

       

        public async Task<GetMavelCharacterDTO> getCharacter(int artistId)
        {
            MavelCharacter character = await _db.MavelCharacters.AsNoTracking().FirstOrDefaultAsync(p => p.ArtistId == artistId);

            GetMavelCharacterDTO mavelCharacterDTO = _mapper.Map<GetMavelCharacterDTO>(character);
            return mavelCharacterDTO;

        }

        public async Task<bool> addCharacter(AddMavelCharacterDTO character)
        {
            MavelCharacter mavelCharacter = _mapper.Map<MavelCharacter>(character);

            _db.MavelCharacters.Add(mavelCharacter);
            return await _db.SaveChangesAsync() > 0;
        }
    }
}
