import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Transaction } from '../models/transaction';
import { TransactionFilter } from '../models/transaction';

@Injectable()
export class DataServiceTransaction {

  private url = "/api/Transactions";

  constructor(private http: HttpClient) {
  }

  GetTransactions() {
    return this.http.get(this.url);
  }

  GetFilteredTransactions(filter: TransactionFilter) {


    let checkInTime = '';
    if (filter.checkInTime != undefined)
      checkInTime = this.parseDate(filter.checkInTime, '%2F');
    let checkOutTime = '';
    if (filter.checkOutTime != undefined)
      checkOutTime = this.parseDate(filter.checkOutTime, '%2F');
    let type = filter.type.toString();
    let clientId = '';
    if (filter.clientId != undefined)
      clientId = filter.clientId.toString();

    return this.http.get(this.url + '/Filter?' + 'start=' + checkInTime + '&' + 'end=' + checkOutTime + '&'
      + 'type=' + type + '&' + 'id=' + clientId);
    // P.S. по-хорошему через параметры не получилось дату передать в нужном формате
  }

  GetTransaction(transactionId: number) {
    return this.http.get(this.url + '/' + transactionId);
  }

  PutTransaction(transaction: Transaction) {
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


  GetFinancicalInfo(start?: Date, end?: Date) {
    let _start = '';
    if (start != undefined)
      _start = this.parseDate(start, '%2F');

    let _end = '';
    if (end != undefined)
      _end = this.parseDate(end, '%2F');

    console.log(this.url + '/FinancialInformation/' + '?start=' + _start + '&end=' + _end);
    return this.http.get(this.url + '/FinancialInformation/' + '?start=' + _start + '&end=' + _end);
  }

  GetUser(UserId: number) {
    return this.http.get(this.url + '/User/' + UserId);
  }

  parseDate(input, separator?: string) {
    if (separator == undefined)
      separator = '%2F';

    let newDate: Date = new Date(input);
    let day: string = ((newDate.getDate() > 9) ? newDate.getDate() : "0" + newDate.getDate()).toString();
    let mouth: string = ((newDate.getMonth() > 9) ? newDate.getMonth() : "0" + newDate.getMonth()).toString();

    return mouth + separator + day + separator + newDate.getFullYear();
  }
}
