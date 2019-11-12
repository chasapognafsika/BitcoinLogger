// import { Component, OnInit } from '@angular/core';
// import { PriceItem } from '../models/price-item';
// import { HistoryService } from '../services/history.service';

// @Component({
//   selector: 'app-history',
//   templateUrl: './history.component.html',
//   styleUrls: ['./history.component.css']
// })
// export class HistoryComponent implements OnInit {
//   allHistoryPriceItems: PriceItem[];

//   displayedColumns: string[] = ['source', 'price', 'timestamp'];

//   constructor(private historyService: HistoryService) { }

//   ngOnInit() {
//     this.historyService.get().subscribe((historyPriceItems) => {
//       this.allHistoryPriceItems = historyPriceItems;
//       console.log('ti fernei to history', historyPriceItems);
//     });
//   }
// }

import { PaginatedResult } from '../models/Pagination';
import { ActivatedRoute } from '@angular/router';
import { HistoryService } from '../services/history.service';
import { Component, OnInit } from '@angular/core';
import { Pagination } from '../models/Pagination';
import { PriceItem } from '../models/price-item';
import { SourcesService } from '../services/sources.service';
import { Source } from '../models/source';

@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.css']
})

export class HistoryComponent implements OnInit {
  allHistoryPriceItems: PriceItem[];
  allSources: Source[];
  historyItemParams: any = {};
  pagination: Pagination;
  selectedSource: Source;


  constructor(private sourcesService: SourcesService, private historyService: HistoryService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.allHistoryPriceItems = data.allHistoryPriceItems.result;
      this.pagination = data.allHistoryPriceItems.pagination;
    });

    this.sourcesService.get().subscribe((sources) => {
      this.allSources = sources;
    });

    this.historyItemParams.sourceId = 0;
    this.historyItemParams.fromDate = null;
    this.historyItemParams.toDate = null;
    this.historyItemParams.orderBy = 'timestamp';
  }

  pageChanged(event: any): void {
    this.pagination.currentPage = event.page;
    this.loadHistoryItems();
  }

  resetFilters() {
    this.historyItemParams.sourceId = 0;
    this.historyItemParams.fromDate = null;
    this.historyItemParams.toDate = null;
    this.historyItemParams.orderBy = 'timestamp';
    this.loadHistoryItems();
  }

  loadHistoryItems() {
    this.historyService.getHistoryItems(this.pagination.currentPage, this.pagination.itemsPerPage, this.historyItemParams)
      .subscribe((res: PaginatedResult<PriceItem[]>) => {
        this.allHistoryPriceItems = res.result;
        this.pagination = res.pagination;
      });
  }

  filterBySource(filterVal: any) {
    if (filterVal !== 0) {
      this.historyItemParams.sourceId = filterVal;
    }
  }

}


