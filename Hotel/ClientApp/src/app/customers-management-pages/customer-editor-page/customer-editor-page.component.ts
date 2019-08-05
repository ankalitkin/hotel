import {Component, OnDestroy, OnInit} from '@angular/core';
import {User} from '../../_models/user';
import {Role} from '../../_models/role';
import {Subscription} from 'rxjs';
import {RoleListService} from '../../user-management/_services/role-list.service';
import {CustomersService} from '../_services/customers.service';
import {ActivatedRoute, Router} from '@angular/router';
import {ToastrService} from 'ngx-toastr';

@Component({
  selector: 'app-customer-editor-page',
  templateUrl: './customer-editor-page.component.html',
  styleUrls: ['./customer-editor-page.component.scss']
})
export class CustomerEditorPageComponent implements OnInit, OnDestroy {
  user: User;
  roles: Role[];
  private routeSub: Subscription;

  constructor(private roleListService: RoleListService,
              private customersService: CustomersService,
              private router: Router,
              private route: ActivatedRoute,
              private toastr: ToastrService) {
  }

  ngOnInit() {
    this.user = new User();
    this.routeSub = this.route.params.subscribe(params => {
      const id = params.id as string;
      if (id) {
        this.customersService.getCustomerByKey(id).subscribe(value => {
          this.user = value;
          this.loadRoles();
        });
      } else {
        this.loadRoles();
      }
    });
  }

  loadRoles() {
    this.roleListService.getCustomerRoles().subscribe(roles => {
      this.roles = roles;
    });
  }

  handleUserSave(user: User) {
    if (user.userId !== undefined) {
      this.customersService.updateCustomer(String(user.userId), user)
        .toPromise().then(this.Return()).catch(this.Error());
    } else {
      this.customersService.addCustomer(user).toPromise().then(this.Return()).catch(this.Error());
    }
  }

  ngOnDestroy() {
    this.routeSub.unsubscribe();
  }

  private Return() {
    return () => {
      this.toastr.success('Сохранено успешно!');
      this.router.navigate(['/customers/']);
    };
  }

  private Error() {
    return () => {
      this.toastr.error('Произошла ошибка!');
    };
  }

}
