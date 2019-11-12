import {Routes} from '@angular/router';
import { HomeComponent } from './home/home.component';
import { HistoryComponent } from './history/history.component';
import { PricesComponent } from './prices/prices.component';
import { HistoryResolver } from './resolvers/history.resolver';

export const appRoutes: Routes = [
    { path: 'home', component: HomeComponent},
    { path: 'prices', component: PricesComponent},
    { path: 'history', component: HistoryComponent, resolve: { allHistoryPriceItems: HistoryResolver }},
    { path: '**', redirectTo: 'home', pathMatch: 'full'}
];

