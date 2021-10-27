using AutoMapper;
using mini.Data.Repositories;
using mini.DTO.Requests;
using mini.DTO.Responses;
using mini.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mini.Services.Business
{
    public class ProductService : IProductService
    {
        private IProductRepository repository;
        private IMapper mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<bool> IsProductExist(int id)
        {
            return await repository.IsItemExists(id);
        }

        public async Task<ProductSimpleUpdateResponse> UpdateProduct(UpdateProductRequest request)
        {
            var product = mapper.Map<Product>(request);
            var updatedProduct = await repository.Update(product);
            var response = mapper.Map<ProductSimpleUpdateResponse>(updatedProduct);
            return response;
        }
    }
}
