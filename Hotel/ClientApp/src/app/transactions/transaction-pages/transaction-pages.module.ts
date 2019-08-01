import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MaterialModule } from '../../material-module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { TransactionRoutingModule } from './transaction-routing.module';
import { TransactionsModule } from '../transaction/transactions.module';

import { EditTransactionPageComponent } from './edit-transaction-page/edit-transaction-page.component';
import { FinancicalInformationPageComponent } from './financical-information-page/financical-information-page.component';
import { InfoTranscationPageComponent } from './info-transcation-page/info-transcation-page.component';


@NgModule({
  declarations: [
    EditTransactionPageComponent,
    FinancicalInformationPageComponent,
    InfoTranscationPageComponent
  ],
  entryComponents: [EditTransactionPageComponent],
  imports: [
    CommonModule,
    MaterialModule,

    TransactionRoutingModule,
    TransactionsModule,

    FormsModule,
    ReactiveFormsModule,
  ]
})
export class TransactionPagesModule { }
