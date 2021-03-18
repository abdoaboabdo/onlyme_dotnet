import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class JarwisService {
  private baseUrl = 'http://localhost:5463/api/Account';

  constructor(private http: HttpClient) { }

  signup(data: any) {
    return this.http.post(`${this.baseUrl}/signup`, data)
  }

  login(data: any) {
    console.log(data);
    return this.http.post(`${this.baseUrl}/Login`, data)
  }

  sendPasswordResetLink(data: any) {
    return this.http.post(`${this.baseUrl}/sendPasswordResetLink`, data)
  }
  
  changePassword(data: any) {
    return this.http.post(`${this.baseUrl}/resetPassword`, data)
  }

}
