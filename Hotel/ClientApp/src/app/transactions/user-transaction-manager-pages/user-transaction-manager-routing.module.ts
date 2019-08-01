import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { MyHistoryPageComponent } from './my-history-page/my-history-page.component';

const routes: Routes = [
  {
    path: 'myHistory',
    component: MyHistoryPageComponent
  }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserTransactionManagerRoutingModule { }
