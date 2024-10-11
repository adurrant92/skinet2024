using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IGenericRepository<Product> repo) : ControllerBase
    {
      

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(string? brand, 
        string? type, string? sort)
        {
            return Ok( await  repo.ListAllAsync());
        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await repo.GetByIdAsync(id);

            if (product == null) return NotFound();

            return product;

        }

        [HttpPost]

        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            repo.Add(product);
             
             if (await repo.SaveAllAsync())
             {
                return CreatedAtAction("GetProduct", new { id = product.Id }, product);
             }

             return BadRequest("Problem creating product");
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateProduct(int id, Product product)
        {
            if (product.Id != id || !ProductExists(id))
            return BadRequest("Can not update product aa");

            repo.Update(product);
            
            if(await repo.SaveAllAsync())
            {
                return NoContent();
            }

            return BadRequest("Problem updating product");
        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await repo.GetByIdAsync(id);
            if (product == null) return NotFound();
            repo.Remove(product);
                if(await repo.SaveAllAsync())
            {
                return NoContent();
            }

            return BadRequest("Problem Deleting product");
        }

        [HttpGet("brands")]

        public async Task<ActionResult<IReadOnlyList<string>>> GetBrands()
        {
           // return Ok(await repo.GetBrandsAsync());
           return Ok(); // to  later
        }

        [HttpGet("types")]

        public async Task<ActionResult<IReadOnlyList<string>>> GetTypes()
        {
            //return Ok(await repo.GetTypesAsync());
               return Ok(); // to  later
        }

        private bool ProductExists(int id)
        {
            return repo.Exists(id);
        }

        

    }
}