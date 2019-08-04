using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Entities
{
    public class User
    {
       

        public User() {}
        public User(string firstname, string lastname, string email, string password)
        {
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Password = password;
           // Phone = phone;
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set;}
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        [StringLength(12)]
        public string ClientId { get; set; }
        public virtual Role Role { get; set; }
        public int RoleId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
