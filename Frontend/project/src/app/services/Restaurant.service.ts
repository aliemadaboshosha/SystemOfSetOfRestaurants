import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs/internal/Observable';
import { city } from '../models/City/city.model';
import { Restaurant } from '../models/Restaurant/Restaurant.model';
import { MenuItem } from '../models/Menu/Menu.model';
import { Order } from '../models/Order/Order.model';
import { OrderItem } from '../models/Order/OrderItem.model';
import { OrderCreatDto } from '../models/Order/OrderCreatDto.model';
import { OrderDetails } from '../models/Order/OrderDetailsDto.model';
@Injectable({
    providedIn: 'root'
  })
  export class RestaurantService{
    private order:any;
    setOrder(order:any){
      this.order=order
    }

    getOrder():any{
      return this.order
    }
    private data:any;
    setData(data:any){
      this.data=data
    }
    getData(): any {
      return this.data;
    }

    constructor(private http: HttpClient){}

    getAllCities():Observable<city[]>{
        return this.http.get<city[]>("http://localhost:5027/api/City")
     
       }

      getAllRestaurant():Observable<Restaurant[]>{
        return this.http.get<Restaurant[]>("http://localhost:5027/api/Restaurant")
      } 

      GetCityRestaurant(City_id:number):Observable<Restaurant[]>{
        return this.http.get<Restaurant[]>("http://localhost:5027/api/Restaurant/CityRestaurants/"+City_id)
      } 
      GetRestaurantById(Restaurant_id:number):Observable<Restaurant>{
        return this.http.get<Restaurant>("http://localhost:5027/api/Restaurant/"+Restaurant_id)
      }
      GetRestaurantMenu(Restaurant_id:any):Observable<MenuItem[]>{
        return this.http.get<MenuItem[]>("http://localhost:5027/api/MenuItem/"+Restaurant_id)

      }
      GetRestaurant(Restaurant_id:string):Observable<MenuItem[]>{
        return this.http.get<MenuItem[]>("http://localhost:5027/api/MenuItem/"+Restaurant_id)

      }
      GetOrder(Order_id:number):Observable<OrderDetails>{
        return this.http.get<OrderDetails>("http://localhost:5027/api/Order/"+Order_id)
      }
      
      FinishOrder(Restaurant_id:number,order:OrderCreatDto):Observable<OrderCreatDto>{
        return this.http.post<OrderCreatDto>("http://localhost:5027/api/Order/"+Restaurant_id,order)
      }

      DeleteOrder(Order_id:number):Observable<Order>{
        return this.http.delete<Order>("http://localhost:5027/api/Order/"+Order_id)
      }
  }