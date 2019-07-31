import { Component, OnInit, OnDestroy, Optional } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Transaction } from '../../../_models/transaction';
import { DataServiceTransaction } from '../../services/data.service.transaction';
import { Router } from '@angular/router';
import { InteractionService } from '../../services/interaction.service';

import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { EditTransactionDialogComponent } from '../../edit-transaction-dialog/edit-transaction-dialog.component'

import { Subscription } from 'rxjs';

@Component({
  selector: 'app-edit-transaction-page',
  templateUrl: './edit-transaction-page.component.html',
  styleUrls: ['./edit-transaction-page.component.scss'],
  providers: [DataServiceTransaction]
})
export class EditTransactionPageComponent implements OnInit, OnDestroy {

  EditedTransaction?: Transaction;
  isLoaded: Boolean = false;
  private routerSub = Subscription.EMPTY;
    
  constructor(
    private dataService: DataServiceTransaction,
    public dialog: MatDialog,
    private activeRoute: ActivatedRoute,
    private router: Router,
    @Optional() private interactionService?: InteractionService) {
  }

 

  ngOnInit() {
    this.routerSub = this.activeRoute.paramMap.subscribe(params => {
      const id = params.get('id') as string;
      this.loadTransactions(Number.parseInt(id));
    });
  }

  ngOnDestroy(): void {
    this.routerSub.unsubscribe();
  }

  loadTransactions(id: number) {
    this.isLoaded = false;
    this.dataService.GetTransaction(id)
      .subscribe((data: Transaction) => { this.CompleteLoad(data); });
  }

  CompleteLoad(data: Transaction) {
    this.EditedTransaction = data;
    this.isLoaded = true;
    this.openDialog();
  }

  saveTransaction() {
    console.log("save...");
    this.dataService.PutTransaction(this.EditedTransaction)
      .subscribe((data: any) => { this.CompleteSave() });
  }

  CompleteSave() {
    if (this.interactionService != undefined) { // передача данных в родительский компонент
      this.interactionService.setTemp(this.EditedTransaction.transactionId);
      this.interactionService.sendMessage();
    }
  }

  handleTransactionChange(transaction?: Transaction) {
    if (transaction != undefined && transaction != this.EditedTransaction) {
      this.EditedTransaction = transaction;
      this.saveTransaction();
    }
    this.router.navigate(['transactions/info']);
  }
  

  openDialog(): void {
    const dialogRef = this.dialog.open(EditTransactionDialogComponent, {
      width: '60%',
      data: this.EditedTransaction
    });

    dialogRef.afterClosed().subscribe(result => {
      this.handleTransactionChange(result);
    });
  }
    

}
