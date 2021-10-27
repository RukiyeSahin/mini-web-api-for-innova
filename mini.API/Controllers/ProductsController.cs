using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mini.DTO.Requests;
using mini.DTO.Responses;
using mini.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mini.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
                
        }
        [HttpPut("{id}")]
        public async Task< IActionResult> UpdateProduct(int id, UpdateProductRequest request)
        {
            if (await productService.IsProductExist(id))
            {
                if (ModelState.IsValid)
                {
                    ProductSimpleUpdateResponse response = await productService.UpdateProduct(request);
                    return Ok(response);
                }
                return BadRequest(ModelState);
            }
            return NotFound();

        }
    }
}
