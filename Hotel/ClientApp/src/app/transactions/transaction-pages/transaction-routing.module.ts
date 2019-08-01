import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { EditTransactionPageComponent } from './edit-transaction-page/edit-transaction-page.component';
import { FinancicalInformationPageComponent } from './financical-information-page/financical-information-page.component';
import { InfoTranscationPageComponent } from './info-transcation-page/info-transcation-page.component';

const routes: Routes = [
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
  },
  {
    path: 'financicalInfo',
    component: FinancicalInformationPageComponent
  }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class TransactionRoutingModule { }
