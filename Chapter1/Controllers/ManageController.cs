using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chapter1.models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Chapter1.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class ManageController : Controller
    {
        IdentityManager identityManager = new IdentityManager();

        //
        // GET: /Manage/
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// add users to roles
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(UserRole userRole)
        {
            if (identityManager.AddUserToRole(userRole.userName, userRole.roleName))
            {
                ViewBag.Status = "User added";
            }
            else
            {
                ViewBag.Status = "User cannot be added";
            }
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }

        //
        // POST: /Role/Delete/5
        [HttpPost]
        public ActionResult Delete(Role role)
        {
            try
            {

                identityManager.ClearUserRoles(role.Name);
                ViewBag.Status = "Successfully deleted role";
            }
            catch (Exception ex)
            {
                ViewBag.status = "Cannot delete user Role.";
            }
            return View();
        }
	}
}