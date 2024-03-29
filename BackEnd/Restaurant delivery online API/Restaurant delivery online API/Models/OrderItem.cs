﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Restaurant_delivery_online_API.Models
{
    public partial class OrderItem
    {
        [Key]
        public int OrderId { get; set; }
        [Key]
        public int MenuItemId { get; set; }

        [Range(1, 100, ErrorMessage = "Quantity must be a positive value.")]
        public int Quantity { get; set; }

        [ForeignKey("MenuItemId")]
        [InverseProperty("OrderItems")]
        public virtual MenuItem MenuItem { get; set; }
        [ForeignKey("OrderId")]
        [InverseProperty("OrderItems")]
        public virtual Order Order { get; set; }
    }
}