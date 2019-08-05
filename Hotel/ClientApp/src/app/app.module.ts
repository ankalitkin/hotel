import '../polyfills';

import {BrowserModule} from '@angular/platform-browser';
import {LOCALE_ID, NgModule} from '@angular/core';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {MaterialModule} from './material-module';

import {registerLocaleData} from '@angular/common';
import localeRu from '@angular/common/locales/ru';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {DateAdapter, MatNativeDateModule} from '@angular/material/core';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {IgxCheckboxModule, IgxInputGroupModule, IgxSliderModule} from 'igniteui-angular';

import {DoubleSliderComponent} from './Slider/slider-component';
// For loading-progress
import {LoadingBarRouterModule} from '@ngx-loading-bar/router';

import {RoomListComponent} from './RoomsManagement/room-list/room-list.component';
import {RoomFormComponent} from './RoomsManagement/room-form/room-form.component';
import {RoomCreateComponent} from './RoomsManagement/room-create/room-create.component';
import {RoomEditComponent} from './RoomsManagement/room-edit/room-edit.component';
import {RegistrationComponent} from './user/registration/registration.component';
import {LoginComponent} from './user/login/login.component';
import {UserService} from 'src/app/user/services/user.service';
import {ToastrModule} from 'ngx-toastr';
import {UserhomeComponent} from './user/userhome/userhome.component';
import {AuthInterceptor} from './auth/auth.interceptor';
import {SharedModule} from './_shared/shared.module';
import {MyDateAdapter} from './_shared/calendar_workaround';

import {RoomCostListComponent} from './RoomCostManagement/roomcost-list/roomcost-list.component';
import {RoomCostFormComponent} from './RoomCostManagement/roomcost-form/roomcost-form.component';
import {RoomCostCreateComponent} from './RoomCostManagement/roomcost-create/roomcost-create.component';
import {RoomCostEditComponent} from './RoomCostManagement/roomcost-edit/roomcost-edit.component';
import {PermitDirective} from './auth/permit.directive';

import {MyHistoryComponent} from './transactions/user-transaction-manager/my-history/my-history.component';
import {MyHistoryPageComponent} from './transactions/user-transaction-manager-pages/my-history-page/my-history-page.component';

import {TransactionPagesModule} from './transactions/transaction-pages/transaction-pages.module';

import {UserTransactionManagerPagesModule} from './transactions/user-transaction-manager-pages/user-transaction-manager-pages.module';
import {GuardsCheckEnd, Router} from '@angular/router';
import {filter, map} from 'rxjs/operators';

import { CategoryListComponent } from './room_client/category-list/category-list.component';
import { ReservationComponent } from './room_client/reservation/reservation';

registerLocaleData(localeRu);

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
    PermitDirective,
    UserhomeComponent,
    MyHistoryPageComponent,
    MyHistoryComponent,
    CategoryListComponent,
    ReservationComponent
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
    SharedModule, //
    TransactionPagesModule,
    UserTransactionManagerPagesModule

    // MyHistoryPageComponent,
    // MyHistoryComponent
  ],
  providers: [
    {provide: LOCALE_ID, useValue: 'ru'},
    {provide: DateAdapter, useClass: MyDateAdapter},
    UserService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }],
  bootstrap: [AppComponent]
})

export class AppModule {
  constructor(private router: Router) {
    router.events.pipe(
      filter(event => event instanceof GuardsCheckEnd),
      map(event => (event as GuardsCheckEnd).shouldActivate)
    ).subscribe(shouldActivate => {
      if (!shouldActivate) {
        this.router.navigate(['user', 'login']);
      }
    });
  }
}
