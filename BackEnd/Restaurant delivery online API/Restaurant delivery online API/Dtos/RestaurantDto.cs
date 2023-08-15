namespace Restaurant_delivery_online_API.Dtos
{
    public class RestaurantDto
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }
        public string Phone { get; set; }

        public string Image { get; set; }


        //here there is no navigation Property like(the virtual property from type ICollection<Order> "Orders" ,  ICollection<MenuItem> "MenuItems" or City "City") To avoide the Circular Error

    }
}
