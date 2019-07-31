import {Component, OnInit} from '@angular/core';
import {DataServiceTransaction} from '../../services/data.service.transaction';
import {Transaction} from '../../../_models/transaction';

import {FormBuilder} from '@angular/forms';

@Component({
  selector: 'app-user-transaction-page',
  templateUrl: './user-transaction-page.component.html',
  styleUrls: ['./user-transaction-page.component.scss'],
  providers: [DataServiceTransaction]
})
export class UserTransactionPageComponent implements OnInit {

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
