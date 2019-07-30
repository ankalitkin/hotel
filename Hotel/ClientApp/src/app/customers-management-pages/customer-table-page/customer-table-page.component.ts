import {Component, OnInit} from '@angular/core';
import {User} from '../../_models/user';
import {CustomersService} from '../_services/customers.service';

@Component({
  selector: 'app-customer-table-page',
  templateUrl: './customer-table-page.component.html',
  styleUrls: ['./customer-table-page.component.scss']
})
export class CustomerTablePageComponent implements OnInit {
  customers: User[];
  displayedColumns: string[] = [
    'userId',
    'lastName',
    'firstName',
    'birthDate',
    'phone',
    'email',
    'clientID',
    'roleName',
    'editButton'
    // 'isDeleted'
  ];

  constructor(private customersService: CustomersService) {
  }

  ngOnInit() {
    this.customersService.getCustomers().subscribe(value => this.customers = value);
  }

}
