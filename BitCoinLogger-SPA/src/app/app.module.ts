import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import {FormsModule} from '@angular/forms';
import { PaginationModule , BsDatepickerModule, ButtonsModule} from 'ngx-bootstrap';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { AuthService } from './services/auth.service';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';


import { AuthenticationInterceptorService } from './interceptors/authentication-interceptor';
import { AngularMaterialModule } from './angular-material/angular-material.module';
import { appRoutes } from './routes';
import { PricesComponent } from './prices/prices.component';
import { HistoryComponent } from './history/history.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HistoryResolver } from './resolvers/history.resolver';

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      HomeComponent,
      RegisterComponent,
      PricesComponent,
      HistoryComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      RouterModule.forRoot(appRoutes),
      BrowserAnimationsModule,
      AngularMaterialModule,
      PaginationModule.forRoot(),
      BsDatepickerModule.forRoot(),
      ButtonsModule.forRoot()
   ],
   providers: [
      AuthService,
      {
            provide: HTTP_INTERCEPTORS,
            useClass: AuthenticationInterceptorService,
            multi: true
      },
      HistoryResolver
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
