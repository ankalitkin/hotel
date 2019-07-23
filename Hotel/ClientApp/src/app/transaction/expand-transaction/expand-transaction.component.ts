import { Component, OnInit, Input } from '@angular/core';
import { User } from '../models/user';

@Component({
  selector: 'expand-transaction',
  templateUrl: './expand-transaction.component.html',
  styleUrls: ['./expand-transaction.component.scss']
})
export class ExpandTransactionComponent implements OnInit {

  @Input()
  userInfo?: User;

  constructor() {
  }


  ngOnInit() {
  }

}
