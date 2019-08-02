import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { DataServiceTransaction } from '../../_services/data.service.transaction';
import { ExpandData } from '../../../_models/transaction';

@Component({
  selector: 'app-user-expand-transaction-page',
  templateUrl: './user-expand-transaction-page.component.html',
  styleUrls: ['./user-expand-transaction-page.component.scss'],
  providers: [DataServiceTransaction]
})
export class UserExpandTransactionPageComponent implements OnInit {

  @Input()
  expandData?: ExpandData;
  isLoaded: Boolean = false;
  @Input()
  transactionId?: Number;

  @Output()
  SaveTemp: EventEmitter<ExpandData> = new EventEmitter<ExpandData>();


  constructor(private dataService: DataServiceTransaction) { }

  ngOnInit() {
    if (this.expandData != undefined && this.expandData.transactionId == this.transactionId)
      this.isLoaded = true;
    else
      this.loadData();
  }

  SaveExpandData() {
    this.SaveTemp.emit(this.expandData);
  }

  loadData() {
    console.log(this.transactionId);
    this.dataService.GetExpandData(this.transactionId)
      .subscribe((data: ExpandData) => { this.CompleteLoad(data); });
  }

  CompleteLoad(data: ExpandData) {
    this.expandData = data;
    this.isLoaded = true;
    this.SaveExpandData();
  }

}
