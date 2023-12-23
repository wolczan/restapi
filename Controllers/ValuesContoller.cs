using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using RestApi.Models;
using MovieManagement.Api.Models;

namespace MovieManagement.Api.Controllers
{

    [ApiController]
    [Route("api/values")]
    public class ValuesController : ControllerBase
    {
        // GET: api/products
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type=typeof(ErrorModel))]
        public async Task<ActionResult<List<string>>> getAsync()

        {
            return await Task.FromResult(new List<string>());
        }
        [HttpGet("products")]
        public IEnumerable<Product> GetProducts()
        {
            // Pobierz wszystkie produkty
            return new List<Product>();
        }

        // GET: api/products/5
        [HttpGet("{id}")]
        public Product? GetProduct(int id)
        {
            // Pobierz produkt o danym ID
            return null;
        }

        // POST: api/products
        [HttpPost]
        public void Post([FromBody] Product product)
        {
            // Dodaj nowy produkt
        }

        // ... inne metody dla PUT, DELETE itp.
    }
}