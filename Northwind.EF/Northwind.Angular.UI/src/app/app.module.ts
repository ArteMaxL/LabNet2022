import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ModalModule, BsModalRef } from 'ngx-bootstrap/modal';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { CrudShippersModule } from './modules/shippers/crud.module';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [

    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    CrudShippersModule,
    HttpClientModule,
    ModalModule.forRoot()

  ],
  providers: [BsModalRef],
  bootstrap: [AppComponent]
})
export class AppModule { }
