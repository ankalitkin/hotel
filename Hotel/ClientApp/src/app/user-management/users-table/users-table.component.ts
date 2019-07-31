import {Component, Input, OnChanges, OnInit, SimpleChanges, ViewChild} from '@angular/core';
import {User} from '../../_models/user';
import {MatPaginator, MatSort, MatTableDataSource} from '@angular/material';

@Component({
  selector: 'app-users-table',
  templateUrl: './users-table.component.html',
  styleUrls: ['./users-table.component.scss']
})
export class UsersTableComponent implements OnInit, OnChanges {
  usersData: MatTableDataSource<User>;
  filter: '';
  showDeleted = false;
  @Input() users: User[];
  @Input() displayedColumns: string[];
  @ViewChild(MatSort, {static: true}) sort: MatSort;
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;

  constructor() {
  }

  ngOnInit() {
  }

  ngOnChanges(changes: SimpleChanges): void {
    if ('users' in changes && this.users) {
      this.applyDeleted(this.showDeleted);
    }
  }

  applyDeleted(showDeleted) {
    this.usersData = new MatTableDataSource<User>(this.users.filter(user => user.isDeleted === showDeleted));
    this.usersData.paginator = this.paginator;
    this.usersData.sort = this.sort;
    this.applyFilter(this.filter);
  }

  applyFilter(filterValue: string) {
    if (!filterValue) {
      return;
    }
    this.usersData.filter = filterValue.trim().toLowerCase();
  }
}
