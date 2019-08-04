import { Component, OnInit, Input } from '@angular/core';
import { DataServiceTransaction } from '../../_services/data.service.transaction';
import { Transaction } from 'src/app/_models/transaction';

@Component({
  selector: 'app-financiacal-information-expand-page',
  templateUrl: './financiacal-information-expand-page.component.html',
  styleUrls: ['./financiacal-information-expand-page.component.scss'],
  providers: [DataServiceTransaction]
})
export class FinanciacalInformationExpandPageComponent implements OnInit {

  @Input()
  day?: Date;

  expandData: Transaction[];
  isLoaded: Boolean = false;

  constructor(private dataService: DataServiceTransaction) { }

  ngOnInit() {
      this.loadData();
  }

  loadData() {
    this.isLoaded = false;
    this.dataService.GetTransactionsOfDate(this.day)
      .subscribe((data: Transaction[]) => { this.CompleteLoad(data); });
  }

  CompleteLoad(data: Transaction[]) {
    console.log(data);
    for (let i = 0; i < data.length; i++) {
      data[i].TheNoumber = i + 1;
    }
    this.expandData = data;
    this.isLoaded = true;
  }


}
