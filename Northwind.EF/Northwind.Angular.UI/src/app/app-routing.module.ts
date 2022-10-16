import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShipperFormComponent } from './modules/shippers/components/shipper-form/shipper-form.component';
import { HomeComponent } from './layout/home/home.component';
import { CategoryFormComponent } from './modules/categories/components/category-form/category-form.component';

const routes: Routes = [{
    path: '',
    component: HomeComponent
  },
  {
    path: 'category',
    component: CategoryFormComponent
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
