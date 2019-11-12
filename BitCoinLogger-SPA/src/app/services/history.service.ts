

import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { PriceItem } from '../models/price-item';
import { PaginatedResult } from '../models/Pagination';
import { map } from 'rxjs/operators';

@Injectable({
 providedIn: 'root'
})

export class HistoryService {
 private controllerName = 'History';
 constructor(private httpClient: HttpClient) { }

 getHistoryItems(page?, itemsPerPage?, historyItemParams?): Observable<PaginatedResult<PriceItem[]>> {

  const paginatedResult: PaginatedResult<PriceItem[]> = new PaginatedResult<PriceItem[]>();

  let params = new HttpParams();

  if (page != null && itemsPerPage != null) {
   params = params.append('pageNumber', page);
   params = params.append('pageSize', itemsPerPage);
  }

  if (historyItemParams != null) {
    params = params.append('sourceId', historyItemParams.sourceId);
    params = params.append('dateFrom', historyItemParams.fromDate);
    params = params.append('dateTo', historyItemParams.toDate);
    params = params.append('orderBy', historyItemParams.orderBy);
  }

  return this.httpClient.get<PriceItem[]>(environment.apiUrl + this.controllerName, { observe: 'response', params: params })
  .pipe(
    map(response => {
      paginatedResult.result = response.body;
      if (response.headers.get('Pagination') != null) {
        paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
      }
      return paginatedResult;
    })
  );
 }
}
