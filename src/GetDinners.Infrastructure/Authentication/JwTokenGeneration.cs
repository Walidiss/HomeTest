using GetDinners.Application.Common.Authentication;
using GetDinners.Application.Common.Interfaces;
using GetDinners.Infrastructure.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GetDinners.Infrastructure.Services
{
    public class JwTokenGeneration : IJwTokenGeneration
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IDateTimeProvider _dateTimeProvider;
        public JwTokenGeneration(IOptions<JwtSettings>options, IDateTimeProvider dateTimeProvider)
        {
            _jwtSettings = options.Value;
            _dateTimeProvider = dateTimeProvider;   

        }
        public string GenerateToken(Guid userId, string firstName, string lastName)
        {
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_jwtSettings.Secret)
                    ), SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, firstName),
                new Claim(JwtRegisteredClaimNames.FamilyName,lastName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

            };
            var securityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                expires: _dateTimeProvider.Now.AddDays(_jwtSettings.ExpirationTimeInMinutes),
                claims: claims,
                signingCredentials: signingCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(securityToken);

        }
    }
}
