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
    public class TeleProspectionsController : Controller
    {
        private Context db = new Context();
        IDatabaseFactory dbf;
        IUnitOfWork uow;
        IService<TeleProspection> servTel;
        public TeleProspectionsController()
        {
            dbf = new DatabaseFactory();
            uow = new UnitOfWork(dbf);
            servTel = new Service<TeleProspection>(uow);
        }


        // GET: administrator/TeleProspections
        public ActionResult Index()
        {
            var teleProspection = db.TeleProspection.Include(t => t.Client);
            return View(teleProspection.ToList());
        }

        // GET: administrator/TeleProspections/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeleProspection teleProspection = db.TeleProspection.Find(id);
            if (teleProspection == null)
            {
                return HttpNotFound();
            }
            return View(teleProspection);
        }

        // GET: administrator/TeleProspections/Create
        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(db.User, "UserId", "Name");
            return View();
        }

        // POST: administrator/TeleProspections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeleProspectionId,Date,State,Description,Priority,ClientId")] TeleProspection teleProspection)
        {
            if (ModelState.IsValid)
            {
                servTel.Add(teleProspection);
                servTel.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(db.User, "UserId", "Name", teleProspection.ClientId);
            return View(teleProspection);
        }

        // GET: administrator/TeleProspections/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeleProspection teleProspection = servTel.GetById((int)id);
            if (teleProspection == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(db.User, "UserId", "Name", teleProspection.ClientId);
            return View(teleProspection);
        }

        // POST: administrator/TeleProspections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeleProspectionId,Date,State,Description,Priority,ClientId")] TeleProspection teleProspection)
        {
            if (ModelState.IsValid)
            {
                servTel.Update(teleProspection);
                servTel.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(db.User, "UserId", "Name", teleProspection.ClientId);
            return View(teleProspection);
        }

        // GET: administrator/TeleProspections/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeleProspection teleProspection = servTel.GetById((int)id);
            if (teleProspection == null)
            {
                return HttpNotFound();
            }
            return View(teleProspection);
        }

        // POST: administrator/TeleProspections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeleProspection teleProspection = servTel.GetById((int)id);
            servTel.Delete(teleProspection);
            servTel.Commit();
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
