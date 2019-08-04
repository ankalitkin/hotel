import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {AccessRights} from '../_models/role';
import {UserService} from '../user/services/user.service';

@Injectable({
  providedIn: 'root'
})
export class PermissionService {

  users: any = {};

  constructor(private userService: UserService) {
  }

  checkPermission(permission: string): Observable<boolean> {
    return new Observable<boolean>(observer => {
      if (!this.getToken()) {
        console.error('No user rights information found');
        return observer.next(false);
      }

      if (!(permission in AccessRights)) {
        console.error('No ' + permission + ' permission found');
        return observer.next(false);
      }

      const cache = this.getCached(permission);
      if (cache !== undefined) {
        return observer.next(this.getCached(permission));
      }

      this.userService.getUserProfile().toPromise().then(user => {
        if (!('rights' in user)) {
          return observer.next(false);
        }
        // @ts-ignore
        // tslint:disable-next-line:no-bitwise
        const value = !!(user.rights & AccessRights[permission]);
        return observer.next(this.cacheAndReturn(permission, value));
      }).catch(reason => {
        console.error(reason);
        observer.next(this.cacheAndReturn(permission, false));
      });
    });
  }

  getToken(): string {
    return localStorage.getItem('token');
  }

  getCached(permission: string) {
    const token = this.getToken();
    if (!(token in this.users) || !(permission in this.users[token])) {
      return undefined;
    }
    return this.users[token][permission];
  }

  cacheAndReturn(permission: string, value: boolean): boolean {
    const token = this.getToken();
    if (!(token in this.users)) {
      this.users[token] = {};
    }
    this.users[token][permission] = value;
    return value;
  }
}
