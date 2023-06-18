using DsignTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DsignTest.ViewModel;
using System.Dynamic;

namespace DsignTest.Controllers
{
    public class CommentController : Controller
    {
        SDM_projectEntities db = new SDM_projectEntities();
       

        // GET: Comment

        public ActionResult ShowComments()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ShowComments(int id)
        {

            dynamic mymodel = new ExpandoObject();

            // To display all comments for the post
            var allCommentsRelated = db.Comments.Where(u => u.Post_id == id).First();
          //  var userComment = db.Users.Where(u => u.Id == allCommentsRelated.User_id).First();


            return View(allCommentsRelated);
        }
        public ActionResult CreateComment(Comment comment)
        {
            if (ModelState.IsValid)
            {
                DateTime dateTime = DateTime.Now;

               // comment.CreatedAt = dateTime.ToString();
                comment.User_id = Convert.ToInt32(Session["Id"]);
                comment.Post_id = comment.Post.Id;
                
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("ShowPosts");
            }

            return View("");
        }

        // GET: Comment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Comment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comment/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Comment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Comment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Comment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Comment/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
