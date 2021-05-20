using ApiTests.ApiRequests.Auth;
using ApiTests.ApiRequests.Client;
using NUnit.Framework;

namespace ApiTests
{
    public class ChangePhoneNumberTests
    {
        [Test]
        public void ChangePhoneNumber()
        {
            var createdUser = AuthRequests.SendRequestClientSignUpPost(Constant.user);

            var changedPhone = ClientRequests.SendRequestChangePhoneNumberPost("123qwe!QWE", "1234567891", createdUser.TokenData.Token);

            Assert.AreEqual("1234567891", changedPhone.PhoneNumber);
        }
    }
}
