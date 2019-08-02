using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Entities;
using Microsoft.AspNetCore.Mvc;
using Hotel.Data;
using static Hotel.Data.RoomCostExtensions;

namespace Hotel.Controllers
{
    [Route("api/Admin/RoomCosts")]
    [ApiController]
    public class RoomsCostController : Controller
    {
        [HttpGet]// Возвращает список всех ценников
        public IEnumerable<RoomCost> Get()
        {
            return AllRoomCosts().Result;
        }

        [HttpGet("{id}")]// Возвращает ценник по id
        public RoomCost Get(int id)
        {
            return FindRoomCost(id).Result;
        }

        [HttpPost]// Добаляет ценник в базу
        public IActionResult Post([FromBody]RoomCost roomCost)
        {
            if (ModelState.IsValid)
            {
                RoomCost rmc;
                if ((rmc = FindRoomCost(roomCost).Result) == null)
                    roomCost.RoomCostSave();
                else
                {
                    rmc.Cost = roomCost.Cost;
                    rmc.RoomCostUpdate();
                }
                    

                return Ok(roomCost);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]// Обновляет данные о ценнике
        public IActionResult Put(int id, [FromBody]RoomCost roomCost)
        {
            if (ModelState.IsValid)
            {
                roomCost.RoomCostUpdate();
                return Ok(roomCost);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]// Удаляет ценник из базы
        public IActionResult Delete(int id)
        {
            return Ok(RoomCostDelete(id).Result);
        }

    }
}
