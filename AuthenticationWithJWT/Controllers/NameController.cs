using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationWithJWT.Controllers
{
    [Authorize]
    [Route("api")]
    [ApiController] 
    public class NameController : ControllerBase
    {
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;
        public NameController(IJwtAuthenticationManager jwtAuthenticationManager) => _jwtAuthenticationManager = jwtAuthenticationManager;
      
         [HttpGet("get_values")]
        public IEnumerable<string> Get()
        {
            return new string[] { "New York", "New Jersey" , "Erevan"};
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserCred userCred)
        {
           var token =  _jwtAuthenticationManager.Authenticate(userCred.username, userCred.password);
            if (token == null)
                return Unauthorized();
            return Ok(token);    
        }
    }
}
