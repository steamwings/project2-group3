using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaData.Models
{
    public class LoginCredentials
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
