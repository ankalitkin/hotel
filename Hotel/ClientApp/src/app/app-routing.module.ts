import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


import { InfoTranscationPageComponent } from './transaction/pages/info-transcation-page/info-transcation-page.component';
import { EditTransactionPageComponent } from './transaction/pages/edit-transaction-page/edit-transaction-page.component';
import { FinancicalInformationPageComponent } from './transaction/pages/financical-information-page/financical-information-page.component';
import { UserTransactionPageComponent } from './transaction/pages/user-transaction-page/user-transaction-page.component';

import { RoomListComponent } from './RoomsManagement/room-list/room-list.component';
import { RoomCreateComponent } from './RoomsManagement/room-create/room-create.component';
import { RoomEditComponent } from './RoomsManagement/room-edit/room-edit.component';




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
      },
      {
        path: 'financicalInfo',
        component: FinancicalInformationPageComponent
      },
      {
        path: 'ownHistory',
        component: UserTransactionPageComponent
      }

    ]
  },
  {
    path: 'roommanager',
    children: [
      { path: 'rooms', component: RoomListComponent },
      { path: 'createRoom', component: RoomCreateComponent },
      { path: 'roomEdit/:id', component: RoomEditComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
