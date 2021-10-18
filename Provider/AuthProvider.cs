using LoginAuthenticationAPI.Model;
using LoginAuthenticationAPI.Repositary;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginAuthenticationAPI.Provider
{
    public class AuthProvider : IAuthProvider
    {
        private readonly ICredentialsRepo obj;
        public AuthProvider(ICredentialsRepo _obj)
        {
            obj = _obj;
        }
        public dynamic Authentication(Login login)
        {
            if(login == null)
            {
                return null;
            }
            try
            {
                UserAccount user = null;
                //List<UserAccount> ua = new List<UserAccount>();
                //if (ua == null)
                //{
                //    return null;
                //}
                //else
                //{
                //    if(ua.Any(u => u.Username == login.Username && u.Password == login.Password))
                //    {
                //        user = new UserAccount { Username = login.Username, Password = login.Password };
                //    }
                //}
                using(var db = new ELearnApplicationContext())
                {
                    user = (from i in db.UserAccounts where i.Username == login.Username && i.Password == login.Password select i).FirstOrDefault();
                }
                return user;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string GenerateJSONWebToken(UserAccount u, IConfiguration _config)
            {
            if(u == null)
            {
                return null;
            }
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(_config["Jwt:Issuer"], null, expires: DateTime.Now.AddMinutes(15),
                    signingCredentials: credentials);
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
