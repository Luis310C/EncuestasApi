using EncuestasApi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EncuestasApi
{
    public class JwtManager : BasicService, IJWTManager 
    {
        private readonly IConfiguration iconfiguration;
        public JwtManager()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("AppSettings.json");
            iconfiguration = configurationBuilder.Build(); ;
        }

        public async Task<Tokens> Authenticate(UserSession user)
        {
            var userRegister = await _db.Usersapps.Where(userdb => userdb.Correo == user.Correo).FirstOrDefaultAsync();
            bool verified = BCrypt.Net.BCrypt.Verify(user.Contrasena, userRegister.Contrasena);
            if (!verified) {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(iconfiguration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
          {
             new Claim(ClaimTypes.Name, user.Correo)
          }),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens { Token = tokenHandler.WriteToken(token) };
        }


        public async Task CreateUser(Usersapp usersapp) {
            usersapp.Contrasena = BCrypt.Net.BCrypt.HashPassword(usersapp.Contrasena);
            _db.Usersapps.Add(usersapp);
            await _db.SaveChangesAsync();

        }

        public async Task<List<UserSession>> Usuarios() {

           return await _db.Usersapps.Select(user=>new UserSession { 
            Correo = user.Correo,
            Contrasena = "Confidencial"
            }).ToListAsync();
        }
    }
}
