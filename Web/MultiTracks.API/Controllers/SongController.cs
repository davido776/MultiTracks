using Microsoft.AspNetCore.Mvc;
using MultiTracks.API.Core;
using MultiTracks.API.Interfaces;
using MultiTracks.API.Models;

namespace MultiTracks.API.Controllers
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
            return HandleResult<PagedList<Song>>(await songRepository.GetSongs(pageNumber,pageize));
        }
    }
}
