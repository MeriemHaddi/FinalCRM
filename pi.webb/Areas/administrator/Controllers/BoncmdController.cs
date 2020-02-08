using crm_pi.pi.data.Infrastructure;
using pi.domaine.Entities;
using Service;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;


namespace pi.webb.Areas.administrator.Controllers
{
    public class BoncmdController : Controller
    {

    //    IDatabaseFactory Factory;
    //    IUnitOfWork Uok;
    //    ILignecmdService serviceLigne;
    //    IBoncmdService serviceBon;
    //    IService<lignecmd> servLignecmd;
    //    IService<domaine.Entities.Product> servProduct;
    //    IService<factdev> servFactdev;
    //    IService<Boncmd> servBoncmd;
    //    IService<User> servuser;

    //    int ussid = 7;


    //    public BoncmdController()
    //    {

    //        Factory = new DatabaseFactory();
    //        Uok = new UnitOfWork(Factory);
    //        servFactdev = new Service.Pattern.Service<factdev>(Uok);
    //        serviceLigne = new LignecmdService();
    //        serviceBon = new BoncmdService();
    //        servLignecmd = new Service.Pattern.Service<lignecmd>(Uok);
    //        servProduct = new Service.Pattern.Service<domaine.Entities.Product>(Uok);
    //        servBoncmd = new Service.Pattern.Service<Boncmd>(Uok);
    //        servuser = new Service.Pattern.Service<User>(Uok);

    //    }

    //    GET: administrator/Boncmd
    //    public ActionResult Index()
    //    {
    //        return View();
    //    }

    //    public ActionResult confirmation(int id)
    //    {
    //        int azer = Convert.ToInt32(Session["lidd"]);
    //        Boncmd lbcd = servBoncmd.GetById(id);
    //        lbcd.etat = 2;
    //        servBoncmd.Update(lbcd);
    //        servBoncmd.Commit();
    //        factdev ff = new factdev();
    //        List<lignecmd> lalis = new List<lignecmd>();

    //        lalis = serviceLigne.findBon(id).ToList();
    //        ff.date = DateTime.Now;
    //        ff.etat = 0;
    //        ff.prix = (int)lbcd.prix;
    //        ff.reference = RandomString(8);

    //        ff.UserId = lalis[0].UserId;
    //        ff.lignes = lalis;
    //        servFactdev.Add(ff);
    //        servFactdev.Commit();

    //        foreach (var pro in lalis)
    //        {

    //            pro.FactdevId = ff.FactdevId;
    //            pro.boncmd = null;
    //            servLignecmd.Update(pro);
    //            servLignecmd.Commit();
    //        }

    //        return RedirectToAction("affadmin");
    //    }
    //    public ActionResult annulation(int id)
    //    {

    //        Boncmd lbcd = servBoncmd.GetById(id);
    //        lbcd.etat = 1;
    //        servBoncmd.Update(lbcd);
    //        servBoncmd.Commit();
    //        List<lignecmd> lalis = new List<lignecmd>();

    //        lalis = serviceLigne.findBon(id).ToList();

    //        foreach (var pp in lalis)
    //        {

    //            domaine.Entities.Product qq = servProduct.GetById(pp.ProductId);

    //            qq.Quantity = qq.Quantity + pp.quantite;
    //            servProduct.Update(qq);
    //            servProduct.Commit();
    //        }

    //        return RedirectToAction("affadmin");
    //    }


    //    public ActionResult toj()
    //    {
    //        return View();
    //    }


    //    public ActionResult affadmin()
    //    {
    //        List<Boncmd> lbcd = servBoncmd.GetAll().ToList();
    //        List<Boncmd> wm = new List<Boncmd>();
    //        foreach (var com in lbcd)
    //        {
    //            if (com.etat == 0)
    //            {
    //                wm.Add(com);
    //            }
    //        }

    //        return View(wm);
    //    }


    //    public ActionResult BarcodeImage(String barcodeText)
    //    {

    //        generating a barcode here. Code is taken from QrCode.Net library
    //        QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
    //        QrCode qrCode = new QrCode();
    //        qrEncoder.TryEncode(barcodeText, out qrCode);
    //        GraphicsRenderer renderer = new GraphicsRenderer(new FixedModuleSize(4, QuietZoneModules.Four), Brushes.Black, Brushes.White);

    //        Stream memoryStream = new MemoryStream();
    //        renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, memoryStream);

    //        very important to reset memory stream to a starting position, otherwise you would get 0 bytes returned
    //        memoryStream.Position = 0;

    //        var resultStream = new FileStreamResult(memoryStream, "image/png");
    //        resultStream.FileDownloadName = String.Format("{0}.png", barcodeText);

    //        return resultStream;
    //    }





    //    public ActionResult affclt()
    //    {
    //        int azer = Convert.ToInt32(Session["lidd"]);
    //        List<Boncmd> lbcd = servBoncmd.GetAll().ToList();
    //        List<Boncmd> wm = new List<Boncmd>();
    //        foreach (var com in lbcd)
    //        {
    //            if (com.UserId == azer)
    //            {
    //                wm.Add(com);
    //            }
    //        }
    //        return View(wm);
    //    }

    //    public ActionResult payment(double id, int ab)
    //    {

    //        ViewBag.qq = id;

    //        ViewBag.kk = ab;

    //        ViewBag.wn = Session["abc"];
    //        return View();

    //    }


    //    private static Random random = new Random();
    //    public static string RandomString(int length)
    //    {
    //        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    //        return new string(Enumerable.Repeat(chars, length)
    //          .Select(s => s[random.Next(s.Length)]).ToArray());
    //    }


    //    public ActionResult generatedbon(int id)
    //    {
    //        Boncmd bbb = servBoncmd.GetById(id);
    //        User uuu = servuser.GetById(bbb.UserId);
    //        List<lignecmd> lll = serviceLigne.findBon(id).ToList();

    //        foreach (var ppp in lll)
    //        {
    //            ppp.product = servProduct.GetById(ppp.ProductId);
    //        }
    //        bbb.lignes = lll;

    //        ViewBag.adresse = uuu.Adress;
    //        ViewBag.name = uuu.Name;
    //        ViewBag.last = uuu.LastName;
    //        ViewBag.phone = uuu.PhoneNumber;
    //        ViewBag.reste = bbb.prix - bbb.prixb;

    //        return View(bbb);
    //    }


    //    [HttpPost]
    //    [ValidateInput(false)]
    //    public FileResult Export(string GridHtml)
    //    {
    //        using (MemoryStream stream = new System.IO.MemoryStream())
    //        {
    //            StringReader sr = new StringReader(GridHtml);
    //            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
    //            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
    //            pdfDoc.Open();
    //            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
    //            pdfDoc.Close();
    //            return File(stream.ToArray(), "application/pdf", "Grid.pdf");
    //        }
    //    }

    //    public ActionResult printAll(int id)
    //    {

    //        ////     var q = new ActionAsPdf("toj");
    //        //         var q = new ActionAsPdf("generatedbon", new { id = id });
    //        //     return q;
    //    }




    //    [HttpPost]
    //    public ActionResult payment(string prkol, string vald, Boncmd lebon, string stripeToken)
    //    {
    //        int azer = Convert.ToInt32(Session["lidd"]);

    //        if (vald.Equals("1"))
    //        {
    //            lebon.date = DateTime.Now.AddDays(7);
    //            lebon.prix = Convert.ToDouble(prkol) * 10;
    //        }
    //        else if (vald.Equals("2"))
    //        {
    //            lebon.date = DateTime.Now.AddDays(14);
    //            lebon.prix = (Convert.ToDouble(prkol) * 100) / 15;
    //        }
    //        else if (vald.Equals("3"))
    //        {
    //            lebon.date = DateTime.Now.AddDays(21);
    //            lebon.prix = (Convert.ToDouble(prkol) * 100) / 20;
    //        }
    //        lebon.etat = 0;
    //        lebon.prixb = Convert.ToDouble(prkol);
    //        lebon.UserId = azer;
    //        lebon.reference = RandomString(8);
    //        lebon.codeqr = RandomString(2) + "-" + RandomString(2);
    //        servBoncmd.Add(lebon);
    //        servBoncmd.Commit();

    //        List<lignecmd> llcmd = serviceLigne.findPanier(azer).ToList();

    //        foreach (var der in llcmd)
    //        {
    //            der.product = servProduct.GetById(der.ProductId);
    //        }



    //        StripeConfiguration.ApiKey = "sk_test_eHX577eunxBcQJ9JF8L99vyb";

    //        long piu = Convert.ToInt64(prkol) * 100;
    //        var options = new ChargeCreateOptions()
    //        {
    //            Amount = piu,
    //            Currency = "usd",
    //            Source = stripeToken,
    //            Description = "Charge for Anis",
    //            Metadata = new Dictionary<String, String>()
    //{
    //    { "OrderId", "6735"}
    //}
    //        };

    //        var service = new ChargeService();
    //        Charge charge = service.Create(options);



    //        foreach (var com in llcmd)
    //        {
    //            com.etat = 1;
    //            com.BoncmdId = lebon.BoncmdId;
    //            servLignecmd.Update(com);
    //            servLignecmd.Commit();
    //            domaine.Entities.Product pr = servProduct.GetById(com.ProductId);
    //            pr.Quantity = pr.Quantity - com.quantite;
    //            servProduct.Update(pr);
    //            servProduct.Commit();
    //        }
    //        var q = new Rotativa.ActionAsPDF("generated bon");

    //        DateTime dt1 = Convert.ToDateTime("02/02/2020 00:00:00".ToString());
    //        factdev fc = new factdev();
    //        lignecmd kg = new lignecmd();
    //        //   kg=serv
    //        fc.etat = 0;
    //        fc.date = DateTime.Now;
    //        fc.prix = id;
    //        fc.UserId = ussid;
    //        //      fc.lignes.Add(kg);
    //        fc.reference = "aazz";
    //        servFactdev.Add(fc);
    //        servFactdev.Commit();
    //        List<lignecmd> llcmd = serviceLigne.findPanier(ussid).ToList();
    //        foreach (var com in llcmd)
    //        {
    //            com.etat = 1;
    //            com.FactdevId = fc.FactdevId;
    //            servLignecmd.Update(com);
    //            servLignecmd.Commit();
    //            Product pr = servProduct.GetById(com.ProductId);
    //            pr.Quantity = pr.Quantity - com.quantite;
    //            servProduct.Update(pr);
    //            servProduct.Commit();

    //        }
    //        return RedirectToAction("Index", "administrator/Product");
    //    }






    //    GET: administrator/Boncmd/Details/5
    //    public ActionResult Details(int id)
    //    {
    //        return View();
    //    }

    //    GET: administrator/Boncmd/Create
    //    public ActionResult Create()
    //    {
    //        return View();
    //    }

    //    POST: administrator/Boncmd/Create
    //   [HttpPost]
    //    public ActionResult Create(FormCollection collection)
    //    {
    //        try
    //        {
    //            TODO: Add insert logic here

    //            return RedirectToAction("Index");
    //        }
    //        catch
    //        {
    //            return View();
    //        }
    //    }

    //    GET: administrator/Boncmd/Edit/5
    //    public ActionResult Edit(int id)
    //    {
    //        return View();
    //    }

    //    POST: administrator/Boncmd/Edit/5
    //    [HttpPost]
    //    public ActionResult Edit(int id, FormCollection collection)
    //    {
    //        try
    //        {
    //            TODO: Add update logic here

    //            return RedirectToAction("Index");
    //        }
    //        catch
    //        {
    //            return View();
    //        }
    //    }

    //    GET: administrator/Boncmd/Delete/5
    //    public ActionResult Delete(int id)
    //    {
    //        return View();
    //    }

    //    POST: administrator/Boncmd/Delete/5
    //    [HttpPost]
    //    public ActionResult Delete(int id, FormCollection collection)
    //    {
    //        try
    //        {
    //            TODO: Add delete logic here

    //            return RedirectToAction("Index");
    //        }
    //        catch
    //        {
    //            return View();
    //        }
    //    }
    }
}
