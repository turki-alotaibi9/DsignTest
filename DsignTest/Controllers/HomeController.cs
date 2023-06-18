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
            // Check if the user exists in the database.
            var userInDb = db.Users.SingleOrDefault(u => u.Email == user.Email && u.Password == user.Password);
            // To check User status Enable Or Disable
            var userStatus = db.Users.SingleOrDefault(u => u.Status == "Enable");
            // to check user Role
            var userRole = db.Users.SingleOrDefault(u => u.Role == "Admin");

            if (user != null)
            {

                if (userInDb != null)
                {
                    // If the user exists, log them in and redirect them to the posts page.
                    if (userStatus == null)
                    {
                        // Set the user's ID and username in the session.
                        Session["Id"] = userInDb.Id;
                        Session["UserName"] = userInDb.UserName;

                        // Redirect the user to the posts page.
                        return RedirectToAction("ShowPosts", "Posts");
                    }
                    else
                    {

                        ViewBag.Message = "Your Account Is Disable ";
                        return View("LoginPage");
                    }
                }

            }
           
               
              //  ViewBag.Message = "Please enter the p";
                return View("LoginPage");
            
          

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
                Session["Id"] = user.Id.ToString();
                Session["UserName"] = user.UserName.ToString();
                Session["Email"] = user.UserName.ToString();
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