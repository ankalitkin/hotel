import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {StaffTablePageComponent} from './staff-table-page/staff-table-page.component';
import {StaffEditorPageComponent} from './staff-editor-page/staff-editor-page.component';


const routes: Routes = [
  {
    path: 'register',
    component: StaffEditorPageComponent
  },
  {
    path: 'edit/:id',
    component: StaffEditorPageComponent
  },
  {
    path: '',
    component: StaffTablePageComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StaffManagementPagesRoutingModule {
}

