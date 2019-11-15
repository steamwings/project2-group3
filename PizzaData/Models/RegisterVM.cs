using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PizzaData.Models
{
    public class RegisterVM
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [MinLength(2)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [MinLength(2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
