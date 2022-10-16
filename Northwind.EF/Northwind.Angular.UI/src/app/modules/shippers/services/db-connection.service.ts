import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { environment } from 'src/environments/environment';
import { Observable, Subject } from 'rxjs';
import { ShipperModel } from '../models/ShipperModel';


import { map } from 'rxjs/operators'

@Injectable({
  providedIn: 'root'
})
export class DbConnectionService {

  startedEditing = new Subject<number>();

  endpoint: string = 'shipper'
  url = environment.apiNorthwind + this.endpoint;

  constructor(private http: HttpClient) { }

  public getAllShippers(): Observable<Array<ShipperModel>> {

    return this.http.get<Array<ShipperModel>>(this.url);
  }

  public getOneShipper(id: number): Observable<ShipperModel>{

    return this.http.get<ShipperModel>(this.url + `/${id}`);
  }

  public addShipper(shipper: ShipperModel){

    return this.http.post(this.url, shipper)
    .pipe(map((res: any)=>{
      return res;
    }));
  }

  public updateShipper(shipper: ShipperModel, id: number): Observable<ShipperModel> {

    return this.http.put<ShipperModel>(this.url + "/" + id, shipper)
    .pipe(map((res:any)=> {
      return res;
    }));
  }

  public deleteShipper(id: number): Observable<any> {

    return this.http.delete(this.url + "/" + id);
  }
}
