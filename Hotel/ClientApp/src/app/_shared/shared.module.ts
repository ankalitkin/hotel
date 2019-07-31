import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {ControlErrorsComponent} from './control-errors/control-errors.component';
import {MatFormFieldModule, MatSelectModule} from '@angular/material';
import {FormsModule} from '@angular/forms';

@NgModule({
  declarations: [ControlErrorsComponent],
  exports: [
    ControlErrorsComponent,
  ],
  imports: [
    CommonModule,
    MatFormFieldModule,
    MatSelectModule,
    FormsModule,
  ]
})
export class SharedModule {
}
