using RestSharp;

namespace ApiTests.Models
{
    public class ResponseModel<T>
    {
        public T Model { get; set; }
        public IRestResponse Response { get; set; }
    }
}
