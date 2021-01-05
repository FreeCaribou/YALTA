import { Observable } from 'rxjs';

export interface IToolService {
  getHistoryRanges(): Observable<any>;
  getGeographicalAreas(): Observable<any>;
}