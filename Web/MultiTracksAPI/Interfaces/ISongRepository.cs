using MultiTracksAPI.Core;
using MultiTracksAPI.Models;
using System.Threading.Tasks;

namespace MultiTracksAPI.Interfaces
{
    public interface ISongRepository
    {
        Task<Result<PagedList<Song>>> GetSongs(int pageNumber, int pageSize);
    }
}
