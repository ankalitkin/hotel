import { Component, OnInit, Input } from '@angular/core';
import { ExpandData } from '../../../_models/transaction';

@Component({
  selector: 'expand-transaction',
  templateUrl: './expand-transaction.component.html',
  styleUrls: ['./expand-transaction.component.scss']
})
export class ExpandTransactionComponent implements OnInit {

  @Input()
  expandData?: ExpandData;

  constructor() { }

  ngOnInit() { }

}
