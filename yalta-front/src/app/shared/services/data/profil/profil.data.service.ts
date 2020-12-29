import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseService } from '../base.service';
import { IProfilService } from './profil.service.interface';


@Injectable({
  providedIn: 'root'
})
export class ProfilDataService implements IProfilService {
  baseUrl = 'profil';

  constructor(private basService: BaseService) { }

  getSuggestedMatchProfil(): Observable<any> {
    return this.basService.get(`${this.basService}`)
  }

  getMyProfil(): Observable<any> {
    return this.basService.get(`${this.basService}/myself`);
  }

}