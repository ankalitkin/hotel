import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';

import {StaffManagementPagesRoutingModule} from './staff-management-routing.module';
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
import {StaffTablePageComponent} from './staff-table-page/staff-table-page.component';
import {StaffEditorPageComponent} from './staff-editor-page/staff-editor-page.component';


@NgModule({
  declarations: [StaffTablePageComponent, StaffEditorPageComponent],
  imports: [
    CommonModule,
    StaffManagementPagesRoutingModule,
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
export class StaffManagementPagesModule {
}
