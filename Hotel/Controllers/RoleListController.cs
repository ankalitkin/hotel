using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel.Entities;

namespace Hotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleListController : ControllerBase
    {
        private readonly HotelContext _context;

        public RoleListController(HotelContext context)
        {
            _context = context;
        }

        // GET: api/RoleList
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        /*// GET: api/Roles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRole(int id)
        {
            var role = await _context.Roles.FindAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            return role;
        }*/


        // GET: api/RoleList/group
        [HttpGet("{group}")]
        public async Task<ActionResult<IEnumerable<Role>>> GetRoles(string group)
        {
            switch (group)
            {
                case "customers":
                return await _context.Roles.Where(r => r.Rights.HasFlag(Role.AccessRights.IsCustomer)).ToListAsync();

                case "staff":
                    return await _context.Roles.Where(r => !r.Rights.HasFlag(Role.AccessRights.IsCustomer)).ToListAsync();
            }

            return NoContent();
        }

    }
}
