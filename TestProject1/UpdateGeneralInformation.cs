using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject1.ApiRequests.Auth;
using TestProject1.ApiRequests.Client;

namespace TestProject1
{
    class UpdateGeneralInformation
    {
        [Test]
        public void Test2()
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
    }
}
