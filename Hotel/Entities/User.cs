using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        [StringLength(12)]
        public string ClientID { get; set; }
        public virtual Role Role { get; set; }
        public int RoleId { get; set; }
        public bool IsDeleted { get; set; }

        [NotMapped] public bool CanEditRooms => Role.Rights.HasFlag(Role.AccessRights.CanEditRooms);
        [NotMapped] public bool CanEditCost => Role.Rights.HasFlag(Role.AccessRights.CanEditCost);
        [NotMapped] public bool CanEditStuff => Role.Rights.HasFlag(Role.AccessRights.CanEditStuff);
        [NotMapped] public bool CanRegisterClients => Role.Rights.HasFlag(Role.AccessRights.CanRegisterClients);
        [NotMapped] public bool CanEditClients => Role.Rights.HasFlag(Role.AccessRights.CanEditClients);
        [NotMapped] public bool CanBookRooms => Role.Rights.HasFlag(Role.AccessRights.CanBookRooms);
        [NotMapped] public bool CanCheckInOut => Role.Rights.HasFlag(Role.AccessRights.CanCheckInOut);
        [NotMapped] public bool CanGetInfo => Role.Rights.HasFlag(Role.AccessRights.CanGetInfo);
        [NotMapped] public bool CanGetAnyHistory => Role.Rights.HasFlag(Role.AccessRights.CanGetAnyHistory);
        [NotMapped] public bool CanGetOwnHistory => Role.Rights.HasFlag(Role.AccessRights.CanGetOwnHistory);
        [NotMapped] public bool CanGetFinancialInformation => Role.Rights.HasFlag(Role.AccessRights.CanGetFinancialInformation);
    }
}
