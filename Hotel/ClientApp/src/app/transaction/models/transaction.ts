import { jsonIgnoreReplacer, jsonIgnore } from 'json-ignore';

export class Transaction {

  public transactionId: number;
  public checkInTime: Date;
  public checkOutTime: Date;
  public userId: number;
  public roomId: number;
  public cost: number;
  public isPaid: Boolean;
  public isCanceled: Boolean;

  @jsonIgnore() public TheNoumber: number;
  @jsonIgnore() public Loading: Boolean;
}

export interface TransactionFilter {

  clientId: number;
  checkInTime: Date;
  checkOutTime: Date;
  type: String;

}

export class FinancicalInformation {

  public dateTime: Date;
  public sum: Number;

  @jsonIgnore() public TheNoumber: number;
}

export interface FinancicalInfoFilter {

  start: Date;
  end: Date;

}

