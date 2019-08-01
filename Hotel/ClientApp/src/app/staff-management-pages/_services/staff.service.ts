import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {HttpClient} from '@angular/common/http';
import {User} from '../../_models/user';

// import {SharedModule} from '../usersData-management.module';

@Injectable({
  providedIn: 'root'
})
export class StaffService {

  constructor(private httpClient: HttpClient) {
  }

  getStaff(): Observable<User[]> {
    return this.httpClient.get<User[]>('api/staff/');
  }

  getStaffByKey(key: string): Observable<User> {
    return this.httpClient.get<User>(`api/staff/${key}`);
  }

  updateStaff(key: string, user: User): Observable<void> {
    return this.httpClient.put<void>(`api/staff/${key}`, user);
  }

  addStaff(user: User): Observable<void> {
    return this.httpClient.post<void>(`api/staff/`, user);
  }

  deleteStaff(key: string): Observable<void> {
    return this.httpClient.delete<void>(`api/staff/${key}`);
  }

}
