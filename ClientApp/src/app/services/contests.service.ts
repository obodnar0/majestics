import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams,  } from '@angular/common/http';
import { environment } from "../../environments/environment";
import { IApiResponse } from "../Models/response";

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
    return this.http.get<IApiResponse>(this.baseUrl + 'api/Contest/GetAll');
  }

  GetContest(contestId: number) {
    return this.http.get<IApiResponse>(this.baseUrl + 'api/Contest/Get?contestId=' + contestId);
  }

  CreateContest(title: string, description: string, isOpen: boolean) {
    const body: CreateContest = {
      title: title,
      description: description,
      isOpen: isOpen,
    }

    return this.http.post<IApiResponse>(this.baseUrl + 'api/Contest/CreateContest', body);
  }

  MarkWork(workId: string, value: string, criteriaId: string) {
    const body: any = {
      workId: workId,
      mark: value,
      criteriaId: criteriaId,
    }

    return this.http.post<IApiResponse>(this.baseUrl + 'api/Contest/AddMark', body);
  }

  CreateWork(title: string, description: string, source: string, contestId: number) {
    const body: CreateWork = {
      title: title,
      description: description,
      source: source,
      contestId: contestId
    }

    return this.http.post<IApiResponse>(this.baseUrl + 'api/Contest/AddWork', body);
  }

  GetWorkDetails(workId: string) {
    return this.http.get<IApiResponse>(this.baseUrl + 'api/Contest/GetWorkDetails?workId=' + workId);
  }

  GetCriterias() {
    return this.http.get<IApiResponse>(this.baseUrl + 'api/Contest/GetCriterias');
  }

  UploadFile(formData: FormData) {
    return this.http.post<IApiResponse>(this.baseUrl + 'Data/UploadFile', formData);
  }
}

class CreateContest {
  title: string;
  description: string;
  isOpen: boolean;
}

class CreateWork {
  contestId: number;
  title: string;
  description: string;
  source: string;
}
