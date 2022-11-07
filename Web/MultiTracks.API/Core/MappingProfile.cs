using AutoMapper;
using MultiTracks.API.Dtos;
using MultiTracks.API.Models;

namespace MultiTracks.API.Core
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
