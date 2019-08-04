import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '../../material-module';

// For loading-progress
import { LoadingBarHttpClientModule } from '@ngx-loading-bar/http-client';
import { LoadingBarHttpModule } from '@ngx-loading-bar/http';
import { LoadingBarRouterModule } from '@ngx-loading-bar/router'

import { RouterModule } from '@angular/router';
import { ExpandTransactionPageComponent } from '../transaction-pages/expand-transaction-page/expand-transaction-page.component';
import { EditTransactionRoomListPageComponent } from '../transaction-pages/edit-transaction-room-list-page/edit-transaction-room-list-page.component';

import { SharedModule } from '../../_shared/shared.module';

import { InfoTransactionComponent } from './info-transaction/info-transaction.component';
import { FinancicalInformationComponent } from './financical-information/financical-information.component';
import { FilterTransactionComponent } from './filter-transaction/filter-transaction.component';
import { ExpandTransactionComponent } from './expand-transaction/expand-transaction.component';
import { EditTransactionDialogComponent } from './edit-transaction-dialog/edit-transaction-dialog.component';
import { EditTransactionRoomListComponent } from './edit-transaction-room-list/edit-transaction-room-list.component';



@NgModule({
  declarations: [
    InfoTransactionComponent,
    FinancicalInformationComponent,
    FilterTransactionComponent,
    ExpandTransactionComponent,
    EditTransactionDialogComponent,

    ExpandTransactionPageComponent,
    EditTransactionRoomListPageComponent,

    EditTransactionRoomListComponent,
  ],
  exports: [
    InfoTransactionComponent,
    FinancicalInformationComponent,
    FilterTransactionComponent,
    ExpandTransactionComponent,
    EditTransactionDialogComponent,
    ExpandTransactionPageComponent,
    EditTransactionRoomListPageComponent,
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
    FormsModule,
    RouterModule,

  ]
})
export class TransactionsModule { }

