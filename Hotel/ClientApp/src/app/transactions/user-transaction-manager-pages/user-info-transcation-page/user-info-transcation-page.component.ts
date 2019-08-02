import { Component, OnInit, ViewChild } from '@angular/core';
import { DataServiceTransaction } from '../../_services/data.service.transaction';
import { InteractionService } from '../../_services/interaction.service';
import { Transaction, TransactionFilter } from '../../../_models/transaction';
import { InfoTransactionComponent } from '../../transaction/info-transaction/info-transaction.component';

@Component({
  selector: 'app-user-info-transcation-page',
  templateUrl: './user-info-transcation-page.component.html',
  styleUrls: ['./user-info-transcation-page.component.scss'],
  providers: [DataServiceTransaction, InteractionService]
})
export class UserInfoTranscationPageComponent implements OnInit {

  transactions?: Transaction[];
  isLoaded: Boolean = false;
  @ViewChild(InfoTransactionComponent, { static: false }) infoTrans: InfoTransactionComponent;

  constructor(private dataService: DataServiceTransaction, private interactionService: InteractionService) {
    interactionService.setRecipient(this); // установка в качестве получателя(получает от дочернего эл-та)
  }

  ngOnInit() {
    this.loadTransactions();
  }

  loadTransactions(filter?: TransactionFilter) {
    this.isLoaded = false;
    if (filter == undefined) {
      this.dataService.GetTransactions()
        .subscribe((data: Transaction[]) => { this.CompleteLoad(data); });
    } else {
      this.dataService.GetInfo(filter)
        .subscribe((data: Transaction[]) => { this.CompleteLoad(data); });
    }
  }

  CompleteLoad(data: Transaction[]) {
    this.transactions = data;
    for (let elem in this.transactions) {
      this.transactions[elem].TheNoumber = +elem + 1;
      this.transactions[elem].Loading = false;
    }
    this.isLoaded = true;
  }

  changeFilter(filter: TransactionFilter) {
    this.loadTransactions(filter);
  }

  // обновление элемента в базе
  putTransaction(transaction: Transaction) {
    transaction.Loading = true;
    this.dataService.PutTransaction(transaction)
      .subscribe(() => { transaction.Loading = false; });
  }

  // Получение id редактируемого объекта, чтобы в списке обновить только его одного
  getMessage() {
    const id = this.interactionService.getTemp();

    // нахождение индекса обновленной транзакции в списке
    const old_transaction = this.infoTrans.dataSource.data.find((t) => t.transactionId == id);
    old_transaction.Loading = true;
    const index = this.infoTrans.dataSource.data.indexOf(old_transaction);

    // Загрузка транзакции из базы по индексу (можно было и без этого, напрямую передав объект)
    //( всё только ради кружочка загрузки только ОДНОГО элемнта :-)
    this.dataService.GetTransaction(id)
      .subscribe((data) => {
        data.Loading = false;
        data.TheNoumber = old_transaction.TheNoumber;
        // обновление транзакции в списке дочернего элемента
        this.infoTrans.updateTransaction(data, index);
      });
  }
}
