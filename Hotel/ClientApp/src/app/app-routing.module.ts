import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';

import {InfoTranscationPageComponent} from './transaction/pages/info-transcation-page/info-transcation-page.component';
import {EditTransactionPageComponent} from './transaction/pages/edit-transaction-page/edit-transaction-page.component';

import {RoomListComponent} from './RoomsManagement/room-list/room-list.component';
import {RoomCreateComponent} from './RoomsManagement/room-create/room-create.component';
import {RoomEditComponent} from './RoomsManagement/room-edit/room-edit.component';


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
    path: 'customers',
    loadChildren: () => import('./customers-management-pages/customers-management-pages.module')
      .then(mod => mod.CustomersManagementPagesModule)
  },
  {
    path: 'staff',
    loadChildren: () => import('./staff-management-pages/staff-management-pages.module')
      .then(mod => mod.StaffManagementPagesModule)
  }


  // children: [
  // {
    //    path: 'user-info',
    //    children: [
    //      {
    //        path: ':id',
    //        component: ExpandTransactionPageComponent,
    //      }
    //
  // }
  // ]
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
