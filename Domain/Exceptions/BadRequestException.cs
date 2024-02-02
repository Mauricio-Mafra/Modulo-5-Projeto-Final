using Domain.Responses;
using System.Text.Json;

namespace Domain.Exceptions
{
    public class BadRequestException : Exception, ICustomException
    {
        public int StatusCode { get => 400; }

        public string GetResponse()
        {
            return JsonSerializer.Serialize(new ErrorResponse(base.Message));
        }
    }
}
