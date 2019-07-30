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

export class TransactionFilter {
  constructor() { }

  public clientId: number;
  public checkInTime: Date;
  public checkOutTime: Date;
  public type: String;

}

export class FinancicalInformation {
  constructor() { }

  public dateTime: Date;
  public sum: Number;

  @jsonIgnore() public TheNoumber: number;
}

export class FinancicalInfoFilter {
  constructor() { }

  public start: Date;
  public end: Date;

}
