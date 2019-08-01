import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InfoTransactionComponent } from './info-transaction/info-transaction.component';
import { FinancicalInformationComponent } from './financical-information/financical-information.component';
import { FilterTransactionComponent } from './filter-transaction/filter-transaction.component';
import { ExpandTransactionComponent } from './expand-transaction/expand-transaction.component';
import { EditTransactionDialogComponent } from './edit-transaction-dialog/edit-transaction-dialog.component';
import { MyHistoryComponent } from './my-history/my-history.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {
  MatButtonModule,
  MatCheckboxModule,
  MatDatepickerModule,
  MatFormFieldModule,
  MatInputModule,
  MatOptionModule,
  MatPaginatorModule,
  MatSelectModule,
  MatSortModule,
  MatTableModule
} from '@angular/material';

import { MaterialModule } from '../material-module';
// For loading-progress
import { LoadingBarHttpClientModule } from '@ngx-loading-bar/http-client';
import { LoadingBarHttpModule } from '@ngx-loading-bar/http';
import { LoadingBarRouterModule } from '@ngx-loading-bar/router'

import { RouterModule } from '@angular/router';
import { ExpandTransactionPageComponent } from '../transaction-pages/expand-transaction-page/expand-transaction-page.component';
import { SharedModule } from '../_shared/shared.module';



@NgModule({
  declarations: [
    InfoTransactionComponent,
    FinancicalInformationComponent,
    FilterTransactionComponent,
    ExpandTransactionComponent,
    EditTransactionDialogComponent,
    MyHistoryComponent,

    ExpandTransactionPageComponent
  ],
  exports: [
    InfoTransactionComponent,
    FinancicalInformationComponent,
    FilterTransactionComponent,
    ExpandTransactionComponent,
    EditTransactionDialogComponent,
    MyHistoryComponent,

    ExpandTransactionPageComponent,
    SharedModule
  ],
  entryComponents: [EditTransactionDialogComponent],
  imports: [
    CommonModule,
    MaterialModule,
    SharedModule,
    //LoadingBarHttpClientModule,
    //LoadingBarHttpModule,
    LoadingBarRouterModule,

    ReactiveFormsModule,
    MatFormFieldModule,
    MatDatepickerModule,
    MatOptionModule,
    MatSelectModule,
    MatCheckboxModule,
    FormsModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatButtonModule,
    RouterModule,
    MatInputModule

  ]
})
export class TransactionsModule { }

