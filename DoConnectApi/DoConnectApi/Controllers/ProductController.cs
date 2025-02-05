using DoConnectEntity;
using DoConnectService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoConnectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet ("GetProducts")]

        public IActionResult Get()
        {
            var result = _productService.GetProducts();
            return Ok(result);
        }
        [HttpPost ("Create")]

        public IActionResult AddProduct(Product product)
        {
            _productService.AddProduct(product);
            object result = "Product Added Succesfully...!";
            return Ok();
        }

        [HttpPut("Update")]
        public IActionResult UpdateProduct([FromBody] Product product, int id)
        {
            _productService.UpdateProduct(product);
            object result = "Product added successfully..";
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public IActionResult DeleteProduct(int id)
        {
            _productService.DeleteProduct(id);
            object result = "Product deleted successfully..";
            return Ok(result);
        }
    }
    public class Response
    {
        public object result { get; set; }
        public string statuscode { get; set; }
        public string message { get; set; }
    } 
}
