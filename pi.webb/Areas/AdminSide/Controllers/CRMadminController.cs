
using pi.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pi.webb.Areas.AdminSide.Controllers
{
    public class CRMadminController : Controller
    {

        private Context db = new Context();
        // GET: AdminSide/CRMadmin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            return View(db.Product.ToList());
        }
    }
}