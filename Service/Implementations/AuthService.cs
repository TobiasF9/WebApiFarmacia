using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Model.Helper;
using Model.Models;
using Model.ViewModel;
using Services.Helper;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly MedicinesAPIContext _context;
        private readonly AppSettings _appSettings;

        public AuthService(MedicinesAPIContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }

        public string CreateUser(UserViewModel User)
        {
            if (string.IsNullOrEmpty(User.Email))
            {
                return "Enter a user";
            }

            Users? user = _context.Users.FirstOrDefault(x => x.Email == User.Email);

            if (user != null)
            {
                return "Existing user";
            }

            _context.Users.Add(new Users()
            {
                Name = User.Name,
                Email = User.Email,
                Password = User.Password.GetSHA256(),
                IdRole = User.IdRole
            });
            _context.SaveChanges();

            string response = GetToken(_context.Users.OrderBy(x => x.Id).Last());

            return response;
        }

        public string Login(AuthViewModel User)
        {
            var HasedPassword = User.Password.GetSHA256();
            Users? user = _context.Users.FirstOrDefault(x => x.Email == User.Email && x.Password == HasedPassword);

            if (user == null)
            {
                return string.Empty;
            }

            return GetToken(user);
        }

        private string GetToken(Users user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, _context.Role.First(x => x.Id == user.IdRole).Description)
                    }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }
    }
}
