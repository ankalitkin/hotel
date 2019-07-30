import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';

import {CustomersManagementPagesRoutingModule} from './customers-management-routing.module';
import {
  MatButtonModule,
  MatCheckboxModule,
  MatDatepickerModule,
  MatFormFieldModule,
  MatInputModule,
  MatPaginatorModule,
  MatSelectModule,
  MatSortModule,
  MatTableModule
} from '@angular/material';
import {SharedModule} from '../_shared/shared.module';
import {UserManagementModule} from '../user-management/user-management.module';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {CustomerTablePageComponent} from './customer-table-page/customer-table-page.component';
import {CustomerEditorPageComponent} from './customer-editor-page/customer-editor-page.component';


@NgModule({
  declarations: [CustomerTablePageComponent, CustomerEditorPageComponent],
  imports: [
    CommonModule,
    CustomersManagementPagesRoutingModule,
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    MatDatepickerModule,
    MatTableModule,
    MatSortModule,
    MatButtonModule,
    MatPaginatorModule,
    SharedModule,
    UserManagementModule,
    FormsModule,
    MatCheckboxModule,
    ReactiveFormsModule,
  ]
})
export class CustomersManagementPagesModule {
}
