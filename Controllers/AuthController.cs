using AuthenticationAndAuthorizationPractise.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationAndAuthorizationPractise.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthController : ControllerBase
	{
		private readonly TokenService _tokenService;

		public AuthController(TokenService tokenService)
		{
			_tokenService = tokenService;
		}

		[HttpPost("login")]
		public IActionResult Login([FromBody] LoginModel model)
		{
			// Normally, you would validate user credentials (e.g., from a database)
			if (model.Username == "user" && model.Password == "password")
			{
				var token = _tokenService.GenerateToken(model.Username);
				return Ok(new { Token = token });
			}

			return Unauthorized();
		}
	}

	public class LoginModel
	{
		public string Username { get; set; }
		public string Password { get; set; }
	}
}
