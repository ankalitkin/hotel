export class User {
  public userId: number;
  public firstName: string;
  public lastName: string;
  public birthDate: Date;
  public phone: string;
  public email: string;
  public clientId: string;
  public roleId: string;
  public roleName: string;
  public isDeleted: boolean;
  public password: string;

  public constructor(init?: Partial<User>) {
    Object.assign(this, init);
    Object.keys(this).forEach((key) => (this[key] == null) && delete this[key]);
  }
}
