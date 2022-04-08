using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EncuestasApi.Model;
using Microsoft.AspNetCore.Authorization;

namespace EncuestasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersappsController : ControllerBase
    {
        private readonly JwtManager _jWTManager;

        public UsersappsController()
        {
            this._jWTManager = new JwtManager();
        }
        [HttpPost]
        [Route("Authenticated")]
        public async Task<ActionResult<Object>> PostAuthenticate(UserSession user) {
            var token = await _jWTManager.Authenticate(user);
            if (token == null) {
                return Unauthorized();
            }
            return Ok(token);
        }
        [Authorize]
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<Object>> GetUsuarios() {
            var users = await _jWTManager.Usuarios();
            return Ok(users);
        
        
        }



        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<Usersapp>> PostUsersapp(Usersapp usersapp)
        {
            await _jWTManager.CreateUser(usersapp);
            return Ok("creado con exito");
        }

 
    }
}
