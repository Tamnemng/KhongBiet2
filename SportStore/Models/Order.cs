﻿using System.ComponentModel.DataAnnotations;

namespace SportStore.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        
        public ICollection<CartLine> Lines { get; set; } = new List<CartLine>();
        
        [Required(ErrorMessage = "Please enter your name")]
        public string? Name { get; set; }
        
        [Required(ErrorMessage = "Please enter the first address line")]
        public string? Line1 { get; set; }
        
        public string? Line2 { get; set; }
        
        public string? Line3 { get; set; }
        
        [Required(ErrorMessage = "Please enter a city name")]
        public string? City { get; set; }
        
        [Required(ErrorMessage = "Please enter a state")]
        public string? State { get; set; }
        
        public string? Zip { get; set; }
        
        [Required(ErrorMessage = "Please enter a country name")]
        public string? Country { get; set; }
        
        public bool GiftWrap { get; set; }
    }
}