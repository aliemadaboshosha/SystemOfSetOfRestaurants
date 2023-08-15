using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant_delivery_online_API.Dtos;
using Restaurant_delivery_online_API.Models;

namespace Restaurant_delivery_online_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        RestaurantDelivery_dbContext dbContext;
        public MenuItemController(RestaurantDelivery_dbContext _DbContext)
        {
            this.dbContext = _DbContext;
        }


        #region Here I Return the MenuItems for one Restaurant By its Id , in a list form from type"MenuItemDto" to avoid the Circular Error 

        [HttpGet("{RestaurantId:int}")]
        public ActionResult<List<MenuItemDto>> GetRestaurantMenu(int RestaurantId)
        {
            var Menu=dbContext.MenuItems.Where(Item=>Item.RestaurantId==RestaurantId).ToList();
            if (Menu.Any())
            {
                List<MenuItemDto> result = new List<MenuItemDto>();
                foreach (var item in Menu)
                {
                    MenuItemDto itemDto = new MenuItemDto() { MenuItemId=item.MenuItemId,Name=item.Name,Price=item.Price,Image=item.Image};
                    
                    result.Add(itemDto);

                }
                return Ok(result);
            }
            else { return NotFound(); }
        }
        #endregion
    }
}
