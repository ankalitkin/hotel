import {Component, OnInit, ViewChild} from '@angular/core';
import {User} from '../../_models/user';
import {CustomersService} from '../_services/customers.service';
import {MatSort, MatTableDataSource} from '@angular/material';

@Component({
  selector: 'app-customers-table',
  templateUrl: './customers-table.component.html',
  styleUrls: ['./customers-table.component.scss']
})
export class CustomersTableComponent implements OnInit {
  customers: MatTableDataSource<User>;
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

  constructor(private customersService: CustomersService) {}

  @ViewChild(MatSort, {static: true}) sort: MatSort;
  ngOnInit() {
    this.customersService.getCustomers().subscribe(value => {
      this.customers = new MatTableDataSource<User>(value);
      this.customers.sort = this.sort;
    });
  }

  applyFilter(filterValue: string) {
    this.customers.filter = filterValue.trim().toLowerCase();
  }
}
