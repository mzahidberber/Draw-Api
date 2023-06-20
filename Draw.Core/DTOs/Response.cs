using Draw.Entities.Abstract;
using System.Text.Json.Serialization;

namespace Draw.Core.DTOs
{
    public class Response<T>
        where T: class 
    {
        public T data { get; set; }
        public int statusCode { get; set; }
        [JsonIgnore]
        public bool IsSuccesful { get; private set; }
        public ErrorDto error { get; set; }

        public static Response<T> Success(T data, int statusCode)
        {
            return new Response<T> { data = data, statusCode = statusCode, IsSuccesful = true };
        }

        public static Response<T> Success(int statusCode)
        {
            return new Response<T> { data = default, statusCode = statusCode, IsSuccesful = true };
        }

        public static Response<T> Fail(ErrorDto error, int statusCode)
        {
            return new Response<T> { error = error, statusCode = statusCode, IsSuccesful = false };
        }

        public static Response<T> Fail(string errorMessage, int statusCode, bool isShow)
        {
            var errorDto = new ErrorDto(errorMessage, isShow);
            return new Response<T> { error = errorDto, statusCode = statusCode, IsSuccesful = false };
        }
    }
}
