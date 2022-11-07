using MultiTracks.API.Core;
using MultiTracks.API.Dtos;
using MultiTracks.API.Models;
using System.Threading.Tasks;

namespace MultiTracks.API.Interfaces
{
    public interface IArtistRepository
    {
        Task<Result<Artist>> Search(string name);

        Task<Result<string>> Add(CreateArtistDto artist);
    }
}
