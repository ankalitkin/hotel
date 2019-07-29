import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges, Inject } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { Transaction } from '../models/transaction';

import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';


@Component({
  selector: 'edit-transaction',
  templateUrl: './edit-transaction.component.html',
  styleUrls: ['./edit-transaction.component.scss']
})
export class EditTransactionComponent implements OnInit {


 // @Input()
  EditedTransaction?: Transaction;
  @Output() transactionChange = new EventEmitter<Transaction>();

  _transactionForm: FormGroup;



  constructor(private fb: FormBuilder, public dialogRef: MatDialogRef<EditTransactionComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Transaction) {
    this.EditedTransaction = data;
    console.log(this.EditedTransaction);
  }

  ngOnInit() {
    // сделать формат для даты
    this._transactionForm = this.fb.group({
      userId: this.fb.control(this.EditedTransaction.userId, [Validators.required, Validators.min(0), Validators.pattern("[0-9]{1,}")]),
      checkInTime: this.fb.control(this.EditedTransaction.checkInTime, [Validators.required]),
      checkOutTime: this.fb.control(this.EditedTransaction.checkOutTime, [Validators.required]),
      roomId: this.fb.control(this.EditedTransaction.roomId, [Validators.required, Validators.min(0), Validators.pattern("[0-9]{1,}")]),
      cost: this.fb.control(this.EditedTransaction.cost, [Validators.required, Validators.min(0), Validators.pattern("[0-9]{1,}")]),
      isPaid: this.fb.control(this.EditedTransaction.isPaid, [Validators.required]),
      isCanceled: this.fb.control(this.EditedTransaction.isCanceled, [Validators.required])
    });
  }
  /*
  handleSaveClick() {
    console.log("save");
    this.EditedTransaction = {
      ...this.EditedTransaction,
      ...this._transactionForm.value
    }

    this.data = this.EditedTransaction;
    console.log(this.EditedTransaction);
  }


  /*
  handleCancelClick() {
    this.transactionChange.emit();
    this._transactionForm.reset();
  }
  */

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
