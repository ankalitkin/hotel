import { Component, OnInit, Input } from '@angular/core';
import { ExpandData } from '../../../_models/transaction';

@Component({
  selector: 'user-expand-transaction',
  templateUrl: './user-expand-transaction.component.html',
  styleUrls: ['./user-expand-transaction.component.scss']
})
export class UserExpandTransactionComponent implements OnInit {

  @Input()
  expandData?: ExpandData;

  constructor() { }

  ngOnInit() { }

}
