﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GeziLog.Models.Classes;

namespace GeziLog.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Index

        Context contextBlogs = new Context();
        BlogComment bc = new BlogComment();

        public ActionResult Index()
        {
            bc.Value3 = contextBlogs.Blogs.OrderByDescending(x=>x.ID).Take(2).ToList();
            return View(bc);
        }

        // GET: About

        Context contextAbout = new Context();
        public ActionResult About()
        {
            var values = contextAbout.Abouts.ToList();
            return View(values);
        }

        // GET: Contact

        public ActionResult Contact()
        {
            return View();
        }

        // GET: Blogs

        public ActionResult Blogs()
        {
            bc.Value1 = contextBlogs.Blogs.ToList();
            return View(bc);
        }

        // GET: Single
        
        public ActionResult Single(int id)
        {
            //var findBlog = contextBlogs.Blogs.Where(x=>x.ID == id).ToList();
            bc.Value1 = contextBlogs.Blogs.Where(x=> x.ID == id).ToList();
            bc.Value2 = contextBlogs.Comments.Where(x=> x.Blogid==id).ToList();
            return View(bc);
        }

        //Context contextComment = new Context();
        // GET: PartialView: ToComment
        [HttpGet]
        public PartialViewResult ToComment(int id)
        {
            ViewBag.value = id;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult ToComment(Comment c)
        {
            contextBlogs.Comments.Add(c);
            contextBlogs.SaveChanges();
            return PartialView();
        }
    }
}