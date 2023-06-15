using DsignTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DsignTest.Controllers
{
    public class HomeController : Controller
    {


      SDM_projectEntities db = new SDM_projectEntities();
           
        
        public ActionResult LoginPage()
        {
            return View("LoginPage");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginPage(User user)
        {
            //To check if user data exists or not

          
                var logInInfo = db.Users.Where(u => u.Email == user.Email && u.Password == user.Password).FirstOrDefault();
                if (logInInfo != null)
                {
                    Session["Id"] = user.Id.ToString();
                    Session["UserName"] = user.UserName.ToString();
                    return RedirectToAction("ShowPosts", "Posts");
                }
                // if user data not exists
                else
                {
                    ViewBag.Mess = "Verify your password or email";
                    return View();
                }
            
            
        }

        
        public ActionResult Register()
        {

            return View();

        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            try
            {
               
                var userNameCheck = db.Users.Where(User => User.UserName == user.UserName).Count();
                var userEmailCheck = db.Users.Where(User => User.Email == user.Email).Count();
                if (userNameCheck > 0 && userEmailCheck > 0)
                {
                    ViewBag.Message = "Username and Email Exists";
                    return View();
                }
                if (userNameCheck > 0)
                {
                    ViewBag.Message = "Username already taken";
                    return View();
                }
                if (userEmailCheck > 0)
                {
                    ViewBag.Message = "Email already exists";
                    return View();
                }

                db.Users.Add(user);
                db.SaveChanges();
                 ViewBag.Message = "Acount Created";
                return RedirectToAction("ShowPosts", "Posts");
            }
            catch (Exception ex) 
            {
                ViewBag.Error = "There Is error";

                return View();
            }
        

            

        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}