import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable, of } from 'rxjs';
import { AlertController } from '@ionic/angular';

@Injectable({
  providedIn: 'root'
})
export class BaseService {
  baseUrl: string = environment.apiUrl;

  constructor(public httpClient: HttpClient, public alertController: AlertController) { }

  getApiTokenHeader(): HttpHeaders {
    let headers = new HttpHeaders();
    headers = headers.set('Api-Token', localStorage.getItem('api_token'));
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');
    headers = headers.set('Content-Language', localStorage.getItem('language'));
    return headers;
  }

  get(path: string): Observable<any> {
    const headers = this.getApiTokenHeader();
    return this.httpClient.get(this.baseUrl + path, { headers });
  }

  post(path: string, body): Observable<any> {
    const headers = this.getApiTokenHeader();
    return this.httpClient.post(this.baseUrl + path, body, { headers });
  }

  put(path: string, body): Observable<any> {
    const headers = this.getApiTokenHeader();
    return this.httpClient.put(this.baseUrl + path, body, { headers });
  }

  delete(path: string): Observable<any> {
    const headers = this.getApiTokenHeader();
    return this.httpClient.delete(this.baseUrl + path, { headers });
  }

}
