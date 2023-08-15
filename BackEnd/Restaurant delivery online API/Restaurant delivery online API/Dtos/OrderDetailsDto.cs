namespace Restaurant_delivery_online_API.Dtos
{
    public class OrderDetailsDto
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerAddress { get; set; }
        public string RestaurantName { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderItemDetails>Items { get; set; }
    }
}
