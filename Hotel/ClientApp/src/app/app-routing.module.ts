import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';

import {RoomListComponent} from './RoomsManagement/room-list/room-list.component';
import {RoomCreateComponent} from './RoomsManagement/room-create/room-create.component';
import {RoomEditComponent} from './RoomsManagement/room-edit/room-edit.component';
import {RoomCostListComponent} from './RoomCostManagement/roomcost-list/roomcost-list.component';
import {RoomCostCreateComponent} from './RoomCostManagement/roomcost-create/roomcost-create.component';
import {RoomCostEditComponent} from './RoomCostManagement/roomcost-edit/roomcost-edit.component';
import {RegistrationComponent} from './user/registration/registration.component';
import {LoginComponent} from './user/login/login.component';
import {UserhomeComponent} from './user/userhome/userhome.component';
import {CustomersGuard} from './customers-management-pages/_guards/customers.guard';
import {RoomManagementGuard} from './RoomsManagement/_guards/roomManagement.guard';
import {RoomCostManagementGuard} from './RoomCostManagement/_guards/roomCostManagement.guard';
import { StaffGuard } from './staff-management-pages/_guards/staff.guard';
import { ReservationComponent } from './room_client/reservation/reservation';
import { CategoryListComponent } from './room_client/category-list/category-list.component';

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
    runGuardsAndResolvers: 'always',
    canActivate: [RoomManagementGuard],
    children: [
      { path: 'rooms', component: RoomListComponent },
      { path: 'createRoom', component: RoomCreateComponent },
      { path: 'roomEdit/:id', component: RoomEditComponent }
    ]
  },
  {
    path: 'roomcostmanager',
    runGuardsAndResolvers: 'always',
    canActivate: [RoomCostManagementGuard],
    children: [
      { path: 'roomCosts', component: RoomCostListComponent },
      { path: 'createRoomCost', component: RoomCostCreateComponent },
      { path: 'roomCostEdit/:id', component: RoomCostEditComponent }
    ]
  },
  {
    path: 'customers',
    runGuardsAndResolvers: 'always',
    canActivate: [CustomersGuard],
    loadChildren: () => import('./customers-management-pages/customers-management-pages.module')
      .then(mod => mod.CustomersManagementPagesModule)
  },
  {
    path: 'staff',
    runGuardsAndResolvers: 'always',
    canActivate: [StaffGuard],
    loadChildren: () => import('./staff-management-pages/staff-management-pages.module')
      .then(mod => mod.StaffManagementPagesModule)
  },
{
  path: 'user',
    children: [
      { path: 'registration', component: RegistrationComponent },
      { path: 'login', component: LoginComponent },
      { path: 'userprofile', component: UserhomeComponent }
    ]

  },
  { path: 'categories', component: CategoryListComponent },
  { path: 'reservation/:id', component: ReservationComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
