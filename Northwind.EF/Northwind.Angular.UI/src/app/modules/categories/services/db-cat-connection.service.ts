import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { environment } from 'src/environments/environment';
import { Observable, Subject } from 'rxjs';
import { CategoryModel } from '../models/CategoryModel';


import { map } from 'rxjs/operators'

@Injectable({
  providedIn: 'root'
})
export class DbConnectionService {

  startedEditing = new Subject<number>();

  endpoint: string = 'category'
  url = environment.apiNorthwind + this.endpoint;

  constructor(private http: HttpClient) { }

  public getAllCategories(): Observable<Array<CategoryModel>> {

    return this.http.get<Array<CategoryModel>>(this.url);
  }

  public getOneCategory(id: number): Observable<CategoryModel>{

    return this.http.get<CategoryModel>(this.url + `/${id}`);
  }

  public addCategory(category: CategoryModel){

    return this.http.post(this.url, category)
    .pipe(map((res: any)=>{
      return res;
    }));
  }

  public updateCategory(category: CategoryModel, id: number): Observable<CategoryModel> {

    return this.http.put<CategoryModel>(this.url + "/" + id, category)
    .pipe(map((res:any)=> {
      return res;
    }));
  }

  public deleteCategory(id: number): Observable<any> {

    return this.http.delete(this.url + "/" + id);
  }
}
