import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { MaterialModule } from '../../material-module';
// For loading-progress
import { LoadingBarHttpClientModule } from '@ngx-loading-bar/http-client';
import { LoadingBarHttpModule } from '@ngx-loading-bar/http';
import { LoadingBarRouterModule } from '@ngx-loading-bar/router'

import { RouterModule } from '@angular/router';
import { UserExpandTransactionPageComponent } from '../user-transaction-manager-pages/user-expand-transaction-page/user-expand-transaction-page.component';
import { SharedModule } from '../../_shared/shared.module';

import { MyHistoryComponent } from './my-history/my-history.component';
import { UserInfoTranscationComponent } from './user-info-transcation/user-info-transcation.component';
import { UserEditTransactionDialogComponent } from './user-edit-transaction-dialog/user-edit-transaction-dialog.component';
import { UserExpandTransactionComponent } from './user-expand-transaction/user-expand-transaction.component';
import { UserFilterTransactionComponent } from './user-filter-transaction/user-filter-transaction.component';



@NgModule({
  declarations: [
    MyHistoryComponent,
    UserInfoTranscationComponent,
    UserEditTransactionDialogComponent,
    UserExpandTransactionComponent,
    UserFilterTransactionComponent,
    UserExpandTransactionPageComponent
  ],
  exports: [
    MyHistoryComponent,
    UserInfoTranscationComponent,
    UserEditTransactionDialogComponent,
    UserExpandTransactionComponent,
    UserFilterTransactionComponent,
    UserExpandTransactionPageComponent,
    SharedModule
  ],
  entryComponents: [UserEditTransactionDialogComponent],
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
export class UserTransactionManagerModule { }
