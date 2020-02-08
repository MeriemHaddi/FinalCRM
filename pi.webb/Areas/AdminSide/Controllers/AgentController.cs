using System.Web;
using System.Web.Mvc;
using pi.data;
using pi.domaine.Entities;
using crm_pi.pi.data.Infrastructure;
using Service;
using Service.Pattern;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace pi.webb.Areas.AdminSide.Controllers
{
    public class AgentController : Controller
    {
        private Context db = new Context();

        // GET: AdminSide/Agents
        public ActionResult Index(string searchString)

        {

            var Agents = new List<Agent>();
            IDatabaseFactory Factory = new DatabaseFactory();
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<Agent> chService = new Service<Agent>(Uok);
            AgentService p = new AgentService();
            IEnumerable<Agent> Agent = chService.GetAll().ToList();
            if (!string.IsNullOrEmpty(searchString))
            {
                Agent = p.GetAgentByTitle(searchString);
            }

            foreach (Agent a in Agent)
            {
                Agents.Add(new Agent()
                {
                    idAgent = a.idAgent,
                    FName = a.FName,
                    LName = a.LName,
                    tel = a.tel,
                    post = a.post,
                    Shop = a.Shop,
                    id_Shop = a.id_Shop




                });
            }


            return View(Agents);

        }

        // GET: AdminSide/Agents/Details/5
        public ActionResult Details(int id)
        {
            IDatabaseFactory Factory = new DatabaseFactory();
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<Agent> chService = new Service<Agent>(Uok);

            Agent p = chService.GetById((long)id);

            return View(p);
        }

        // GET: AdminSide/Agents/Create
        public ActionResult Create()
        {
            ViewBag.Shop = db.Shop;
            return View();
        }

        // POST: AdminSide/Agents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idAgent,FName,LName,post,tel,id_Shop")] Agent a, HttpPostedFileBase file)
        {
            DatabaseFactory Factory = new DatabaseFactory();
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<Agent> chServic = new Service<Agent>(Uok);



            if (!ModelState.IsValid || file.ContentLength == 0)
            {
                RedirectToAction("Create");
            }

            Agent ag = new Agent()
            {
                idAgent = a.idAgent,
                FName = a.FName,
                LName = file.FileName,
                tel = a.tel,
                post = a.post,
                Shop = a.Shop,
                id_Shop = a.id_Shop



            };

            chServic.Add(ag);
            chServic.Commit();
            var fileName = "";
            if (file.ContentLength > 0)
            {
                fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Uploads/"), fileName);
                file.SaveAs(path);
            }


            return RedirectToAction("Index");
        }

        // GET: AdminSide/Agents/Edit/5
        public ActionResult Edit(int? id, Agent a)
        {
            IDatabaseFactory Factory = new DatabaseFactory();
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<Agent> chService = new Service<Agent>(Uok);



            Agent p = chService.GetById((long)id);



            chService.Update(p);




            ViewBag.Shop = db.Shop;

            return View(p);


        }

        // POST: AdminSide/Agents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public ActionResult Edit(Agent a, int id)
        {
            IDatabaseFactory Factory = new DatabaseFactory();
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<Agent> chService = new Service<Agent>(Uok);
            if (!ModelState.IsValid)
            {
                RedirectToAction("Edit");
            }

            Agent p = chService.GetById((long)id);


            p.FName = a.FName;

            p.tel = a.tel;
            p.post = a.post;
            p.Shop = a.Shop;
            p.id_Shop = a.id_Shop;






            chService.Update(p);
            chService.Commit();


            return RedirectToAction("Index");


        }

        // GET: AdminSide/Agents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agent agent = db.Agents.Find(id);
            if (agent == null)
            {
                return HttpNotFound();
            }
            return View(agent);
        }

        // POST: AdminSide/Agents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Agent agent = db.Agents.Find(id);
            db.Agents.Remove(agent);
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
    }
}
