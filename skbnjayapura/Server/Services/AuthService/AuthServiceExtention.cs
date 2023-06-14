﻿using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using skbnjayapura.Server.Datas;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace skbnjayapura.Server.Services.AuthService;

public static class AuthServiceExtention
{
    public static Task<string> GenerateToken(this IdentityUser user, AppSettings _appSettings, IList<string> roles = null)
    {
        var issuer = _appSettings.Issuer;
        var audience = _appSettings.Audience;
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
            new Claim("id", user.Id),
            new Claim(JwtRegisteredClaimNames.Name, user.UserName),
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti,
            Guid.NewGuid().ToString())
         }),
            Expires = DateTime.UtcNow.AddDays(7),
            Issuer = issuer,
            Audience = audience,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
        };

        if (roles != null)
        {
            foreach (var item in roles)
            {
                tokenDescriptor.Subject.AddClaim(new Claim("role", item));
            }
        }
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return Task.FromResult(tokenHandler.WriteToken(token));
    }
    
}
