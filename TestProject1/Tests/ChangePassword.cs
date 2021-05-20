using ApiTests.ApiRequests.Auth;
using ApiTests.ApiRequests.Client;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net;

namespace ApiTests
{
    public class ChangePasswordTests
    {
        [Test]
        public void ChangePassword()
        {
            var createdUser = AuthRequests.SendRequestClientSignUpPost(Constant.user);

            ClientRequests.SendRequestChangePasswordPost("123qwe!QWE", "Aa!234567", createdUser.TokenData.Token);

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
