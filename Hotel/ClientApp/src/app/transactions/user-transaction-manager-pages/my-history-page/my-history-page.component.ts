import { Component, OnInit } from '@angular/core';
import { Transaction } from '../../../_models/transaction';

import {FormBuilder} from '@angular/forms';
import { DataServiceTransaction } from '../../_services/data.service.transaction';

@Component({
  selector: 'app-my-history-page',
  templateUrl: './my-history-page.component.html',
  styleUrls: ['./my-history-page.component.scss']
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
