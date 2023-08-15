using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant_delivery_online_API.Dtos;
using Restaurant_delivery_online_API.Models;

namespace Restaurant_delivery_online_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        RestaurantDelivery_dbContext dbContext;
        public RestaurantController(RestaurantDelivery_dbContext _DbContext)
        {
            this.dbContext = _DbContext;
        }



        #region Here I get all Restaurant of all Cities which I have in the DataBase And Resturn them in a list of type"RestaurantDto" to avoid the Circular Error
        [HttpGet]
        public ActionResult<List<RestaurantDto>> GetAll()
        {
            var Resturantslist = dbContext.Restaurants.ToList();
            if (Resturantslist.Any())
            {
                List<RestaurantDto> result = new List<RestaurantDto>();
                foreach (var item in Resturantslist)
                {
                    var temp = new RestaurantDto()
                    { 
                        RestaurantId=item.RestaurantId,
                        Name=item.Name,
                        Address=item.Address,
                        Phone=item.Phone
                    };
                    
                    result.Add(temp);
                }
                return Ok(result);

                
            }
            else
            {
                return NotFound();
            }
        }


        #endregion






        #region Here I Get all Restaurants of one City by --CityId-- which I Get It from the Head of Request ... and I Return them in a list of Type "RestaurantDto" to avoid the Circular Error 

        [HttpGet("CityRestaurants/{CityId:int}")]//here I modify the Url to match the role of the EndPoint which it will return all Restaurants for one City So add the section "CityRestaurants/" in the Url 
        public ActionResult<List<RestaurantDto>>GetResturantsByCityId(int CityId)
        {
            var resturantslist = dbContext.Restaurants.Where(R=>R.CityId== CityId);
            if (resturantslist.Any())
            {
                List<RestaurantDto> result = new List<RestaurantDto>();
                foreach (var item in resturantslist)
                {
                    RestaurantDto temp = new RestaurantDto() 
                    { 
                        Address=item.Address,
                        Name=item.Name,
                        RestaurantId=item.RestaurantId,
                        Phone=item.Phone
                    };

                    result.Add(temp);
                    
                }

                return Ok(result);


               


            }
            else {
                return NotFound();

            }
        }

        #endregion






        #region Here I Get one Restaurant Data by Its ID and Return it in new Type form"RestaurantDto" to prevent  the Circular Error

        [HttpGet("{RestaurantId:int}")]//here I get the Id of Restaurant which I need to Return Its Data , this Id I get it from the Request Header.
        public ActionResult<RestaurantDto>GetRestaurant(int RestaurantId)
        {
            if (RestaurantId==null)
            {
                return BadRequest();
            }
            else
            {
                var restaurant = dbContext.Restaurants.FirstOrDefault(R => R.RestaurantId == RestaurantId);
                if (restaurant==null)
                {
                    return NotFound();

                }
                else {

                    RestaurantDto result = new RestaurantDto() 
                    { 
                        Address = restaurant.Address,
                        Name = restaurant.Name,
                        RestaurantId = restaurant.RestaurantId,
                        Phone = restaurant.Phone,
                        Image=restaurant.Image 
                    };
                    return Ok(result);
                }
            }
        }



        #endregion



    }


}
