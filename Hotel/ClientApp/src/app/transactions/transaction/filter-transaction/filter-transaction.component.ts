import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {TransactionFilter} from '../../../_models/transaction';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';


@Component({
  selector: 'filter-transaction',
  templateUrl: './filter-transaction.component.html',
  styleUrls: ['./filter-transaction.component.scss']
})
export class FilterTransactionComponent implements OnInit {

  @Output()
  changeFilter = new EventEmitter<TransactionFilter>();

  _filterForm: FormGroup;
  filter: TransactionFilter;
  typeList = [{ value: 'all', viewValue: 'Все' },
    { value: 'isReadyComeIn', viewValue: 'На заселение' }, { value: 'isReadyComeOut', viewValue: 'На выселение' },
    { value: 'isPaid', viewValue: 'Оплаченные' }, { value: 'isCanceled', viewValue: 'Отмененные' },
    { value: 'isNotPaid', viewValue: 'НЕ Оплаченные' },{ value: 'isNotCanceled', viewValue: 'НЕ Отмененные' }];
  typeSelect: string = 'all';

  constructor(private fb: FormBuilder) {
  }
  ngOnInit() {
    this._filterForm = this.fb.group({
      clientId: this.fb.control(undefined, [Validators.pattern("[0-9]{12,12}")]),
      checkInTime: this.fb.control(undefined),
      checkOutTime: this.fb.control(undefined),
      type: this.fb.control(this.typeSelect, [Validators.required])
    });
  }

  handleRefreshClick() {
    this.changeFilter.emit(this._filterForm.value);
  }

}
