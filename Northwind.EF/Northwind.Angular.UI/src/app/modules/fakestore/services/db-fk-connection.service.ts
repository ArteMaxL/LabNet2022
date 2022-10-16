import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { environment } from 'src/environments/environment';
import { Observable, Subject } from 'rxjs';
import { FakeStoreModel } from '../models/FakeStoreModel';


import { map } from 'rxjs/operators'

@Injectable({
  providedIn: 'root'
})
export class DbFkConnectionService {

  startedEditing = new Subject<number>();

  endpoint: string = 'fakestoreapi'
  url = environment.apiNorthwind + this.endpoint;

  constructor(private http: HttpClient) { }

  public getAllProducts(): Observable<Array<FakeStoreModel>> {

    return this.http.get<Array<FakeStoreModel>>(this.url);
  }
}
