//using MoviesForYou.Application.API.Models;
//using System.Net;

//namespace MoviesForYou.Application.API.Helpers
//{
//    public class CustomResponseHandler : DelegatingHandler
//    {
//        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
//        {
//            var response = await base.SendAsync(request, cancellationToken);
//            try
//            {
//                return GenerateResponse(request, response);
//            }
//            catch (Exception ex)
//            {
//                return request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
//            }
//        }
//        private HttpResponseMessage GenerateResponse(HttpRequestMessage request, HttpResponseMessage response)
//        {
//            string errorMessage = null;
//            HttpStatusCode statusCode = response.StatusCode;
//            if (!IsResponseValid(response))
//            {
//                return request.CreateResponse(HttpStatusCode.BadRequest, "Invalid response..");
//            }
//            object responseContent;
//            if (response.TryGetContentValue(out responseContent))
//            {
//                HttpError httpError = responseContent as HttpError;
//                if (httpError != null)
//                {
//                    errorMessage = httpError.Message;
//                    statusCode = HttpStatusCode.InternalServerError;
//                    responseContent = null;
//                }
//            }
//            ResponseMetadata responseMetadata = new ResponseMetadata();
//            responseMetadata.Version = "1.0";
//            responseMetadata.StatusCode = statusCode;
//            responseMetadata.Content = responseContent;
//            DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond);
//            responseMetadata.Timestamp = dt;
//            responseMetadata.ErrorMessage = errorMessage;
//            responseMetadata.Size = responseContent.ToString().Length;
//            var result = request.CreateResponse(response.StatusCode, responseMetadata);
//            return result;
//        }
//        private bool IsResponseValid(HttpResponseMessage response)
//        {
//            if ((response != null) && (response.StatusCode == HttpStatusCode.OK))
//                return true;
//            return false;
//        }
//    }
//}
