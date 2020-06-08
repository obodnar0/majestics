import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams,  } from '@angular/common/http';
import { environment } from "../../environments/environment";
import { IApiResponse } from "../Models/response";

@Injectable({
  providedIn: 'root',
})
export class UsersService {
  private http: HttpClient;
  private baseUrl: string;

  constructor(http: HttpClient) {
    this.http = http;
    this.baseUrl = environment.apiBaseUrl;
  }

  updateUserInfo(name: string, surname: string, phone: string, address: string, email: string, institution: string, birthDate: Date) {
    const body: any = {
      name: name,
      surname: surname,
      phone: phone,
      address: address,
      email: email,
      institution: institution,
      birthDate: birthDate.toString()
    }

    return this.http.post<IApiResponse>(this.baseUrl + 'api/Users/Update', body);
  }
  
  getUserInfo() {
    return this.http.get<IApiResponse>(this.baseUrl + 'api/Users/Get');
  }
 
}
