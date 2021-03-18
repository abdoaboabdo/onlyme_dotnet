import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Customer } from 'src/app/_models/customer/customer';
import { IPagedResult } from 'src/app/_models/PagedResult/iPagedResult';
import { Response } from 'src/app/_models/response/response';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  private BASEURL='http://localhost:9222/api';

  constructor(private http:HttpClient) { }
  
  getPageResult(filter:any){
    return this.http.get<IPagedResult<Customer>>(`${this.BASEURL}/Customer?`+this.toQueryString(filter));
  }

  getAll(){
    return this.http.get<Customer[]>(`${this.BASEURL}/Customer/getAll`);
  }

  // Get Customer By Id
  getById(id:number){
    return this.http.get<Response<Customer>>(`${this.BASEURL}/Customer/${id}`);
  }

  // Add New Customer
  addCustomer(customer:Customer){
    const formData = new FormData();
    formData.append('name',customer.name);
    formData.append('mobileNumber',customer.mobileNumber);
    formData.append('addressDetails',customer.addressDetails);
    return this.http.post(`${this.BASEURL}/Customer`,formData);
  }

  // Update Customer
  updateCustomer(id:number,customer:Customer){
    const formData = new FormData();
    formData.append('name',customer.name);
    formData.append('mobileNumber',customer.mobileNumber);
    formData.append('addressDetails',customer.addressDetails);
    return this.http.put(`${this.BASEURL}/Customer/${id}`,customer);
  }

  // Delete Customer
  deleteCustomer(id:number){
    return this.http.delete(`${this.BASEURL}/Customer/${id}`);
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
