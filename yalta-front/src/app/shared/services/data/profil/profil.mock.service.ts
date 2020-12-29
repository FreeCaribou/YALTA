import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { mock_profil } from './profil.mock';
import { IProfilService } from './profil.service.interface';

@Injectable({
  providedIn: 'root'
})
export class ProfilMockDataService implements IProfilService {

  getSuggestedMatchProfil(): Observable<any> {
    return of(mock_profil)
  }

}