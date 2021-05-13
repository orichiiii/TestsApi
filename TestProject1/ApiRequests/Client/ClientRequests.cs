using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject1.Models.Client;

namespace TestProject1.ApiRequests.Client
{
    public static class ClientRequests
    {
        public static string SenRequestChangeClientEmailPost(string password, string email, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/change_email/");
            var request = new RestRequest(Method.POST);
            var newEmailModel = new Dictionary<string, string>
             {
                 { "email", email },
                 { "password", password }
             };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newEmailModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var ChangeEmailResponse = JsonConvert.DeserializeObject<ChangeEmailResponse>(response.Content);

            return ChangeEmailResponse.Email;
        }

        public static User SendRequestChangeGeneralInformationPost(string firstName, string lastName, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/self/");
            var request = new RestRequest(Method.PATCH);
            var newGenaralInfoModel = new Dictionary<string, string>
             {
                 { "first_name", firstName },
                 { "last_name", lastName }
             };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newGenaralInfoModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var ChangeNameResponse = JsonConvert.DeserializeObject<User>(response.Content);

            return ChangeNameResponse;
        }
    }
}
