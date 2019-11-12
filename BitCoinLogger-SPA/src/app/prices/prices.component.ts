import { Component, OnInit } from '@angular/core';
import { SourcesService } from '../services/sources.service';
import { Source } from '../models/source';
import { PricesService } from '../services/prices.service';
import { PriceItem } from '../models/price-item';

@Component({
  selector: 'app-prices',
  templateUrl: './prices.component.html',
  styleUrls: ['./prices.component.css']
})

export class PricesComponent implements OnInit {
  model: any = {};
  allSources: Source[];
  priceItem: PriceItem;
  showDetails = false;

  constructor(private sourcesService: SourcesService, private pricesService: PricesService) { }

  ngOnInit() {
    this.sourcesService.get().subscribe((sources) => {
      this.allSources = sources;
    });
  }

  getBySources(model) {
    this.pricesService.getBySources(model).subscribe((priceItem) => {
      this.priceItem = priceItem;
      this.showDetails = true;
    });
  }

}






