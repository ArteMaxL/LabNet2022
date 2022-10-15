import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShipperFormComponent } from './modules/shippers/components/shipper-form/shipper-form.component';

const routes: Routes = [{
    path: '',
    component: ShipperFormComponent
  }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ]
})

export class AppRoutingModule { }
