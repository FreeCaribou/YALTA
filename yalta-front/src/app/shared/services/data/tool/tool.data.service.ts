import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseService } from '../base.service';
import { IToolService } from './tool.service.interface';


@Injectable({
  providedIn: 'root'
})
export class ToolDataService implements IToolService {
  baseUrl = 'tool';

  constructor(public baseService: BaseService) { }

  getHistoryRanges(): Observable<any> {
    return this.baseService.get(`${this.baseUrl}/historyRanges`)
  }

  getGeographicalAreas(): Observable<any> {
    return this.baseService.get(`${this.baseService}/geographicalAreas`);
  }

}