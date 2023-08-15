using System.ComponentModel.DataAnnotations;

namespace Restaurant_delivery_online_API.Dtos
{
    public class OrderItemDto
    {
        // here I set all Data Notation that allow me to control the all values will be entered to this properties for an object from this Type
        [Required]
        public int MenuItemId { get; set; } 
        [Range(1, 100, ErrorMessage = "Quantity must be a positive value.")]

        public int Quantity { get; set; }
    }
}
