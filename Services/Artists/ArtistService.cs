using AutoMapper;
using MavelArtist.Data;
using MavelArtist.DTOs;
using MavelArtist.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MavelArtist.Services.Artists
{
    public class ArtistService : IArtistService
    {
        private readonly ArtistContext _db;
        private readonly IMapper _mapper;
        public ArtistService(ArtistContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        

        public async Task<List<GetArtistDTO>> GetArtists()
        {
            List<GetArtistDTO> artists = await _db.Artists.Select(p => _mapper.Map<GetArtistDTO>(p)).AsNoTracking().ToListAsync();

            return artists;
        }



        public async Task<GetArtistDTO> GetArtist(int id)
        {
            Artist artist = await _db.Artists.AsNoTracking().FirstOrDefaultAsync(p => p.ArtistId == id);
            GetArtistDTO artistdto = _mapper.Map<GetArtistDTO>(artist);
            return artistdto;
        }

        public async Task<bool> AddArtist(AddArtistDTO artistDTO)
        {
            Artist artist = _mapper.Map<Artist>(artistDTO);
            _db.Artists.Add(artist);
            return await _db.SaveChangesAsync() > 0;
        }



        public async Task<bool> UpdateArtist(int id,AddArtistDTO artistDTO)
        {
            Artist artist = await _db.Artists.FindAsync(id);
            if (artist != null)
            {
                Artist artist1 = _mapper.Map<Artist>(artistDTO);

                artist.Name = artist1.Name;
                artist.DayOfBirth = artist1.DayOfBirth;
                artist.Education = artist1.Education;
                artist.Hometown = artist1.Hometown;

                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteArtist(int id)
        {
            Artist artist = await _db.Artists.FindAsync(id);
            if (artist != null)
            {
                _db.Artists.Remove(artist);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
