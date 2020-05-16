using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace myeshop.Data.Entities
{
    public class Role : IdentityRole<Guid>
    {
        public string Description { get; set; }
    }
}
