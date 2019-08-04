import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {HttpClient} from '@angular/common/http';
import {Role} from '../../_models/role';

@Injectable({
  providedIn: 'root'
})

export class RoleListService {

  constructor(private httpClient: HttpClient) { }

  getAllRoles(): Observable<Role[]> {
    return this.httpClient.get<Role[]>('api/roleList/');
  }

  getCustomerRoles(): Observable<Role[]> {
    return this.httpClient.get<Role[]>('api/roleList/customers');
  }

  getStaffRoles(): Observable<Role[]> {
    return this.httpClient.get<Role[]>('api/roleList/staff');
  }

  getRoles(group: string): Observable<Role[]> {
    return this.httpClient.get<Role[]>('api/roleList/' + group);
  }

}
