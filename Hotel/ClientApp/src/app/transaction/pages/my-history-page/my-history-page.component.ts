import { Component, OnInit } from '@angular/core';
import { DataServiceTransaction } from '../../services/data.service.transaction';
import { Transaction } from '../../models/transaction';

import { FormBuilder, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';

@Component({
  selector: 'app-my-history-page',
  templateUrl: './my-history-page.component.html',
  styleUrls: ['./my-history-page.component.scss'],
  providers: [DataServiceTransaction]
})
export class MyHistoryPageComponent implements OnInit {

  transactions?: Transaction[];
  isLoaded: Boolean = false;

  constructor(private dataService: DataServiceTransaction, private fb: FormBuilder) { }

  ngOnInit() {
    this.loadUserTransaction();
  }

  loadUserTransaction() {
    this.isLoaded = false;

    this.dataService.GetMyHistory()
        .subscribe((data: Transaction[]) => { this.CompleteLoad(data); });
  }

  CompleteLoad(data: Transaction[]) {
    this.transactions = data;
    for (let elem in this.transactions) {
      this.transactions[elem].TheNoumber = +elem + 1;
    }

    this.isLoaded = true;
  }

}
