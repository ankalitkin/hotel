using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Entities
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        [Required, DataType(DataType.Date)]
        public DateTime CheckInTime { get; set; }
        [Required, DataType(DataType.Date)]
        public DateTime CheckOutTime { get; set; }

        [JsonIgnore] public virtual User User { get; set; }
        [JsonIgnore] public virtual Room Room { get; set; }

        [Required]
        public int UserId { get; set; }
        [Required]
        public int RoomId { get; set; }
        [DataType(DataType.Currency)]
        public int Cost { get; set; }
        public bool IsPaid { get; set; }
        public bool IsCanceled { get; set; }
        public bool isEvicted { get; set; }

    }
}
