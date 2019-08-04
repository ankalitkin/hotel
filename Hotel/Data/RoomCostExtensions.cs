using Hotel.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Data
{
    public static class RoomCostExtensions
    {
        // Поиск в базе
        public static async Task<RoomCost> FindRoomCost(RoomCost roomCost)
        {
            using (HotelContext db = new HotelContext())
            {
                return await db.RoomCosts.AsNoTracking().FirstOrDefaultAsync(
                    rc => roomCost.CategoryId == rc.CategoryId &&
                          roomCost.NumberOfSeats == rc.NumberOfSeats &&
                          roomCost.HasMiniBar == rc.HasMiniBar);
            }
        }

        // Поиск записи в базе
        public static async Task<RoomCost> FindRoomCost(int id)
        {
            using (HotelContext db = new HotelContext())
            {
                return await db.RoomCosts.AsNoTracking()
                    .FirstOrDefaultAsync(rc => rc.RoomCostId == id &&
                                               rc.Cost > 0);
            }
        }

        // Вывод всех записей
        public static async Task<IEnumerable<RoomCost>> AllRoomCosts()
        {
            using (HotelContext db = new HotelContext())
            {
                return await db.RoomCosts.AsNoTracking().Where(x => x.Cost > 0).ToListAsync();
            }
        }

        // Сохранение комнаты в базе данных
        public static async void RoomCostSave(this RoomCost unsyRoomCost)
        {
            using (HotelContext db = new HotelContext())
            {
                await db.RoomCosts.AddAsync(unsyRoomCost);
                await db.SaveChangesAsync();
            }
        }

        // Обновление данных в базе о ценнике
        public static async void RoomCostUpdate(this RoomCost unsyRoomCost)
        {
            using (HotelContext db = new HotelContext())
            {
                db.RoomCosts.Update(unsyRoomCost);
                await db.SaveChangesAsync();
            }
        }

        // Удаление ценника из базы
        public static async Task<RoomCost> RoomCostDelete(int id)
        {
            using (HotelContext db = new HotelContext())
            {
                RoomCost roomCost = db.RoomCosts.FirstOrDefault(x => x.RoomCostId == id);
                if (roomCost != null)
                {
                    roomCost.Cost = 0;
                    db.RoomCosts.Update(roomCost);
                    await db.SaveChangesAsync();
                }
                return roomCost;
            }
        }
    }
}
