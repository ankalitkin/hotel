import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { DataServiceTransaction } from '../../services/data.service.transaction';
import { ExpandData } from '../../models/transaction';

@Component({
  selector: 'app-expand-transaction-page',
  templateUrl: './expand-transaction-page.component.html',
  styleUrls: ['./expand-transaction-page.component.scss'],
  providers: [DataServiceTransaction]
})
export class ExpandTransactionPageComponent implements OnInit {

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
