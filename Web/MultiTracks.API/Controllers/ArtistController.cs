using Microsoft.AspNetCore.Mvc;
using MultiTracks.API.Core;
using MultiTracks.API.Dtos;
using MultiTracks.API.Interfaces;
using MultiTracks.API.Models;

namespace MultiTracks.API.Controllers
{
    public class ArtistController : BaseApiController
    {
        private readonly IArtistRepository artistRepository;
        public ArtistController(IArtistRepository ArtistRepository)
        {
            artistRepository = ArtistRepository;
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string name)
        {
            return HandleResult<Artist>(await artistRepository.Search(name));
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateArtistDto request)
        {
            return HandleResult<string>(await artistRepository.Add(request));
        }
    }
}
