using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hotel.Entities;
using Hotel.Data;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hotel.Controllers
{
    [Route("registration")]
    public class RegistrationController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {

            return View("~/Views/Registration.cshtml");
        }


        [HttpPost]
        public IActionResult Register(string firstname,string lastname,string password,string email,string phone)
        {
            ViewData["name"] = firstname;
            ViewData["email"] = email;
            ViewData["lastname"] = lastname;
            ViewData["password"] = password;
            ViewData["phone"] = phone;

            User userx = new User(firstname,lastname, email,password);
            //userx.FirstName = firstname;
            //userx.LastName = lastname;
            //userx.Password = password;
            //userx.Email = email;
            //userx.Phone = phone;
            userx.UserSave();
            
            return View("~/Views/SuccessfullyRegistration.cshtml");
        }
    }
}
