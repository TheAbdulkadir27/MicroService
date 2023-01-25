using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FreeCourse.Shared
{
    //Static Factory Method
    public class Response<T>
    {
        public T Data { get; private set; }

        [JsonIgnore]
        public int StatusCode { get; private set; }

        [JsonIgnore]
        public bool IsSuccessfull { get; private set; }

        public List<string> Mistakes { get; private set; }
        public static Response<T> Success(T data, int statusCode)
        {
            return new Response<T> { Data = default(T), IsSuccessfull = true, StatusCode = statusCode };
        }
        public static Response<T> Success(int statuscode)
        {
            return new Response<T> { StatusCode = statuscode, IsSuccessfull = true};
        }

        public static Response<T> Fail(List<string> mistakes, int statuscode)
        {
            return new Response<T> { StatusCode = statuscode, Mistakes = mistakes, IsSuccessfull=false};
        }
        public static Response<T> Fail(string mistake, int statuscode)
        {
            return new Response<T> { IsSuccessfull = false, Mistakes = new List<string>() { mistake }, StatusCode = statuscode };
        }
    }
}
