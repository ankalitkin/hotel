using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Hotel.Entities;
using Hotel.Services;
using Hotel.Data;


namespace Hotel.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly DataService _userService;
        public UserController()
        {
            _userService = new DataService();
        }
        // GET: api/User
        [HttpPost]
        [Route("Registration")]
        public IActionResult Registration([FromBody]reg_model r)
        {
            if (ModelState.IsValid)
            {
                User user1 = new User {FirstName = r.Firstname, LastName = r.Lastname, BirthDate = DateTime.Parse("01.05.1996"), Phone = "8-800-555-35-35", Email = r.Email, ClientID = "123456789099", RoleId = 1, IsDeleted = false };
                user1.UserSave();
                return Ok();
            }
            return BadRequest(ModelState);
        }

      [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(string email, string password)
        {
           var user = _userService.FindByUserEmail(email);
            if (user != null && user.password==password)
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID",user.UserId.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("RelexPractice1234")), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
            }
            else
                return BadRequest(new { message = "неправильный логин или пароль" });
        } 
      
    }
}
