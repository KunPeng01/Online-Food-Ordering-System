using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace OnlineFoodOrderingSystem.Models
{
    public class CheckoutModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string DeliveryMethod { get; set; } // Delivery or Pickup

        [Required]
        [Display(Name = "Card Number")]
        [CreditCard]
        public string CardNumber { get; set; }

        [Required]
        [Display(Name = "Expiration Date")]
        public string ExpirationDate { get; set; }

        [Required]
        [Display(Name = "CVV")]
        public string Cvv { get; set; }
    }
}