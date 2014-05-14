
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1.models
{
    public class ApplicationUser: IdentityUser
    {
        public ApplicationUser()
        {
            DateCreated = DateTime.Now;
        }
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }       

        public string ProfilePicUrl { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? LastLoginTime { get; set; }

        public bool Activated { get; set; }

        public string RoleId { get; set; }



    }
}
