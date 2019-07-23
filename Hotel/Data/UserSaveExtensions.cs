using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Data
{
    public static class UserSaveExtensions
    {
        public static async void UserSave(this User userx)
        {
            using (HotelContext db = new HotelContext())
            {
                await db.Users.AddAsync(userx);
               // await db.Users.Add()
                await db.SaveChangesAsync();
            }
        }
    }
}
