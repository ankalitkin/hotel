import {Injectable} from '@angular/core';
import {ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot} from '@angular/router';
import {Observable} from 'rxjs';
import {PermissionService} from '../../auth/permission.service';

@Injectable({
  providedIn: 'root'
})

export class RoomCostManagementGuard implements CanActivate {
  constructor(private permissionService: PermissionService) {
  }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> {
    return this.permissionService.checkPermission('CanEditCost');
  }

}

