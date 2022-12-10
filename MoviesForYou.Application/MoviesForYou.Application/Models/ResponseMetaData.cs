using System.Net;

namespace MoviesForYou.Application.API.Models
{
    public class ResponseMetadata
    {
        public string Version { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public object Result { get; set; }
        public DateTime Timestamp { get; set; }
        public long? Size { get; set; }
        public object? Content { get; set; }
    }
}
