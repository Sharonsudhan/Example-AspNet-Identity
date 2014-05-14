using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Chapter1.models
{
    public class IdentityManager
    {

        RoleManager<IdentityRole> rm = new RoleManager<IdentityRole>(
              new RoleStore<IdentityRole>(new ChapterContext()));

        UserManager<ApplicationUser> um = new UserManager<ApplicationUser>(
            new UserStore<ApplicationUser>(new ChapterContext()));

        public bool RoleExists(string name)
        {
          return rm.RoleExists(name);
        }


        public bool CreateRole(string name)
        {
            var idResult = rm.Create(new IdentityRole(name));
            return idResult.Succeeded;
        }

        public bool DeleteRole(string name)
        {
            IdentityRole identityRole= rm.FindByName(name);
            var idResult = rm.Delete(identityRole);
            return idResult.Succeeded;
        }



        public bool CreateUser(ApplicationUser user, string password)
        {
            var idResult = um.Create(user, password);
            return idResult.Succeeded;
        }


        public bool AddUserToRole(string userName, string roleName)
        {
            try
            {
                var user = um.FindByName(userName);
                var idResult = um.AddToRole(user.Id, roleName);
                return true;
            }
            catch
            {
            return false;
            }
        }


        public void ClearUserRoles(string userName)
        {
            var user = um.FindByName(userName);
            var currentRoles = new List<IdentityUserRole>();
            currentRoles.AddRange(user.Roles);
            var Roles = new List<IdentityRole>();
            foreach (var role in currentRoles)
            {
                var thisRoles = rm.FindById(role.RoleId);
                um.RemoveFromRole(user.Id, thisRoles.Name);
            }
        }
    }
}