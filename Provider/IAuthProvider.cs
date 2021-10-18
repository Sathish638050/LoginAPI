using LoginAuthenticationAPI.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAuthenticationAPI.Provider
{
    public interface IAuthProvider
    {
        public string GenerateJSONWebToken(UserAccount u, IConfiguration _config);
        public dynamic Authentication(Login login);
    }
}
