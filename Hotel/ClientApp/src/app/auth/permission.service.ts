import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {AccessRights} from '../_models/role';
import {CurrentUserService} from './current-user.service';

@Injectable({
  providedIn: 'root'
})
export class PermissionService {

  constructor(private currentUserService: CurrentUserService) {
  }

  checkPermission(permission: string): Observable<boolean> {
    return new Observable<boolean>(observer => {
      const rights = this.currentUserService.getUserRights();
      // tslint:disable-next-line:no-bitwise
      const value = !!(rights & AccessRights[permission]);
      return observer.next(value);
    });
  }
}
