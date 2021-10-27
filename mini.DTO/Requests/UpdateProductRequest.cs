using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mini.DTO.Requests
{
   public class UpdateProductRequest
    {
        public int Id { get; set; }
        [Required]   
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
    }
}
