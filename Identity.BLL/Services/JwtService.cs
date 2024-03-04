using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Identity.BLL.DTO.JWT;
using Identity.BLL.Abstractions;
using Microsoft.Extensions.Options;

namespace Identity.BLL.Services
{
  public class JwtService : IJwtService
  {
    private readonly JwtModel _options;

    public JwtService(IOptions<JwtModel> options)
    {
      _options = options.Value;
    }

    public string GetJwtSecurityTokenAsync(string UserName)
    {
      List<Claim> claims = new List<Claim>();
      claims.Add(new Claim(ClaimTypes.Name, UserName));

      var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));

      //создаем JWT-токен
      var jwt = new JwtSecurityToken(
          issuer: _options.Issuer,
          audience: _options.Audience,
          claims: claims,
          expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(1)),
          notBefore: DateTime.UtcNow,
          signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
          );
      return new JwtSecurityTokenHandler().WriteToken(jwt);
    }

  }
}
