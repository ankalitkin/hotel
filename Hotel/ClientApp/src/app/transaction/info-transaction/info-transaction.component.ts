import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Transaction } from '../../_models/transaction';
import { User } from '../../_models/user';


import { animate, state, style, transition, trigger } from '@angular/animations';

/*
 * @title Data table with sorting, pagination, and filtering and expanded.
 */
@Component({
  selector: 'info-transaction',
  styleUrls: ['info-transaction.component.scss'],
  templateUrl: 'info-transaction.component.html',
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({ height: '0px', minHeight: '0' })),
      state('expanded', style({ height: '*' })),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class InfoTransactionComponent implements OnInit {
  displayedColumns: string[] = ['TheNoumber', 'UserID', 'ComeIn', 'ComeOut', 'cost'];
  dataSource: MatTableDataSource<Transaction>;
  @Input()
  transactions: Transaction[] | null | undefined;
  expandedElement: Transaction | null;
  showInfoUser: Boolean = false;
  tempUserInfo?: User;

  SaveTemp(user: User) {
    this.tempUserInfo = user;
  }
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor() { }

  ngOnInit() {
    // Assign the data to the data source for the table to render
    this.dataSource = new MatTableDataSource(this.transactions);

    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

}
