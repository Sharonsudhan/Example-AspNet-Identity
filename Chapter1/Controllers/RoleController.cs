using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chapter1.models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Chapter1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        IdentityManager identityManager = new IdentityManager();
        
        //
        // GET: /Role/
        public ActionResult Index()
        {
            return View();
        }


        //
        // GET: /Role/
        public ActionResult Create()
        {
            return View();
        }
       
        //
        // GET: /Role/Create
        [HttpPost]
        public ActionResult Create(Role role)
        {
            bool Status = false;
            bool RoleExist = identityManager.RoleExists(role.Name);
            if (ModelState.IsValid && RoleExist != true)
            {
                Status = identityManager.CreateRole(role.Name);
            }

            if (Status)
                ViewBag.Status = "Successfully added role";
            else
                ViewBag.status = "Cannot create Role,Please make sure role doesnt exist already";
            return View();
        }

        //
        // GET: /Role/Delete/5
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
            
            identityManager.DeleteRole(role.Name);
            ViewBag.Status = "Successfully deleted role";
            }
           catch(Exception ex)
           {
               ViewBag.status = "Cannot delete user Role.";
           }
            return View();
        }
    }
}
