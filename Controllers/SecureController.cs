using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationAndAuthorizationPractise.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SecureController : ControllerBase
	{
		// Only authenticated users can access this endpoint
		[Authorize]
		[HttpGet("protected")]
		public IActionResult GetProtectedData()
		{
			return Ok("This is a protected API response.");
		}
	}
}
