using ApiTests.ApiRequests.Auth;
using ApiTests.ApiRequests.Client;
using NUnit.Framework;
using System;

namespace ApiTests
{
    public class UpdateEmailTests
    {
        [Test]
        public void ChangeEmail()
        {
            var expected = $"asda2sd2asd{DateTime.Now:ddyyyymmHHmmssffff}@asdasd.ert";
            var createdUser = AuthRequests.SendRequestClientSignUpPost(NewUser.GetNewUser());

            var changedEmail = ClientRequests.SenRequestChangeClientEmailPost("123qwe!QWE", expected, createdUser.TokenData.Token);

            Assert.AreEqual(expected, changedEmail);
        }
    }
}
