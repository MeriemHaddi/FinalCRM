using pi.data;
using pi.domaine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PusherServer;


namespace pi.webb.Areas.administrator.Controllers
{
    public class ChatController : Controller
    {
        private Pusher pusher;

        //class constructor
        public ChatController()
        {
            var options = new PusherOptions
            {
                Cluster = "eu",
                Encrypted = true
            };

            var pusher = new Pusher(
               "895201",
      "ca6eb146868dd4454768",
      "6366285fdb177a616d6c",
      options);
           
        }
            // GET: administrator/Chat
            public ActionResult Index()
        {
            
            //Random r = new Random();
      
            //Random r2 = new Random();
            //var user = new User();
           
            //user.UserId = r2.Next(1,3);
            //user.Name = "meriem"+ user.UserId;
            //Session["user"] = user ;
            //Console.WriteLine(user.UserId);

             if (Session["user"] == null) {
                
                return Redirect("/administrator/Users/Login");
                

            }

            var currentUser = (User) Session["user"];

                using ( var db = new Context() ) {

                    ViewBag.allUsers = db.User.Where(u => u.Name != currentUser.Name )
                                     .ToList();
                }


                ViewBag.currentUser = currentUser;
            return View();
        }
        public JsonResult ConversationWithContact(int contact)
        {
            if (Session["user"] == null)
            {
                return Json(new { status = "error", message = "User is not logged in" });
            }

            var currentUser = (User)Session["user"];

            var conversations = new List<Conversation>();

            using (var db = new Context())
            {
                conversations = db.Conversations.
                                  Where(c => (c.receiver_id == currentUser.UserId
                                      && c.sender_id == contact) ||
                                      (c.receiver_id == contact
                                      && c.sender_id == currentUser.UserId))
                                  .OrderBy(c => c.created_at)
                                  .ToList();
            }

            return Json(
                new { status = "success", data = conversations },
                JsonRequestBehavior.AllowGet
            );
        }
        [HttpPost]
        public JsonResult SendMessage()
        {
            if (Session["user"] == null)
            {
                return Json(new { status = "error", message = "User is not logged in" });
            }

            var currentUser = (User)Session["user"];

            string socket_id = Request.Form["socket_id"];

            Conversation convo = new Conversation
            {
                sender_id = currentUser.UserId,
                message = Request.Form["message"],
                receiver_id = Convert.ToInt32(Request.Form["contact"]),
              
            };

            using (var db = new Context())
            {
                db.Conversations.Add(convo);
                db.SaveChanges();
            }

            return Json(convo);
        }
        private String getConvoChannel(int user_id, int contact_id)
        {
            if (user_id > contact_id)
            {
                return "private-chat-" + contact_id + "-" + user_id;
            }

            return "private-chat-" + user_id + "-" + contact_id;
        }
    }
}