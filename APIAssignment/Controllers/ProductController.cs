using API.BLL.Manager.Abstraction;
using API.BLL.Manager.Implementation;
using API.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;

namespace APIAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager productManager;
        public ProductController(IProductManager _productManager)
        {
            productManager = _productManager;
        }
        //The first end point
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            productManager.AddProduct(product);
            return CreatedAtAction("GetProductById", new { id = product.Id }, product);
        }
        //5
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            
                Product product = productManager.GetById(id);
                if (product != null)
                {
                    return Ok(product);
                }
                else
                {
                    return NotFound("The product not exists");
                }
            
            
        }
        // The second end point
        [HttpPost("form")]
        public IActionResult AddPremetiveProduct( Product product)
        {


            productManager.AddProduct(product);
            return CreatedAtAction("GetProductById", new { id = product.Id }, product);


        }
        //the third end point
        [HttpPost("Upload")]
        public IActionResult AddProductUploadIMage(Product product)
        {
            
                if (product.formFile != null && product.formFile.Length > 0)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", product.formFile.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        product.formFile.CopyTo(stream);
                    }

                    product.ImageUrl = "/images/" + product.formFile.FileName;
                }
                productManager.AddProduct(product);
                return CreatedAtAction("GetProductById", new { id = product.Id }, product);

            
            

        }
        [HttpPost("query")]
        public IActionResult AdProductQuery([FromQuery]Product product)
        {
            

                productManager.AddProduct(product);
                return CreatedAtAction("GetProductById", new { id = product.Id }, product);


            
        }
    }
}
