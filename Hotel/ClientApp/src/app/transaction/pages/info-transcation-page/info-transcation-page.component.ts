import { Component, OnInit } from '@angular/core';
import { DataService } from '../../services/data.service';
import { Transaction } from '../../models/transaction';

@Component({
  selector: 'app-info-transcation-page',
  templateUrl: './info-transcation-page.component.html',
  styleUrls: ['./info-transcation-page.component.scss'],
  providers: [DataService]
})
export class InfoTranscationPageComponent implements OnInit {

  transactions?: Transaction[];
  isLoaded: Boolean = false;

  constructor(private dataService: DataService) { }

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
      this.transactions[elem].UserName = this.transactions[elem].user.firstName + ' ' + this.transactions[elem].user.lastName;
      this.transactions[elem].ComeIn = this.parseDate(this.transactions[elem].checkInTime);
      this.transactions[elem].ComeOut = this.parseDate(this.transactions[elem].checkOutTime);
      this.transactions[elem].TheNoumber = +elem + 1;
    }
    this.isLoaded = true;
  }

}
