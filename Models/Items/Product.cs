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
        public long ProductID {get;set;}

        [Required]
        public string Name {get; set;}
        public string Description {get;set;}

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price {get;set;}

        //public int ProviderID{}
        [Required]
        public Provider Provider {get; set;}

    }
}