import { Component, OnInit } from '@angular/core';
import { FakeStoreModel } from '../../models/FakeStoreModel';
import { HttpClient } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import {MatGridListModule} from '@angular/material/grid-list';
import { DbFkConnectionService } from '../../services/db-fk-connection.service';

@Component({
  selector: 'app-fakestore',
  templateUrl: './fakestore.component.html',
  styleUrls: ['./fakestore.component.css']
})
export class FakestoreComponent implements OnInit {
  err = null;
  isLoading = false;
  fakeStoreModel : FakeStoreModel = new FakeStoreModel;

  public products: Array<FakeStoreModel> = [];

  constructor(private httpclient:     HttpClient,
    private apiService:     DbFkConnectionService,
    private toastrService:  ToastrService) { }

  ngOnInit(): void {
    this.getProducts();
  }

  getProducts(){

    this.isLoading = true;
    this.apiService.getAllProducts()
    .subscribe(res => {

      this.isLoading = false;
      this.products = res;

    },
    err => {

      this.isLoading = false;
      this.err = err.message
      this.toastrService.error('Error getting list - ' + err.message)
    });
  }

}
