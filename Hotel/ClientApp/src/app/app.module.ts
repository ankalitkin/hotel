import '../polyfills';

import { BrowserModule } from '@angular/platform-browser';
import {LOCALE_ID, NgModule} from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MaterialModule } from './material-module';

import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {DateAdapter, MatNativeDateModule} from '@angular/material/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {
  IgxInputGroupModule,
  IgxSliderModule
} from "igniteui-angular";

import { IgxCheckboxModule } from 'igniteui-angular';

import { DoubleSliderComponent } from "./Slider/slider-component";

// For loading-progress
import { LoadingBarHttpClientModule } from '@ngx-loading-bar/http-client';
import { LoadingBarHttpModule } from '@ngx-loading-bar/http';
import { LoadingBarRouterModule } from '@ngx-loading-bar/router';

import { RoomListComponent } from './RoomsManagement/room-list/room-list.component';
import { RoomFormComponent } from './RoomsManagement/room-form/room-form.component';
import { RoomCreateComponent } from './RoomsManagement/room-create/room-create.component';
import { RoomEditComponent } from './RoomsManagement/room-edit/room-edit.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { LoginComponent } from './user/login/login.component';
import { UserService } from 'src/app/user/services/user.service';
import { ToastrModule } from 'ngx-toastr';
import { UserhomeComponent } from './user/userhome/userhome.component';
import { AuthInterceptor } from './auth/auth.interceptor';
import { HTTP_INTERCEPTORS } from "@angular/common/http";
import {SharedModule} from './_shared/shared.module';
import {MyDateAdapter} from './_shared/calendar_workaround';

import { RoomCostListComponent } from './RoomCostManagement/roomcost-list/roomcost-list.component';
import { RoomCostFormComponent } from './RoomCostManagement/roomcost-form/roomcost-form.component';
import { RoomCostCreateComponent } from './RoomCostManagement/roomcost-create/roomcost-create.component';
import { RoomCostEditComponent } from './RoomCostManagement/roomcost-edit/roomcost-edit.component';

@NgModule({

  declarations: [
    AppComponent,
    RoomListComponent,
    RoomFormComponent,
    RoomCreateComponent,
    RoomEditComponent,
    RoomCostListComponent,
    RoomCostFormComponent,
    RoomCostCreateComponent,
    RoomCostEditComponent,
    DoubleSliderComponent,
    RegistrationComponent,
    LoginComponent,
    UserhomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MaterialModule, //
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    MatNativeDateModule,
    ReactiveFormsModule,
    LoadingBarRouterModule,
    ToastrModule.forRoot({
      progressBar: true
    }),
    IgxInputGroupModule,
    IgxSliderModule,
    IgxCheckboxModule,
    LoadingBarRouterModule, //
    SharedModule,
  ],
  providers: [
/*    {provide: LOCALE_ID, useValue: 'ru'},*/
    {provide: DateAdapter, useClass: MyDateAdapter}
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
