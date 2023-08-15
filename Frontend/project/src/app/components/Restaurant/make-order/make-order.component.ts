import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'src/app/models/Menu/Menu.model';
import { RestaurantService } from 'src/app/services/Restaurant.service';
import { Router, ActivatedRoute } from '@angular/router';
import { OrderCreatDto } from 'src/app/models/Order/OrderCreatDto.model';
import { OrderItem } from 'src/app/models/Order/OrderItem.model';
import { Restaurant } from 'src/app/models/Restaurant/Restaurant.model';

@Component({
  selector: 'app-make-order',
  templateUrl: './make-order.component.html',
  styleUrls: ['./make-order.component.css']
})
export class MakeOrderComponent implements OnInit {
  order:OrderCreatDto={orderId:0,customerName:"",customerAddress:"",customerEmail:"",customerPhone:"",orderDate:"",items:[]};

  OrderItems:MenuItem[]=[]
  SelectedItem:OrderItem[]=[];
  temp:OrderItem=
  {menuItemId:0,
    quantity:0};
    Restaurant_id:number=0;
    Restaurant:Restaurant={restaurantId:0,name:"",address:"",phone:"",image:""}
    
  flag:boolean=true;


  constructor(private RestaurantService:RestaurantService,private router:Router,private route:ActivatedRoute){
    this.OrderItems=this.RestaurantService.getData();
  }
  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next:(params)=>{
        const Restaurant_id=params.get("Restaurant_id")
        if(Restaurant_id){
          this.Restaurant_id=Number(Restaurant_id);
        }
      }
    })
   
  }


  totalPrice:number=0
  finish(){ this.SelectedItem=[];
    console.log(this.OrderItems)
    let meals=document.querySelectorAll("input");
  
    for (let index = 0; index < meals.length; index++) {
      this.temp={menuItemId:0,quantity:0};
     this.temp.menuItemId=this.OrderItems[index].menuItemId
      //  this.temp.menuItemId=this.OrderItems[index].menuItemId;
      console.log(meals[index].value);
this.temp.quantity=Number(meals[index].value);
      //  this.temp.quantity=Number(meals[index].value);
      if(this.temp.quantity>0){this.SelectedItem.push(this.temp);}
      
       

      
      this.totalPrice+=(this.OrderItems[index].price*this.temp.quantity);
      // this.items.push(this.temp);
      console.log(this.totalPrice);
      console.log(this.order);
      
     
      
    }
    this.order.items=this.SelectedItem;
this.RestaurantService.FinishOrder(this.Restaurant_id,this.order).subscribe({
next:(response:any)=>{console.log(response);
  this.router.navigate(['/Order',response.orderId])}

})

}


  submitOrder(){ this.flag=false;}
  onCancel(){this.flag=true;}
  BackToMenu(){
    this.RestaurantService.GetRestaurantById(this.Restaurant_id).subscribe({
      next:(response)=>{this.Restaurant=response;
        console.log(this.Restaurant);
        this.router.navigate(['/Restaurant','Menu',this.Restaurant_id,this.Restaurant.name,this.Restaurant.address,this.Restaurant.phone])
      }})
      
  console.log(this.Restaurant_id);}


}
