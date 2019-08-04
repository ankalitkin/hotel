using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Entities;

namespace Hotel
{
    public class info
    {
        public string Firstname{ get; set;}
        public string Email { get; set;}
        public string Phone { get; set;}

        public info(string f, string e, string p)
        {
            Firstname = f;
            Email = e;
            Phone = p;
        }
    }
}
