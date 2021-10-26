using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mini.DTO.Requests
{
   public class AddCustomerRequest
    {

        public string Gender { get; set; }
        [Required]
        public string UserName { get; set; } = "none";
        [Required]
        public string Password { get; set; } = "none";
        [Required]

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
