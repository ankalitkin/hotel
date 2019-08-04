import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {PermitDirective} from './permit/permit.directive';

@NgModule({
  declarations: [PermitDirective],
  exports: [],
  imports: [
    CommonModule,
  ]
})
export class AuthModule {
}
