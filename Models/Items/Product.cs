using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using OnlineFoodOrderingSystem.Models.Users.Provider;

namespace OnlineFoodOrderingSystem.Models.Items
{
    public class Product
    {

        [Key]
        public static long ProductID {get;set;}

        [Required]
        public string Name {get; set;}

        [Required]
        public string Description {get;set;}

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price {get;set;}

        public string ImageUrl {get; set;}
        public int ProviderID{get; set;}
        // [Required]
        // public Provider Provider {get; set;}

    }
}