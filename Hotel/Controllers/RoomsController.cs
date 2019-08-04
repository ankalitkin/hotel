using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Entities;
using Microsoft.AspNetCore.Mvc;
using Hotel.Data;
using static Hotel.Data.RoomExtensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hotel
{
    [Route("api/Admin/Rooms")]
    public class RoomsController : Controller
    {
        [HttpGet]// Возвращает список всех комнат
        public IEnumerable<Room> Get()
        {
            return GetRooms().Result;
        }

        [HttpGet("{id}")]// Возвращает комнату по id
        public Room Get(int id)
        {
            return FindRoom(id).Result;
        }

        [HttpPost]// Добаляет комнату в базу
        public IActionResult Post([FromBody]Room room)
        {
            if (ModelState.IsValid)
            {
                Room rm;
                if ((rm = FindRoom(room.Name).Result) == null)
                    room.RoomSave();
                else
                    rm.RoomUpdate();

                return Ok(room);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]// Обновляет данные о комнате
        public IActionResult Put(int id, [FromBody]Room room)
        {
            if (ModelState.IsValid)
            {
                room.RoomUpdate();
                return Ok(room);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]// Удаляет комнату из базы
        public IActionResult Delete(int id)
        {
            return Ok(RoomDelete(id).Result);
        }
    }
}
