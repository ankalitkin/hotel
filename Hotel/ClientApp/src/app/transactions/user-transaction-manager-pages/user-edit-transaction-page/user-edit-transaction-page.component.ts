import { Component, OnInit, OnDestroy, Optional } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Transaction } from '../../../_models/transaction';
import { DataServiceTransaction } from '../../_services/data.service.transaction';
import { Router } from '@angular/router';
import { InteractionService } from '../../_services/interaction.service';

import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { UserEditTransactionDialogComponent } from '../../user-transaction-manager/user-edit-transaction-dialog/user-edit-transaction-dialog.component'

import { Subscription } from 'rxjs';
import { Room } from 'src/app/_models/room';

import { SnackBarService } from '../../_services/snack-bar.service';



@Component({
  selector: 'app-user-edit-transaction-page',
  templateUrl: './user-edit-transaction-page.component.html',
  styleUrls: ['./user-edit-transaction-page.component.scss'],
  providers: [DataServiceTransaction, SnackBarService]
})
export class UserEditTransactionPageComponent implements OnInit {

  EditedTransaction?: Transaction;
  Room?: Room;
  isLoaded: Boolean = false;
  private routerSub = Subscription.EMPTY;

  constructor(
    private dataService: DataServiceTransaction,
    public dialog: MatDialog,
    private activeRoute: ActivatedRoute,
    private router: Router,
    private snackBarService: SnackBarService,
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
    this.GetRoom();
  }

  saveTransaction() {

    this.dataService.GetRoomId(this.Room, this.EditedTransaction)
      .subscribe((data: number) => {
        this.EditedTransaction.roomId = data;
        console.log('id = ' + data);
        this.dataService.PutTransaction(this.EditedTransaction)
          .subscribe((data: any) => { this.CompleteSave() }, (error: any) => { this.snackBarService.failureSnack() });
      }, (error: any) => { this.snackBarService.failureSnack() });

  }

  CompleteSave() {
    this.snackBarService.succsesSnack();

    if (this.interactionService != undefined) { // передача данных в родительский компонент
      this.interactionService.setTemp(this.EditedTransaction.transactionId);
      this.interactionService.sendMessage();
    }
  }

  handleTransactionChange(result?) {
    if (result != undefined && result.transaction != undefined && result.transaction != this.EditedTransaction) {
      this.EditedTransaction = result.transaction;
      this.Room = result.room;
      this.saveTransaction();
    }
    this.router.navigate(['usertransactions/info']);
  }

  GetRoom() {
    this.dataService.GetRoom(this.EditedTransaction.roomId)
      .subscribe((data: Room) => this.CompleteLoadRoom(data));
  }

  CompleteLoadRoom(data: Room) {
    this.Room = data;
    this.openDialog();
    console.log(data);
    this.isLoaded = true;
  }
  openDialog(): void {
    const dialogRef = this.dialog.open(UserEditTransactionDialogComponent, {
      width: '60%',
      data: { transaction: this.EditedTransaction, room: this.Room }
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(result);
      this.handleTransactionChange(result);
    });
  }

}
