﻿using System;
using System.Collections.Generic;
using System.Text;

namespace myeShop.ViewModels.System.Uesrs
{
    public class LoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
