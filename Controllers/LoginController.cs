using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Class;
using WebApplication1.Security;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserDbContext context;
        private readonly JwtTokenService jwtTokenService;
        public LoginController(UserDbContext context, JwtTokenService jwtTokenService)
        {
            context = context;
            jwtTokenService = jwtTokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] TB_USER users)
        {
            var user = context.TB_USERS
                .FirstOrDefault(u => u.EMAIL == users.FULLNAME && u.PASSWORDHASH == users.PASSWORDHASH);

            if (user == null)
                return Unauthorized("Invalid email or password");

            string token = jwtTokenService.GenerateToken(user.ID.ToString(), user.ROLE.ToString());

            return Ok(new
            {
                token,
                user.FULLNAME,
                user.EMAIL
            });
        }
    }
}