using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using netCoreAPI.Services;

namespace netCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly TodoContext _context;

        public ProductController(TodoContext context)
        {
            _context = context;
        }

        // GetAll() is automatically recognized as
        // http://localhost:<port #>/api/todo
        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        // GetById() is automatically recognized as
        // http://localhost:<port #>/api/todo/{id}

        // For example:
        // http://localhost:<port #>/api/todo/1

        [HttpGet("{id}", Name = "GetProject")]
        public IActionResult GetById(long id)
        {
            var item = _context.Products.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
        /// <summary>
        /// Creates a ProductItem.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Product
        ///     {
        ///        "title": "Item1",
        ///        "createdOn": "2020-01-01T00:00:00.0000001"
        ///     }
        /// </remarks> 
        /// <param name="product"></param>
        /// <returns>A newly created Product Item</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">The item is not saved</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody]Product product)
        {
            if (product.Title == null || product.Title == "")
            {
                return BadRequest();
            }
            _context.Products.Add(product);
            _context.SaveChanges();
            return CreatedAtRoute("GetById", new { id = product.Id }, product);

        }
        [HttpPut]
        [Route("MyEdit")] // Custom route
        public IActionResult GetByParams([FromBody]Product product)
        {
            var item = _context.Products.Where(t => t.Id == product.Id).FirstOrDefault();
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                item.Title = product.Title;
                _context.SaveChanges();
            }
            return new ObjectResult(item);
        }
        /// <summary>
        /// Deletes a specific Project.
        /// </summary> 
        /// <param name="id"></param>
        [HttpDelete]
        [Route("MyDelete")] // Custom route

        public IActionResult MyDelete(long Id)
        {
            var item = _context.Products.Where(t => t.Id == Id).FirstOrDefault();
            if (item == null)
            {
                return NotFound();
            }
            _context.Products.Remove(item);
            _context.SaveChanges();
            return new ObjectResult(item);
        }

    }
}