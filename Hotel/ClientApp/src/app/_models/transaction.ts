import {jsonIgnore } from 'json-ignore';

export class Transaction {

  constructor() { }
  public transactionId: number;
  public checkInTime: Date;
  public checkOutTime: Date;
  public userId: number;
  public roomId: number;
  public cost: number;
  public isPaid: boolean;
  public isCanceled: boolean;

   // для фильтра
  @jsonIgnore() public UserName: string;
  @jsonIgnore() public ComeIn: string;
  @jsonIgnore() public ComeOut: string;
  @jsonIgnore() public TheNoumber: number;
}
