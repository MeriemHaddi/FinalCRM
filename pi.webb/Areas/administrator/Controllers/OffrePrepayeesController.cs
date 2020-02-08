using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using pi.domaine.Entities;
using pi.webb.Models;
using crm_pi.pi.data.Infrastructure;
using Service.Pattern;
using System.IO;

namespace pi.webb.Areas.administrator.Controllers
{
    public class OffrePrepayeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        IDatabaseFactory Factory = new DatabaseFactory();
        // GET: OffrePrepayees
        public ActionResult Index()
        {
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<OffrePrepayee> serOffre = new Service<OffrePrepayee>(Uok);
            return View(serOffre.GetAll());
        }

        //public ActionResult IndexOffreClient()
        // {
        //     IUnitOfWork Uok = new UnitOfWork(Factory);
        //     IService<OffrePrepayee> serOffre = new Service<OffrePrepayee>(Uok);
        //     return View(serOffre.GetAll());
        // }

        public ActionResult ListeOffres()
        {
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<OffrePrepayee> serOffre = new Service<OffrePrepayee>(Uok);
            return View(serOffre.GetAll());
        }

        public ActionResult DetailsOffreClient(string id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<OffrePrepayee> serOffre = new Service<OffrePrepayee>(Uok);


            OffrePrepayee offrePrepayee = serOffre.GetById(id);

            if (offrePrepayee == null)
            {
                return HttpNotFound();
            }

            return View(offrePrepayee);
        }

        // GET: OffrePrepayees/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<OffrePrepayee> serOffre = new Service<OffrePrepayee>(Uok);

            OffrePrepayee offrePrepayee = serOffre.GetById(id);
            if (offrePrepayee == null)
            {
                return HttpNotFound();
            }
            return View(offrePrepayee);
        }

        // GET: OffrePrepayees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OffrePrepayees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OffrePrepayee offrePrepayee, HttpPostedFileBase file)
        {

            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<OffrePrepayee> serOffre = new Service<OffrePrepayee>(Uok);
            DateTime D1 = Convert.ToDateTime(Request.Form["date_debut"]);

            // DateTime.TryParse(Request.Form["date_debut"], out D1);
            DateTime D2 = Convert.ToDateTime(Request.Form["date_fin"]);
            //  DateTime.TryParse(Request.Form["date_fin"], out D2);
            // int result = DateTime.Compare(D1, D2);

            //if (DateTime.Compare(D1, D2) < 0)
            //{
            //    RedirectToAction("Create");
            //}
            if (!ModelState.IsValid || file.ContentLength == 0 || DateTime.Compare(D1, D2) > 0)
            {
                //  ModelState.AddModelError("", "adfdghdghgdhgdhdgda");
                RedirectToAction("Create");
            }


            offrePrepayee.img = file.FileName;
            serOffre.Add(offrePrepayee);
            serOffre.Commit();
            Uok.Dispose();
            var fileName = "";
            if (file.ContentLength > 0)
            {
                fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Uploads/"), fileName);
                file.SaveAs(path);
            }
            return RedirectToAction("Index");


            // return View(offrePrepayee);
        }

        // GET: OffrePrepayees/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<OffrePrepayee> serOffre = new Service<OffrePrepayee>(Uok);

            OffrePrepayee offrePrepayee = serOffre.GetById(id);
            if (offrePrepayee == null)
            {
                return HttpNotFound();
            }
            return View(offrePrepayee);
        }

        // POST: OffrePrepayees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OffrePrepayee offrePrepayee, HttpPostedFileBase file)
        {

            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<OffrePrepayee> serOffre = new Service<OffrePrepayee>(Uok);
            if (!ModelState.IsValid || file.ContentLength == 0)
            {
                RedirectToAction("Index");
            }
            offrePrepayee.img = file.FileName;
            serOffre.Update(offrePrepayee);
            serOffre.Commit();
            Uok.Dispose();
            var fileName = "";
            if (file.ContentLength > 0)
            {
                fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Uploads/"), fileName);
                file.SaveAs(path);
            }
            return RedirectToAction("Index");

            //  return View(offrePrepayee);
        }

        // GET: OffrePrepayees/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<OffrePrepayee> serOffre = new Service<OffrePrepayee>(Uok);

            OffrePrepayee offrePrepayee = serOffre.GetById(id);
            if (offrePrepayee == null)
            {
                return HttpNotFound();
            }
            return View(offrePrepayee);
        }

        // POST: OffrePrepayees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<OffrePrepayee> serOffre = new Service<OffrePrepayee>(Uok);
            OffrePrepayee offrePrepayee = serOffre.GetById(id);
            serOffre.Delete(offrePrepayee);

            serOffre.Commit();
            Uok.Dispose();

            return RedirectToAction("Index");
        }

        public ActionResult stat()
        {
            string a = "";
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<OffrePrepayee> serOffre = new Service<OffrePrepayee>(Uok);

            var list = serOffre.GetMany(o => o.periode == a);

            var t = serOffre.GetMany(o => o.periode == "Summer").Count();
            var f = serOffre.GetMany(o => o.periode == "Winter").Count();
            var rr = serOffre.GetMany(o => o.periode == "Fall").Count();
            var s = serOffre.GetMany(o => o.periode == "Spring").Count();


            ViewBag.t = t;
            ViewBag.f = f;
            ViewBag.rr = rr;
            ViewBag.s = s;
            return View(serOffre.GetAll().ToList());

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
