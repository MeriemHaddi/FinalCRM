using crm_pi.pi.data.Infrastructure;
using pi.domaine.Entities;
using pi.webb.Models;
using Service;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace pi.webb.Areas.administrator.Controllers
{
    public class LignecmdController : Controller 
    {

      //  IDatabaseFactory Factory;
      //  IUnitOfWork Uok;
        
      //  IService<lignecmd> servLignecmd;
      //  IService<Product> servProduct;
      //  IService<User> servUser;
      //  IService<factdev> servFactdev;
      //  ILignecmdService serviceLigne;

      //  int ussid = 7;
      //  public LignecmdController()
      //  {
      //      Factory = new DatabaseFactory();
      //      Uok = new UnitOfWork(Factory);
      //      servLignecmd = new Service<lignecmd>(Uok);
      //      servProduct = new Service<Product>(Uok);
      //      servUser=new Service<User>(Uok);
      //      servFactdev=new Service<factdev>(Uok);
      //      serviceLigne = new LignecmdService();

      //  }
      //  // GET: administrator/Lignecmd
      //  public ActionResult Index()
      //  {
      //      int azer = Convert.ToInt32(Session["lidd"]);
      //      double x=0;
      //      List<lignecmd> hotels = servLignecmd.GetAll().ToList();
      //      List<lignecmd> zz=new List<lignecmd>();
      //      foreach (var com in hotels)
      //      { 
      //       //   if(com.etat==0 && com.UserId == ussid)
      //              if (com.etat == 0 && com.UserId == azer)
      //              {
      //              com.product = servProduct.GetById(com.ProductId);
      //              zz.Add(com);

      //              x += com.product.Price * com.quantite;
      //          }
               
             
      //      }
      //      ViewBag.prixtot = x;
      //   //   Session["abc"] = "gh";

      //      return View(zz);

      //  }


      //  public ActionResult LineChart()
      //  {
      //      return View();
      //  }

      //  public ActionResult VisualizeStudentResult()
      //  {
      //      return Json(Result(), JsonRequestBehavior.AllowGet);
      //  }



      //  public List<StudentResult> Result()
      //  {

      //      List<StudentResult> stdResult = new List<StudentResult>();

      //      IQueryable<IGrouping<int, lignecmd>> zaz = serviceLigne.chart();
      ////      List < int, lignecmd >> zaz = serviceLigne.chart().ToList();


      //      foreach (IQueryable<IGrouping<int, lignecmd>> ck in zaz)
      //      {
      //          foreach (IGrouping<int, lignecmd> ww in ck)
      //          {
      //              string cvbn = "";
      //              foreach (lignecmd ckmp in ww)
      //              {
      //                  cvbn = ckmp.product.Product_Name;
      //              }

      //              stdResult.Add(new StudentResult()
      //              {

      //                  stdName = cvbn,
      //                  marksObtained = ww.Key
      //              });
      //          }

      //      }





      //      return stdResult;
      //  }



      //  public ActionResult panii()
      //  {


      //      int azer = Convert.ToInt32(Session["lidd"]);
      //      double x = 0;
      //      List<lignecmd> hotels = servLignecmd.GetAll().ToList();
      //      List<lignecmd> zz = new List<lignecmd>();
      //      foreach (var com in hotels)
      //      {
      //          //   if(com.etat==0 && com.UserId == ussid)
      //          if (com.etat == 0 && com.UserId == azer)
      //          {
      //              com.product = servProduct.GetById(com.ProductId);
      //              zz.Add(com);

      //              x += com.product.Price * com.quantite;
      //          }


      //      }
      //      ViewBag.prixtot = x;
      //      return View(zz);
      //  }

      //  // GET: administrator/Lignecmd/Details/5
      //  public ActionResult Details(int id)
      //  {
      //      return View();
      //  }

     




      //  // GET: administrator/Lignecmd/Create
      //  public ActionResult Create(int id, lignecmd lc)
      //  {
      //      int azer = Convert.ToInt32(Session["lidd"]);
      //      List<lignecmd> ls = new List<lignecmd>();
      //      ls = serviceLigne.findProductUser(azer, id).ToList();
      //      Product xs = servProduct.GetById(id);
      //      //   lignecmd lg = new lignecmd();
      //      if (xs.Quantity == 0)
      //      {

      //      }
      //      else { 
      //      if (ls.Count == 0 )
      //      {


      //          lc.ProductId = id;
      //          lc.product = servProduct.GetById(id);
      //          servProduct.Commit();
      //          lc.userr = servUser.GetById(azer);
      //          servUser.Commit();
      //          lc.UserId = azer;
      //          lc.etat = 0;
      //          lc.quantite = 1;
      //          lc.prix = lc.product.Price * lc.quantite;
      //          lc.FactdevId = null;
      //      //    lc.factdev = servFactdev.GetById(9);
      //          servFactdev.Commit();

      //          servLignecmd.Add(lc);

      //          //         ls.Add(lc);

      //      }
      //      else
      //      {
      //          if (ls[0].quantite + 1 > servProduct.GetById(id).Quantity)
      //          {
      //             //     ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email envoyé.');", true);


      //              }
      //              else
      //          {
      //              lc = ls[0];
      //              lc.product = servProduct.GetById(id);
      //              lc.quantite = lc.quantite + 1;
      //              lc.prix = lc.prix + lc.product.Price;
      //              servLignecmd.Update(lc);
      //          }

      //      }
      //      }

      //      servLignecmd.Commit();
      //      return RedirectToAction("Index","Product");
      //  }

      //  // POST: administrator/Lignecmd/Create
      //  [HttpPost]
      //  public ActionResult Create(FormCollection collection)
      //  {
      //      try
      //      {
                          
      //          // TODO: Add insert logic here

      //          return RedirectToAction("Index","Product");
      //      }
      //      catch
      //      {
      //          return View();
      //      }
      //  }

      //  //   GET: administrator/Lignecmd/Edit/5

      //  public ActionResult Edit(int id)
      //  {

      //      lignecmd ld = servLignecmd.GetById(id);

      //      //     ViewBag.s = wq;
      //      //    ViewBag.a = id;
      //      //   Console.WriteLine(wq);
      //      return View(ld);
      //  }

      //  // POST: administrator/Lignecmd/Edit/5
      //  [HttpPost]
      //  [ValidateAntiForgeryToken]
      //  public ActionResult Edit([Bind(Include = "LignecmdId,ProductId,FactdevId,UserId,quantite,prix,etat")] lignecmd reclamation)
      //  {
      //      if (ModelState.IsValid)
      //      {
      //          reclamation.product = servProduct.GetById(reclamation.ProductId);
      //          if (reclamation.quantite > reclamation.product.Quantity)
      //          {
      //              return RedirectToAction("Index","Product");
      //          }
      //          else {
      //          reclamation.prix = reclamation.quantite * reclamation.product.Price;
      //          servLignecmd.Update(reclamation);
      //          servLignecmd.Commit();
      //          return RedirectToAction("panii");
      //          }
      //      }


              
            
      //         return View();
            
      //  }

     

      //  // GET: administrator/Lignecmd/Delete/5
      //  public ActionResult Delete(int id)
      //  {
      //      lignecmd ll = servLignecmd.GetById(id);
      //      servLignecmd.Delete(ll);
      //      servLignecmd.Commit();

      //      //    ViewBag.q = id;

      //      return RedirectToAction("panii");
      //  }

      //  // POST: administrator/Lignecmd/Delete/5
      //  [HttpPost]
      //  public ActionResult Delete(int id, FormCollection collection)
      //  {
      //      try
      //      {
      //          // TODO: Add delete logic here

      //          return RedirectToAction("Index");
      //      }
      //      catch
      //      {
      //          return View();
      //      }
      //  }

      //  public ActionResult Creatl(int? id)
      //  {
      //      List<SelectListItem> item8 = new List<SelectListItem>();
      //      List<Product> cxs = servProduct.GetAll().ToList();

      //      foreach (var c in cxs)
      //      {
      //          item8.Add(new SelectListItem
      //          {
      //              Text = c.Product_Name,
      //              Value = c.idProduct.ToString()
      //          });
      //      }

      //      ViewBag.Product = item8;
      //      return View();
      //  }

      //  [HttpPost]
      //  [ValidateAntiForgeryToken]
      //  public ActionResult Creatl(int id,int productId,int quantite)
      //  {
      //      int azer = Convert.ToInt32(Session["lidd"]);
      //      if (ModelState.IsValid)
      //      {
      //          lignecmd ck = new lignecmd();
      //          Product pnl = servProduct.GetById(productId);
      //          ck.ProductId = productId;
      //          ck.quantite = quantite;
      //          ck.FactdevId = id;
      //          ck.UserId = azer;
      //          ck.etat = 1;
      //          ck.prix = pnl.Price*ck.quantite;
      //          servLignecmd.Add(ck);
      //       //   rs.Add(response);
      //          servLignecmd.Commit();
      //          return RedirectToAction("Details\\"+id,"Factdev");
      //      }

      //      return View();
      //  }


    }
}
