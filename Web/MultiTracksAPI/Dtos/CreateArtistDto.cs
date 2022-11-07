using System;
using System.Text.Json.Serialization;

namespace MultiTracksAPI.Dtos
{
    public class CreateArtistDto
    {
        [JsonIgnore]
        public DateTime DateCreation { get; set; } = DateTime.Now;
        public string Title { get; set; } = null!;
        public string Biography { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string HeroUrl { get; set; } = null!;
    }
}
