import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPagedResult } from 'src/app/_models/PagedResult/iPagedResult';
import { Product } from 'src/app/_models/product/product';
import { Response } from 'src/app/_models/response/response';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private BASEURL='http://localhost:9222/api';

  constructor(private http:HttpClient) { }

  addProduct(product:Product){
    const formData = new FormData();
    formData.append('name',product.name);
    formData.append('description',product.description);
    formData.append('varietyId',product.varietyId.toString());
    return this.http.post(`${this.BASEURL}/Product`,formData);
  }

  getPagedResult(filter:any){
    return this.http.get<IPagedResult<Product>>(`${this.BASEURL}/Product?`+this.toQueryString(filter));
  }

  getAll(params:any=null){
    return this.http.get<Product[]>(`${this.BASEURL}/Product/GetAll?`+this.toQueryString(params));
  }
  getById(id:number){
    return this.http.get<Response<Product>>(`${this.BASEURL}/Product/${id}`);
  }

  updateProduct(id:number,product:Product){
    const formData = new FormData();
    formData.append('name',product.name);
    formData.append('description',product.description);
    formData.append('varietyId',product.varietyId.toString());
    return this.http.put(`${this.BASEURL}/Product/${id}`,product);
  }

  deleteProduct(id:number){
    return this.http.delete(`${this.BASEURL}/Product/${id}`);
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
