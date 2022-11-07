using MultiTracksAPI.Core;
using MultiTracksAPI.Interfaces;
using MultiTracksAPI.Models;
using System.Threading.Tasks;

namespace MultiTracksAPI.Repositories
{
    public class SongRepository : ISongRepository
    {
        private readonly MultiTracksDBContext context;
        public SongRepository(MultiTracksDBContext Context)
        {
            context = Context;
        }

        public async Task<Result<PagedList<Song>>> GetSongs(int pageNumber, int pageSize)
        {
            var source = context.Songs.AsQueryable();
            return Result<PagedList<Song>>.Success(await PagedList<Song>.CreateAsync(source, pageNumber, pageSize));
        }
    }
}
