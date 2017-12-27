using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MovieService.Models
{
    public class LoginView
    {
        [Required(ErrorMessage = "Enter email")]
        public string email { get; set; }

        [Required(ErrorMessage = "Enter password")]
        public string password { get; set; }

        public bool isPersisent { get; set; }
    }
}