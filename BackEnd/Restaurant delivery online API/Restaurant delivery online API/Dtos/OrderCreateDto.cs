using System.ComponentModel.DataAnnotations;

namespace Restaurant_delivery_online_API.Dtos
{
    public class OrderCreateDto

    {
        //here I put all Data Notation Which I need to Controls the all values I will get from the Api Body to fill an object from this Type
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        [Required(ErrorMessage = "Customer name is required.")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Customer Name must be between 10 and 200 characters.")]

        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Customer phone is required.")]
        [StringLength(20, ErrorMessage = "Customer phone length can't exceed 20 characters.")]
        public string CustomerPhone { get; set; }
        [Required(ErrorMessage = "Customer email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [StringLength(200, ErrorMessage = "Customer email length can't exceed 200 characters.")]
        public string CustomerEmail { get; set; }

        [Required(ErrorMessage = "Customer address is required.")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "Customer address must be between 10 and 200 characters.")]
        public string CustomerAddress { get; set; }
        [Required(ErrorMessage ="You must enter the order items")]
        public List<OrderItemDto>? Items { get; set; }// here the list of items which Customer choose from Menu and enter the quantity of each Item  

    }
}
