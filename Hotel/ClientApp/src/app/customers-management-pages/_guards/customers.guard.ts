import {Injectable} from '@angular/core';
import {ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot} from '@angular/router';
import {Observable} from 'rxjs';
import {PermissionService} from '../../_auth/_services/permission.service';

@Injectable({
  providedIn: 'root'
})

export class CustomersGuard implements CanActivate {
  constructor(private permissionService: PermissionService) {
  }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> {
    return this.permissionService.checkPermission('CanEditCustomers');
  }

}

