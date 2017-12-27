using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MovieService.Models
{
    public class RegisterView
    {
        [Required(ErrorMessage = "Enter User's Name")]
        [MinLength(2, ErrorMessage = "Minimum name length is 6")]
        [MaxLength(100, ErrorMessage = "Maximum name length is 100" )]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Enter email")]
        [MinLength(5,ErrorMessage = "Minimum email length is 5")]
        [MaxLength(150, ErrorMessage = "Maximum email length is 150")]
        public string email { get; set; }

        [Required(ErrorMessage = "Enter password")]
        [MinLength(6, ErrorMessage = "Minimum password length is 6")]
        [MaxLength(50, ErrorMessage = "Maximum password length is 50")]

        public string password { get; set; }

        [Required(ErrorMessage = "Enter password yet")]
        [MaxLength(50, ErrorMessage = "Maximum password length is 50")]
        [Compare("password", ErrorMessage = "Password don't match")]
        public string confirmPassword { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Gender { get; set; }
    }
}