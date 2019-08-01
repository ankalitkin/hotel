import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { MaterialModule } from '../../material-module';
// For loading-progress
import { LoadingBarHttpClientModule } from '@ngx-loading-bar/http-client';
import { LoadingBarHttpModule } from '@ngx-loading-bar/http';
import { LoadingBarRouterModule } from '@ngx-loading-bar/router'

import { RouterModule } from '@angular/router';
import { SharedModule } from '../../_shared/shared.module';

import { MyHistoryComponent } from './my-history/my-history.component';
import { UserInfoTranscationComponent } from './user-info-transcation/user-info-transcation.component';



@NgModule({
  declarations: [
    MyHistoryComponent,
    UserInfoTranscationComponent
  ],
  exports: [
    MyHistoryComponent,
    UserInfoTranscationComponent,
    SharedModule
  ],
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
