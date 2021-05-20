using System;
using System.Collections.Generic;

namespace ApiTests
{
    public static class NewUser
    {
        public static Dictionary<string, string> GetNewUser()
        {
            var user = new Dictionary<string, string>
             {
                 { "email", $"asda2sd2asd{DateTime.Now:ddyyyymmHHmmssffff}@asdasd.ert" },
                 { "first_name", "asdasdasd" },
                 { "last_name", "asdasdasd" },
                 { "password", "123qwe!QWE" },
                 { "phone_number", "3453453454" }
             };

            return user;
        }
    }
}
