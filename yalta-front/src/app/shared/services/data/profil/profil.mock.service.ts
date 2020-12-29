import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { mock_one_profil, mock_profils } from './profil.mock';
import { IProfilService } from './profil.service.interface';

@Injectable({
  providedIn: 'root'
})
export class ProfilMockDataService implements IProfilService {

  getSuggestedMatchProfil(): Observable<any> {
    return of(mock_profils)
  }

  getMyProfil(): Observable<any> {
    return of(mock_one_profil);
  }

}