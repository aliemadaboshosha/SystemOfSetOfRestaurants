import { Component, OnInit,Input, Output, EventEmitter } from '@angular/core';
import { ActivatedRoute, Data, Router } from '@angular/router';

import { city } from 'src/app/models/City/city.model';
import { Restaurant } from 'src/app/models/Restaurant/Restaurant.model';
import { RestaurantService } from 'src/app/services/Restaurant.service';

@Component({
  selector: 'app-details-city',
  templateUrl: './details-city.component.html',
  styleUrls: ['./details-city.component.css']
})
export class DetailsCityComponent implements OnInit{
  @Output() dataEvent=new EventEmitter<Restaurant>();
  Restaurant:Restaurant={
    restaurantId:0,
    name:"",
    address:"",
    phone:"", 
    image:""
  }
Restaurants:Restaurant[]=[];
  cities:city[]=[];
  CityID:number=0;
  constructor(private CityService:RestaurantService,private router:Router){}
  
  ngOnInit(): void {
this.CityService.getAllCities().subscribe({
  next:( Cities:city[])=>{this.cities=Cities
  },
  error:(response:any)=>{console.log(response)}
});
this.CityService.getAllRestaurant().subscribe({
  
  next:(Restaurants:Restaurant[])=>{this.Restaurants=Restaurants
  },
  error:(response:any)=>{console.log(response)}
});


  }
  list:any=document.querySelector("select")?.value;

  ShoW(id:number){
    if (id==0) {
      this.CityService.getAllRestaurant().subscribe({
  
        next:(Restaurants:Restaurant[])=>{this.Restaurants=Restaurants
        },
        error:(response:any)=>{console.log(response)}
      });
      
    }
    
this.CityID=id;
 this.CityService.GetCityRestaurant(id).subscribe({
  next:(Restaurants:Restaurant[])=>{this.Restaurants=Restaurants
    },
    error:(response:any)=>{console.log(response)}
 })
    
  }
  // key:string='';
  Search(searchValue:string){
    // console.log(this.key)
    console.log(searchValue)
    let resultArray=[];
    if(searchValue){
    for (let index = 0; index < this.Restaurants.length; index++) {
    if ((this.Restaurants[index].name.toUpperCase().split(searchValue.toUpperCase().trim()).length)>1){
      resultArray.push(this.Restaurants[index]);

    }
    }
    if(resultArray.length){
    this.Restaurants=resultArray;
  }
  else{
    this.CityService.GetCityRestaurant(this.CityID).subscribe({
      next:(Restaurants:Restaurant[])=>{this.Restaurants=Restaurants
        },
        error:(response:any)=>{console.log(response)}
     })
  }
}
else{
  this.CityService.GetCityRestaurant(this.CityID).subscribe({
    next:(Restaurants:Restaurant[])=>{this.Restaurants=Restaurants
      },
      error:(response:any)=>{console.log(response)}
   })
}
  

  }
  emitData(Restaurant:Restaurant){
    this.dataEvent.emit(Restaurant);
    console.log(Restaurant)
    this.Restaurant=Restaurant
    
  }
  

}
