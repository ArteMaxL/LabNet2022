import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShipperFormComponent } from './modules/shippers/components/shipper-form/shipper-form.component';
import { HomeComponent } from './layout/home/home.component';
import { CategoryFormComponent } from './modules/categories/components/category-form/category-form.component';
import { CustomerFormComponent } from './modules/customers/components/customer-form/customer-form.component';
import { FakestoreComponent } from './modules/fakestore/components/fakestore/fakestore.component';

const routes: Routes = [{
    path: '',
    component: HomeComponent
  },
  {
    path: 'category',
    component: CategoryFormComponent
  },
  {
    path: 'customer',
    component: CustomerFormComponent
  },
  {
    path: 'shippers',
    component: ShipperFormComponent
  },
  {
    path: 'fakestoreapi',
    component: FakestoreComponent
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
