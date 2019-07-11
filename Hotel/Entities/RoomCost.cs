using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Entities
{
    public class RoomCost
    {
        public int CostID { get; set; }
        public virtual Category Category { get; set; }
        public int NumberOfSeats { get; set; }
        public bool HasMiniBar { get; set; }
        public int Cost { get; set; }
    }
}
