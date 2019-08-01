import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  MatButtonModule,
  MatCheckboxModule,
  MatDatepickerModule,
  MatFormFieldModule,
  MatInputModule,
  MatPaginatorModule,
  MatSelectModule,
  MatSortModule,
  MatTableModule
} from '@angular/material';
import { MaterialModule } from '../material-module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { TransactionRoutingModule } from './transaction-routing.module';
import { TransactionsModule } from '../transaction/transactions.module';

import { EditTransactionPageComponent } from './edit-transaction-page/edit-transaction-page.component';
import { FinancicalInformationPageComponent } from './financical-information-page/financical-information-page.component';
import { InfoTranscationPageComponent } from './info-transcation-page/info-transcation-page.component';
import { MyHistoryPageComponent } from './my-history-page/my-history-page.component';


@NgModule({
  declarations: [
    EditTransactionPageComponent,
    FinancicalInformationPageComponent,
    InfoTranscationPageComponent,
    MyHistoryPageComponent  
  ],
  entryComponents: [EditTransactionPageComponent],
  imports: [
    CommonModule,
    MaterialModule,
    TransactionRoutingModule,
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    MatDatepickerModule,
    MatTableModule,
    MatSortModule,
    MatButtonModule,
    MatPaginatorModule,
    TransactionsModule,
    FormsModule,
    MatCheckboxModule,
    ReactiveFormsModule,

  ]
})
export class TransactionPagesModule { }
