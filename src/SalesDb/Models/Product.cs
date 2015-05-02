using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalesDb.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}