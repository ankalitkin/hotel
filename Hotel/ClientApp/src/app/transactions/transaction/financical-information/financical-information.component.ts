import {Component, Input, OnInit, ViewChild} from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import {MatSort} from '@angular/material/sort';
import {MatTableDataSource} from '@angular/material/table';
import {FinancicalInformation, Transaction} from '../../../_models/transaction';

import { animate, state, style, transition, trigger } from '@angular/animations';


@Component({
  selector: 'financical-information',
  templateUrl: './financical-information.component.html',
  styleUrls: ['./financical-information.component.scss'],
  animations: [ // для раскрываемого списка
    trigger('detailExpand', [
      state('collapsed', style({ height: '0px', minHeight: '0' })),
      state('expanded', style({ height: '*' })),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ]
})
export class FinancicalInformationComponent implements OnInit {

  displayedColumns: string[] = ['TheNoumber', 'dateTime', 'sum'];
  dataSource: MatTableDataSource<FinancicalInformation>;
  @Input()
  financicalInformation: FinancicalInformation[] | null | undefined;
  sum: number = 0;

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  expandedElement: FinancicalInformation | null;
  showExpandData: Boolean = false;
  tempExpandData?: Transaction;
  updateExpand?: Boolean = false;

  constructor() { }

  ngOnInit() {
    this.dataSource = new MatTableDataSource(this.financicalInformation);
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;


    this.dataSource.data.forEach((info) => this.sum += info.sum.valueOf());
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

}
