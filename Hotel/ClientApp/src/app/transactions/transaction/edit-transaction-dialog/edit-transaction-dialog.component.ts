import { Component, EventEmitter, Inject, OnInit, Output, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Transaction } from '../../../_models/transaction';

import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Room } from 'src/app/_models/room';
import { EditTransactionRoomListPageComponent } from '../../transaction-pages/edit-transaction-room-list-page/edit-transaction-room-list-page.component';


@Component({
  selector: 'edit-transaction-dialog',
  templateUrl: './edit-transaction-dialog.component.html',
  styleUrls: ['./edit-transaction-dialog.component.scss']
})
export class EditTransactionDialogComponent implements OnInit {

  EditedTransaction?: Transaction;
  Room?: Room;

  @ViewChild(EditTransactionRoomListPageComponent, { static: false }) editlist: EditTransactionRoomListPageComponent;

  patternTrans?: Transaction;
  patternRoom?: Room;
  selectedRoom?: Room;

  @Output() transactionChange = new EventEmitter<Transaction>();

  typeList = [{ value: '1', viewValue: 'Обычно' }, { value: '2', viewValue: 'Средне' }, { value: '3', viewValue: 'Люкс' }];
  _transactionForm: FormGroup;

  isOpenFreeRoom: Boolean = false;
  isSelectedRoom: Boolean = true;

  constructor(
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<EditTransactionDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data) {
    this.EditedTransaction = data.transaction;
    this.Room = data.room;
    //this.Room.roomId = 0;
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

  //closeDialog() {
  //  this.dialogRef.close({
  //    transaction:
  //    {
  //      ...this.EditedTransaction,
  //      ...this._transactionForm.value
  //    },
  //    room:
  //    {
  //      ...this.Room,
  //      ...this._transactionForm.value
  //    }
  //  });
  //}

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
     // room.roomId = 0;
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

    this.patternTrans = {
      ...this.EditedTransaction,
      ...this._transactionForm.value
    };

    this.patternRoom = {
      ...this.Room,
      ...this._transactionForm.value
    };

    this.isOpenFreeRoom = true;

    if (this.editlist != undefined)
      this.editlist.update();
  }

  SetSelectRoom(room: Room) {
    console.log("SEET");
    console.log(room);
    this.isSelectedRoom = true;
    this.selectedRoom = room;
  }


}
