import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {UsersTableComponent} from './users-table/users-table.component';
import {UserEditorComponent} from './user-editor/user-editor.component';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {
  MatButtonModule,
  MatCheckboxModule,
  MatDatepickerModule,
  MatFormFieldModule,
  MatInputModule,
  MatOptionModule,
  MatPaginatorModule,
  MatSelectModule,
  MatSortModule,
  MatTableModule
} from '@angular/material';
import {RouterModule} from '@angular/router';

@NgModule({
  declarations: [UsersTableComponent, UserEditorComponent],
  exports: [
    UserEditorComponent,
    UsersTableComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatDatepickerModule,
    MatOptionModule,
    MatSelectModule,
    MatCheckboxModule,
    FormsModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatButtonModule,
    RouterModule,
    MatInputModule
  ]
})
export class UserManagementModule {
}
