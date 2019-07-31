import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { DataServiceTransaction } from '../../services/data.service.transaction';
import { User } from '../../../_models/user';

@Component({
  selector: 'app-expand-transaction-page',
  templateUrl: './expand-transaction-page.component.html',
  styleUrls: ['./expand-transaction-page.component.scss'],
  providers: [DataServiceTransaction]
})
export class ExpandTransactionPageComponent implements OnInit {

  @Input()
  userInfo?: User;
  isLoaded: Boolean = false;
  @Input()
  id?: number;

  @Output()
  SaveTemp: EventEmitter<User> = new EventEmitter<User>();


  constructor(private dataService: DataServiceTransaction) { }

  ngOnInit() {
    if (this.userInfo != undefined && this.userInfo.userId == this.id)
      this.isLoaded = true;
    else
      this.loadData();
  }

  SaveUserInfo() {
    this.SaveTemp.emit(this.userInfo);
  }

  loadData() {
    this.dataService.GetExpandData(this.id)
      .subscribe((data: User) => { this.CompleteLoad(data); });
  }

  CompleteLoad(data: User) {
    this.userInfo = data;
    this.isLoaded = true;
    this.SaveUserInfo();
  }

}
