using System;
using System.Threading.Tasks;
using Assignment1.Data;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticateController : ControllerBase
    {
        private IUserService userService;
        
        public AuthenticateController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<User>> ValidateUser([FromQuery] string userName, [FromQuery] string password)
        {
            try
            {
                User user = userService.ValidateUser(userName, password);
                
                if (user == null)
                {
                    return NotFound();
                }

                if (!user.Password.Equals(password))
                {
                    return Unauthorized(password);
                }

                return Ok(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}