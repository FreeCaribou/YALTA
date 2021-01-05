import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ToolDataService } from './tool.data.service';
import { IToolService } from './tool.service.interface';

@Injectable({
  providedIn: 'root'
})
export class ToolService implements IToolService {
  constructor(public service: ToolDataService) { }

  getHistoryRanges(): Observable<any> {
    return this.service.getHistoryRanges();
  }

  getGeographicalAreas(): Observable<any> {
    return this.service.getGeographicalAreas();
  }

}