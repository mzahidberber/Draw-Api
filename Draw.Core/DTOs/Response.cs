using Draw.Entities.Abstract;
using System.Text.Json.Serialization;

namespace Draw.Core.DTOs
{
    public class Response<T>
        where T: class 
    {
        public T? Data { get; set; }
        public int StatusCode { get; set; }
        [JsonIgnore]
        public bool IsSuccesful { get; private set; }
        public ErrorDto? Error { get; set; }

        public static Response<T> Success(T data, int statusCode)
        {
            return new Response<T> { Data = data, StatusCode = statusCode, IsSuccesful = true };
        }

        public static Response<T> Success(int statusCode)
        {
            return new Response<T> { Data = default, StatusCode = statusCode, IsSuccesful = true };
        }

        public static Response<T> Fail(ErrorDto error, int statusCode)
        {
            return new Response<T> { Error = error, StatusCode = statusCode, IsSuccesful = false };
        }

        public static Response<T> Fail(string errorMessage, int statusCode, bool isShow)
        {
            var errorDto = new ErrorDto(errorMessage, isShow);
            return new Response<T> { Error = errorDto, StatusCode = statusCode, IsSuccesful = false };
        }
    }
}
