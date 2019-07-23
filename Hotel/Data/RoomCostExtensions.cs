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
        public static async Task<RoomCost> FindRoomCost(int CategoryId, int NumberOfSeats, bool HasMiniBar)
        {
            using (HotelContext db = new HotelContext())
            {
                return await db.RoomCosts.AsNoTracking().FirstOrDefaultAsync(
                    rc => CategoryId == rc.CategoryId &&
                          NumberOfSeats == rc.NumberOfSeats &&
                          HasMiniBar == rc.HasMiniBar);
            }
        }

        // Вывод всех записей
        public static async Task<IEnumerable<RoomCost>> AllRoomCosts()
        {
            using (HotelContext db = new HotelContext())
            {
                return await db.RoomCosts.AsNoTracking().ToListAsync();
            }
        }

        // Сохраниение/добавление в базу
        public static async void RoomCostSave(this RoomCost roomCost)
        {
            using (HotelContext db = new HotelContext())
            {
                RoomCost foundRoomCost = FindRoomCost(roomCost.CategoryId, roomCost.NumberOfSeats, roomCost.HasMiniBar).Result;
                if (foundRoomCost == null)
                    await db.RoomCosts.AddAsync(roomCost);
                else
                {
                    foundRoomCost.Cost = roomCost.Cost;
                    db.RoomCosts.Update(foundRoomCost);
                }                   

                await db.SaveChangesAsync();
            }
        }
    }
}
