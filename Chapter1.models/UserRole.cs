using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Chapter1.models
{
    public class UserRole : IdentityUserRole 
    {
        public string userName { get; set; }
        public string roleName { get; set; }
    }
}
