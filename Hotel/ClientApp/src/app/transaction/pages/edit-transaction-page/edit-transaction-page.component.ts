import { Component, OnInit, Optional } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Transaction } from '../../models/transaction';
import { DataServiceTransaction } from '../../services/data.service.transaction';
import { Router } from '@angular/router';
import { InteractionService } from '../../services/interaction.service';

import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { EditTransactionComponent } from '../../edit-transaction/edit-transaction.component'
import { Overlay, ScrollStrategyOptions } from '@angular/cdk/overlay';

@Component({
  selector: 'app-edit-transaction-page',
  templateUrl: './edit-transaction-page.component.html',
  styleUrls: ['./edit-transaction-page.component.scss'],
  providers: [DataServiceTransaction]
})
export class EditTransactionPageComponent implements OnInit {


  constructor(private dataService: DataServiceTransaction, public dialog: MatDialog, private activeRoute: ActivatedRoute, private router: Router,
    @Optional() private interactionService?: InteractionService) {
  }

  EditedTransaction?: Transaction;
  isLoaded: Boolean = false;

  ngOnInit() {
    this.activeRoute.paramMap.subscribe(params => {
      const id = params.get('id') as string;
      this.loadTransactions(Number.parseInt(id));
    }).unsubscribe();

  }

  loadTransactions(id: number) {

    this.isLoaded = false;
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
    this.openDialog();
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
  

  openDialog(): void {
    const dialogRef = this.dialog.open(EditTransactionComponent, {
      width: '60%',
      data: this.EditedTransaction
    });

    dialogRef.afterClosed().subscribe(result => {
      this.handleTransactionChange(result);
    });
  }
    

}
