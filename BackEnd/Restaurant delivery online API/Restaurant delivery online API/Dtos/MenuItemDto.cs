namespace Restaurant_delivery_online_API.Dtos
{
    public class MenuItemDto
    {
        public int MenuItemId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }
        //here there is no navigation Property like(the virtual property from type ICollection<OrderItem> "OrderItems" or Restaurant "Restaurant" ) To avoide the Circular Error


    }
}
