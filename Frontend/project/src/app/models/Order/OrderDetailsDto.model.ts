import { OrderItemDetails } from "./OrderItemDetails.model";

export interface OrderDetails{
    orderId:number;
    orderDate  :string;
    customerName:string;
    customerPhone:string;
    customerEmail:string;
    customerAddress:string;
    restaurantName:string;
    items:OrderItemDetails[];
    totalPrice:number;
}