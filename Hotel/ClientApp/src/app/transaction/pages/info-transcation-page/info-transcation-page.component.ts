import { Component, OnInit } from '@angular/core';
import { DataServiceTransaction } from '../../services/data.service.transaction';
import { Transaction } from '../../models/transaction';
import { TransactionFilter } from '../../models/transaction';


@Component({
  selector: 'app-info-transcation-page',
  templateUrl: './info-transcation-page.component.html',
  styleUrls: ['./info-transcation-page.component.scss'],
  providers: [DataServiceTransaction]
})
export class InfoTranscationPageComponent implements OnInit {

  transactions?: Transaction[];
  isLoaded: Boolean = false;

  constructor(private dataService: DataServiceTransaction) { }

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


}
