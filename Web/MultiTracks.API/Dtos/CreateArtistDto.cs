using System.Text.Json.Serialization;

namespace MultiTracks.API.Dtos
{
    public class CreateArtistDto
    {
        //public int ArtistId { get; set; }

        [JsonIgnore]
        public DateTime DateCreation { get; set; } = DateTime.Now;
        public string Title { get; set; } = null!;
        public string Biography { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string HeroUrl { get; set; } = null!;
    }
}
