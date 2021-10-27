using mini.DTO.Requests;
using mini.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mini.Services.Business
{
   public interface IProductService
    {
        Task<bool> IsProductExist(int id);
        Task<ProductSimpleUpdateResponse> UpdateProduct(UpdateProductRequest request);
    }
}
