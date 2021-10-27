using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mini.DTO.Responses
{
   public class ProductSimpleUpdateResponse
    {
        public int Id { get; set; }      
        public string Name { get; set; }       
        public double Price { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
