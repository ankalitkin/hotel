import {Component, OnChanges, OnDestroy, OnInit, SimpleChanges} from '@angular/core';
import {Role} from '../../_models/role';
import {User} from '../../_models/user';
import {RoleListService} from '../../_shared/_services/role-list.service';
import {CustomersService} from '../_services/customers.service';
import {ActivatedRoute, Router} from '@angular/router';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {EMPTY, Subscription} from 'rxjs';
import {switchMap} from 'rxjs/operators';

@Component({
  selector: 'app-customer-editor',
  templateUrl: './customer-editor.component.html',
  styleUrls: ['./customer-editor.component.scss']
})
export class CustomerEditorComponent implements OnInit, OnDestroy {
  roles: Role[];
  customer: User;
  customerForm: FormGroup;
  private routeSub: Subscription;
  constructor(private roleListService: RoleListService,
              private customersService: CustomersService,
              private router: Router,
              private route: ActivatedRoute,
              private fb: FormBuilder) {
    this.customerForm = fb.group({
      userId: fb.control(undefined),
      firstName: fb.control(undefined, [Validators.required]),
      lastName: fb.control(undefined, [Validators.required]),
      birthDate: fb.control(undefined, [Validators.required]),
      email: fb.control(undefined),
      phone: fb.control(undefined),
      clientId: fb.control(undefined, [Validators.required]),
      password: fb.control(undefined),
      roleId: fb.control(undefined, [Validators.required]),
      isDeleted: fb.control(undefined)
    });

    /*activeRoute.paramMap
      .pipe(
        switchMap(params => {
          const id = params.get('id') as string;
          if (id) {
            return customersService.getCustomerByKey(id);
          } else { return EMPTY; }
        })
      ).subscribe(customer => {
        this.customer = customer;
        this.customerForm.patchValue(customer);
      });*/

  }


  ngOnInit() {
    this.customer = new User();
    this.routeSub = this.route.params.subscribe(params => {
      const id = params.id as string;
      if (!id) { return; }
      this.customersService.getCustomerByKey(id).subscribe(value => {
        this.customer = value;
        this.customerForm.patchValue(this.customer);
      });
    });

    this.roleListService.getCustomerRoles().subscribe(value => {
      if (!this.customer.roleId) {
        this.roles = value;
        this.customerForm.patchValue({roleId: String(value[0].roleId)});
      }
    });
  }

  handleSaveClick() {
    this.customer = new User(this.customerForm.value);
    if (this.customer.userId !== undefined) {
      this.customersService.updateCustomer(String(this.customer.userId), this.customer)
        .toPromise().then(this.Return()).catch(this.Error());
    } else {
      this.customersService.addCustomer(this.customer).toPromise().then(this.Return()).catch(this.Error());
    }
  }

  private Return() {
    return value => {
      alert('Сохранено успешно!');
      this.router.navigate(['/customers']);
    };
  }

  private Error() {
    return value => {
      alert('Произошла ошибка!');
    };
  }

  ngOnDestroy() {
    this.routeSub.unsubscribe();
  }
}
