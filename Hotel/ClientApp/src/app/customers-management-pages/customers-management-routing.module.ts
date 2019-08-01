import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {CustomerTablePageComponent} from './customer-table-page/customer-table-page.component';
import {CustomerEditorPageComponent} from './customer-editor-page/customer-editor-page.component';


const routes: Routes = [
  {
    path: 'register',
    component: CustomerEditorPageComponent
  },
  {
    path: 'edit/:id',
    component: CustomerEditorPageComponent
  },
  {
    path: '',
    component: CustomerTablePageComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CustomersManagementPagesRoutingModule {
}
