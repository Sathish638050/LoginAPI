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
    public class AddNewStaffController : ControllerBase
    {
        [HttpPost("AddRequestStaff")]
        public async Task<IActionResult> AddRequest(NewStaff n)
        {
            using(var db = new ELearnApplicationContext())
            {
                db.NewStaffs.Add(n);
                await db.SaveChangesAsync();
                return Ok();
            }
        }
    }
}
