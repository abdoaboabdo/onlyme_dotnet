import { Injectable } from '@angular/core';
import { Variety } from 'src/app/_models/variety/variety';
import { IPagedResult } from 'src/app/_models/PagedResult/iPagedResult';
import { Response } from 'src/app/_models/response/response';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class VarietyService {

  private BASEURL = 'http://localhost:9222/api';

  constructor(private http: HttpClient) { }

  addVariety(variety: Variety) {
    const formData = new FormData();
    formData.append('name', variety.name);
    formData.append('categoryId', variety.categoryId.toString());
    return this.http.post(`${this.BASEURL}/Variety`, formData);
  }
  getPagedResult(filter: any) {
    return this.http.get<IPagedResult<Variety>>(`${this.BASEURL}/Variety?` + this.toQueryString(filter));
  }
  getAll(params: any=null) {
    return this.http.get<Variety[]>(`${this.BASEURL}/Variety/GetAll?`+this.toQueryString(params));
  }
  getById(id: number) {
    return this.http.get<Response<Variety>>(`${this.BASEURL}/Variety/${id}`);
  }
  updateVariety(id: number, variety: Variety) {
    const formData = new FormData();
    formData.append('name', variety.name);
    formData.append('categoryId', variety.categoryId.toString());
    return this.http.put(`${this.BASEURL}/Variety/${id}`, variety);
  }
  deleteVariety(id: number) {
    return this.http.delete(`${this.BASEURL}/Variety/${id}`);
  }

  toQueryString(obj: any) {
    const parts = [];
    for ( const property in obj) {
      const value = obj[property];
      if (value != null && value != undefined) {
        parts.push(encodeURIComponent(property) + '=' + encodeURIComponent(value));
      }
    }
    return parts.join('&');
  }
}
