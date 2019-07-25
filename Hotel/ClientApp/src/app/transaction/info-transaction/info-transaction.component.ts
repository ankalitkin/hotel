import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Transaction } from '../models/transaction';
import { User } from '../models/user';
import { DataServiceTransaction } from '../services/data.service.transaction';
import { InteractionService } from '../services/edit-transaction-interaction.service';


import { animate, state, style, transition, trigger } from '@angular/animations';

/*
 * @title Data table with sorting, pagination, and filtering and expanded.
 */
@Component({
  selector: 'info-transaction',
  styleUrls: ['info-transaction.component.scss'],
  templateUrl: 'info-transaction.component.html',
  providers: [DataServiceTransaction, InteractionService],
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

  constructor(private dataService: DataServiceTransaction,
    private interactionService: InteractionService) {
    interactionService.setRecipient(this); // установка в качестве получателя(получает от дочернего эл-та)
  }

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

  // обновление элемента в списке
  putTransaction(transaction: Transaction) {
    transaction.Loading = true;
    this.dataService.PutTransaction(transaction)
      .subscribe(() => { transaction.Loading = false; });
  }

  // Получение редактируемого объекта, чтобы в списке обновить только его одного
  getMessage() {
    const id = this.interactionService.getTemp();
    this.updateTransaction(id);
  }

  updateTransaction(id: number) {
    // нахождение индекса обновленной транзакции в списке
    const transaction = this.dataSource.data.find((t) => t.transactionId == id);
    const index = this.dataSource.data.indexOf(transaction);
    transaction.Loading = true;

    // взятие из базы и обновление в списке
    this.dataService.GetTransaction(id)
      .subscribe((data: Transaction) => {
        transaction.Loading = false;
        data.ComeIn = transaction.ComeIn;
        data.ComeOut = transaction.ComeOut;
        data.TheNoumber = transaction.TheNoumber;
        this.dataSource.data[index] = data;
        this.dataSource._updateChangeSubscription(); });
  }


}
