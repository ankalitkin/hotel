using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Entities
{
    public class RoomCost
    {
        private int v1;
        private int v2;
        private bool v3;
        private int v4;
        public RoomCost() { }
        public RoomCost(int v1, int v2, bool v3, int v4)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
        }

        public int RoomCostId { get; set; }
        [JsonIgnore]public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
        public int NumberOfSeats { get; set; }
        public bool HasMiniBar { get; set; }
        public int Cost { get; set; }
    }
}
