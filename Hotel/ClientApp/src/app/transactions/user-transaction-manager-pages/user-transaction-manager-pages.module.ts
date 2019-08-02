import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MaterialModule } from '../../material-module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { UserTransactionManagerRoutingModule } from './user-transaction-manager-routing.module';
import { UserTransactionManagerModule } from '../user-transaction-manager/user-transaction-manager.module';

import { DataServiceTransaction } from '../_services/data.service.transaction';

import { MyHistoryPageComponent } from './my-history-page/my-history-page.component';
import { UserInfoTranscationPageComponent } from './user-info-transcation-page/user-info-transcation-page.component';
import { UserEditTransactionPageComponent } from './user-edit-transaction-page/user-edit-transaction-page.component';


@NgModule({
  declarations: [
    MyHistoryPageComponent,
    UserInfoTranscationPageComponent,
    UserEditTransactionPageComponent
  ],
  entryComponents: [UserEditTransactionPageComponent],
  imports: [
    CommonModule,
    MaterialModule,

    UserTransactionManagerRoutingModule,
    UserTransactionManagerModule,

    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [DataServiceTransaction]
})
export class UserTransactionManagerPagesModule { }
