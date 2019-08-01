import {Component, EventEmitter, Inject, OnInit, Output} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import { Transaction } from '../../../_models/transaction';

import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';


@Component({
  selector: 'edit-transaction-dialog',
  templateUrl: './edit-transaction-dialog.component.html',
  styleUrls: ['./edit-transaction-dialog.component.scss']
})
export class EditTransactionDialogComponent implements OnInit {

  EditedTransaction?: Transaction;
  @Output() transactionChange = new EventEmitter<Transaction>();

  _transactionForm: FormGroup;



  constructor(
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<EditTransactionDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Transaction) {

    this.EditedTransaction = data;
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
      isEvicted: this.fb.control(this.EditedTransaction.isEvicted, [Validators.required])
    });
  }


  CancelClick(): void {
    this.dialogRef.close();
  }

  closeDialog() {
    this.dialogRef.close({
      ...this.EditedTransaction,
      ...this._transactionForm.value
    });
  }


}
