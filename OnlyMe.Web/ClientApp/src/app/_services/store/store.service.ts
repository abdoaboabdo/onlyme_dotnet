import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPagedResult } from 'src/app/_models/PagedResult/iPagedResult';
import { Response } from 'src/app/_models/response/response';
import { Store } from 'src/app/_models/store/store';

@Injectable({
  providedIn: 'root'
})
export class StoreService {
  private BASEURL='http://localhost:9222/api';

  constructor(private http:HttpClient) { }

  addStore(store:Store){
    const formData = new FormData();
    formData.append('name',store.name);
    formData.append('code',store.code);
    formData.append('address',store.address);
    return this.http.post(`${this.BASEURL}/Store`,formData);
  }

  getPagedResult(filter:any){
    return this.http.get<IPagedResult<Store>>(`${this.BASEURL}/Store?`+this.toQueryString(filter));
  }

  getAll(){
    return this.http.get<Store[]>(`${this.BASEURL}/Store/GetAll`);
  }
  getById(id:number){
    return this.http.get<Response<Store>>(`${this.BASEURL}/Store/${id}`);
  }

  updateStore(id:number,store:Store){
    const formData = new FormData();
    formData.append('name',store.name);
    formData.append('code',store.code);
    formData.append('address',store.address);
    return this.http.put(`${this.BASEURL}/Store/${id}`,store);
  }

  deleteStore(id:number){
    return this.http.delete(`${this.BASEURL}/Store/${id}`);
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
