using LoginAuthenticationAPI.Model;
using LoginAuthenticationAPI.Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LoginAuthenticationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AuthController));
        private IConfiguration config;
        private readonly IAuthProvider ap;
        public string tokenString = "";
        public AuthController(IConfiguration config, IAuthProvider ap)
        {
            this.config = config;
            this.ap = ap;
        }

        [HttpPost]
        public IActionResult Login([FromBody] Login login)
        {
            _log4net.Info(" Http Post request");
            if (login == null)
            {
                return Ok("invalid");
            }
            try
            {

                IActionResult response = Unauthorized();
                UserAccount user = ap.Authentication(login);         //authenticatin the user first

                if (user != null)
                {
                    tokenString = ap.GenerateJSONWebToken(user, config);        //generating token only if the user is authenticated
                    CookieOptions cookie = new CookieOptions();
                    cookie.Expires = DateTime.Now.AddMinutes(15);
                    Response.Cookies.Append("Valid", tokenString, cookie);
                    response = Ok(tokenString);
                    return Ok(tokenString);
                }

                return Ok("Invalid");
            }
            catch (Exception e)
            {
                _log4net.Error("Exception Occured " + e.Message);
                return Ok("Invalid");
            }

        }
        [HttpGet("CheckAuthentication")]
        [Authorize]
        [AllowAnonymous]
        public IActionResult CheckAuthentication()
        {
            if (Request.Cookies["valid"] != null)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }
        [HttpPost("Register")]
        public async Task<IActionResult> AddUser(UserAccount u)
        {
            using (var db = new ELearnApplicationContext())
            {
                db.UserAccounts.Add(u);
                await db.SaveChangesAsync();
                return Ok();
            }
        }
        [HttpPost("UserDetail")]
        public async Task<ActionResult<UserAccount>> GetDetail(Login u)
        {
            using (var db = new ELearnApplicationContext())
            {
                UserAccount ua = await (from i in db.UserAccounts where i.Username == u.Username && i.Password == u.Password select i).FirstOrDefaultAsync();
                return Ok(ua);
            }
        }
        [HttpGet]
        [Route("{name}")]
        public async Task<ActionResult<UserAccount>> GetDetailByUsername(string name)
        {
            using(var db = new ELearnApplicationContext())
            {
                UserAccount ua = await (from i in db.UserAccounts where i.Username == name select i).FirstOrDefaultAsync();
                return Ok(ua);
            }
        }
        [HttpGet("GetStudentList")]
        public async Task<IActionResult> GetStudentList()
        {
            List<UserAccount> ui = new List<UserAccount>();
            using (var db= new ELearnApplicationContext())
            {
                ui = await (from i in db.UserAccounts where i.Role == "Student" select i).ToListAsync();
                return Ok(ui);
            }
        }
        [HttpGet("GetStaffList")]
        public async Task<IActionResult> GetStaffList()
        {
            List<UserAccount> ui = new List<UserAccount>();
            using (var db = new ELearnApplicationContext())
            {
                ui = await (from i in db.UserAccounts where i.Role == "Staff" select i).ToListAsync();
                return Ok(ui);
            }
        }
        [HttpGet("GetNewRequest")]
        public async Task<IActionResult> GetNewReq()
        {
            List<NewStaff> ls = new List<NewStaff>();
            using(var db = new ELearnApplicationContext())
            {
                ls = await (from i in db.NewStaffs where i.Status == "false" select i).ToListAsync();
                return Ok(ls);
            }
        }
        [HttpPut("EditRequest")]
        public async Task<IActionResult> EditReq(int id,NewStaff n)
        {
            NewStaff ne = new NewStaff();
            using (var db = new ELearnApplicationContext())
            {
                ne = await db.NewStaffs.FindAsync(id);
                ne.Status = "true";
                await db.SaveChangesAsync();
                return Ok();
            }
        }
        [HttpGet("GetDetailByReqName")]
        public async Task<IActionResult> GetDetailByReqName(string name)
        {
            List<NewStaff> ne = new List<NewStaff>();
            using(var db = new ELearnApplicationContext())
            {
                ne = await (from i in db.NewStaffs where i.Username == name select i).ToListAsync();
                return Ok(ne);
            }
        }

    }
}
