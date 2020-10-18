using HackTheU_Escrow_Feature.Contracts;
using HackTheU_Escrow_Feature.Data;
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
        private readonly IEscrowAccountRepository accountRepo;

        public AccountController(IEscrowAccountRepository accountRepo)
        {
            this.accountRepo = accountRepo;
        }
        [HttpPost]
        public virtual async Task<IActionResult> CreateUser([FromBody] UserCredentials creds)
        {
            var result = await accountRepo.CreateUser(creds.Username);
            return Ok(result);
        }
    }
}
