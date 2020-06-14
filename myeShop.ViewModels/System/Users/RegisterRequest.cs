using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace myeShop.ViewModels.System.Users
{
    public class RegisterRequest
    {
        public string FirstName { get; set; }

       
        public string LastName { get; set; }

        
        public DateTime Dob { get; set; }

        
        public string Email { get; set; }

       
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }

       
        public string Password { get; set; }

       
        public string ConfirmPassword { get; set; }

    }
}
