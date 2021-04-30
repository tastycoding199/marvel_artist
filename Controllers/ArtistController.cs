using MavelArtist.DTOs;
using MavelArtist.Errors;
using MavelArtist.Models;
using MavelArtist.Services.Artists;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace MavelArtist.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _artistService;

        public ArtistController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        [HttpGet]
        public async Task<DataRespone<List<GetArtistDTO>>> getArtists()
        {
            List<GetArtistDTO> artists = await _artistService.GetArtists();
            return new DataRespone<List<GetArtistDTO>>() { Ok = true, data = artists, error = "" };
        }

        [HttpGet("{id}")]
        public async Task<DataRespone<GetArtistDTO>> getArtist(int id)
        {
            if (id == 0)
            {
                throw new MyBadRequestException(HttpStatusCode.BadRequest, "ArtistID must be not null.");
            }
            GetArtistDTO artist = await _artistService.GetArtist(id);

            if (artist == null)
            {
                throw new MyNotFoundException(HttpStatusCode.NotFound, "Artist have not found.");
            }
            return new DataRespone<GetArtistDTO>() { Ok = true, data = artist, error = "" };
        }

        [HttpPost]
        public async Task<DataRespone<string>> Add(AddArtistDTO artistDTO)
        {
            bool result = await _artistService.AddArtist(artistDTO);
            if (result) return new DataRespone<string>() { Ok = true, data = "The new artist has added.", error = "" };
            return new DataRespone<string>() { Ok = false, data = "Something went wrong.", error = "Adding an Artist was not success." };
        }

        [HttpPut("{id}")]
        public async Task<DataRespone<string>> Update(int id,AddArtistDTO artistDTO)
        {
            bool result = await _artistService.UpdateArtist(id, artistDTO);
            if (result) return new DataRespone<string>() { Ok = true, data = "Artist "+id+" has been updated.", error = "" };
            throw new MyNotFoundException(HttpStatusCode.NotFound, "Artist have not found.");
        }

        [HttpDelete("{id}")]
        public async Task<DataRespone<string>> Delete(int id)
        {
            bool result = await _artistService.DeleteArtist(id);
            if (result) return new DataRespone<string>() { Ok = true, data = "Artist " + id + " has been removed.", error = "" };
            throw new MyNotFoundException(HttpStatusCode.NotFound, "Artist have not found.");
        }
    }
}
