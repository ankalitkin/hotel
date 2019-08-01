import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { TransactionFilter } from '../../_models/transaction';
import { FormBuilder, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';

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
  typeList = [{ value: 'all', viewValue: 'Все' }, { value: 'isPaid', viewValue: 'Оплаченные' }, { value: 'isCanceled', viewValue:'Отмененные' }];
  typeSelect: string = 'all';

  constructor(private fb: FormBuilder) {
  }
  ngOnInit() {
    // TODO: сделать шаблон для даты
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
