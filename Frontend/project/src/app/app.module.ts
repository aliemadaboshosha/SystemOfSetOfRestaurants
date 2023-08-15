import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { FormsModule } from '@angular/forms';

import { DetailsCityComponent } from './components/Restaurant/details-city/details-city.component';
import { RestaurantMenuComponent } from './components/Restaurant/restaurant-menu/restaurant-menu.component';
import { RestaurantService } from './services/Restaurant.service';
import { MakeOrderComponent } from './components/Restaurant/make-order/make-order.component';
import { ShowOrderComponent } from './components/Restaurant/show-order/show-order.component';

@NgModule({
  declarations: [
 AppComponent,
    DetailsCityComponent,
    RestaurantMenuComponent,
    MakeOrderComponent,
    ShowOrderComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    RouterModule
  ],
  providers: [],
  bootstrap: [AppComponent]
  
})
export class AppModule { }
