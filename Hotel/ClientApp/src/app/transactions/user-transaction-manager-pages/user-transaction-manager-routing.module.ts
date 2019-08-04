import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { UserEditTransactionPageComponent } from './user-edit-transaction-page/user-edit-transaction-page.component';
import { UserInfoTranscationPageComponent } from './user-info-transcation-page/user-info-transcation-page.component';

import { MyHistoryPageComponent } from './my-history-page/my-history-page.component';

const routes: Routes = [
  {
    path: 'info',
    component: UserInfoTranscationPageComponent,
    children: [
      {
        path: 'edit',
        children: [
          {
            path: ':id',
            component: UserEditTransactionPageComponent,
          }]
      }
    ]
  }
  //,
  //{
  //  path: 'myHistory',
  //  component: MyHistoryPageComponent
  //}

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserTransactionManagerRoutingModule { }
