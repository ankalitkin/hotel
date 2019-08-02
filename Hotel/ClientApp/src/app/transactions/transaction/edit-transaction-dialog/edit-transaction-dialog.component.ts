import {Component, EventEmitter, Inject, OnInit, Output} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import { Transaction } from '../../../_models/transaction';

import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Room } from 'src/app/_models/room';


@Component({
  selector: 'edit-transaction-dialog',
  templateUrl: './edit-transaction-dialog.component.html',
  styleUrls: ['./edit-transaction-dialog.component.scss']
})
export class EditTransactionDialogComponent implements OnInit {

  EditedTransaction?: Transaction;
  Room?: Room;

  @Output() transactionChange = new EventEmitter<Transaction>();

  typeList = [{ value: '1', viewValue: 'Обычно' }, { value: '2', viewValue: 'Средне' }, { value: '3', viewValue: 'Люкс' }];
  _transactionForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<EditTransactionDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data) {
    this.EditedTransaction = data.transaction;
    this.Room = data.room;
  }

  ngOnInit() {
    // TODO: сделать шаблон для даты и провреку, чтобы checkInTime <= checkOutTime
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
    this.dialogRef.close({
      transaction:
      {
        ...this.EditedTransaction,
        ...this._transactionForm.value
      },
      room:
      {
        ...this.Room,
        ...this._transactionForm.value
      }
    });
  }


}
