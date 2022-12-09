using Microsoft.VisualBasic;

namespace MoviesForYou.Application.API.Models
{
    public class Producer
    {
        public int ProducerId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public string Company { get; set; } = string.Empty;
        public GenderOption Gender { get; set; }
    }
}
