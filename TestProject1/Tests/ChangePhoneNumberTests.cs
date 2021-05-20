using ApiTests.ApiRequests.Auth;
using ApiTests.ApiRequests.Client;
using NUnit.Framework;
using System.Net;

namespace ApiTests
{
    public class ChangePhoneNumberTests
    {
        [Test]
        public void ChangePhoneNumber()
        {
            var createdUser = AuthRequests.SendRequestClientSignUpPost(NewUser.GetNewUser());

            var changedPhone = ClientRequests.SendRequestChangePhoneNumberPost("123qwe!QWE", "1234567891", createdUser.TokenData.Token);

            Assert.AreEqual("1234567891", changedPhone.Model.User.PhoneNumber);
        }

        [Test]
        public void ChangePhoneNumberInvalid()
        {
            var createdUser = AuthRequests.SendRequestClientSignUpPost(NewUser.GetNewUser());

            var changedPhone = ClientRequests.SendRequestChangePhoneNumberPost("123qwe!QWE", "", createdUser.TokenData.Token);

            Assert.AreEqual(HttpStatusCode.BadRequest, changedPhone.Response.StatusCode);
        }
    }
}
