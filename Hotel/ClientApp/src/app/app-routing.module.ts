import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { RoomListComponent } from './RoomsManagement/room-list/room-list.component';
import { RoomCreateComponent } from './RoomsManagement/room-create/room-create.component';
import { RoomEditComponent } from './RoomsManagement/room-edit/room-edit.component';

import { RoomCostListComponent } from './RoomCostManagement/roomcost-list/roomcost-list.component';
import { RoomCostFormComponent } from './RoomCostManagement/roomcost-form/roomcost-form.component';
import { RoomCostCreateComponent } from './RoomCostManagement/roomcost-create/roomcost-create.component';
import { RoomCostEditComponent } from './RoomCostManagement/roomcost-edit/roomcost-edit.component';


const routes: Routes = [
  {
    path: 'transactions',
    loadChildren: () => import('./transactions/transaction-pages/transaction-pages.module')
      .then(mod => mod.TransactionPagesModule)
  },
  {
    path: 'usertransactions',
    loadChildren: () => import('./transactions/user-transaction-manager-pages/user-transaction-manager-pages.module')
      .then(mod => mod.UserTransactionManagerPagesModule)
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
  },
  {
    path: 'customers',
    loadChildren: () => import('./customers-management-pages/customers-management-pages.module')
      .then(mod => mod.CustomersManagementPagesModule)
  },
  {
    path: 'staff',
    loadChildren: () => import('./staff-management-pages/staff-management-pages.module')
      .then(mod => mod.StaffManagementPagesModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
