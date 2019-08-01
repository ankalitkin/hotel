import { Component, OnInit, ViewChild, Input, Output, EventEmitter } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { FinancicalInformation } from '../../_models/transaction';


@Component({
  selector: 'financical-information',
  templateUrl: './financical-information.component.html',
  styleUrls: ['./financical-information.component.scss'],
})
export class FinancicalInformationComponent implements OnInit {

  displayedColumns: string[] = ['TheNoumber', 'dateTime', 'sum'];
  dataSource: MatTableDataSource<FinancicalInformation>;
  @Input()
  financicalInformation: FinancicalInformation[] | null | undefined;

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor() { }

  ngOnInit() {
    this.dataSource = new MatTableDataSource(this.financicalInformation);
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
