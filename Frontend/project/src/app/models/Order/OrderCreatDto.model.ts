import { OrderItem } from "./OrderItem.model";

export interface OrderCreatDto{
    orderId:number;
    customerName:string;
    customerPhone:string;
    customerEmail:string;
    customerAddress:string;
    orderDate  :string;
    items:OrderItem[];
}