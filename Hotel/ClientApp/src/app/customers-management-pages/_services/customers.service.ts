import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {HttpClient} from '@angular/common/http';
import {User} from '../../_models/user';

// import {SharedModule} from '../usersData-management.module';

@Injectable({
  providedIn: 'root'
})
export class CustomersService {

  constructor(private httpClient: HttpClient) { }

  getCustomers(): Observable<User[]> {
    return this.httpClient.get<User[]>('api/customers/');
  }

  getCustomerByKey(key: string): Observable<User> {
    return this.httpClient.get<User>(`api/customers/${key}`);
  }

  updateCustomer(key: string, user: User): Observable<void> {
    return this.httpClient.put<void>(`api/customers/${key}`, user);
  }

  addCustomer(user: User): Observable<void> {
    return this.httpClient.post<void>(`api/customers/`, user);
  }

  deleteCustomer(key: string): Observable<void> {
    return this.httpClient.delete<void>(`api/customers/${key}`);
  }

}
