using AutoMapper;
using MultiTracksAPI.Dtos;
using MultiTracksAPI.Models;

namespace MultiTracksAPI.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateArtistDto, Artist>()
                .ReverseMap();

        }
    }
}
