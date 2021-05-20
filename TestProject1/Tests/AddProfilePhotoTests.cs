using ApiTests.ApiRequests.Auth;
using ApiTests.ApiRequests.Client;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ApiTests.Tests
{
    public class AddProfilePhotoTests
    {
        [Test]
        public void AddPhoto()
        {
            var createdUser = AuthRequests.SendRequestClientSignUpPost(NewUser.GetNewUser());

            ClientRequests.SendRequestUploadPhotoOptions(createdUser.TokenData.Token);
            var newPhoto = ClientRequests.SendRequestChangePhotoPatch(createdUser.TokenData.Token);

            Assert.AreEqual(HttpStatusCode.OK, newPhoto.Response.StatusCode);
        }
    }
}
