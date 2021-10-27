using Microsoft.AspNetCore.Mvc;
using mini.API.Models;
using mini.DTO.Responses;
using mini.Services.Business;
using RiskFirst.Hateoas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mini.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsHATEOASController : ControllerBase
    {
        ILinksService linksService;
        IProductService productService;

        public ProductsHATEOASController(ILinksService linksService, IProductService productService)
        {
            this.productService = productService;
            this.linksService = linksService;
        }
        [HttpGet(Name = nameof(Get))]
        public async Task <IActionResult> Get()
        {
            var items = new List<ProductSimpleUpdateResponse> {
                new ProductSimpleUpdateResponse { Id=1, Name="Fake Pro 1", Price=5, CategoryId=1},
                new ProductSimpleUpdateResponse { Id=2, Name="Fake Pro 2", Price=15, CategoryId=1},
                new ProductSimpleUpdateResponse { Id=3, Name="Fake Pro 3", Price=25, CategoryId=1},

            };

            var hateoasResults = new List<Models.ProductHateoasResponse>();

            foreach (var item in items)
            {
                var hateoasResult = new ProductHateoasResponse { Product = item };
                 await linksService.AddLinksAsync<ProductHateoasResponse>(hateoasResult);
                hateoasResults.Add(hateoasResult);
            }

            var result = new { results = hateoasResults };
            return Ok(result);
        }
     
    }
}
