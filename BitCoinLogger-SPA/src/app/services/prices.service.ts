import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';
import { PriceItem } from '../models/price-item';
import { environment } from 'src/environments/environment';
import { Source } from '../models/source';
@Injectable({
  providedIn: 'root'
})
export class PricesService {

  private controllerName = 'Prices';

  constructor(private httpClient: HttpClient) { }
  
  getBySources(source: Source): Observable<PriceItem> {
    console.log(source);
    return this.httpClient.post<PriceItem>(environment.apiUrl + this.controllerName, source);
  }

}



