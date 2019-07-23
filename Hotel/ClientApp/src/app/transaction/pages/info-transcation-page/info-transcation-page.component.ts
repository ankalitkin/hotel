import { Component, OnInit } from '@angular/core';
import { DataServiceTransaction } from '../../services/data.service.transaction';
import { Transaction } from '../../models/transaction';

@Component({
  selector: 'app-info-transcation-page',
  templateUrl: './info-transcation-page.component.html',
  styleUrls: ['./info-transcation-page.component.scss'],
  providers: [DataServiceTransaction]
})
export class InfoTranscationPageComponent implements OnInit {

  transactions?: Transaction[];
  isLoaded: Boolean = false;

  editMode: Boolean = false;
  editedTransaction?: Transaction;

  constructor(private dataService: DataServiceTransaction) { }

  ngOnInit() {
    this.loadTransactions();
  }

  loadTransactions() {
    this.dataService.GetTransactions()
      .subscribe((data: Transaction[]) => { this.CompleteLoad(data); });
  }

  // для фильтра (знаю, что криво)
  parseDate(input) {
    let separator: string = '-';
    let newDate: Date = new Date(input);
    let day: string = ((newDate.getDate() > 9) ? newDate.getDate() : "0" + newDate.getDate()).toString();
    let mouth: string = ((newDate.getMonth() > 9) ? newDate.getMonth() : "0" + newDate.getMonth()).toString();

    return day + separator + mouth + separator + newDate.getFullYear();
  }

  CompleteLoad(data: Transaction[]) {
    this.transactions = data;
    for (let elem in this.transactions) {
      //this.transactions[elem].UserName = this.transactions[elem].user.firstName + ' ' + this.transactions[elem].user.lastName;
      this.transactions[elem].ComeIn = this.parseDate(this.transactions[elem].checkInTime);
      this.transactions[elem].ComeOut = this.parseDate(this.transactions[elem].checkOutTime);
      this.transactions[elem].TheNoumber = +elem + 1;
    }
    this.isLoaded = true;
  }

}
