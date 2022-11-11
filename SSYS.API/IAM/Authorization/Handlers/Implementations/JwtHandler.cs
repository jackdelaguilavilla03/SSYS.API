using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SSYS.API.IAM.Authorization.Handlers.Interfaces;
using SSYS.API.IAM.Authorization.Settings;
using SSYS.API.IAM.Domain.Models;
using SSYS.API.IAM.Domain.Models.Entities;

namespace SSYS.API.IAM.Authorization.Handlers.Implementations;

public class JwtHandler : IJwtHandler
{
    private readonly AppSettings _appSettings;
    
    public JwtHandler(IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings.Value;
    }
    public string GenerateToken(User user)
    {
        Console.WriteLine($"Secrete: {_appSettings.Secret}");
        var secret = _appSettings.Secret;
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        Console.WriteLine(($"Secret Key Length: {key.Length}"));
        Console.WriteLine($"User Id: {user.Id.ToString()}");
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        
        Console.WriteLine($"Token Expiration: {tokenDescriptor.Expires.ToString()}");

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);

    }

    public int? ValidateToken(string token)
    {
        if (string.IsNullOrEmpty(token))
            return null;
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);
            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = int.Parse(jwtToken.Claims.First(
                claim => claim.Type == ClaimTypes.Sid).Value);
            return userId;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }
}