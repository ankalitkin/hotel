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

import { RegistrationComponent } from './user/registration/registration.component';
import { LoginComponent } from './user/login/login.component';
import { UserhomeComponent } from './user/userhome/userhome.component';

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
  path: 'user',
    children: [
      { path: 'registration', component: RegistrationComponent },
      { path: 'login', component: LoginComponent },
      { path: 'userprofile', component: UserhomeComponent }
    ]
    
  },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
