import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from "../../environments/environment";
import { ApiResponse } from "../Models/response";

@Injectable({
  providedIn: 'root',
})
export class ContestsService {
  private http: HttpClient;
  private baseUrl: string;

  constructor(http: HttpClient) {
    this.http = http;
    this.baseUrl = environment.apiBaseUrl;
  }

  GetContests() {
    return this.http.get<ApiResponse>(this.baseUrl + 'api/Contest/Get')
  }

  CreateContest(title: string, description: string, isOpen: boolean) {
    const body: CreateContest = {
      title: title,
      description: description,
      isOpen: isOpen,
    }

    return this.http.post<ApiResponse>(this.baseUrl + 'api/Contest/CreateContest', body);
  }
}

class CreateContest {
  title: string;
  description: string;
  isOpen: boolean;
}
