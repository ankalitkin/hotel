import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Transaction } from '../models/transaction'

@Injectable()
export class DataServiceTransaction {

  private url = "/api/Transactions";

  constructor(private http: HttpClient) {
  }

  GetTransactions() {
    return this.http.get(this.url);
  }

  GetTransaction(transactionId: number) {
    return this.http.get(this.url + '/' + transactionId);
  }

  PutTransaction(transaction: Transaction) {
    console.log(this.url + '/' + transaction.transactionId);
    console.log(transaction);
    return this.http.put(this.url + '/' + transaction.transactionId, transaction);
  }

  PostTransaction(transaction: Transaction) {
    return this.http.post(this.url, transaction);
  }

  DeleteTransaction(transactionId: number) {
    return this.http.delete(this.url + '/' + transactionId);
  }

  GetHistory(id: number, isOnlyPaid: boolean = false) {
    return this.http.get(this.url + '/History/' + id);
  }

  
  GetInfo(date?: Date) {
    return this.http.get(this.url + '/Info/' + date);
  }

  GetUser(UserId: number) {
    return this.http.get(this.url + '/User/' + UserId);
  }
}
