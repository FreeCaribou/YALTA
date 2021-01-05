import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { mock_geographical_areas, mock_history_ranges } from './tool.mock';
import { IToolService } from './tool.service.interface';

@Injectable({
  providedIn: 'root'
})
export class ToolMockDataService implements IToolService {

  getHistoryRanges(): Observable<any> {
    return of(mock_history_ranges)
  }

  getGeographicalAreas(): Observable<any> {
    return of(mock_geographical_areas);
  }

}