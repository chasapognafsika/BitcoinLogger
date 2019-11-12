import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { PriceItem } from '../models/price-item';
import { HistoryService } from '../services/history.service';

@Injectable()
export class HistoryResolver implements Resolve<PriceItem[]> {
    pageNumber = 1;
    pageSize = 5;

    constructor(private historyService: HistoryService, private router: Router) { }

    resolve(route: ActivatedRouteSnapshot): PriceItem[] | Observable<PriceItem[]> | Promise<PriceItem[]> {
        return this.historyService.getHistoryItems(this.pageNumber, this.pageSize).pipe(
            catchError(error => {
                this.router.navigate(['/home']);
                return of(null);
            })
        );
    }
}
