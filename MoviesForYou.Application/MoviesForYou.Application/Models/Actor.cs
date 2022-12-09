using Microsoft.VisualBasic;

namespace MoviesForYou.Application.API.Models
{
    public class Actor
    {
        public int ActorId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public GenderOption Gender { get; set; }
        public List<Movie>? Movies { get; set;}
    }
}
