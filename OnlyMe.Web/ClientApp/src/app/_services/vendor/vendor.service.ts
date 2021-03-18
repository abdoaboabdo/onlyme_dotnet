import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Vendor } from 'src/app/_models/vendor/vendor';
import { IPagedResult } from 'src/app/_models/PagedResult/iPagedResult';
import { Response } from 'src/app/_models/response/response';

@Injectable({
  providedIn: 'root'
})
export class VendorService {
  private BASEURL='http://localhost:9222/api';

  constructor(private http:HttpClient) { }

  // Get All Vendor
  getPageResult(filter:any){
    return this.http.get<IPagedResult<Vendor>>(`${this.BASEURL}/Vendor?`+this.toQueryString(filter));
  }

  getAll(){
    return this.http.get<Vendor[]>(`${this.BASEURL}/Vendor/getAll`);
  }

  // Get Vendor By Id
  getById(id:number){
    return this.http.get<Response<Vendor>>(`${this.BASEURL}/Vendor/${id}`);
  }

  // Add New Vendor name:string, email : string, mobileNumber:string, phoneNumber:string, addressDetails:string
  addVendor(vendor:Vendor){
    const formData = new FormData();
    formData.append('name',vendor.name);
    formData.append('email',vendor.email);
    formData.append('mobileNumber',vendor.mobileNumber);
    formData.append('phoneNumber',vendor.phoneNumber);
    formData.append('addressDetails',vendor.addressDetails);
    return this.http.post(`${this.BASEURL}/Vendor`,formData);
  }

  // Update Vendor
  updateVendor(id:number,vendor:Vendor){
    const formData = new FormData();
    formData.append('name',vendor.name);
    formData.append('email',vendor.email);
    formData.append('mobileNumber',vendor.mobileNumber);
    formData.append('phoneNumber',vendor.phoneNumber);
    formData.append('addressDetails',vendor.addressDetails);
    return this.http.put(`${this.BASEURL}/Vendor/${id}`,vendor);
  }

  // Delete Vendor
  deleteVendor(id:number){
    return this.http.delete(`${this.BASEURL}/Vendor/${id}`);
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
