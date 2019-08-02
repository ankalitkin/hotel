import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { InfoTransactionComponent } from './transaction/info-transaction/info-transaction.component';
import { EditTransactionComponent } from './transaction/edit-transaction/edit-transaction.component';

import { InfoTranscationPageComponent } from './transaction/pages/info-transcation-page/info-transcation-page.component';
import { EditTransactionPageComponent } from './transaction/pages/edit-transaction-page/edit-transaction-page.component';
import { ExpandTransactionComponent } from './transaction/expand-transaction/expand-transaction.component';
import { ExpandTransactionPageComponent } from './transaction/pages/expand-transaction-page/expand-transaction-page.component';

import { RoomListComponent } from './RoomsManagement/room-list/room-list.component';
import { RoomFormComponent } from './RoomsManagement/room-form/room-form.component';
import { RoomCreateComponent } from './RoomsManagement/room-create/room-create.component';
import { RoomEditComponent } from './RoomsManagement/room-edit/room-edit.component';

import { RoomCostListComponent } from './RoomCostManagement/roomcost-list/roomcost-list.component';
import { RoomCostFormComponent } from './RoomCostManagement/roomcost-form/roomcost-form.component';
import { RoomCostCreateComponent } from './RoomCostManagement/roomcost-create/roomcost-create.component';
import { RoomCostEditComponent } from './RoomCostManagement/roomcost-edit/roomcost-edit.component';


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
  },
  {
    path: 'roommanager',
    children: [
      { path: 'rooms', component: RoomListComponent },
      { path: 'createRoom', component: RoomCreateComponent },
      { path: 'roomEdit/:id', component: RoomEditComponent }
    ]
  },
  {
    path: 'roomcostmanager',
    children: [
      { path: 'roomCosts', component: RoomCostListComponent },
      { path: 'createRoomCost', component: RoomCostCreateComponent },
      { path: 'roomCostEdit/:id', component: RoomCostEditComponent }
    ]
  }
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
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
