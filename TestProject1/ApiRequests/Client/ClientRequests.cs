using ApiTests.Models.Client;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace ApiTests.ApiRequests.Client
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

        public static User SendRequestChangeGeneralInforNameLastNamePatch(string firstName, string lastName, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/self/");
            var request = new RestRequest(Method.PATCH);
            var newGenaralInfoModel = new Dictionary<string, string>
             {
                 { "first_name", firstName },
                 { "last_name", lastName },
                 //{"location_admin1_code", "TN" },
                 //{"location_city_name", "Gatlinburg" },
                 {"location_name", "Gatlinburg, TN 37738, USA"},
                 {"location_timezone", "America/New_York" }
             };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newGenaralInfoModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var ChangeGeneralInfoResponse = JsonConvert.DeserializeObject<User>(response.Content);

            return ChangeGeneralInfoResponse;
        }

        public static ClientProfile SendRequestChangeGeneralInformationLocationIndustryPatch(string industry, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/profile/");
            var request = new RestRequest(Method.PATCH);
            var newGenaralInfoModel = new Dictionary<string, string>
             {
                 {"industry", industry },
                 //{"location_admin1_code", "TN" },
                 //{"location_city_name", "Gatlinburg" },
                 {"location_name", "Gatlinburg, TN 37738, USA"},
                 {"location_timezone", "America/New_York" }
             };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newGenaralInfoModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var ChangeGeneralInfoResponse = JsonConvert.DeserializeObject<ClientProfile>(response.Content);

            return ChangeGeneralInfoResponse;
        }

        public static User SendRequestChangePhoneNumberPost(string password, string phoneNumber, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/change_phone/");
            var request = new RestRequest(Method.POST);
            var newGenaralInfoModel = new Dictionary<string, string>
             {
                 { "password", password },
                 { "phone_number", phoneNumber }
             };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newGenaralInfoModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var ChangePhoneResponse = JsonConvert.DeserializeObject<User>(response.Content);

            return ChangePhoneResponse;
        }

        public static string SendRequestChangePasswordPost(string currentPassword, string newPassword, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/password/change/");
            var request = new RestRequest(Method.POST);
            var newGenaralInfoModel = new Dictionary<string, string>
             {
                 { "old_password", currentPassword },
                 { "new_password", newPassword }
             };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newGenaralInfoModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var ChangePasswordResponse = JsonConvert.DeserializeObject<ChangePasswordResponse>(response.Content);

            return ChangePasswordResponse.Token;
        }
    }
}
