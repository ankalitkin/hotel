import '../polyfills';

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MaterialModule } from './material-module';

import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatNativeDateModule } from '@angular/material/core';
//import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

// For loading-progress
import { LoadingBarHttpClientModule } from '@ngx-loading-bar/http-client';
import { LoadingBarHttpModule } from '@ngx-loading-bar/http';
import { LoadingBarRouterModule } from '@ngx-loading-bar/router'

import { InfoTransactionComponent } from './transaction/info-transaction/info-transaction.component';
import { InfoTranscationPageComponent } from './transaction/pages/info-transcation-page/info-transcation-page.component';


@NgModule({

  declarations: [
    AppComponent,
    InfoTransactionComponent,
    InfoTranscationPageComponent
  ],
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
