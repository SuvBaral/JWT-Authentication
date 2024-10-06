using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthenticationAndAuthorizationPractise.Services
{
	public class TokenService
	{
		public string GenerateToken(string username)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.UTF8.GetBytes("your_super_secret_key_here_that_is_32_chars_long");

			// Define the claims (user identity, roles) in the token
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new[]
				{
				new Claim(ClaimTypes.Name, username),
				new Claim(ClaimTypes.Role, "User")  // Assigning user roles
            }),
				Expires = DateTime.UtcNow.AddMinutes(30), // Token expires in 30 minutes
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
				Issuer = "http://localhost:5000",
				Audience = "http://localhost:5000"
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token); // Return the serialized JWT
		}
	}
}
