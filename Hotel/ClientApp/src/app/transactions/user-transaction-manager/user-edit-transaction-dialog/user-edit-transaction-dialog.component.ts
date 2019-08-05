import { Component, EventEmitter, Inject, OnInit, Output, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Transaction } from '../../../_models/transaction';

import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Room } from 'src/app/_models/room';
import { UserEditTransactionRoomListPageComponent } from '../../user-transaction-manager-pages/user-edit-transaction-room-list-page/user-edit-transaction-room-list-page.component';

@Component({
  selector: 'user-edit-transaction-dialog',
  templateUrl: './user-edit-transaction-dialog.component.html',
  styleUrls: ['./user-edit-transaction-dialog.component.scss']
})
export class UserEditTransactionDialogComponent implements OnInit {

  EditedTransaction?: Transaction;
  Room?: Room;

  @ViewChild(UserEditTransactionRoomListPageComponent, { static: false }) editlist: UserEditTransactionRoomListPageComponent;

  patternTrans?: Transaction;
  patternRoom?: Room;
  selectedRoom?: Room;

  @Output() transactionChange = new EventEmitter<Transaction>();

  typeList = [{ value: '1', viewValue: 'Эконом' }, { value: '2', viewValue: 'Обычный' }, { value: '3', viewValue: 'Люкс' }];
  _transactionForm: FormGroup;

  isOpenFreeRoom: Boolean = false;
  isSelectedRoom: Boolean = true;

  constructor(
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<UserEditTransactionDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data) {
    this.EditedTransaction = data.transaction;
    this.Room = data.room;
  }

  ngOnInit() {
    this._transactionForm = this.fb.group({
      userId: this.fb.control(this.EditedTransaction.userId, [Validators.required, Validators.min(0), Validators.pattern("[0-9]{1,}")]),
      checkInTime: this.fb.control(this.EditedTransaction.checkInTime, [Validators.required]),
      checkOutTime: this.fb.control(this.EditedTransaction.checkOutTime, [Validators.required]),
      roomId: this.fb.control(this.EditedTransaction.roomId, [Validators.required, Validators.min(0), Validators.pattern("[0-9]{1,}")]),
      cost: this.fb.control(this.EditedTransaction.cost, [Validators.required, Validators.min(0), Validators.pattern("[0-9]{1,}")]),
      isPaid: this.fb.control(this.EditedTransaction.isPaid, [Validators.required]),
      isCanceled: this.fb.control(this.EditedTransaction.isCanceled, [Validators.required]),
      isEvicted: this.fb.control(this.EditedTransaction.isEvicted, [Validators.required]),

      roomTypeId: this.fb.control(this.typeList[this.Room.roomTypeId - 1].value, [Validators.required]),
      numberOfSeats: this.fb.control(this.Room.numberOfSeats, [Validators.required]),
      hasMiniBar: this.fb.control(this.Room.hasMiniBar, [Validators.required]),
      name: this.fb.control(this.Room.name, [Validators.required])
    });
  }


  CancelClick(): void {
    this.dialogRef.close();
  }

  closeDialog() {
    let transaction = {
      ...this.EditedTransaction,
      ...this._transactionForm.value
    };

    let room = this.selectedRoom;
    if (room == undefined) {
      room = {
        ...this.Room,
        ...this._transactionForm.value
      }
    }

    console.log(room);
    this.dialogRef.close(
      {
        transaction: transaction,
        room: room
      }
    );
  }

  SeacrhFreeRooms() {

    this.isSelectedRoom = false;
    this.selectedRoom = undefined;
    this.isOpenFreeRoom = true;

    this.patternTrans = {
      ...this.EditedTransaction,
      ...this._transactionForm.value
    };

    this.patternRoom = {
      ...this.Room,
      ...this._transactionForm.value
    };



    if (this.editlist != undefined)
      this.editlist.update(this.patternTrans, this.patternRoom);
  }

  SetSelectRoom(room: Room) {
    console.log("SEET");
    console.log(room);
    this.isSelectedRoom = true;
    this.selectedRoom = room;
  }


}
