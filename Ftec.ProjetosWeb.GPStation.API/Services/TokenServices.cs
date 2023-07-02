using Ftec.ProjetosWeb.GPStation.API.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ftec.ProjetosWeb.GPStation.API.Services
{
	public class TokenServices
	{
		public static string GenerateToken(UsuarioModel usuario)
		{
			var tokenHandler = new JwtSecurityTokenHandler();

			var key = Encoding.ASCII.GetBytes("1223klj1k3j4kl402984290482wejjry");
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Name, usuario.Nome.ToString()),
					new Claim(ClaimTypes.Role, usuario.Senha.ToString())
				}),
				Expires = DateTime.UtcNow.AddHours(2),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
															SecurityAlgorithms.HmacSha256Signature),
				Audience = "ftec",
				Issuer = "ftec"
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}
	}
}
