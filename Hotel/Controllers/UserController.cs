
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json;
using System.Security.Claims;
using Hotel.Entities;
using Hotel.Services;
using Hotel.Data;

using Microsoft.AspNetCore.Authorization;

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
                User user1 = new User {FirstName = r.Firstname, LastName = r.Lastname, BirthDate = DateTime.Parse("01.05.1996"), Phone = r.Phone, Email = r.Email, ClientID = "123456789099", RoleId = 1, IsDeleted = false, Password=r.Password};
                user1.UserSave();
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("Login")]
        public async Task Login([FromBody]LoginModel lm)
        {
            var identity = await Task.Run(()=>GetIdentity(lm.Email, lm.Password));
            if (identity == null)
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("Invalid username or password.");
                return;
            }

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                token = encodedJwt,
                
            };

            Response.ContentType = "application/json";
            await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
        
    }

        [HttpGet]
        [Authorize]
        //GET : /api/UserProfile
        [Route("userprofile")]
        public async Task<Object> GetUserProfile()
        {
            
            string userId = User.Claims.First(c => c.Type == "userid").Value;
            User user1 = await Task.Run(()=>_userService.FindByUserId(userId));
            string firstName=user1.FirstName;
          
            return new
            {
 
                firstName,
                user1.Email,
                userId

            };

        }

        private async Task<ClaimsIdentity> GetIdentity(string email, string password)
        {
            //var user = _userService.FindByUserEmail(email);
            var user = await Task.Run(() => _userService.FindByUserEmail(email));
            
            if (user.Password==password)
            {
                var claims = new List<Claim>
                {
                    new Claim("userid", user.UserId.ToString()),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.RoleId.ToString())
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }
            return null;
        }

    }
}
