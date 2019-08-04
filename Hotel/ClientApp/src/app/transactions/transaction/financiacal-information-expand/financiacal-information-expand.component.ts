import { Component, OnInit, ViewChild, Input} from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Transaction } from '../../../_models/transaction';

@Component({
  selector: 'financiacal-information-expand',
  templateUrl: './financiacal-information-expand.component.html',
  styleUrls: ['./financiacal-information-expand.component.scss']
})
export class FinanciacalInformationExpandComponent implements OnInit {

  @Input()
  expandData?: Transaction[];

  displayedColumns: string[] = ['TheNoumber','transactionId','userId','checkInTime', 'checkOutTime', 'cost'];
  dataSource: MatTableDataSource<Transaction>;

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor() { }

  ngOnInit() {
    this.dataSource = new MatTableDataSource(this.expandData);
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
