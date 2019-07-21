using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Entities
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }

        public virtual User User { get; set; }
        [JsonIgnore] public virtual Room Room { get; set; }

        public int UserId { get; set; }
        public int RoomId { get; set; }
        public int Cost { get; set; }
        public bool IsPaid { get; set; }
        public bool IsCanceled { get; set; }

    }
}
