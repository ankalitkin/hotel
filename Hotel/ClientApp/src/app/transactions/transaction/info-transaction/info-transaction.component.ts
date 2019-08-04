import { Component, OnInit, ViewChild, Input, Output, EventEmitter } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Transaction, ExpandData } from '../../../_models/transaction';


import {animate, state, style, transition, trigger} from '@angular/animations';

@Component({
  selector: 'info-transaction',
  styleUrls: ['info-transaction.component.scss'],
  templateUrl: 'info-transaction.component.html',
  animations: [ // для раскрываемого списка
    trigger('detailExpand', [
      state('collapsed', style({ height: '0px', minHeight: '0' })),
      state('expanded', style({ height: '*' })),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class InfoTransactionComponent implements OnInit {
  displayedColumns: string[] = ['TheNoumber', 'checkInTime', 'checkOutTime', 'status', 'cost'];
  dataSource: MatTableDataSource<Transaction>;

  @Input()
  transactions: Transaction[] | null | undefined;

  @Output()
  putTransactionEvent = new EventEmitter<Transaction>();

  expandedElement: Transaction | null;
  showExpandData: Boolean = false;
  tempExpandData?: ExpandData;
  updateExpand?: Boolean = false;
  currentDate: Date = new Date(); // чтобы не горела кнопка "отменить"

  SaveTemp(expandData: ExpandData) {
    this.tempExpandData = expandData;
    this.updateExpand = false;
  }

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor() { }

  ngOnInit() {
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

  // запрос к родителю на обновление элемента в базе
  putTransaction(transaction: Transaction) {
    this.putTransactionEvent.emit(transaction);
  }

  // обновление транзакции в списке (после редактирования)
  updateTransaction(transaction: Transaction, index: number) {
    this.updateExpand = true;
    this.dataSource.data[index] = transaction;
    this.dataSource._updateChangeSubscription();
  }

}
