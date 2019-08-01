import { Component, OnInit } from '@angular/core';
import { DataServiceTransaction } from '../_services/data.service.transaction';
import { FinancicalInformation, FinancicalInfoFilter } from '../../_models/transaction';

import {FormBuilder, FormGroup} from '@angular/forms';


@Component({
  selector: 'app-financical-information-page',
  templateUrl: './financical-information-page.component.html',
  styleUrls: ['./financical-information-page.component.scss'],
  providers: [DataServiceTransaction]
})
export class FinancicalInformationPageComponent implements OnInit {

  financicalInformation?: FinancicalInformation[];
  isLoaded: Boolean = false;

  _filterForm: FormGroup;
  filter: FinancicalInfoFilter;

  constructor(private dataService: DataServiceTransaction, private fb: FormBuilder) { }

  ngOnInit() {
    this.loadFinancicalInfo();

    this._filterForm = this.fb.group({
      start: this.fb.control(undefined),
      end: this.fb.control(undefined)
    });
  }

  loadFinancicalInfo(filter?: FinancicalInfoFilter) {
    this.isLoaded = false;
    if (filter == undefined) {
      this.dataService.GetFinancicalInfo()
        .subscribe((data: FinancicalInformation[]) => { this.CompleteLoad(data); });
    } else {
      this.dataService.GetFinancicalInfo(filter.start, filter.end)
        .subscribe((data: FinancicalInformation[]) => { this.CompleteLoad(data); });
    }
  }

  CompleteLoad(data: FinancicalInformation[]) {
    this.financicalInformation = data;
    for (let elem in this.financicalInformation) {
      this.financicalInformation[elem].TheNoumber = +elem + 1;
    }

    this.isLoaded = true;
  }

  changeFilter() {
    this.loadFinancicalInfo(this._filterForm.value);
  }
}
