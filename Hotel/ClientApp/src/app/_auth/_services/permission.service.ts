import {Injectable} from '@angular/core';
import {Observable, of} from "rxjs";
import {AccessRights} from "../../_models/role";
import {CurrentUserService} from "./current-user.service";

@Injectable({
  providedIn: 'root'
})
export class PermissionService {

  constructor(private currentUserService: CurrentUserService) {
  }

  getRights(permission: string): boolean {
    const user = this.currentUserService.getUserData();
    if (!user)
      return false;
    const rights = user['rights'];
    if (!rights)
      return false;
    // tslint:disable-next-line:no-bitwise
    return !!(rights & AccessRights[permission]);
  }

  checkPermission(permission: string): Observable<boolean> {
    // return new Observable<boolean>(observer =>
    //   observer.next(confirm(`Do you REALLY have "${permission}" permission?`)));
    return of(this.getRights(permission));
  }
}
