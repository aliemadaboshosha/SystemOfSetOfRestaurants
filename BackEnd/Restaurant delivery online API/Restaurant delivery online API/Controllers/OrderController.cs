using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant_delivery_online_API.Dtos;
using Restaurant_delivery_online_API.Models;

namespace Restaurant_delivery_online_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        RestaurantDelivery_dbContext dbContext;
        public OrderController(RestaurantDelivery_dbContext _DbContext)
        {

            this.dbContext = _DbContext;    
        }


        #region Get All Orders of all Restaurants 

        [HttpGet]
        public ActionResult<OrderDto> GetAll()
        {
            var orders = dbContext.Orders.ToList();
            if (orders.Any())
            {
                List<OrderDto> result = new List<OrderDto>();
                foreach (var item in orders)
                {
                    string restaurantName = dbContext.Restaurants.FirstOrDefault(R => R.RestaurantId == item.RestaurantId).Name;
                    if (restaurantName==null)
                    {
                        return BadRequest();
                    }
                    OrderDto order = new OrderDto()
                    {
                        OrderId = item.OrderId,
                        Restaurant = restaurantName,
                        OrderDate = item.OrderDate,
                        CustomerPhone = item.CustomerPhone,
                        CustomerAddress = item.CustomerAddress,
                        CustomerEmail = item.CustomerEmail,
                        CustomerName = item.CustomerName
                    };
                    result.Add(order);

                }
                return Ok(result);

            }
            else { return NotFound(); }
           
        }
        #endregion



        #region Get all orders for one Restaurant by Restaurant_ID


        [HttpGet("RestaurantOrders/{RestaurantId:int}")]
        public ActionResult<OrderDto> GetAllRestaurantsOrders(int RestaurantId)
        {
            var orders = dbContext.Orders.Where(O=>O.RestaurantId==RestaurantId).ToList();
            if (orders.Any())
            {
                string restaurantName = dbContext.Restaurants.FirstOrDefault(R => R.RestaurantId == RestaurantId).Name;

                List<OrderDto> result = new List<OrderDto>();
                foreach (var item in orders)
                {
                    OrderDto order = new OrderDto()
                    {
                        OrderId = item.OrderId,
                        Restaurant = restaurantName,
                        OrderDate = item.OrderDate,
                        CustomerPhone = item.CustomerPhone,
                        CustomerAddress = item.CustomerAddress,
                        CustomerEmail = item.CustomerEmail,
                        CustomerName = item.CustomerName
                    };
                    result.Add(order);

                }
                return Ok(result);

            }
            else { return NotFound(); }

        }



        #endregion




        #region Get One Order Details by Its ID

        [HttpGet("{OrderId:int}")]
        public ActionResult<OrderDetailsDto> GetOrder(int OrderId)
        {
            var order = dbContext.Orders.Include(o => o.OrderItems).ThenInclude(o => o.MenuItem).FirstOrDefault(O => O.OrderId == OrderId);
            if (order == null)
            {
                return NotFound();
            }
            else
            {
                string restaurantName = dbContext.Restaurants.FirstOrDefault(R => R.RestaurantId == order.RestaurantId).Name;
                OrderDetailsDto returnedOrder=new OrderDetailsDto() {
                    OrderId = order.OrderId,
                    CustomerAddress = order.CustomerAddress,
                    CustomerEmail=order.CustomerEmail,
                    CustomerName=order.CustomerName,
                    OrderDate=order.OrderDate,
                    RestaurantName=restaurantName,
                    CustomerPhone=order.CustomerPhone
                    
                };
                List<OrderItemDetails> orderItemsDetails=new List<OrderItemDetails>();  
                foreach(var item in order.OrderItems)
                {
                    var itemDetails=new OrderItemDetails();
                    itemDetails.Quantity = item.Quantity;
                    itemDetails.Name = dbContext.MenuItems.FirstOrDefault(I => I.MenuItemId == item.MenuItemId).Name;
                    itemDetails.Price = dbContext.MenuItems.FirstOrDefault(I => I.MenuItemId == item.MenuItemId).Price;
                    returnedOrder.TotalPrice += itemDetails.Price*itemDetails.Quantity;
                    orderItemsDetails.Add(itemDetails);
                }
                returnedOrder.Items=orderItemsDetails;
                return Ok(returnedOrder);
            }
            

        }
        #endregion




        #region create a new Order in a Restaurant by Order Data and Restaurant_ID to match the order item from that Restaurant

        [HttpPost("{RestaurantId:int}")]
        public ActionResult creat(int RestaurantId , OrderCreateDto order)// here I get the RestaurantId from Request Head and The Object Order which I will save it in the dataBase from Request body
        {
            if (ModelState.IsValid)// here I check the Validation of the all Properties in Type "OrderCreatDto" of object order
            {
                try
                {
                    #region Here I set the data which I get from the Api body and fill an object from Type"Order" to save it in the DataBase so I can use its Id to save the OrderItems in Its Table


                    Order storageOrder =new Order() 
                    {
                        RestaurantId=RestaurantId,
                        OrderDate=order.OrderDate,
                        CustomerAddress=order.CustomerAddress,
                        CustomerEmail=order.CustomerEmail,
                        CustomerName=order.CustomerName,
                        CustomerPhone=order.CustomerPhone
                    };
               
                dbContext.Orders.Add(storageOrder);
                dbContext.SaveChanges();


                    #endregion




                    #region Here I loop on the List of Items I get from the object from Request Body and set each item and its data in the DataBase after putting it in the suitable Form


                    foreach (var item in order.Items)
                    {
                      OrderItem orderItem = new OrderItem()
                      { 
                        MenuItemId=item.MenuItemId,
                        Quantity=item.Quantity,
                        OrderId=storageOrder.OrderId
                      };
                    
                    dbContext.OrderItems.Add(orderItem);
                    dbContext.SaveChanges();




                    }
                    #endregion

                    order.OrderId = storageOrder.OrderId;
                    

                    

                    return Created ("url", order);
                }
                catch(Exception e) 
                {
                    return BadRequest(e.Message);
                }

                    
               

            }
            else { return BadRequest(); }
        }


        #endregion




        #region Delete an order by its Id 
        [HttpDelete("{orderId:int}")]
        public ActionResult DeleteOrder(int orderId)
        {
            if (orderId==null)
            {
                return BadRequest();

            }
            else
            {
                var order = dbContext.Orders.Find(orderId);
                if (order == null)
                {
                    return NotFound();
                }
                else 
                { 
                    dbContext.Orders.Remove(order);
                    dbContext.SaveChanges();
                    return NoContent();
                }
            }
        }

        #endregion

    }
}
