using ApiTests.ApiRequests.Auth;
using ApiTests.ApiRequests.Client;
using NUnit.Framework;

namespace ApiTests
{
    public class UpdateGeneralInformationTests
    {
        [Test]
        public void ChangeNameInGeneralInfo()
        {
            var createdUser = AuthRequests.SendRequestClientSignUpPost(Constant.user);

            var changedName = ClientRequests.SendRequestChangeGeneralInforNameLastNamePatch("Lilit", "Nombre", createdUser.TokenData.Token);

            Assert.AreEqual("Lilit", changedName.FirstName);
            Assert.AreEqual("Nombre", changedName.LastName);
        }

        [Test]
        public void ChangeLocationAndIndustryInGeneralInfo()
        {
            var createdUser = AuthRequests.SendRequestClientSignUpPost(Constant.user);

            var changedData = ClientRequests.SendRequestChangeGeneralInformationLocationIndustryPatch("fashion", createdUser.TokenData.Token);

            Assert.AreEqual("fashion", changedData.Industry);
            Assert.AreEqual("Gatlinburg, TN 37738, USA", changedData.CompanyAddress);
        }
    }
}
