using MavelArtist.DTOs;
using MavelArtist.Errors;
using MavelArtist.Models;
using MavelArtist.Services.Character;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MavelArtist.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {

        private readonly IMavelCharacterService _characterService;

        public CharacterController(IMavelCharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet("{id}")]
        public async Task<DataRespone<GetMavelCharacterDTO>> GetCharacter(int id)
        {
            if (id == 0)
            {
                throw new MyBadRequestException(HttpStatusCode.BadRequest,"Character must be not null.");
            }

            GetMavelCharacterDTO character = await _characterService.getCharacter(id);

            if (character == null)
            {
                throw new MyNotFoundException(HttpStatusCode.NotFound, "Character have not found.");
            }

            return new DataRespone<GetMavelCharacterDTO>() { Ok = true, data = character, error = "" };

        }

        [HttpPost]
        public async Task<DataRespone<string>> Add(AddMavelCharacterDTO character)
        {
            bool result = await _characterService.addCharacter(character);

            if (result) return new DataRespone<string>() { Ok = true, data = "A new Character has already added." ,error=""};
            return new DataRespone<string>() { Ok = false, data = "Something went wrong", error = "Adding an Character was failed." };
        }
    }
}
