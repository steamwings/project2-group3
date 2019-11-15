using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaData.Models
{
    public partial class Customers
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "char(32)")] // 256 bit
        public string PasswordHash { get; set; }
        [Required]
        [Column(TypeName = "char(16)")] // 128 bit
        public string Salt { get; set; }
        [MinLength(2)]
        public string FirstName { get; set; }
        [MinLength(2)]
        public string LastName { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
