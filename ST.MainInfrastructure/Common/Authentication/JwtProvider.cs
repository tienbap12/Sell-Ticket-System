using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ST.Application.Commons.Abstractions;
using ST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ST.MainInfrastructure.Common.Authentication
{
    internal class JwtProvider(IOptions<JwtOptions> options) : IJwtProvider
    {

        private readonly JwtOptions _jwtOptions = options.Value;
        public string Generate(Account req)
        {
            var secretKey = "sdafasdf";
            var tokenExpires = DateTime.UtcNow.AddMinutes(15);
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(secretKey);
            var authClaims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new(JwtRegisteredClaimNames.NameId, req.Id.ToString()),
                new(JwtRegisteredClaimNames.UniqueName, req.Username),
            };

            var token = new JwtSecurityToken(
                expires: tokenExpires,
                claims: authClaims,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key),
                                                       SecurityAlgorithms.HmacSha256Signature));

            var jwtToken = jwtTokenHandler.WriteToken(token);
            return jwtToken;
        }
    }
}
