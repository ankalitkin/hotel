import { Injectable } from '@angular/core';
import {Observable} from 'rxjs';
import {HttpClient} from '@angular/common/http';
import {User} from '../../_models/user';
// import {SharedModule} from '../customers-management.module';

@Injectable({
  providedIn: 'root'
})
export class CustomersService {

  constructor(private httpClient: HttpClient) { }

  getCustomers(): Observable<User[]> {
    return this.httpClient.get<User[]>('api/users/');
  }

  getCustomerByKey(key: string): Observable<User> {
    return this.httpClient.get<User>(`api/users/${key}`);
  }

  updateCustomer(key: string, user: User): Observable<void> {
    return this.httpClient.put<void>(`api/users/${key}`, user);
  }

  addCustomer(user: User): Observable<void> {
    return this.httpClient.post<void>(`api/users/`, user);
  }

  deleteCustomer(key: string): Observable<void> {
    return this.httpClient.delete<void>(`api/users/${key}`);
  }

}
