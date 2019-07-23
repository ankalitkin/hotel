using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Entities;
using Microsoft.AspNetCore.Mvc;
using Hotel.Data;

namespace Hotel.Controllers
{
    [Route("RoomCost")]
    [ApiController]
    public class RoomsCostController : Controller
    {
        // GET: RoomCost?role=права
        [HttpGet]
        public IActionResult Get(int role)
        {
            if ((role & (int)Role.AccessRights.CanEditRooms) == 0)
            {
                return View("~/Views/AccessError.cshtml");
            }
            ViewData["RoomCosts"] = RoomCostExtensions.AllRoomCosts().Result;
            return  View("~/Views/CostChanges.cshtml");
        }

        // POST:
        [HttpPost]
        public IActionResult Post(int role)
        {
            if ((role & (int)Role.AccessRights.CanEditRooms) == 0)
            {
                return View("~/Views/AccessError.cshtml");
            }
            RoomCost obj = new RoomCost(
                int.Parse(Request.Form.FirstOrDefault(r => r.Key == "categoryId").Value),
                int.Parse(Request.Form.FirstOrDefault(r => r.Key == "numberOfSeats").Value),
                Request.Form.FirstOrDefault(r => r.Key == "hasMiniBar").Value == "true",
                int.Parse(Request.Form.FirstOrDefault(r => r.Key == "cost").Value)
                );

            obj.RoomCostSave();
            ViewData["name"] = obj.Cost;
            return View("~/Views/SuccessfullyRegistration.cshtml");
        }

    }
}
