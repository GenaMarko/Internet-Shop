using Internet_Shop.Models;
using Internet_Shop.Services;
using Microsoft.AspNetCore.Mvc;

namespace Internet_Shop.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly AuthService _authService;

        public AuthController(IUserService userService, AuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var user = await _userService.RegisterAsync(dto);
            if (user == null) return BadRequest("Такой email уже зарегестрирован");

            return Ok(new {user.Username,user.Email});
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _userService.ValidateUserAsync(dto.Email, dto.Password);
            if (user == null) return Unauthorized();

            var token = _authService.GenerateJwtToken(user);

            return Ok(new { token });
        }
    }
}
