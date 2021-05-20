using ApiTests.ApiRequests.Auth;
using ApiTests.ApiRequests.Client;
using NUnit.Framework;
using System.Net;

namespace ApiTests
{
    public class UpdateGeneralInformationTests
    {
        [Test]
        public void ChangeNameInGeneralInfo()
        {
            var createdUser = AuthRequests.SendRequestClientSignUpPost(NewUser.GetNewUser());

            var changedName = ClientRequests.SendRequestChangeGeneralInforNameLastNamePatch("Lilit", "Nombre", createdUser.TokenData.Token);

            Assert.AreEqual("Lilit", changedName.Model.User.FirstName);
            Assert.AreEqual("Nombre", changedName.Model.User.LastName);
        }

        [Test]
        public void ChangeNameInGeneralInfoInvalid()
        {
            var createdUser = AuthRequests.SendRequestClientSignUpPost(NewUser.GetNewUser());

            var changedName = ClientRequests.SendRequestChangeGeneralInforNameLastNamePatch("", "", createdUser.TokenData.Token);

            Assert.AreEqual(HttpStatusCode.BadRequest, changedName.Response.StatusCode);
        }

        [Test]
        public void ChangeLocationAndIndustryInGeneralInfo()
        {
            var createdUser = AuthRequests.SendRequestClientSignUpPost(NewUser.GetNewUser());

            var changedData = ClientRequests.SendRequestChangeGeneralInformationLocationIndustryPatch("fashion", createdUser.TokenData.Token);

            Assert.AreEqual("fashion", changedData.Industry);
            Assert.AreEqual("Gatlinburg, TN 37738, USA", changedData.CompanyAddress);
        }
    }
}
