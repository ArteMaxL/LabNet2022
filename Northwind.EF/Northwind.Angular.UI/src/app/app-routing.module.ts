import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShipperFormComponent } from './modules/shippers/components/shipper-form/shipper-form.component';
import { HomeComponent } from './layout/home/home.component';

const routes: Routes = [{
    path: '',
    component: HomeComponent
  },
  {
    path: 'shippers',
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
