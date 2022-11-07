using System;
using System.Collections.Generic;

namespace MultiTracks.API.Models
{
    public partial class Artist
    {
       
        public int ArtistId { get; set; }
        public DateTime DateCreation { get; set; }
        public string Title { get; set; } = null!;
        public string Biography { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string HeroUrl { get; set; } = null!;
    }
}
