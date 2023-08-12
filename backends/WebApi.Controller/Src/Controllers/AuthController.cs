using Microsoft.AspNetCore.Mvc;
using WebApi.Business.Src.Abstractions;
using WebApi.Business.Src.Dtos;

namespace WebApi.Controller.Src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost]
        public async Task<ActionResult<string>> VerifyCredentials([FromBody] UserCredentialDto credentials)
        {
            return Ok(await _authService.VerifyCredentials(credentials)); 
        }
    }
}