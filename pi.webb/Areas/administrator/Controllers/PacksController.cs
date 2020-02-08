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
using pi.data;
using System.Web.ModelBinding;

namespace pi.webb.Areas.administrator.Controllers
{
    public class PacksController : Controller
    {
        Context db = new Context();
        IDatabaseFactory Factory = new DatabaseFactory();
        // GET: Packs
        public ActionResult Index()
        {
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<Pack> serPack = new Service<Pack>(Uok);

            return View(serPack.GetAll());
        }

        // GET: Packs
        public ActionResult IndexClient()
        {
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<Pack> serPack = new Service<Pack>(Uok);

            return View(serPack.GetAll());
        }

        // GET: Packs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<Pack> serPack = new Service<Pack>(Uok);

            Pack pack = serPack.GetById(id);
            if (pack == null)
            {
                return HttpNotFound();
            }

            return View(pack);
        }

        //public ActionResult listProduits(string id)
        //{
        //    IUnitOfWork Uok = new UnitOfWork(Factory);
        //    IService<Pack> serPack = new Service<Pack>(Uok);

        //    Pack pack = serPack.GetById(id);
        //    if (pack != null)
        //    {
        //        var list = db.Product.Where(p => p.Id_Pack == pack.Id_Pack).ToList();

        //        if (list != null)
        //        { return View(list); }

        //    }
        //    return View();
        //}

        //public IQueryable<Product> GetProducts([QueryString("id")] string packId)
        //{
        //   // var _db = new WingtipToys.Models.ProductContext();
        //    IQueryable<Product> query = db.Product;
        //    if (packId!="" )
        //    {
        //        query = query.Where(p => p.Id_Pack = packId);
        //    }
        //    return query;
        //}

        public ActionResult DetailsClient(string id)
        {
            List<Product> productList = new List<Product>();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<Pack> serPack = new Service<Pack>(Uok);

            Pack pack = serPack.GetById(id);


            if (pack == null)
            {
                return HttpNotFound();
            }
            return View(pack);
        }

        // GET: Packs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Packs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pack pack, HttpPostedFileBase file)
        {
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<Pack> serOffre = new Service<Pack>(Uok);

            if (!ModelState.IsValid || file.ContentLength == 0)
            {
                RedirectToAction("Create");
            }
            Pack pack1 = new Pack()
            {
                Id_Pack = pack.Id_Pack,
                Titre = pack.Titre,
                Description = pack.Description,
                Periode_Engagement = pack.Periode_Engagement,
                Prix = pack.Prix,
                img = file.FileName,
            };


            serOffre.Add(pack1);
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

        // GET: Packs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<Pack> serPack = new Service<Pack>(Uok);

            Pack pack = serPack.GetById(id);
            if (pack == null)
            {
                return HttpNotFound();
            }
            return View(pack);
        }

        // POST: Packs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Pack,Titre,Description,Periode_Engagement,Prix")] Pack pack, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid || file.ContentLength == 0)
            {
                RedirectToAction("Index");
            }

            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<Pack> serPack = new Service<Pack>(Uok);
            pack.img = file.FileName;
            serPack.Update(pack);

            serPack.Commit();
            Uok.Dispose();
            var fileName = "";
            if (file.ContentLength > 0)
            {
                fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Uploads/"), fileName);
                file.SaveAs(path);
            }

            return RedirectToAction("Index");

            //  return View(pack);
        }

        // GET: Packs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<Pack> serPack = new Service<Pack>(Uok);

            Pack pack = serPack.GetById(id);
            if (pack == null)
            {
                return HttpNotFound();
            }
            return View(pack);
        }

        // POST: Packs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<Pack> serPack = new Service<Pack>(Uok);

            Pack pack = serPack.GetById(id);
            serPack.Delete(pack);

            serPack.Commit();
            Uok.Dispose();
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
