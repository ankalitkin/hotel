using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Entities
{
    public class Role
    {
        [Flags]
        public enum AccessRights
        {
            CanEditRooms = 1,
            CanEditCost = 2,
            CanEditStuff = 4,
            CanRegisterClients = 8,
            CanEditClients = 16,
            CanBookRooms = 32,
            CanCheckInOut = 64,
            CanGetInfo = 128,
            CanGetAnyHistory = 256,
            CanGetOwnHistory = 512,
            CanGetFinancialInformation = 1024,
            IsCustomer = 2048
        }

        public int RoleId { get; set; }
        public string Name { get; set; }
        public AccessRights Rights { get; set; }
    }
}
