using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database;
using ValueTypes.Entity;
using ProductService;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductBusiness _business;

        public ProductController(IProductBusiness business)
        {
            _business = business;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            return await _business.GetProducts();
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var products = await _business.GetProductById(id);

            if (products == null)
            {
                return NotFound();
            }

            return products;
        }

        // PUT: api/Product/edit/5
        [HttpPut("edit/{id}")]
        public ActionResult<IEnumerable<string>> EditProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            var newProduct = _business.Update(product);
            return new OkObjectResult(newProduct);

        }

        // POST: api/Product/add
        [HttpPost("add")]
        public ActionResult<Product> AddProduct(Product product)
        {
            var newProduct = _business.Insert(product);

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Product/delete/5
        [HttpDelete("delete/{id}")]
        public ActionResult<Product> DeleteProduct(int id)
        {
            var product = _business.Delete(id);

            return new OkObjectResult(product);
        }

    }
}
