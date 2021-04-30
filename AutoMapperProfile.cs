using AutoMapper;
using MavelArtist.DTOs;
using MavelArtist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MavelArtist
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            
            CreateMap<GetArtistDTO, Artist>();
            CreateMap<Artist, GetArtistDTO>();


            CreateMap<AddArtistDTO,Artist>();



            CreateMap<MavelCharacter,GetMavelCharacterDTO>();

            CreateMap<AddMavelCharacterDTO,MavelCharacter>();


            CreateMap<Movies, GetMovieDTO>();

            CreateMap<AddMovieDTO,Movies>();

        }
    }
}
