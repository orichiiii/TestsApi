using Newtonsoft.Json;
using OpenQA.Selenium.Remote;
using RestSharp;
using System;
using System.Collections.Generic;
using TestProject1.Models.Client;

namespace TestProject1.ApiRequests.Auth
{
    public static class AuthRequests
    {
        public static ClientAuthModel SendRequestClientSignUpPost(Dictionary<string, string> user)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/auth/client/signup/");
            var request = new RestRequest(Method.POST);

            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(user);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var createdUser = JsonConvert.DeserializeObject<ClientAuthModel>(response.Content);

            return createdUser;
        }

        public static ResponceModel<ClientAuthModel> SendRequestClientSignInPost(Dictionary<string, string> user)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/auth/signin/");
            var request = new RestRequest(Method.POST);

            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(user);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var authUser = JsonConvert.DeserializeObject<ClientAuthModel>(response.Content);

            return new ResponceModel<ClientAuthModel> { Model = authUser, Response = response };
        }

        public static ClientAuthModel CreateUserViaApi()
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/auth/client/signup/");
            var request = new RestRequest(Method.POST);
            var user = new Dictionary<string, string>
             {
                 { "email", $"as2sd2asd{DateTime.Now:ddyyyymmHHssmm}@asdasd.ert" },
                 { "first_name", "asdasdasd" },
                 { "last_name", "asdasdasd" },
                 { "password", "123qwe!QWE" },
                 { "phone_number", "3453453454" }
             };

            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(user);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var createdUser = JsonConvert.DeserializeObject<ClientAuthModel>(response.Content);

            return createdUser;
        }

        public class ResponceModel<T>
        {
            public T Model { get; set; }
            public IRestResponse Response { get; set; }
        }
    }
}
