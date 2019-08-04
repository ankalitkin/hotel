using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Data;
using Hotel.Entities;

namespace Hotel.Services
{
    public class DataService
    {
        public async void AddUser(User Userx)
        {
            using (HotelContext db = new HotelContext())
            {
                await db.Users.AddAsync(Userx);
                await db.SaveChangesAsync();
            }
        }



        public User FindByUserEmail(string _email)
        {
            using (HotelContext db = new HotelContext())
            {
                var userlist = db.Users.ToList();
                var user = userlist.FirstOrDefault(v => v.Email == _email);
                return user;
            }
        }

        public User FindByUserId(string _id)
        {
            using (HotelContext db = new HotelContext())
            {
                var userlist = db.Users.ToList();
                var user = userlist.FirstOrDefault(v => v.UserId ==Convert.ToInt32(_id));
                return user;
            }
        }


    }
}
