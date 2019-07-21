import { User } from './user';

export class Transaction {

  constructor() { }
  public transactionId: number;
  public checkInTime: Date;
  public checkOutTime: Date;
  public user: User;
  public userId: number;
  public roomId: number;
  public cost: number;
  public isPaid: Boolean;
  public isCanceled: Boolean;

   // для фильтра
  public UserName: string;
  public ComeIn: string;
  public ComeOut: string;
  public TheNoumber: number;
}
