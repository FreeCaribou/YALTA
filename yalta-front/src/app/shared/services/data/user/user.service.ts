import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserDataService } from './user.data.service';
import { IUserService } from './user.service.interface';

@Injectable({
  providedIn: 'root'
})
export class UserService implements IUserService {
  constructor(private service: UserDataService) { }

  login(user): Observable<any> {
    return this.service.login(user);
  }
}