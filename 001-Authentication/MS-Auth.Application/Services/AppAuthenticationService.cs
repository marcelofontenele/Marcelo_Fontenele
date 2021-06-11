using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MS_Auth.Application.Dto;
using MS_Auth.Application.Interfaces;
using MS_Auth.Domain.Entities;
using MS_Auth.Domain.Interfaces.Services;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MS_Auth.Application.Services
{
    public class AppAuthenticationService : IAppAuthenticationService
    {
        private readonly IMapper mapper;
        private readonly IUserService userService;
        private readonly IConfiguration configuration;

        public AppAuthenticationService(
            IMapper _mapper,
            IConfiguration _configuration,
            IUserService _userService)
        {
            this.mapper = _mapper ?? throw new NullReferenceException(nameof(IMapper)); ;
            this.configuration = _configuration ?? throw new NullReferenceException(nameof(IConfiguration));
            this.userService = _userService ?? throw new NullReferenceException(nameof(IUserService));
        }

        public TokenDTO Authenticate(UserDTO userDTO)
        {
            var user = this.userService.Get(this.mapper.Map<User>(userDTO));

            if (user == null)
            {
                return null;
            }

            return new TokenDTO
            {
                access_token = this.GetJwtToken(user),
                name = user.Name
            };
        }

        private string GetJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(this.configuration.GetValue<string>("TokenSecretKey"));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.WriteToken(
                tokenHandler.CreateToken(tokenDescriptor)
            );
        }
    }
}