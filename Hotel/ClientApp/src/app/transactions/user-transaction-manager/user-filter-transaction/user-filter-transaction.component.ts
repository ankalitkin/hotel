import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { TransactionFilter } from '../../../_models/transaction';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'user-filter-transaction',
  templateUrl: './user-filter-transaction.component.html',
  styleUrls: ['./user-filter-transaction.component.scss']
})
export class UserFilterTransactionComponent implements OnInit {

  @Output()
  changeFilter = new EventEmitter<TransactionFilter>();

  _filterForm: FormGroup;
  filter: TransactionFilter;
  typeList = [{ value: 'all', viewValue: 'Все' }, { value: 'isPaid', viewValue: 'Оплаченные' }, { value: 'isCanceled', viewValue: 'Отмененные' }];
  typeSelect: string = 'all';

  constructor(private fb: FormBuilder) {
  }
  ngOnInit() {
    this._filterForm = this.fb.group({
      clientId: this.fb.control(undefined),
      checkInTime: this.fb.control(undefined),
      checkOutTime: this.fb.control(undefined),
      type: this.fb.control(this.typeSelect, [Validators.required])
    });
  }

  handleRefreshClick() {
    this.changeFilter.emit(this._filterForm.value);
  }
}
