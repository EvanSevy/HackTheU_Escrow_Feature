using HackTheU_Escrow_Feature.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackTheU_Escrow_Feature.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        [HttpPost]
        public virtual async Task<IActionResult> CreateUser([FromBody] UserCredentials creds)
        {
            return Ok(true);
        }
    }
}
