import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProfilDataService } from './profil.data.service';
import { IProfilService } from './profil.service.interface';

@Injectable({
  providedIn: 'root'
})
export class ProfilService implements IProfilService {
  constructor(public service: ProfilDataService) { }

  getSuggestedMatchProfil(): Observable<any> {
    return this.service.getSuggestedMatchProfil();
  }

  getMyProfil(): Observable<any> {
    return this.service.getMyProfil();
  }

}