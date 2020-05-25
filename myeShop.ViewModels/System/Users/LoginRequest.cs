using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace myeShop.ViewModels.System.Users
{
    public class LoginRequest
    {
        [Required(ErrorMessage ="Username is required")]
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
