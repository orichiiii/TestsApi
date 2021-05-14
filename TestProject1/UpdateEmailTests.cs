using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using RestSharp;
using System;
using System.Collections.Generic;
using TestProject1.ApiRequests.Auth;
using TestProject1.ApiRequests.Client;
using TestProject1.Models.Client;

namespace TestProject1
{
    public class UpdateEmailTests
    {
        [Test]
        public void ChangeEmail()
        {
            var expected = $"asda2sd2asd{DateTime.Now:ddyyyymmHHmmssffff}@asdasd.ert";
            var user = new Dictionary<string, string>
             {
                 { "email", $"asda2sd2asd{DateTime.Now:ddyyyymmHHmmssffff}@asdasd.ert" },
                 { "first_name", "asdasdasd" },
                 { "last_name", "asdasdasd" },
                 { "password", "123qwe!QWE" },
                 { "phone_number", "3453453454" }
             };
            var createdUser = AuthRequests.SendRequestClientSignUpPost(user);

            var changedEmail = ClientRequests.SenRequestChangeClientEmailPost("123qwe!QWE", expected, createdUser.TokenData.Token);

            Assert.AreEqual(expected, changedEmail);
        }
    }
}
