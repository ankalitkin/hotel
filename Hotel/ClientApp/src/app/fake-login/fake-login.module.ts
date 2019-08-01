import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {FakeLoginComponent} from './fake-login/fake-login.component';
import {FakeLoginRoutingModule} from './fake-login-routing.module';


@NgModule({
  declarations: [FakeLoginComponent],
  imports: [
    CommonModule,
    FakeLoginRoutingModule
  ]
})
export class FakeLoginModule {
}
