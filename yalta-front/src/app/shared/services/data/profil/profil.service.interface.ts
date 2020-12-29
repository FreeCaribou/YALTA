import { Observable } from 'rxjs';

export interface IProfilService {
  getSuggestedMatchProfil(): Observable<any>;
}