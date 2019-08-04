import {Injectable} from '@angular/core';
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class PermissionService {

  constructor() {
  }

  checkPermission(permission: string): Observable<boolean> {
    // tslint:disable-next-line:no-bitwise
    // return !!(rights & AccessRights[permission]);
    return new Observable<boolean>(observer =>
      observer.next(confirm(`Do you REALLY have "${permission}" permission?`)));
  }
}
