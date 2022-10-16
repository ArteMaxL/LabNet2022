import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ModalModule, BsModalRef } from 'ngx-bootstrap/modal';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { CrudShippersModule } from './modules/shippers/crud.module';
import { HeaderComponent } from './layout/header/header.component';
import { FooterComponent } from './layout/footer/footer.component';
import { CrudCategoriesModule } from './modules/categories/crud-categories.module';
import { CrudCustomersModule } from './modules/customers/crud-customers.module';
@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    CrudCategoriesModule,
    CrudCustomersModule,
    CrudShippersModule,
    HttpClientModule,
    ModalModule.forRoot()

  ],
  providers: [BsModalRef],
  bootstrap: [AppComponent]
})
export class AppModule { }
