import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import {MatCardModule} from '@angular/material/card';
import { ToastrModule } from 'ngx-toastr';
import { NgxMaskModule } from 'ngx-mask';

import { FakestoreComponent } from '../fakestore/components/fakestore/fakestore.component';

@NgModule({
  declarations: [
    FakestoreComponent
  ],
  imports: [
    CommonModule,
    MatCardModule,
    BrowserAnimationsModule,
    HttpClientModule,
    ToastrModule.forRoot(),
    NgxMaskModule.forRoot({
      dropSpecialCharacters: false
    })
  ]
})
export class FakestoreModule { }
