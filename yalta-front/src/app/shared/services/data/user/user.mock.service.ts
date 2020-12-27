import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { mock_login } from './user.mock';
import { IUserService } from './user.service.interface';

@Injectable({
  providedIn: 'root'
})
export class UserMockDataService implements IUserService {

  login(user): Observable<any> {
    return of(mock_login)
  }
}