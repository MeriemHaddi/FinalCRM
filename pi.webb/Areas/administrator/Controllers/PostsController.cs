using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Web;
using System.Web.Mvc;
using crm_pi.pi.data.Infrastructure;
using pi.data;
using pi.domaine.Entities;
using Service.Pattern;

namespace pi.webb.Areas.administrator.Controllers
{
    public class PostsController : Controller
    {
        private Context db = new Context();
        IDatabaseFactory dbf;
        IUnitOfWork uow;
        IService<Post> servPost;
        IService<Comment> servComment;
        IService<Client> servCl;

        public PostsController()
        {
            dbf = new DatabaseFactory();
            uow = new UnitOfWork(dbf);
            servPost = new Service<Post>(uow);
            servComment = new Service<Comment>(uow);
            servCl = new Service<Client>(uow);

        }

        // GET: administrator/Posts
        public ActionResult Index()
        {
          
            var post = db.Post.Include(p => p.Client);

            
            return View(post.ToList());
        }
        [HttpPost]
        public ActionResult Index(string searchString)
        {
            List<Post> posts = Session["posts"] as List<Post>;
            if (!String.IsNullOrEmpty(searchString))
            {
                posts = servPost.GetAll().Where(m => m.Title.Contains(searchString)).ToList();
            }
            return View(posts);
        }

        // GET: administrator/Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Post.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
           
            return View(post);
        }

        // GET: administrator/Posts/Create
        public ActionResult Create()
        {
            if (Session["user"] == null)
            {
                return Redirect("/administrator/Users/Login");
            }
            var currentUser = (User)Session["user"];

            ViewBag.ClientId = db.User.Where(u => u.Name != currentUser.Name)
                                     .ToList();
           
            ViewBag.currentUser = currentUser;
            //ViewBag.ClientId = new SelectList(db.User, "UserId", "Name");
            return View();
        }

        // POST: administrator/Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostId,Title,vue,Description,Date,State,ImageFile,ClientId")] Post post)
        {
            var currentUser = (User)Session["user"];

            post.ClientId = currentUser.UserId;
            string filename = Path.GetFileNameWithoutExtension(post.ImageFile.FileName);
            string extension = Path.GetExtension(post.ImageFile.FileName);
            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            post.Picture = "~/Image/" + filename;
            filename = Path.Combine(Server.MapPath("~/Image/"), filename);
            post.ImageFile.SaveAs(filename);
           
            if (ModelState.IsValid)
            {
               
                servPost.Add(post);
                servPost.Commit();
                return RedirectToAction("Index");
            }
           
            return View(post);
        }

        // GET: administrator/Posts/Edit/5
        public ActionResult Edit(int? id, User iduser)
        {




            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = servPost.GetById((int)id);

            if (post == null)
            {
                return HttpNotFound();
            }

            ViewBag.ClientId = new SelectList(db.User, "UserId", "Name", post.ClientId);

            return View(post);

        }




        // POST: administrator/Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostId,Title,Description,Date,State,ClientId")] Post post)
        {
            if (ModelState.IsValid)
            {
                
                servPost.Update(post);
                servPost.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(db.User, "UserId", "Name", post.ClientId);
            return View(post);
        }

        // GET: administrator/Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = servPost.GetById((int)id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: administrator/Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = servPost.GetById((int)id);
            servPost.Delete(post);
            servPost.Commit();
            return RedirectToAction("Index");
        }


       

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        public ActionResult CreateComment(int? id)
        {
            Post post = servPost.GetById((int)id);
            if (Session["user"] == null)
            {
                return Redirect("/administrator/Users/Login");
            }
            var currentUser = (User)Session["user"];

            ViewBag.ClientId = db.User.Where(u => u.Name != currentUser.Name)
                                     .ToList();
            ViewBag.currentUser = currentUser;

            //ViewBag.PostId = new SelectList(db.Post, "PostId", "Title");
            //ViewBag.ClientId = new SelectList(db.User, "UserId", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateComment([Bind(Include = "CommentId,date,ClientId,Text,PostId")] Comment comment, int id)
        {
            //IEnumerable<Client> clients = servCl.GetAll();

            var currentUser = (User)Session["user"];

            
            Post post = servPost.GetById((int)id);
            comment.PostId = post.PostId;
            comment.ClientId = currentUser.UserId;

            if (ModelState.IsValid)
            {
                servComment.Add(comment);
                servComment.Commit();
                return RedirectToAction("IndexComment/" + comment.PostId);
            }

           // ViewBag.PostId = new SelectList(db.Post, "PostId", "Title", comment.PostId);
            //ViewBag.ClientId = new SelectList(db.User, "UserId", "Name", comment.ClientId);
            return View(comment);
        }

        // GET: administrator/Comments/Edit/5
        public ActionResult EditComment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = servComment.GetById((int)id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.PostId = new SelectList(db.Post, "PostId", "Description", comment.PostId);
            return View(comment);
        }

        // POST: administrator/Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditComment([Bind(Include = "CommentId,Text,date,ClientId,PostId")] Comment comment,Post p)
        {
            if (ModelState.IsValid)
            {
                servComment.Update(comment);
                servComment.Commit();
                return RedirectToAction("IndexComment/"+comment.PostId);
            }
            ViewBag.PostId = new SelectList(db.Post, "PostId", "Description", comment.PostId);
            return View(comment);
        }

        // GET: administrator/Comments/Delete/5
        public ActionResult DeleteComment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = servComment.GetById((int)id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: administrator/Comments/Delete/5
        [HttpPost, ActionName("DeleteComment")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCommentConfirmed(int id)
        {
            Comment comment = servComment.GetById((int)id);
            servComment.Delete(comment);
            servComment.Commit();
            return RedirectToAction("Index");
        }
        public ActionResult IndexComment(int? id)
        {
          
            Post post = servPost.GetById((int)id);
            var comment = db.Comment.Where(a => a.PostId == id);
            ViewBag.ArticleID = id;
            return View(comment.ToList());
        }

        // GET: administrator/Comments/Details/5
        public ActionResult DetailsComment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comment.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }
        [HttpPost]
        public ActionResult AddComment(int articleid, int rating, string articleComment)
        {
            if (Session["user"] == null)
            {
                return Redirect("/administrator/Users/Login");
            }
            Comment objComment = new Comment();

            objComment.PostId = articleid;
            objComment.Text = articleComment;
            objComment.date = DateTime.Now;
            objComment.Rating = rating;
            var currentUser = (User)Session["user"];
            objComment.ClientId = currentUser.UserId;
            db.Comment.Add(objComment);
            db.SaveChanges();
            return RedirectToAction("IndexComment/" + objComment.PostId);
        }
       

    }



}

