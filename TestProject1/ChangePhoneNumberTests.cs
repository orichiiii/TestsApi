using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject1.ApiRequests.Auth;
using TestProject1.ApiRequests.Client;

namespace ApiTests
{
    public class ChangePhoneNumberTests
    {
        [Test]
        public void ChangePhoneNumber()
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

            var changedPhone = ClientRequests.SendRequestChangePhoneNumberPost("123qwe!QWE", "1234567891", createdUser.TokenData.Token);

            Assert.AreEqual("1234567891", changedPhone.PhoneNumber);
        }
    }
}
