namespace MoviesForYou.Application.API.ExceptionHandler
{
    public abstract class CustomExceptionHandler : Exception
    {
        public CustomExceptionHandler(string message) : base(message)
        {

        }
    }

    public class NotFoundException : CustomExceptionHandler
    {
        public NotFoundException(string message) : base(message)
        {

        }
    }
    public class BadRequestException : CustomExceptionHandler
    {
        public BadRequestException(string message) : base(message)
        {

        }
    }
    public class InternalServerException : CustomExceptionHandler
    {
        public InternalServerException(string message) : base(message)
        {

        }
    }
}
