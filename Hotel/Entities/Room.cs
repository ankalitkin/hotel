using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Hotel.Entities
{
    public class Room
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public string Floor { get; set; }
        [JsonIgnore] public virtual Category RoomType { get; set; }
        public int RoomTypeId { get; set; }

        public int NumberOfSeats { get; set; }
        public bool HasMiniBar { get; set; }
        public bool IsDeleted { get; set; }
        [NotMapped] public bool IsFree { get; } //ToDo
    }
}
