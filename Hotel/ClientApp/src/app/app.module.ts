import '../polyfills';

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MaterialModule } from './material-module';

import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatNativeDateModule } from '@angular/material/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

// For loading-progress
import { LoadingBarHttpClientModule } from '@ngx-loading-bar/http-client';
import { LoadingBarHttpModule } from '@ngx-loading-bar/http';
import { LoadingBarRouterModule } from '@ngx-loading-bar/router'

import { InfoTranscationPageComponent } from './transaction/pages/info-transcation-page/info-transcation-page.component';
import { InfoTransactionComponent } from './transaction/info-transaction/info-transaction.component';
import { EditTransactionDialogComponent } from './transaction/edit-transaction-dialog/edit-transaction-dialog.component';
import { ExpandTransactionComponent } from './transaction/expand-transaction/expand-transaction.component';
import { ExpandTransactionPageComponent } from './transaction/pages/expand-transaction-page/expand-transaction-page.component';
import { EditTransactionPageComponent } from './transaction/pages/edit-transaction-page/edit-transaction-page.component';
import { ControlErrorsComponent } from './_shared/control-errors/control-errors.component';

import { RoomListComponent } from './RoomsManagement/room-list/room-list.component';
import { RoomFormComponent } from './RoomsManagement/room-form/room-form.component';
import { RoomCreateComponent } from './RoomsManagement/room-create/room-create.component';
import { RoomEditComponent } from './RoomsManagement/room-edit/room-edit.component';
import { FilterTransactionComponent } from './transaction/filter-transaction/filter-transaction.component';
import { FinancicalInformationPageComponent } from './transaction/pages/financical-information-page/financical-information-page.component';
import { FinancicalInformationComponent } from './transaction/financical-information/financical-information.component';
import { MyHistoryPageComponent } from './transaction/pages/my-history-page/my-history-page.component';
import { MyHistoryComponent } from './transaction/my-history/my-history.component';
import { InfoUserTranscationPageComponent } from './transaction/pages/info-user-transcation-page/info-user-transcation-page.component';

@NgModule({

  declarations: [
    AppComponent,
    InfoTransactionComponent,
    InfoTranscationPageComponent,    EditTransactionDialogComponent,
    ExpandTransactionComponent,
    ExpandTransactionPageComponent,
    EditTransactionPageComponent,
    ControlErrorsComponent,
    RoomListComponent,
    RoomFormComponent,
    RoomCreateComponent,
    RoomEditComponent,
    FilterTransactionComponent,
    FinancicalInformationPageComponent,
    FinancicalInformationComponent,
    MyHistoryPageComponent,
    MyHistoryComponent,
    InfoUserTranscationPageComponent
  ],
  entryComponents: [EditTransactionDialogComponent, EditTransactionPageComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MaterialModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    MatNativeDateModule,
    ReactiveFormsModule,
    //LoadingBarHttpClientModule,
    //LoadingBarHttpModule,
    LoadingBarRouterModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
