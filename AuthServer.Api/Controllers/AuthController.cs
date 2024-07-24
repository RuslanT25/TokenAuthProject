using AuthServer.Core.DTOs;
using AuthServer.Core.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthServer.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authenticationService;

        public AuthController(IAuthService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateToken(LoginDTO loginDto)
        {
            var result = await _authenticationService.CreateToken(loginDto);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult CreateTokenByClient(ClientLoginDTO clientLoginDto)
        {
            var result = _authenticationService.CreateTokenByClient(clientLoginDto);

            if (result.IsSuccessful)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> RevokeRefreshToken(string refreshToken)
        {
            var result = await _authenticationService.RevokeRefreshToken(refreshToken);

            if (result.IsSuccessful)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTokenByRefreshToken(string refreshToken)

        {
            var result = await _authenticationService.CreateTokenByRefreshToken(refreshToken);

            if (result.IsSuccessful)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
