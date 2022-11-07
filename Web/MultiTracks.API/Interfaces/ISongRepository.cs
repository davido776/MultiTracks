using MultiTracks.API.Core;
using MultiTracks.API.Models;

namespace MultiTracks.API.Interfaces
{
    public interface ISongRepository
    {
        Task<Result<PagedList<Song>>> GetSongs(int pageNumber, int pageSize);
    }
}
