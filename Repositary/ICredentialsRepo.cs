using LoginAuthenticationAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAuthenticationAPI.Repositary
{
    public interface ICredentialsRepo
    {
        public List<UserAccount> GetCredentials();
    }
}
