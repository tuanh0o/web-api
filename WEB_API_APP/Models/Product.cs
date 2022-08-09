using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_API_APP.Models
{
    public class ProductVM
    {
        public string ProductName { get; set; }

        public double Price { get; set; }

    }

    public class Product: ProductVM
    {
        public Guid ProductId { get; set; }
    }
}
