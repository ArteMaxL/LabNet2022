import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { environment } from 'src/environments/environment';
import { Observable, Subject } from 'rxjs';
import { CustomerModel } from '../models/CustomerModel';


import { map } from 'rxjs/operators'

@Injectable({
  providedIn: 'root'
})
export class DbConnectionService {

  startedEditing = new Subject<number>();

  endpoint: string = 'customer'
  url = environment.apiNorthwind + this.endpoint;

  constructor(private http: HttpClient) { }

  public getAllCustomers(): Observable<Array<CustomerModel>> {

    return this.http.get<Array<CustomerModel>>(this.url);
  }

  public getOneCustomer(id: string): Observable<CustomerModel>{

    return this.http.get<CustomerModel>(this.url + `/${id}`);
  }

  public addCustomer(customer: CustomerModel){

    return this.http.post(this.url, customer)
    .pipe(map((res: any)=>{
      return res;
    }));
  }

  public updateCustomer(customer: CustomerModel, id: string): Observable<CustomerModel> {

    return this.http.put<CustomerModel>(this.url + "/" + id, customer)
    .pipe(map((res:any)=> {
      return res;
    }));
  }

  public deleteCustomer(id: string): Observable<any> {

    return this.http.delete(this.url + "/" + id);
  }
}
