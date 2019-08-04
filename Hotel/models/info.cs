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
        public int Rights { get; set;}

        public info(string f, string e, string p, int r)
        {
            Firstname = f;
            Email = e;
            Phone = p;
            Rights = r;
        }
    }
}
