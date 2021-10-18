using LoginAuthenticationAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAuthenticationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        [HttpPost("Contact")]
        public async Task<IActionResult> AddContact(Contact c)
        {
            using(var db = new ELearnApplicationContext())
            {
                db.Contacts.Add(c);
                await db.SaveChangesAsync();
                return Ok();
            }
        }
        [HttpGet("GetContactDetails")]
        public async Task<IActionResult> GetContact()
        {
            using(var db = new ELearnApplicationContext())
            {
                List<Contact> lc = db.Contacts.ToList();
                return Ok(lc);
            }
        }
    }
}
