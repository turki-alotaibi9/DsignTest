using DsignTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DsignTest.Controllers
{
    public class PostsController : Controller
    {
        SDM_projectEntities db = new SDM_projectEntities();

        // GET: Posts
        public ActionResult ShowPosts()
        {
            var allPosts = db.Posts.OrderByDescending(item => item.CreatedAt).ToList();
            return View(allPosts);
        }
        public ActionResult CreatePosts()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreatePosts([Bind(Include = "Title,Description")] Post post)
        {
            if (ModelState.IsValid)
            {
                DateTime dateTime = DateTime.Now;

                post.CreatedAt = dateTime.ToString();
                post.User_id = Convert.ToInt32(Session["Id"]);
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("ShowPosts");
            }
            else
            {
                ViewBag.Message = "Data must be completed";
                return View();
            }
           
        }

        public ActionResult MyPosts() 
        {
            return View();
        }

       [HttpGet]
        public ActionResult MyPosts(int id) 
        {
            // int ses = Convert.ToInt32(id);
            // var myPosts = db.Posts.OrderByDescending(item => item.CreatedAt).Where(item => item.Id == ses).ToList();
           
         
            return View(db.Posts.Where(u => u.User_id == id).ToList());
        }
        public ActionResult DeletePost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
           
        }
        [HttpPost, ActionName("DeletePost")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) 
        {
            // to remove post by id 
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);

            db.SaveChanges();
            return RedirectToAction("ShowPosts");

          
        }

    }
}