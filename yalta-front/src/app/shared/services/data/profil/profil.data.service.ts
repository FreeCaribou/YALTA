import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseService } from '../base.service';
import { IProfilService } from './profil.service.interface';


@Injectable({
  providedIn: 'root'
})
export class ProfilDataService implements IProfilService {
  baseUrl = 'profil';

  constructor(public baseService: BaseService) { }

  getSuggestedMatchProfil(): Observable<any> {
    return this.baseService.get(`${this.baseUrl}`)
  }

  getMyProfil(): Observable<any> {
    return this.baseService.get(`${this.baseUrl}/myself`);
  }

}