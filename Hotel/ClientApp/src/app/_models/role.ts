export enum AccessRights {
  CanEditRooms = 1,
  CanEditCost = 2,
  CanEditStaff = 4,
  CanRegisterCustomers = 8,
  CanEditCustomers = 16,
  CanBookRooms = 32,
  CanCheckInOut = 64,
  CanGetInfo = 128,
  CanGetAnyHistory = 256,
  CanGetOwnHistory = 512,
  CanGetFinancialInformation = 1024,
  IsCustomer = 2048
}

export class Role {
  roleId: number;
  name: string;
  rights: AccessRights;
}
