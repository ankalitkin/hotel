import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';

import {CustomersManagementRoutingModule} from './customers-management-routing.module';
import {CustomersTableComponent} from './customers-table/customers-table.component';
import {CustomerEditorComponent} from './customers-editor/customer-editor.component';
import {
  MatButtonModule, MatCheckboxModule,
  MatDatepickerModule,
  MatFormFieldModule,
  MatInputModule, MatPaginatorModule,
  MatSelectModule, MatSortModule,
  MatTableModule
} from '@angular/material';
import {SharedModule} from "../_shared/shared.module";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";


@NgModule({
  declarations: [CustomersTableComponent, CustomerEditorComponent],
  imports: [
    CommonModule,
    CustomersManagementRoutingModule,
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    MatDatepickerModule,
    MatTableModule,
    MatSortModule,
    MatButtonModule,
    MatPaginatorModule,
    SharedModule,
    FormsModule,
    MatCheckboxModule,
    ReactiveFormsModule,
  ]
})
export class CustomersManagementModule {
}
