using AuthServer.Business.Configurations;
using AuthServer.Core.Configurations;
using AuthServer.Core.DTOs;
using AuthServer.Core.Entities;
using AuthServer.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Business.Services
{
    public class TokenManager : ITokenService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly CustomTokenOption _tokenOption;

        public TokenManager(UserManager<AppUser> userManager, IOptions<CustomTokenOption> options)
        {
            _userManager = userManager;
            _tokenOption = options.Value;
        }

        private string CreateRefreshToken()
        {
            var numberByte = new byte[32];
            using var rnd = RandomNumberGenerator.Create();
            rnd.GetBytes(numberByte);

            return Convert.ToBase64String(numberByte);
        }

        private IEnumerable<Claim> GetClaim(AppUser user, List<string> audience)
        {
            var users = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier,user.Id),
                new(ClaimTypes.Email,user.Email!),
                new(ClaimTypes.Name,user.UserName!),
                new(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            users.AddRange(audience.Select(x => new Claim(JwtRegisteredClaimNames.Aud, x)));

            return users;
        }

        public TokenDTO CreateToken(AppUser user)
        {
            throw new NotImplementedException();
        }

        public ClientTokenDTO CreateTokenByClient(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
