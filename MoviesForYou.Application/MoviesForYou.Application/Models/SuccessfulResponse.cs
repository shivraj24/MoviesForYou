namespace MoviesForYou.Application.API.Models
{
    public class SuccessfulResponse<T>
    {
        public T? Content { get; set; }
        public string message { get; set; } = string.Empty;

        public SuccessfulResponse(T content, string msg)
        {
            this.Content = content;
            this.message = msg;
        }
    }
}
