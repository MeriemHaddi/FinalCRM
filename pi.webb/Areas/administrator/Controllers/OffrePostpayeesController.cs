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
using pi.data;
using System.Globalization;
using System.IO;
using System.Web.Helpers;

namespace pi.webb.Areas.administrator.Controllers
{
    public class OffrePostpayeesController : Controller
    {
        Context db = new Context();

        IDatabaseFactory Factory = new DatabaseFactory();


        // GET: OffrePostpayees
        public ActionResult Index()
        {
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<OffrePostpayee> serOffre = new Service<OffrePostpayee>(Uok);

            return View(serOffre.GetAll());
        }


        public ActionResult IndexOffreClient()
        {
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<OffrePostpayee> serOffre = new Service<OffrePostpayee>(Uok);

            return View(serOffre.GetAll());
        }

        public ActionResult ListeOffres()
        {
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<OffrePostpayee> serOffre = new Service<OffrePostpayee>(Uok);

            return View(serOffre.GetAll());
        }


        // GET: OffrePostpayees/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<OffrePostpayee> serOffre = new Service<OffrePostpayee>(Uok);

            OffrePostpayee offrePostpayee = serOffre.GetById(id);

            if (offrePostpayee == null)
            {
                return HttpNotFound();
            }
            return View(offrePostpayee);
        }

        public ActionResult DetailsOffreClient(string id)
        {
            String t = "";
            ViewBag.pack = db.Pack;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<OffrePostpayee> serOffre = new Service<OffrePostpayee>(Uok);

            var lm = from m in db.Pack  //fetch data from database
                     select m;
            OffrePostpayee offrePostpayee = serOffre.GetById(id);

            if (offrePostpayee == null)
            {
                return HttpNotFound();
            }
            foreach (var temp in lm)
            {
                if (temp.Id_Pack == offrePostpayee.Id_Pack)
                    t = temp.Titre;
            }
            ViewBag.titrepack = t;
            return View(offrePostpayee);
        }

        // GET: OffrePostpayees/Create
        public ActionResult Create()
        {
            ViewBag.pack = db.Pack;

            return View();
        }

        // POST: OffrePostpayees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OffrePostpayee offrePostpayee, HttpPostedFileBase file)
        {
            float r = 0;
            string a = Request.Form["PrixHorsPack"];
            var lm = from m in db.Pack  //fetch data from database
                     select m;
            foreach (var temp in lm)
            {
                if (temp.Id_Pack == offrePostpayee.Id_Pack)
                    r = temp.Prix;
            }
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<OffrePostpayee> serOffre = new Service<OffrePostpayee>(Uok);

            if (!ModelState.IsValid || file.ContentLength == 0)
            {
                RedirectToAction("Create");
            }

            offrePostpayee.img = file.FileName;

            if (offrePostpayee.Id_Pack == null)

                offrePostpayee.Prix = float.Parse(a, CultureInfo.InvariantCulture.NumberFormat);
            else

                offrePostpayee.Prix = (float.Parse(a, CultureInfo.InvariantCulture.NumberFormat) + r) - (((float.Parse(a, CultureInfo.InvariantCulture.NumberFormat) + r) * 10) / 100);

            //  serOffre.Update(offrePostpayee);
            serOffre.Add(offrePostpayee);

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

        }




        // GET: OffrePostpayees/Edit/5
        public ActionResult Edit(string id)
        {
            ViewBag.pack = db.Pack;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<OffrePostpayee> serOffre = new Service<OffrePostpayee>(Uok);

            OffrePostpayee offrePostpayee = serOffre.GetById(id);
            if (offrePostpayee == null)
            {
                return HttpNotFound();
            }
            return View(offrePostpayee);
        }

        // POST: OffrePostpayees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OffrePostpayee offrePostpayee, HttpPostedFileBase file)
        {
            float r = 0;
            string a = Request.Form["PrixHorsPack"];
            DateTime D1 = Convert.ToDateTime(Request.Form["date_debut"]);
            DateTime D2 = Convert.ToDateTime(Request.Form["date_fin"]);
            var lm = from m in db.Pack  //fetch data from database
                     select m;
            foreach (var temp in lm)
            {
                if (temp.Id_Pack == offrePostpayee.Id_Pack)
                    r = temp.Prix;
            }

            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<OffrePostpayee> serOffre = new Service<OffrePostpayee>(Uok);
            if (!ModelState.IsValid || file.ContentLength == 0 || DateTime.Compare(D1, D2) > 0)
            {
                RedirectToAction("Index");
            }
            offrePostpayee.img = file.FileName;
            if (offrePostpayee.Id_Pack == null)

                offrePostpayee.Prix = float.Parse(a, CultureInfo.InvariantCulture.NumberFormat);
            else

                offrePostpayee.Prix = float.Parse(a, CultureInfo.InvariantCulture.NumberFormat) + r;
            serOffre.Update(offrePostpayee);

            serOffre.Commit();
            Uok.Dispose();
            var fileName = "";
            if (file.ContentLength > 0)
            {
                fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Uploads/"), fileName);
                file.SaveAs(path);
            }


            //db.Entry(offrePostpayee).State = EntityState.Modified;
            //db.SaveChanges();
            return RedirectToAction("Index");

            // return View(offrePostpayee);
        }

        // GET: OffrePostpayees/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<OffrePostpayee> serOffre = new Service<OffrePostpayee>(Uok);

            OffrePostpayee offrePostpayee = serOffre.GetById(id);
            if (offrePostpayee == null)
            {
                return HttpNotFound();
            }
            return View(offrePostpayee);
        }

        // POST: OffrePostpayees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(String id)
        {
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<OffrePostpayee> serOffre = new Service<OffrePostpayee>(Uok);
            OffrePostpayee offrePostpayee = serOffre.GetById(id);
            serOffre.Delete(offrePostpayee);

            serOffre.Commit();
            Uok.Dispose();

            return RedirectToAction("Index");
        }

        public ActionResult GetPack(string id)
        {
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<OffrePostpayee> serOffre = new Service<OffrePostpayee>(Uok);

            OffrePostpayee offrepostpayee = serOffre.GetById(id);
            if (offrepostpayee != null)
            {
                var pack = db.Pack.Where(p => p.Id_Pack == offrepostpayee.Id_Pack).FirstOrDefault();

                if (pack != null)
                { return View(pack); }

            }
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Dashboard()
        {
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<OffrePostpayee> serOffre = new Service<OffrePostpayee>(Uok);

            var list = serOffre.GetAll();
            List<int> repartitions = new List<int>();

            var periodes = list.Select(x => x.Id_Pack).Distinct();

            //   var price= list.Select(x => x.Prix).Distinct();

            foreach (var item in periodes)
            {
                repartitions.Add(list.Count(x => x.Id_Pack == item));
            }

            var rep = repartitions;
            ViewBag.PERIODE = periodes;
            ViewBag.REP = repartitions.ToList();

            return View();

        }





        public ActionResult Search(string filtre)
        {
            return View(db.OffrePostpayee.Where(x => x.Titre.Contains(filtre) || filtre == null).ToList());
        }
    }
}
