using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TadaManagement.Models;

namespace TadaManagement.Controllers
{
    public class LoginController : Controller
    {

        TadaManageEntities db = new TadaManageEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        } 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(user obja)
        {

            if (ModelState.IsValid)
            {
                using (TadaManageEntities db=new TadaManageEntities())
                {

                    var obj = db.user.Where(a => a.username.Equals(obja.username) && a.password.Equals(obja.password)).FirstOrDefault();

                    if (obj != null)
                    {
                        Session["UserId"] = obj.id.ToString();
                        Session["UserName"] = obj.username.ToString();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "The UserName or Password Incorrect");
                    }
                }
            }
            
            return View(obja);
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");

        }
    }
}