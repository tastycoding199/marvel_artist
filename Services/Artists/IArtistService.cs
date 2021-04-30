using MavelArtist.DTOs;
using MavelArtist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MavelArtist.Services.Artists
{
    public interface IArtistService
    {
        Task<List<GetArtistDTO>> GetArtists();
        Task<GetArtistDTO> GetArtist(int id);
        Task<bool> AddArtist(AddArtistDTO artistDTO);
        Task<bool> UpdateArtist(int id,AddArtistDTO artistDTO);
        Task<bool> DeleteArtist(int id);
    }
}
