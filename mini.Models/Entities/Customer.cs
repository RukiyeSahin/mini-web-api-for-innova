using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mini.Models.Entities
{
   public class Customer : IEntity
    {      
        public Guid Id { get; set; }
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
