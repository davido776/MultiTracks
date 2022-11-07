using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultiTracks.API.Core;
using MultiTracks.API.Dtos;
using MultiTracks.API.Interfaces;
using MultiTracks.API.Models;

namespace MultiTracks.API.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly MultiTracksDBContext context;
        private readonly IMapper mapper;
        public ArtistRepository(MultiTracksDBContext Context, IMapper Mapper)
        {
            context = Context;
            mapper = Mapper;
        }

        public async Task<Result<string>> Add(CreateArtistDto request)
        {
            var artist = mapper.Map<Artist>(request);

            await context.Artists.AddAsync(artist);
            
            var res = await context.SaveChangesAsync();

            if(res > 0) return Result<string>.Success($"Artist Creation Successful with id {artist.ArtistId}");

            return Result<string>.Failure("Something went wrong");
        }

        public async Task<Result<Artist>> Search(string name)
        {
            //if (string.IsNullOrWhiteSpace(name)) return Result<Artist>.Failure("Please use a valid name");

            var artist = await context.Artists.FirstOrDefaultAsync(a => a.Title == name);

            return Result<Artist>.Success(artist);
        }
    }
}
