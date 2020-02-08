using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using pi.data;
using pi.domaine.Entities;
using PusherServer;


namespace pi.webb.Areas.administrator.Controllers
{
    public class UsersController : Controller
    {
        private Context db = new Context();

        // GET: administrator/Users
        public ActionResult Index()
        {
            return View(db.User.ToList());
        }

        // GET: administrator/Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: administrator/Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: administrator/Users/Create
        public ActionResult Login()
        {
            if (Request.HttpMethod == "POST")
            {
                string user_name = Request.Form["username"];

                using (var db = new Context())
                {
                    User user = db.User.FirstOrDefault(u => u.Name == user_name);
                    if (user == null)
                    {
                        user = new User { Name = user_name };

                        db.User.Add(user);
                        db.SaveChanges();
                    }
                    Session["user"] = user;
                }
                return Redirect("/administrator/Posts");
            }
            return View();
        }

        // POST: administrator/Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,Name,LastName,Adress,PhoneNumber")] User user)
        {
            if (ModelState.IsValid)
            {
                db.User.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: administrator/Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: administrator/Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,Name,LastName,Adress,PhoneNumber")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: administrator/Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: administrator/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.User.Find(id);
            db.User.Remove(user);
            db.SaveChanges();
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

        private Pusher pusher;

        //class constructor
        public UsersController()
        {

            var options = new PusherOptions
            {
                Cluster = "eu",
                Encrypted = true
            };

            pusher = new Pusher(
              "895201",
              "ca6eb146868dd4454768",
              "6366285fdb177a616d6c",
              options);
        }
        [HttpPost]
        public ActionResult Login2()
        {

            string user_name = Request.Form["username"];

            if (user_name.Trim() == "")
            {
                return Redirect("/");
            }


            using (var db = new Context())
            {

                User user = db.User.FirstOrDefault(u => u.Name == user_name);

                if (user == null)
                {
                    user = new User { Name = user_name };

                    db.User.Add(user);
                    db.SaveChanges();
                }

                Session["user"] = user;
            }

            return Redirect("/chat");
        }

        public JsonResult AuthForChannel(string channel_name, string socket_id)
        {
            if (Session["user"] == null)
            {
                return Json(new { status = "error", message = "User is not logged in" });
            }

            var currentUser = (User)Session["user"];

            if (channel_name.IndexOf("presence") >= 0)
            {

                var channelData = new PresenceChannelData()
                {
                    user_id = currentUser.UserId.ToString(),
                    user_info = new
                    {
                        id = currentUser.UserId,
                        name = currentUser.Name
                    },
                };

                var presenceAuth = pusher.Authenticate(channel_name, socket_id, channelData);

                return Json(presenceAuth);

            }

            if (channel_name.IndexOf(currentUser.UserId.ToString()) == -1)
            {
                return Json(new { status = "error", message = "User cannot join channel" });
            }

            var auth = pusher.Authenticate(channel_name, socket_id);

            return Json(auth);


        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("index", "Posts");
        }
    }
}


