import { Observable } from 'rxjs';

export interface IUserService {
  login(user): Observable<any>;
  signUp(user): Observable<any>;
}