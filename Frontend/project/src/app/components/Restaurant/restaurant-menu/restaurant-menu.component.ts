import {  Component, OnInit,Input, Output, EventEmitter } from '@angular/core';
import { tick } from '@angular/core/testing';
import { ActivatedRoute, Router } from '@angular/router';
import { MenuItem } from 'src/app/models/Menu/Menu.model';
import { Restaurant } from 'src/app/models/Restaurant/Restaurant.model';
import { RestaurantService } from 'src/app/services/Restaurant.service';

@Component({
  selector: 'app-restaurant-menu',
  templateUrl: './restaurant-menu.component.html',
  styleUrls: ['./restaurant-menu.component.css']
})
export class RestaurantMenuComponent implements OnInit{

  @Output() dataEvent=new EventEmitter<MenuItem[]>();

DetailsRestaurant:Restaurant={
  restaurantId:0,
  name:"",
  address:"",
  phone:"", 
  image:""
}


getData(data:Restaurant){
  this.DetailsRestaurant=data;
console.log(data)}




  Menu:MenuItem[]=[]
  SelectedMenuItems:MenuItem[]=[];
  
  @Output() menuItemsSelected = new EventEmitter<any>();
  constructor(private RestaurantService:RestaurantService,private router:Router,private route:ActivatedRoute){}
  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next:(params)=>{
        const Restaurant_id=Number(params.get("Restaurant_id"));
        const name=params.get("RestaurantName");
        const phone=params.get("RestaurantPhone");
        const address=params.get("RestaurantAddress")
        

       
        if  (Restaurant_id&&name&&phone&&address){
          this.DetailsRestaurant.name=name;
          this.DetailsRestaurant.address=address;
          
          this.DetailsRestaurant.restaurantId=Restaurant_id;
          this.DetailsRestaurant.phone=phone

          this.RestaurantService.GetRestaurantMenu(Restaurant_id).subscribe(
            {
              next:(response:MenuItem[])=>{this.Menu=response
             }
              ,
              error:(response:any)=>{console.log(response)}
            }
          );
          // this.RestaurantService.
        }
      }
    });
    

  }

 createorder(arr:any){
  this.SelectedMenuItems=[];
  let meals=document.querySelectorAll("input");
for (let index = 0; index < meals.length; index++) {
  if(meals[index].checked){
let selecteditem;
    for (let index2 = 0; index2 < this.Menu.length; index2++) {
      
      if(this.Menu[index2].menuItemId==Number(meals[index].value)){
        selecteditem=this.Menu[index2]
      }
    }
    if(selecteditem){
    // this.SelectedMenuItems[index]=selecteditem;
  this.SelectedMenuItems.push(selecteditem)}
   
  }
  
}

this.RestaurantService.setData(this.SelectedMenuItems);
console.log(this.RestaurantService.getData());
}
// sendData(){
//   this.RestaurantService.setData(this.SelectedMenuItems)
//   console.log(this.SelectedMenuItems)
//   }
  
FinishChoose(){
  this.router.navigate(['/MakeOrder', this.DetailsRestaurant.restaurantId]);}

}