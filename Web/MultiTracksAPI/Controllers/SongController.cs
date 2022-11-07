using Microsoft.AspNetCore.Mvc;
using MultiTracksAPI.Core;
using MultiTracksAPI.Interfaces;
using MultiTracksAPI.Models;
using System.Threading.Tasks;

namespace MultiTracksAPI.Controllers
{
    public class SongController : BaseApiController
    {
        private readonly ISongRepository songRepository;

        public SongController(ISongRepository SongRepository)
        {
            songRepository = SongRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int pageNumber, int pageize)
        {
            return HandleResult<PagedList<Song>>(await songRepository.GetSongs(pageNumber, pageize));
        }
    }
}
