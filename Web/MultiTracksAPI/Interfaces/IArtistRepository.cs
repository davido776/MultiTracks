using MultiTracksAPI.Core;
using MultiTracksAPI.Dtos;
using MultiTracksAPI.Models;
using System.Threading.Tasks;

namespace MultiTracksAPI.Interfaces
{
    public interface IArtistRepository
    {
        Task<Result<Artist>> Search(string name);

        Task<Result<string>> Add(CreateArtistDto artist);
    }
}
