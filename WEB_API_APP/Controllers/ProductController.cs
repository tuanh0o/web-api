using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_API_APP.Models;

namespace WEB_API_APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public static List<Product> products = new List<Product>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var product = products.SingleOrDefault(p => p.ProductId == Guid.Parse(id));
                if (product == null)
                    return NotFound();
                return Ok(product);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPost]
        public IActionResult Create(ProductVM productVM)
        {
            var product = new Product
            {
                ProductId = Guid.NewGuid(),
                ProductName = productVM.ProductName,
                Price = productVM.Price
            };
            products.Add(product);
            return Ok(new
            {
                Success = true,
                Data = product
            });
        }

        [HttpPut("{id}")]
        public IActionResult Edit(string id, Product productEdit)
        {
            try
            {
                var product = products.SingleOrDefault(p => p.ProductId == Guid.Parse(id));
                if (product == null)
                    return NotFound();
                //update
                if(productEdit.ProductId.ToString() != id)
                {
                    return NotFound();
                }
                product.ProductName = productEdit.ProductName;
                product.Price = productEdit.Price;
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var product = products.SingleOrDefault(p => p.ProductId == Guid.Parse(id));
                if (product == null)
                    return NotFound();
                products.Remove(product);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
