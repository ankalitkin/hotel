import {Injectable} from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import {FinancicalInformation, Transaction, TransactionFilter} from '../../_models/transaction';
import {Observable} from 'rxjs';
import {User} from '../../_models/user';

@Injectable()
export class DataServiceTransaction {

  private baseUrl = '/api/Transactions';

  constructor(private http: HttpClient) { }

  GetTransactions(): Observable<Transaction[]> {
    return this.http.get<Transaction[]>(this.baseUrl);
  }

  GetInfo(filter?: TransactionFilter): Observable<Transaction[]> {

    let checkInTime = '';
    if (filter.checkInTime != undefined)
      checkInTime = filter.checkInTime.toISOString().substr(0,10);
    let checkOutTime = '';
    if (filter.checkOutTime != undefined)
      checkOutTime = filter.checkOutTime.toISOString().substr(0, 10);
    let type = filter.type.toString();
    let clientId = '';
    if (filter.clientId != undefined)
      clientId = filter.clientId.toString();

    let params = new HttpParams();

    params = params
      .append('start', checkInTime)
      .append('end', checkOutTime)
      .append('type', type)
      .append('id', clientId);


    return this.http.get<Transaction[]>(this.baseUrl +'/Info' , { params });
  }

  GetTransaction(transactionId: number): Observable<Transaction> {
    return this.http.get <Transaction>(this.baseUrl + '/' + transactionId);
  }

  PutTransaction(transaction: Transaction): Observable<void> {
    return this.http.put<void>(this.baseUrl + '/' + transaction.transactionId, transaction);
  }

  PostTransaction(transaction: Transaction): Observable<Transaction> {
    return this.http.post<Transaction>(this.baseUrl, transaction);
  }

  DeleteTransaction(transactionId: number): Observable<Transaction> {
    return this.http.delete<Transaction>(this.baseUrl + '/' + transactionId);
  }

  GetMyHistory(): Observable<Transaction[]> {
    return this.http.get<Transaction[]>(this.baseUrl + '/myHistory');
  }

  GetFinancicalInfo(start?: Date, end?: Date): Observable<FinancicalInformation[]> {
    let _start = '';
    if (start != undefined)
      _start = start.toISOString().substr(0, 10);;

    let _end = '';
    if (end != undefined)
      _end = end.toISOString().substr(0, 10);

    let params = new HttpParams();

    params = params
      .append('start', _start)
      .append('end', _end);

    return this.http.get<FinancicalInformation[]>(this.baseUrl + '/FinancialInformation', { params });
  }

  GetExpandData(UserId: number): Observable<User> {
    return this.http.get<User>(this.baseUrl + '/User/' + UserId);
  }
}
