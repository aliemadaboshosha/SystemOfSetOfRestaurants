import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DetailsCityComponent } from './components/Restaurant/details-city/details-city.component';
import { RestaurantMenuComponent } from './components/Restaurant/restaurant-menu/restaurant-menu.component';
import { MakeOrderComponent } from './components/Restaurant/make-order/make-order.component';
import { ShowOrderComponent } from './components/Restaurant/show-order/show-order.component';


const routes: Routes = [
  { path: '',
   component:DetailsCityComponent },

   
   {path:'home',
    component:DetailsCityComponent},

   {path:"Restaurant/Menu/:Restaurant_id/:RestaurantName/:RestaurantAddress/:RestaurantPhone",
   component:RestaurantMenuComponent},
   
   
{path:"MakeOrder/:Restaurant_id",
component:MakeOrderComponent}, 

 {path:"Order/:Order_id",
 component:ShowOrderComponent}

  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
