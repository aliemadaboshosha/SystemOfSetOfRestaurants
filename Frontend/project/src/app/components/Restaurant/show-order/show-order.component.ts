import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { OrderDetails } from 'src/app/models/Order/OrderDetailsDto.model';
import { RestaurantService } from 'src/app/services/Restaurant.service';
@Component({
  selector: 'app-show-order',
  templateUrl: './show-order.component.html',
  styleUrls: ['./show-order.component.css']
})
export class ShowOrderComponent implements OnInit {
  constructor(private RestaurantService:RestaurantService,private router:Router,private route:ActivatedRoute) {
    
  }
  Order:OrderDetails={ 
    orderId:0,
    orderDate  :'',
    customerName:'',
    customerPhone:'',
    customerEmail:'',
    customerAddress:'',
    restaurantName:'',
    items:[],
    totalPrice:0}
  ngOnInit(): void {
    this.route.paramMap.subscribe(
      params=>
      {
        this.RestaurantService.GetOrder(
        Number(params.get("Order_id"))
      ).subscribe({
        next:(order:OrderDetails)=>{this.Order=order;
        console.log(this.Order)}
        ,error:(r:any)=>{console.log(r);}

      });

    });
  }

  CancelOrder(){this.RestaurantService.DeleteOrder(this.Order.orderId).subscribe({
    next:(r)=>this.router.navigate(['/home']),
  })}
  finishOrder(){this.router.navigate(['/home'])}
}
