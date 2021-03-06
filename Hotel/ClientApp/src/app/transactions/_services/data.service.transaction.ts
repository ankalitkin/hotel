import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Transaction, FinancicalInformation, TransactionFilter, ExpandData } from '../../_models/transaction';
import { Room } from '../../_models/room';
import { Observable } from 'rxjs';

@Injectable()
export class DataServiceTransaction {

  private baseUrl = '/api/Transactions';

  constructor(private http: HttpClient) { }

  GetTransactions(): Observable<Transaction[]> {
    return this.http.get<Transaction[]>(this.baseUrl);
  }

  GetInfo(filter?: TransactionFilter): Observable<Transaction[]> {

    if (filter == undefined) {
      let params = new HttpParams();

      params = params
        .append('type', 'all');

      return this.http.get<Transaction[]>(this.baseUrl + '/Info', { params });
    }
    let checkInTime = '';
    if (filter.checkInTime != undefined)
      checkInTime = filter.checkInTime.toISOString().substr(0,10);
    let checkOutTime = '';
    if (filter.checkOutTime != undefined)
      checkOutTime = filter.checkOutTime.toISOString().substr(0, 10);
    let type = '';
    if (filter.type != undefined)
      type = filter.type.toString();
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
      _start = start.toISOString().substr(0, 10);

    let _end = '';
    if (end != undefined)
      _end = end.toISOString().substr(0, 10);

    let params = new HttpParams();

    params = params
      .append('start', _start)
      .append('end', _end);

    return this.http.get<FinancicalInformation[]>(this.baseUrl + '/FinancialInformation', { params });
  }

  GetExpandData(transactionId: Number): Observable<ExpandData> {
    return this.http.get<ExpandData>(this.baseUrl + '/ExpandData/' + transactionId);
  }

  GetRoomId(room: Room, transaction: Transaction): Observable<number>{
    return this.http.post<number>(this.baseUrl + '/RoomId', { room: room, transaction: transaction });
  }

  
  GetRoom(roomId: number): Observable<Room> {
    return this.http.get<Room>('/api/Admin/Rooms/' + roomId);
  }

  GetFreeRooms(transaction: Transaction, room: Room): Observable<Room[]> {

    console.log(transaction.checkInTime);
    let checkInTime = new Date(transaction.checkInTime).toISOString().substr(0, 10);
    let checkOutTime = new Date(transaction.checkOutTime).toISOString().substr(0, 10);
    let type = room.roomTypeId.toString();
    let seats = room.numberOfSeats.toString();
    let minibar = room.hasMiniBar.toString();

    let params = new HttpParams();

    params = params
      .append('start', checkInTime)
      .append('end', checkOutTime)
      .append('type', type)
      .append('seats', seats)
      .append('minibar', minibar);

    return this.http.get<Room[]>(this.baseUrl + '/FreeRooms', { params } );
  }

  GetRoomCost(roomId: number): Observable<number> {
    return this.http.get<number>(this.baseUrl + '/RoomCost/' + roomId);
  }

  GetTransactionsOfDate(date: Date): Observable<Transaction[]> {
    let _date = new Date(date).toISOString().substr(0, 10);

    let params = new HttpParams();
    params = params
      .append('date', _date);

    return this.http.get<Transaction[]>(this.baseUrl + '/TransactionsOfDate', { params });
  }
}
