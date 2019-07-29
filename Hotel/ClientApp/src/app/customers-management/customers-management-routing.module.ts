import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {CustomersTableComponent} from './customers-table/customers-table.component';
import {CustomerEditorComponent} from './customers-editor/customer-editor.component';


const routes: Routes = [
  {
    path: 'register',
    component: CustomerEditorComponent
  },
  {
    path: 'edit/:id',
    component: CustomerEditorComponent
  },
  {
    path: '',
    component: CustomersTableComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CustomersManagementRoutingModule { }
