import { User } from './user';
import { jsonIgnoreReplacer, jsonIgnore } from 'json-ignore';

export class Transaction {

  constructor() { }
  public transactionId: number;
  public checkInTime: Date;
  public checkOutTime: Date;
  public userId: number;
  public roomId: number;
  public cost: number;
  public isPaid: Boolean;
  public isCanceled: Boolean;

   // для фильтра
  @jsonIgnore() public ComeIn: string;
  @jsonIgnore() public ComeOut: string;
  @jsonIgnore() public TheNoumber: number;
  @jsonIgnore() public Loading: Boolean;
}
