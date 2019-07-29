import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Transaction } from '../../../_models/transaction';
import { DataServiceTransaction } from '../../services/data.service.transaction';

@Component({
  selector: 'app-edit-transaction-page',
  templateUrl: './edit-transaction-page.component.html',
  styleUrls: ['./edit-transaction-page.component.scss'],
  providers: [DataServiceTransaction]
})
export class EditTransactionPageComponent implements OnInit {


  constructor(private dataService: DataServiceTransaction, private activeRoute: ActivatedRoute) {
  }

  transaction?: Transaction;
  isLoaded: Boolean = false;

  ngOnInit() {
    this.activeRoute.paramMap.subscribe(params => {
      const id = params.get('id') as string;
      this.loadTransactions(Number.parseInt(id));
    });

  }

  loadTransactions(id: number) {
    this.isLoaded = false;
    window.scrollTo(0, 0);
    this.dataService.GetTransaction(id)
      .subscribe((data: Transaction) => { this.CompleteLoad(data); });
  }

  saveTransaction() {
    console.log("save...");
    this.dataService.PutTransaction(this.transaction)
      .subscribe((data: any) => { console.log(data); });
  }

  CompleteLoad(data: Transaction) {
    this.transaction = data;
    this.isLoaded = true;
    console.log(this.transaction);
  }

  handleTransactionChange(transaction: Transaction) {
    this.transaction = transaction;
    this.saveTransaction();
  }

}
