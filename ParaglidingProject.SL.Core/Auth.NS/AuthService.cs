﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ParaglidingProject.Data;
using ParaglidingProject.SL.Core.Auth.NS.TransfertObjects;

namespace ParaglidingProject.SL.Core.Auth.NS
{
    public class AuthService : IAuthService
    {
        private readonly ParaglidingClubContext _context;

        public AuthService(ParaglidingClubContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<bool?> Authenticate(CredentialsParams credentials)
        {
            var user = await _context.Pilots
                .FirstOrDefaultAsync(p => p.FirstName == credentials.FirstName);

            if (user == null) return null;

            return user.PhoneNumber == credentials.PhoneNumber;
        }
        public TokenDto GenerateJwt(string name, string secret)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);

            var role = _context.Roles
                .Include(r => r.Pilot)
                .FirstOrDefault(r => r.Pilot.FirstName == name);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, name),
                role != null ? new Claim(ClaimTypes.Role, role.Name) : new Claim(ClaimTypes.Role, "Guest") // enum
            };


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new TokenDto
            {
                FirstName = name,
                Token = tokenHandler.WriteToken(token),
            };
        }
        public UserInfoDto ExtractInfo(ClaimsPrincipal user)
        {
            var claimsIdentity = user.Identity as ClaimsIdentity;
            var userName = claimsIdentity?.FindFirst(ClaimTypes.Name);
            var role = claimsIdentity?.FindFirst(ClaimTypes.Role);
            return new UserInfoDto
            {
                FirstName = userName?.Value,
                Role = role?.Value
            };
        }
    }
}
