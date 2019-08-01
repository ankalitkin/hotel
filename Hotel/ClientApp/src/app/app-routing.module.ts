import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';

import {RoomListComponent} from './RoomsManagement/room-list/room-list.component';
import {RoomCreateComponent} from './RoomsManagement/room-create/room-create.component';
import {RoomEditComponent} from './RoomsManagement/room-edit/room-edit.component';
import {CustomersGuard} from "./customers-management-pages/_guards/customers.guard";


const routes: Routes = [
  {
    path: 'transactions',
    loadChildren: () => import('./transaction-pages/transaction-pages.module')
      .then(mod => mod.TransactionPagesModule)
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
    path: 'customers',
    runGuardsAndResolvers: 'always',
    canActivate: [CustomersGuard],
    loadChildren: () => import('./customers-management-pages/customers-management-pages.module')
      .then(mod => mod.CustomersManagementPagesModule)
  },
  {
    path: 'staff',
    loadChildren: () => import('./staff-management-pages/staff-management-pages.module')
      .then(mod => mod.StaffManagementPagesModule)
  },
  {
    path: 'flogin',
    loadChildren: () => {
      return import('./fake-login/fake-login.module')
        .then(mod => mod.FakeLoginModule);
    }
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
