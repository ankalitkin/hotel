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

  constructor(private dataService: DataServiceTransaction) {
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


    this.dataService.GetFilteredTransactions(filter)
      .subscribe((data: Transaction[]) => { this.CompleteLoad(data); });
    }
  }

  // для фильтра (знаю, что криво)
  parseDate(input, separator?: string) {
    if (separator == undefined)
      separator = '-';

    let newDate: Date = new Date(input);
    let day: string = ((newDate.getDate() > 9) ? newDate.getDate() : "0" + newDate.getDate()).toString();
    let mouth: string = ((newDate.getMonth() > 9) ? newDate.getMonth() : "0" + newDate.getMonth()).toString();

    return day + separator + mouth + separator + newDate.getFullYear();
  }

  CompleteLoad(data: Transaction[]) {
    this.transactions = data;
    for (let elem in this.transactions) {
      this.transactions[elem].ComeIn = this.parseDate(this.transactions[elem].checkInTime);
      this.transactions[elem].ComeOut = this.parseDate(this.transactions[elem].checkOutTime);
      this.transactions[elem].TheNoumber = +elem + 1;
      this.transactions[elem].Loading = false;
    }
    this.isLoaded = true;
  }

  changeFilter(filter: TransactionFilter) {
    console.log("Accpet filter");
    this.loadTransactions(filter);
  }


}
