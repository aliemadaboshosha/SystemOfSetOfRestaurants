using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant_delivery_online_API.Dtos;
using Restaurant_delivery_online_API.Models;

namespace Restaurant_delivery_online_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        RestaurantDelivery_dbContext dbContext;
        public CityController( RestaurantDelivery_dbContext _DbContext)
        {
            this.dbContext = _DbContext;
        }

        #region Here I get all Cities from Database to use it in drop down list to filter the Restaurant , I will show depende on the value of City Id 
        [HttpGet]
        public ActionResult<List<CityDto>> GetAll()
        {
            var cityList = dbContext.Cities.ToList();
            
            if (cityList == null)
            {
                return NotFound();
            }
            else {
                List<CityDto> result = new List<CityDto>();
                foreach (var city in cityList)
                {
                    var temp = new CityDto();
                    temp.Name = city.Name;
                    temp.CityId = city.CityId;
                    result.Add(temp);


                }

                return Ok(result); }

        }
        #endregion


    }
}
