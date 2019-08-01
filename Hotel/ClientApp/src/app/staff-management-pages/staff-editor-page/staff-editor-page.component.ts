import {Component, OnDestroy, OnInit} from '@angular/core';
import {User} from '../../_models/user';
import {Role} from '../../_models/role';
import {Subscription} from 'rxjs';
import {RoleListService} from '../../_shared/_services/role-list.service';
import {StaffService} from '../_services/staff.service';
import {ActivatedRoute, Router} from '@angular/router';

@Component({
  selector: 'app-staff-editor-page',
  templateUrl: './staff-editor-page.component.html',
  styleUrls: ['./staff-editor-page.component.scss']
})
export class StaffEditorPageComponent implements OnInit, OnDestroy {
  user: User;
  roles: Role[];
  private routeSub: Subscription;

  constructor(private roleListService: RoleListService,
              private staffService: StaffService,
              private router: Router,
              private route: ActivatedRoute) {
  }

  ngOnInit() {
    this.user = new User();
    this.routeSub = this.route.params.subscribe(params => {
      const id = params.id as string;
      if (id) {
        this.staffService.getStaffByKey(id).subscribe(value => {
          this.user = value;
          this.loadRoles();
        });
      } else {
        this.loadRoles();
      }
    });
  }

  loadRoles() {
    this.roleListService.getStaffRoles().subscribe(roles => {
      this.roles = roles;
    });
  }

  handleUserSave(user: User) {
    if (user.userId !== undefined) {
      this.staffService.updateStaff(String(user.userId), user)
        .toPromise().then(this.Return()).catch(this.Error());
    } else {
      this.staffService.addStaff(user).toPromise().then(this.Return()).catch(this.Error());
    }
  }

  ngOnDestroy() {
    this.routeSub.unsubscribe();
  }

  private Return() {
    return () => {
      alert('Сохранено успешно!');
      this.router.navigate(['/staff/']);
    };
  }

  private Error() {
    return () => {
      alert('Произошла ошибка!');
    };
  }

}
