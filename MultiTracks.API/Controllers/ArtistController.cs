using Microsoft.AspNetCore.Mvc;
using MultiTracks.API.Interfaces;

namespace MultiTracks.API.Controllers
{
    public class ArtistController : ControllerBase
    {
        private readonly IArtistRepository artistRepository;

        public ArtistController(IArtistRepository ArtistRepository)
        {
            artistRepository = ArtistRepository;
        }

        //[HttpGet("/search")]
        //public ActionResult Search([FromQuery] string name)
        //{
        //    return Ok(artistRepository.Search(name));
        //}

        //[HttpPost("")]
        //public ActionResult Add([FromBody] Artist artist)
        //{
        //    var res = artistRepository.Add(artist);
        //    if(res > 0) return BadRequest();
        //    return NoContent();
        //}
    }
}
