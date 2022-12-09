using Microsoft.VisualBasic;
using System.Text.Json.Serialization;

namespace MoviesForYou.Application.API.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Plot { get; set; } = string.Empty;
        public DateTime? DateOfRelease { get; set; }
        public Producer? Producer { get; set; }
        public List<Actor>? Actors { get; set; }

    }
}
