using ApiTests.Models;
using ApiTests.Models.Client;
using ApiTests.Models.EmailResponse;
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
            var changeEmailResponse = JsonConvert.DeserializeObject<ChangeEmailResponse>(response.Content);

            return changeEmailResponse.Email;
        }

        public static ResponseModel<ClientAuthModel> SendRequestChangeGeneralInforNameLastNamePatch(string firstName, string lastName, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/self/");
            var request = new RestRequest(Method.PATCH);
            var newGenaralInfoModel = new Dictionary<string, string>
             {
                 { "first_name", firstName },
                 { "last_name", lastName },
             };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newGenaralInfoModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var changeGeneralInfoResponse = JsonConvert.DeserializeObject<ClientAuthModel>(response.Content);

            return new ResponseModel<ClientAuthModel> { Model = changeGeneralInfoResponse, Response = response };
        }

        public static ClientProfile SendRequestChangeGeneralInformationLocationIndustryPatch(string industry, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/profile/");
            var request = new RestRequest(Method.PATCH);
            var newGenaralInfoModel = new Dictionary<string, string>
             {
                 {"industry", industry },
                 {"location_name", "Gatlinburg, TN 37738, USA"},
                 {"location_timezone", "America/New_York" }
             };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newGenaralInfoModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var changeGeneralInfoResponse = JsonConvert.DeserializeObject<ClientProfile>(response.Content);

            return changeGeneralInfoResponse;
        }

        public static ResponseModel<ClientAuthModel> SendRequestChangePhoneNumberPost(string password, string phoneNumber, string token)
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
            var changePhoneResponse = JsonConvert.DeserializeObject<ClientAuthModel>(response.Content);

            return new ResponseModel<ClientAuthModel> { Model = changePhoneResponse, Response = response };
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
            var changePasswordResponse = JsonConvert.DeserializeObject<ChangePasswordResponse>(response.Content);

            return changePasswordResponse.Token;
        }

        public static ResponseModel<ClientAuthModel> SendRequestChangePhotoPatch(string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/self/");
            client.Timeout = -1;
            var request = new RestRequest(Method.PATCH);
            request.AddHeader("authorization", token);
            request.AlwaysMultipartFormData = true;
            request.AddParameter("avatar_id", "89b701bb-12d4-45f9-92e0-f4ea910eb0ab");

            var response = client.Execute(request);
            var addPhoto = JsonConvert.DeserializeObject<ClientAuthModel>(response.Content);

            return new ResponseModel<ClientAuthModel> { Model = addPhoto, Response = response }; ;
        }

        public static ResponseModel<ClientAuthModel> SendRequestUploadPhotoOptions(string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/images/upload/");
            client.Timeout = -1;
            var request = new RestRequest(Method.OPTIONS);

            request.AddHeader("authorization", token);
            request.AddHeader("Content-Disposition", "form-data; name=\"file\"; filename=\"Man-Silhouette.jpg\"");
            request.AddHeader("Content-Type", "image/jpeg");
            request.AddFile("file", "C:/Users/proho/Desktop/Man-Silhouette.jpg");
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var addPhoto = JsonConvert.DeserializeObject<ClientAuthModel>(response.Content);

            return new ResponseModel<ClientAuthModel> { Model = addPhoto, Response = response }; ;
        }
    }
}
