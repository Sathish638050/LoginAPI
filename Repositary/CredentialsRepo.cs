using LoginAuthenticationAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAuthenticationAPI.Repositary
{
    public class CredentialsRepo : ICredentialsRepo
    {
        private readonly ELearnApplicationContext db;
        public List<UserAccount> GetCredentials()
        {
            List<UserAccount> u = new List<UserAccount>();
            u = db.UserAccounts.ToList();
            return u;
        }
    }
}
