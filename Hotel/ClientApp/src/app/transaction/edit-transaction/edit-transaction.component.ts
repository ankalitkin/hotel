import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { Transaction } from '../models/transaction';


@Component({
  selector: 'edit-transaction',
  templateUrl: './edit-transaction.component.html',
  styleUrls: ['./edit-transaction.component.scss']
})
export class EditTransactionComponent implements OnInit {


  @Input()
  transaction?: Transaction;
  @Output() transactionChange = new EventEmitter<Transaction>();

  _transactionForm: FormGroup;



  constructor(private fb: FormBuilder) {
  }

  ngOnInit() {

    this._transactionForm = this.fb.group({
      userId: this.fb.control(this.transaction.userId, [Validators.required, Validators.min(0)]),
      checkInTime: this.fb.control(this.transaction.checkInTime, [Validators.required]),
      checkOutTime: this.fb.control(this.transaction.checkOutTime, [Validators.required]),
      roomId: this.fb.control(this.transaction.roomId, [Validators.required, Validators.min(0)]),
      cost: this.fb.control(this.transaction.cost, [Validators.required, Validators.min(0)]),
      isPaid: this.fb.control(this.transaction.isPaid, [Validators.required]),
      isCanceled: this.fb.control(this.transaction.isCanceled, [Validators.required])
    });
  }

  //ngOnChanges(changes: SimpleChanges): void {
  //  if ('transaction' in changes) {
  //    if (this._transactionForm != undefined) {
  //      this._transactionForm.setValue({
  //        userId: this._transactionForm.get('userId'),
  //        checkInTime: this._transactionForm.get('checkInTime')
  //      });
  //    } else {
  //      this._transactionForm.reset();
  //    }
  //  }
  //}

  handleSaveClick() {
    this.transactionChange.emit({
      ...this.transaction,
      ...this._transactionForm.value
    });
    this._transactionForm.reset();
  }

}
