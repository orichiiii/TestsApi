using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using TestProject1.ApiRequests.Auth;
using TestProject1.ApiRequests.Client;

namespace ApiTests
{
    public class UpdateGeneralInformationTests
    {
        [Test]
        public void ChangeNameInGeneralInfo()
        {
            var user = new Dictionary<string, string>
             {
                 { "email", $"asda2sd2asd{DateTime.Now:ddyyyymmHHmmssffff}@asdasd.ert" },
                 { "first_name", "asdasdasd" },
                 { "last_name", "asdasdasd" },
                 { "password", "123qwe!QWE" },
                 { "phone_number", "3453453454" }
             };
            var createdUser = AuthRequests.SendRequestClientSignUpPost(user);

            var changedEmail = ClientRequests.SendRequestChangeGeneralInformationPost("Lilit", "Nombre", createdUser.TokenData.Token);

            Assert.AreEqual("Lilit", changedEmail.FirstName);
            Assert.AreEqual("Nombre", changedEmail.LastName);
        }

        [Test]
        public void ChangePassword()
        {
            var user = new Dictionary<string, string>
             {
                 { "email", $"asda2sd2asd{DateTime.Now:ddyyyymmHHmmssffff}@asdasd.ert" },
                 { "first_name", "asdasdasd" },
                 { "last_name", "asdasdasd" },
                 { "password", "123qwe!QWE" },
                 { "phone_number", "3453453454" }
             };
            var createdUser = AuthRequests.SendRequestClientSignUpPost(user);

            var changedPassword = ClientRequests.SendRequestChangePasswordPost("123qwe!QWE", "Aa!234567", createdUser.TokenData.Token);

            var userWithNewPassword = new Dictionary<string, string>
            {
                {"password", "Aa!234567"},
                {"email", createdUser.User.Email }
            };

            var authWithNewPassword = AuthRequests.SendRequestClientSignInPost(userWithNewPassword);

            Assert.AreEqual(HttpStatusCode.OK, authWithNewPassword.Response.StatusCode);
        }
    }
}
