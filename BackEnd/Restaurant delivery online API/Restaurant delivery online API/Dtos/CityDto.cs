namespace Restaurant_delivery_online_API.Dtos
{
    public class CityDto
    {
        public int CityId { get; set; }
        public string Name { get; set; }

        //here there is no navigation Property like(the virtual property from type ICollection<Restaurant> "Restaurants" ) To avoide the Circular Error
    }
}
