using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using pi.domaine.Entities;
using pi.webb.Models;
using Service;
//using Twilio;
//using Twilio.Rest.Api.V2010.Account;




namespace pi.webb.Areas.administrator.Controllers
{
    public class ReclamationsController : Controller
    {
        private ReclamationService rs = new ReclamationService();
        private ResponsesService r = new ResponsesService();
        private ResponsesService responseService = new ResponsesService();

        private ApplicationDbContext db = new ApplicationDbContext();






        public ActionResult Satisfaction([Bind(Include = "IdReclamation, SatisfactionEnum")] Reclamation claim)
        {

            int id = claim.idReclamation;
            Reclamation updateClaim = rs.GetById(id);
            var i = claim.SatisfactionEnum;
            updateClaim.SatisfactionEnum = i;
            rs.Update(id, updateClaim);

            rs.Commit();

            try
            {
                //MailMessage mail = new MailMessage("nada.tounsi@esprit.tn","leviofr@gmail.com") ;
                MailMessage mail = new MailMessage("ali.bouhdiba@esprit.tn", "bouhdibaali@gmail.com");
                mail.Subject = "Le Client vient de faire un avis sur le traitement de ca reclamation";
                mail.Body = "BONJOUR ";

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.Credentials = new System.Net.NetworkCredential("ali.bouhdiba@esprit.tn", "Kedac53222838");
                smtpClient.EnableSsl = true;
                smtpClient.Send(mail);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }



            return RedirectToAction("Index", "Reclamations", new { id = id });
        }






        // GET: Reclamations
        public ActionResult Index()
        {
            return View(rs.GetAll().ToList());
        }

        public ActionResult AllReclamation()
        {
            return View(rs.GetReclamationNotTreated("In process").ToList());
        }


        public ActionResult Treated()
        {
            return View(rs.GetReclamationNotTreated("Treated").ToList());
        }


        public ActionResult stat()
        {
            var t = rs.GetReclamationbytype(TypeReclamation.Technique).Count();
            var f = rs.GetReclamationbytype(TypeReclamation.Financiere).Count();
            var rr = rs.GetReclamationbytype(TypeReclamation.Relationnelle).Count();


            ViewBag.t = t;
            ViewBag.f = f;
            ViewBag.rr = rr;

            return View(rs.GetAll().ToList());

        }

        public ActionResult statisfaction()
        {
            var t = rs.GetReclamationbysatis(enumSatisfaction.NotSatisfied).Count();
            var f = rs.GetReclamationbysatis(enumSatisfaction.Satisfied).Count();
            var rr = rs.GetReclamationbysatis(enumSatisfaction.VerySatisfied).Count();


            ViewBag.t = t;
            ViewBag.f = f;
            ViewBag.rr = rr;

            return View(rs.GetAll().ToList());

        }

        // GET: Reclamations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reclamation reclamation = rs.GetById((long)id);
            Response reponse = new Response();
            reponse = r.GetResponseByIdClaim(reclamation.idReclamation);
            //Candidat user = us.GetById(claims.IdUser);
            //ViewBag.username=user.

            if (reponse == null)
            {
                ViewBag.nombre = "0";
            }
            else
            {
                ViewBag.content = reponse.Content;
                ViewBag.nombre = "1";

            }
            if (reclamation == null)
            {
                return HttpNotFound();
            }
            return View(reclamation);
        }


        public ActionResult Reply(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reclamation claims = rs.GetById((long)id);
            if (claims == null)
            {
                return HttpNotFound();
            }
            return View(claims);
        }

        [HttpPost]
        //public ActionResult Reply(Reclamation claim, string texte, Response response)
        //{
        //    int id = claim.idReclamation;
        //    Reclamation updateClaim = rs.GetById(id);
        //    updateClaim.etat = "Treated";
        //    response.Content = texte;
        //    response.Date = DateTime.Now;
        //    response.ResponseDate = DateTime.Now;
        //    response.idClaim = id;
        //    response.IdUser = 1;
        //    rs.Update(id, updateClaim);
        //    responseService.Add(response);
        //    responseService.Commit();
        //    rs.Commit();

        //    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
        //                                        | SecurityProtocolType.Tls11
        //                                        | SecurityProtocolType.Tls12
        //                                        | SecurityProtocolType.Ssl3;
        //    const string accountSid = "AC9a8bb6e8676265a06afea3cd62edf071";
        //    const string authToken = "70c410c306981f341aeb5b4e6cef2df5";
        //    TwilioClient.Init(accountSid, authToken);

        //    var message = MessageResource.Create(
        //        from: new Twilio.Types.PhoneNumber("+17578287636"),
        //    to: new Twilio.Types.PhoneNumber("+21653222838"),
        //        body: "Votre Reclamation a ete traiter");
        //    try
        //    {
        //        //MailMessage mail = new MailMessage("nada.tounsi@esprit.tn","leviofr@gmail.com") ;
        //        MailMessage mail = new MailMessage("ali.bouhdiba@esprit.tn", "bouhdibaali@gmail.com");
        //        mail.Subject = texte;
        //        mail.Body = "BONJOUR  ";

        //        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
        //        smtpClient.Credentials = new System.Net.NetworkCredential("ali.bouhdiba@esprit.tn", "Kedac53222838");
        //        smtpClient.EnableSsl = true;
        //        smtpClient.Send(mail);
        //    }

        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.StackTrace);
        //    }

        //    return RedirectToAction("AllReclamation");
        //}



        //GET: Reclamations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reclamations/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idReclamation,Titre,contenu,etat,TypeReclamation")] Reclamation reclamation, [Bind(Include = "file")] HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                reclamation.Urlimage = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/uploads"), reclamation.Urlimage);
                file.SaveAs(path);
            }


            if (ModelState.IsValid)
            {


                reclamation.Date = DateTime.Now;
                reclamation.IdUser = 1;
                reclamation.etat = "In process";

                rs.Add(reclamation);
                rs.Commit();
                return RedirectToAction("Index");
            }

            return View(reclamation);
        }

        // GET: Reclamations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reclamation reclamation = rs.GetById((long)id);
            if (reclamation == null)
            {
                return HttpNotFound();
            }
            return View(reclamation);
        }

        // POST: Reclamations/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idReclamation,Titre,contenu,etat,TypeReclamation")] Reclamation reclamation)
        {
            if (ModelState.IsValid)

            {

                reclamation.Date = DateTime.Now;
                reclamation.IdUser = 1;
                reclamation.etat = "In process";
                reclamation.Urlimage = "facture.jpg";
                rs.Update(reclamation.idReclamation, reclamation);
                rs.Commit();
                return RedirectToAction("Index");
            }
            return View(reclamation);
        }


        // GET: Reclamations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reclamation reclamation = rs.GetById((long)id);
            if (reclamation == null)
            {
                return HttpNotFound();
            }
            return View(reclamation);
        }

        // POST: Reclamations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reclamation reclamation = rs.GetById((long)id);
            rs.Delete(reclamation);
            rs.Commit();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAjax(int id)
        {
            Reclamation reclamation = rs.GetById((long)id);
            rs.Delete(reclamation);
            rs.Commit();
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
