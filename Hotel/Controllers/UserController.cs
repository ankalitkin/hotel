using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public UserController(DataService userservice)
        {
            _userService = userservice;
        }
        // GET: api/User
        [HttpPost]
        [Route("Registration")]
        public IActionResult Registration([FromBody]reg_model r)
        {
            if (ModelState.IsValid)
            {
                //Role Owner = new Role { RoleId = 1, Name = "Owner", Rights = (Role.AccessRights)2047 };
                User user1 = new User {FirstName = r.Firstname, LastName = r.Lastname, BirthDate = DateTime.Parse("01.05.1996"), Phone = "8-800-555-35-35", Email = r.Email, ClientID = "123456789099", RoleId = 1, IsDeleted = false };
                user1.UserSave();
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        [Route("Registration2")]
        public string Registration2()
        {
            return "gfdgdfgdf";
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
