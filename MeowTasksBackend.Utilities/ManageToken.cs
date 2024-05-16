using MeowTasksBackend.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MeowTasksBackend.Utilities
{
  public class ManageToken
  {
    public string? CreateToken(IConfiguration config, MeowUser model)
    {
      var key = config.GetSection("JWTSettings:key").Value;
      var keyBytes = Encoding.ASCII.GetBytes(key);

      var credentialsToken = new SigningCredentials(
        new SymmetricSecurityKey(keyBytes),
        SecurityAlgorithms.HmacSha256
      );

      var claims = new ClaimsIdentity();
      claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, Convert.ToString(model.MeowUserId)));
      
      foreach (var role in model.MeowUserRoles)
      {
        claims.AddClaim(new Claim(ClaimTypes.Role, role.Name));
      }

      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = claims,
        Expires = DateTime.UtcNow.AddHours(Convert.ToDouble(config.GetSection("JWTSettings:expires").Value)),
        SigningCredentials = credentialsToken
      };

      var tokenHandler = new JwtSecurityTokenHandler();
      var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);
      
      var token = tokenHandler.WriteToken(tokenConfig);

      return token;
    }
  }
}
