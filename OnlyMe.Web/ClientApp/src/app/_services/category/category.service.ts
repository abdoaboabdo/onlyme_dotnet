import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IPagedResult } from 'src/app/_models/PagedResult/iPagedResult';
import { Category } from 'src/app/_models/category/category';
import { Response } from 'src/app/_models/response/response';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  private BASEURL='http://localhost:9222/api';

  constructor(private http:HttpClient) { }

  addCategory(category:Category){
    const formData = new FormData();
    formData.append('name',category.name);
    return this.http.post(`${this.BASEURL}/Category`,formData);
  }
  getPagedResult(filter:any){
    return this.http.get<IPagedResult<Category>>(`${this.BASEURL}/Category?`+this.toQueryString(filter));
  }
  getAll(){
    return this.http.get<Category[]>(`${this.BASEURL}/Category/GetAll`);
  }
  getById(id:number){
    return this.http.get<Response<Category>>(`${this.BASEURL}/Category/${id}`);
  }
  updateCategory(id:number,category:Category){
    const formData = new FormData();
    formData.append('name',category.name);
    return this.http.put(`${this.BASEURL}/Category/${id}`,category);
  }
  deleteCategory(id:number){
    return this.http.delete(`${this.BASEURL}/Category/${id}`);
  }

  toQueryString(obj:any){
    var parts = [];
    for ( let property in obj) {
      let value = obj[property];
      if (value != null && value != undefined) {
        parts.push(encodeURIComponent(property) + '=' + encodeURIComponent(value));
      }
    }
    return parts.join('&');
  }
}
