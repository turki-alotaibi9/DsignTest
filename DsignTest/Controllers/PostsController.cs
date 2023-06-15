using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DsignTest.Controllers
{
    public class PostsController : Controller
    {
        // GET: Posts
        public ActionResult ShowPosts()
        {
            return View();
        }
    }
}