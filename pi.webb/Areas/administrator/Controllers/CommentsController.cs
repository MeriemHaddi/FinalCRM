using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using crm_pi.pi.data.Infrastructure;
using pi.data;
using pi.domaine.Entities;
using Service.Pattern;

namespace pi.webb.Areas.administrator.Controllers
{
    public class CommentsController : Controller
    {
        private Context db = new Context();
        IDatabaseFactory dbf;
        IUnitOfWork uow;
        IService<Comment> servComment;
        IService<Post> servPost;

        public CommentsController()
        {
            dbf = new DatabaseFactory();
            uow = new UnitOfWork(dbf);
            servComment = new Service<Comment>(uow);
            servPost = new Service<Post>(uow);
        }

        // GET: administrator/Comments
        public ActionResult Index()
        {
            var comment = db.Comment.Include(c => c.Post);
            return View(comment.ToList());
        }

        // GET: administrator/Comments/Details/5
        public ActionResult Details(int? id)
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

        // GET: administrator/Comments/Create
        public ActionResult Create()
        {
            

            ViewBag.PostId = new SelectList(db.Post, "PostId", "Title");
            ViewBag.ClientId = new SelectList(db.User, "UserId", "Name");
            return View();
        }

        // POST: administrator/Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentId,date,ClientId,Text")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                servComment.Add(comment);
                servComment.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.PostId = new SelectList(db.Post, "PostId", "Title", comment.PostId);
            ViewBag.ClientId = new SelectList(db.User, "UserId", "Name", comment.ClientId);
            return View(comment);
        }

        // GET: administrator/Comments/Edit/5
        public ActionResult Edit(int? id)
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
        public ActionResult Edit([Bind(Include = "CommentId,date,ClientId,PostId")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                servComment.Update(comment);
                servComment.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.PostId = new SelectList(db.Post, "PostId", "Description", comment.PostId);
            return View(comment);
        }

        // GET: administrator/Comments/Delete/5
        public ActionResult Delete(int? id)
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = servComment.GetById((int)id);
            servComment.Delete(comment);
            servComment.Commit();
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
    }
}
