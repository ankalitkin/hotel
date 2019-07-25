import { Component, OnInit, Optional } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Transaction } from '../../models/transaction';
import { DataServiceTransaction } from '../../services/data.service.transaction';
import { Router } from '@angular/router';
import { InteractionService } from '../../services/edit-transaction-interaction.service';

@Component({
  selector: 'app-edit-transaction-page',
  templateUrl: './edit-transaction-page.component.html',
  styleUrls: ['./edit-transaction-page.component.scss'],
  providers: [DataServiceTransaction]
})
export class EditTransactionPageComponent implements OnInit {


  constructor(private dataService: DataServiceTransaction, private activeRoute: ActivatedRoute, private router: Router,
    @Optional() private interactionService?: InteractionService) {
  }

  EditedTransaction?: Transaction;
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
    this.dataService.PutTransaction(this.EditedTransaction)
      .subscribe((data: any) => { this.CompleteSave() });
  }

  CompleteLoad(data: Transaction) {
    this.EditedTransaction = data;
    this.isLoaded = true;
  }

  handleTransactionChange(transaction?: Transaction) {
    if (transaction != undefined && transaction != this.EditedTransaction) {
      this.EditedTransaction = transaction;
      this.saveTransaction();
    }
    this.router.navigate(['transactions/info']);
  }

  CompleteSave() {
    if (this.interactionService != undefined) { // передача данных в родительский компонент
      this.interactionService.setTemp(this.EditedTransaction.transactionId);
      this.interactionService.sendMessage();
    }
  }
    

}
