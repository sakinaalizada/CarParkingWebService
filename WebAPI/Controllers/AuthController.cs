using Business.Abstract;
using Core.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace AirportWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserLoginDto userLoginDto)
        {
            var userToLogin = _authService.Login(userLoginDto);

            if (!userToLogin.Success) return BadRequest(userToLogin);

            var result = _authService.CreateAccessToken(userToLogin.Data);

            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("register")]
        public IActionResult Register(UserRegisterDto userRegisterDto)
        {
            var registerResult = _authService.Register
                (userRegisterDto, userRegisterDto.Password);

            var result = _authService.CreateAccessToken(registerResult.Data);

            if (registerResult.Success) return Ok(registerResult);

            return BadRequest(result);
        }
    }
}
