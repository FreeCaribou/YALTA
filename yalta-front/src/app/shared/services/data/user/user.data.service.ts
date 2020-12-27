import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseService } from '../base.service';
import { IUserService } from './user.service.interface';

@Injectable({
  providedIn: 'root'
})
export class UserDataService implements IUserService {
  baseUrl = 'user';

  constructor(private baseService: BaseService) { }

  login(user): Observable<any> {
    return this.baseService.post(`${this.baseUrl}/login`, user)
  }
}