using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel
{
    public class reg_model
    {
        public string Firstname { get; set;}
        public string Lastname { get; set; }
        public string Password{ get; set; }
        public string Email { get; set; }

        public reg_model(string f, string l,string p,string e)
        {
            Firstname = f;
            Lastname = l;
            Password = p;
            Email=e;
        }
    }
}
