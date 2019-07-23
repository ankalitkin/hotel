import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { InfoTransactionComponent } from './transaction/info-transaction/info-transaction.component';
import { EditTransactionComponent } from './transaction/edit-transaction/edit-transaction.component';

import { InfoTranscationPageComponent } from './transaction/pages/info-transcation-page/info-transcation-page.component';
import { EditTransactionPageComponent } from './transaction/pages/edit-transaction-page/edit-transaction-page.component';
import { ExpandTransactionComponent } from './transaction/expand-transaction/expand-transaction.component';
import { ExpandTransactionPageComponent } from './transaction/pages/expand-transaction-page/expand-transaction-page.component';




const routes: Routes = [
  {
    path: 'transactions',
    children: [
      {
        path: 'info',
        component: InfoTranscationPageComponent,
        children: [
          {
            path: 'edit',
            children: [
              {
                path: ':id',
                component: EditTransactionPageComponent,
              }]
          }
        ]
      }
    ]
    //children: [
    //{
    //    path: 'user-info',
    //    children: [
    //      {
    //        path: ':id',
    //        component: ExpandTransactionPageComponent,
    //      }
    //    ]
    //}
    //]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
