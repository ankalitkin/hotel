using Hotel.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Data
{
    public static class RoomExtensions
    {
        // Сохранение комнаты в базе данных
        public static async void RoomSave(this Room unsyRoom)
        {
            using (HotelContext db = new HotelContext())
            {
                await db.Rooms.AddAsync(unsyRoom);
                await db.SaveChangesAsync();
            }
        }

        // Обновление данных в базе о комнате
        public static async void RoomUpdate(this Room unsyRoom)
        {
            using (HotelContext db = new HotelContext())
            {
                db.Rooms.Update(unsyRoom);
                await db.SaveChangesAsync();
            }
        }

        // Поиск комнаты в базе по id
        public static async Task<Room> FindRoom(int id)
        {
            using (HotelContext db = new HotelContext())
            {
                return await db.Rooms.AsNoTracking().FirstOrDefaultAsync(r => r.RoomId == id && r.IsDeleted == false);
            }
        }

        // Поиск комнаты в базе по номеру комнаты
        public static async Task<Room> FindRoom(string number)
        {
            using (HotelContext db = new HotelContext())
            {
                return await db.Rooms.AsNoTracking().FirstOrDefaultAsync(r => r.Name == number && r.IsDeleted == false);
            }
        }

        // Удаление комнаты из базы
        public static async Task<Room> RoomDelete(int id)
        {
            using (HotelContext db = new HotelContext())
            {
                Room room = db.Rooms.FirstOrDefault(x => x.RoomId == id);
                if (room != null)
                {
                    room.IsDeleted = true;
                    db.Rooms.Update(room);
                    await db.SaveChangesAsync();
                }
                return room;
            }
        }

        // Получить список комнат
        public static async Task<IEnumerable<Room>> GetRooms()
        {
            using (HotelContext db = new HotelContext())
            {
                return await db.Rooms.AsNoTracking().Where(r => r.IsDeleted == false).ToListAsync();
            }
        }
    }

}
