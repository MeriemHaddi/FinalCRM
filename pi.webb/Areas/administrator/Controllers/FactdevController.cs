using crm_pi.pi.data.Infrastructure;
using pi.domaine.Entities;
using Service;
using Service.Pattern;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Text;
using System.Data;
using System.Net;
using System.Net.Mail;

using System.Web.UI;


namespace pi.webb.Areas.administrator.Controllers
{
    public class FactdevController : Controller
    {

    //    IDatabaseFactory Factory;
    //    IUnitOfWork Uok;
    //    ILignecmdService serviceLigne;
    //    IService<lignecmd> servLignecmd;
    //    IService<domaine.Entities.Product> servProduct;
    //    IService<factdev> servFactdev;
    //    IService<User> servuser;
    //    int ussid = 7;
    //    public FactdevController()
    //    {
    //        Factory = new DatabaseFactory();
    //        Uok = new UnitOfWork(Factory);
    //        servFactdev = new Service.Pattern.Service<factdev>(Uok);
    //        serviceLigne = new LignecmdService();
    //        servLignecmd = new Service.Pattern.Service<lignecmd>(Uok);
    //        servProduct = new Service.Pattern.Service<domaine.Entities.Product>(Uok);
    //        servuser = new Service.Pattern.Service<User>(Uok);
    //    }
    //    // GET: administrator/Factdev
    //    public ActionResult Index()
    //    {
    //        return RedirectToAction("Index","Product");
    //    }

    //    public ActionResult maild(int id)
    //    {

    //        int azer = Convert.ToInt32(Session["lidd"]);
    //        lignecmd lcs = servLignecmd.GetById(id);
    //        domaine.Entities.Product xcgh = servProduct.GetById(lcs.ProductId);

    //        User luti = servuser.GetById(azer);
    //        MailMessage mm = new MailMessage("testmail2366@gmail.com",luti.Adress);
    //        mm.Subject = "Demande du produit : "+xcgh.Product_Name ;
    //        mm.Body = "j'ai besoin de "+lcs.quantite+" "+xcgh.Product_Name ;  
    //        mm.IsBodyHtml = true;
    //        SmtpClient smtp = new SmtpClient();
    //        smtp.Host = "smtp.gmail.com";
    //        smtp.EnableSsl = true;
    //        NetworkCredential NetworkCred = new NetworkCredential();
    //        NetworkCred.UserName = "testmail2366@gmail.com";
    //        NetworkCred.Password = "biat2366";
    //        smtp.UseDefaultCredentials = true;
    //        smtp.Credentials = NetworkCred;
    //        smtp.Port = 587;
    //        smtp.Send(mm);

    //        return RedirectToAction("Details");
    //    }


    //    public ActionResult payment(double? id)
    //     //     public ActionResult payment()
    //    {

    //        ViewBag.qq = id;

    //     //   ViewBag.wn = Session["abc"];
    //        return View();

    //    }



    //    public ActionResult bca(double? id)
    //    {

    //        ViewBag.qq = id;

    ////        ViewBag.wn = Session["abc"];
    //        return View();

    //    }

    //    [HttpPost]
    //    public ActionResult bca(double pp,int dd)
    //    {

    //        double id = 0;
    //        if (dd == 1)
    //        {
    //            id = pp / 10;

    //        }
    //        else if( dd==2){
    //            id=(15*pp)/ 100;
    //        }
    //        else if (dd == 3)
    //        {

    //            id = (20 * pp) / 100;
    //        }

    //            return RedirectToAction("payment\\"+id,"Boncmd", new { ab = dd });
                     
    //      //  ViewBag.wn = Session["abc"];   
            
    //    }



    //    //public ActionResult bcaa(double? id)
    //    //{

    //    //    ViewBag.qq = id;

    //    //    ViewBag.wn = Session["abc"];
    //    //    return View();

    //    //}

     




    //    public ActionResult ajdevis(double id,factdev dd)
    //    {
    //        int azer = Convert.ToInt32(Session["lidd"]);
    //        dd.etat = 1;
    //        dd.date = DateTime.Now;
    //        dd.prix =(int) id;
    //        //dd.UserId = azer;
    //        //      fc.lignes.Add(kg);
    //        dd.reference = "aazz";
    //        servFactdev.Add(dd);
    //        servFactdev.Commit();
    //        List<lignecmd> llcmd = serviceLigne.findPanier(azer).ToList();
    //        foreach (var com in llcmd)
    //        {
    //            com.etat = 1;
    //            com.FactdevId = dd.FactdevId;
    //            servLignecmd.Update(com);
    //            servLignecmd.Commit();
    //            //Product pr = servProduct.GetById(com.ProductId);
    //            //pr.Quantity = pr.Quantity - com.quantite;
    //            //servProduct.Update(pr);
    //            //servProduct.Commit();

    //        }


    //        return RedirectToAction("Index","Product");

    //    }

    //    public ActionResult histo()
    //    {
    //        int azer = Convert.ToInt32(Session["lidd"]);
    //        List<factdev> hotels = servFactdev.GetAll().ToList();
    //        List<factdev> zz = new List<factdev>();
    //        foreach (var com in hotels)
    //        {
    //            if ((com.etat = 0) && (com.UserId = azer))
    //            {
    //                zz.Add(com);
    //            }
    //        }
    //            return View(zz);
    //    }


    //    //public ActionResult printAll(int id)
    //    //{

    //    //    //     var q = new ActionAsPdf("toj");
    //    //    var q = new ActionAsPdf("limpre", new { id = id });
    //    //    return q;
    //    //}

    //    public ActionResult limpre(int id)
    //    {
    //        factdev bbb = servFactdev.GetById(id);
    //        User uuu = servuser.GetById(bbb.UserId);
    //        List<lignecmd> lll = serviceLigne.findFacture(id).ToList();

    //        foreach (var ppp in lll)
    //        {
    //            ppp.product = servProduct.GetById(ppp.ProductId);
    //        }
    //        bbb.lignes = lll;

    //        ViewBag.adresse = uuu.Adress;
    //        ViewBag.name = uuu.Name;
    //        ViewBag.last = uuu.LastName;
    //        ViewBag.phone = uuu.PhoneNumber;
         

    //        return View(bbb);

   
    //    }

    //    public ActionResult affdevis()
    //    {

    //        int azer = Convert.ToInt32(Session["lidd"]);
         

    //        List<factdev> hotels = servFactdev.GetAll().ToList();
    //        List<factdev> zz = new List<factdev>();
    //        List<lignecmd> xx = new List<lignecmd>();
    //        foreach (var com in hotels)
    //        {
    //            if (com.etat == 1 && com.UserId == azer)
    //            {

    //                xx = serviceLigne.findDevis(azer,com.FactdevId).ToList();
    //                int a = 0;

    //                int b = 0;
    //                int c = 0;

    //                foreach (var hg in xx)
    //                {

    //                    hg.product = servProduct.GetById(hg.ProductId);

    //                    if (hg.quantite > hg.product.Quantity)
    //                    {
    //                        a++; //red
    //                    }
    //                    else if (hg.product.Quantity - hg.quantite >= 0 && hg.product.Quantity - hg.quantite <= 3)
    //                    {
    //                        b++; //yellow
    //                    }
    //                    else
    //                    {
    //                        c++; //vert
    //                    }
    //                }
    //                ViewBag.redd = a;
    //                ViewBag.yell = b;
    //                ViewBag.gree = c;
    //                com.lignes = xx;
    //                //       com.product = servProduct.GetById(com.ProductId);
    //                zz.Add(com);
    //            }
    //        }

           

    //        return View(zz);
    //    }

    //    private static Random random = new Random();
    //    public static string RandomString(int length)
    //    {
    //        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    //        return new string(Enumerable.Repeat(chars, length)
    //          .Select(s => s[random.Next(s.Length)]).ToArray());
    //    }


    //    [HttpPost]
    //    public ActionResult payment(string reportName,factdev fc,string stripeToken)
    //    {
    //        int azer = Convert.ToInt32(Session["lidd"]);

    //        //  DateTime dt1 = Convert.ToDateTime("02/02/2020 00:00:00".ToString());
    //        //   factdev fc = new factdev();
    //        lignecmd kg = new lignecmd();
    //     //   kg=serv
    //        fc.etat = 0;
    //        fc.date = DateTime.Now ;
    //        fc.prix = Convert.ToDouble(reportName);
    //        fc.UserId = azer;
    //        //      fc.lignes.Add(kg);
    //        //var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    //        //var stringChars = new char[8];
    //        //var random = new Random();

    //        //for (int i = 0; i < stringChars.Length; i++)
    //        //{
    //        //    stringChars[i] = chars[random.Next(chars.Length)];
    //        //}
    //        //      fc.reference =new String(stringChars);
    //        fc.reference = RandomString(8);
    //        servFactdev.Add(fc);
    //        servFactdev.Commit();
    //        List<lignecmd> llcmd = serviceLigne.findPanier(azer).ToList();

    //        foreach (var der in llcmd)
    //        {
    //            der.product = servProduct.GetById(der.ProductId);
    //        }


    //            StripeConfiguration.ApiKey = "sk_test_eHX577eunxBcQJ9JF8L99vyb";

    //        long piu = Convert.ToInt64(reportName) * 100;
    //        var options = new ChargeCreateOptions()
    //        {
    //            Amount =piu ,
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

    //        User luti = servuser.GetById(azer);

    //        using (StringWriter sw = new StringWriter())
    //        {
    //            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
    //            {
    //                string companyName = "Ooreedoo";
    //                string Nomp = "Nom produit";
    //                string Descp = "Description";
    //                string prixu = "prix unitaire";
    //                string qte = "Quantite";
    //                string prixt = "Prix total";
    //                string prixtotal = "Le Prix total de la facture : "+ reportName;
    //                string companyadd = "testmail2366@gmail.com";
    //                StringBuilder sb = new StringBuilder();
    //                sb.Append("<table width='100%' cellspacing='0' cellpadding='2'>");
    //                sb.Append("<tr><td align='center' style='background-color: #18B5F0' colspan = '2'><b>Facture</b></td></tr>");
    //                sb.Append("<tr><td colspan = '2'></td></tr>");
    //                sb.Append("<tr><td><b>Reference :</b>");
    //                sb.Append(fc.reference);
    //                sb.Append("</td><td><b>Date : </b>");
    //                sb.Append(DateTime.Now);
    //                sb.Append(" </td></tr>");
    //                sb.Append("<tr><td colspan = '2'><b>Nom de la societe :</b> ");
    //                sb.Append(companyName);
    //                sb.Append("</td></tr>");
    //                sb.Append("<tr><td colspan = '2'><b>Adresse de la societe :</b> ");
    //                sb.Append(companyadd);
    //                sb.Append("</td></tr>");
    //                sb.Append("<tr><td colspan = '2'><b>Vers le client :</b>");
    //                sb.Append(luti.Name);
    //                sb.Append(luti.LastName);
    //                sb.Append("</td></tr>");
    //                sb.Append("<tr><td colspan = '2'><b>Numero de telephone :</b>");
    //                sb.Append(luti.PhoneNumber);
    //                sb.Append("</td></tr>");
    //                sb.Append("<tr><td colspan = '2'><b>Email :</b>");
    //                sb.Append(luti.Adress);
    //                sb.Append("</td></tr>");
    //                sb.Append("</table>");
    //                sb.Append("<br />");
    //                sb.Append("<table border = '1'>");

    //                sb.Append("<tr>");

    //                sb.Append("<th style = 'background-color: #D20B0C;color:#ffffff'>");
    //                sb.Append(Nomp);
    //                sb.Append("</th>");
    //                sb.Append("<th style = 'background-color: #D20B0C;color:#ffffff'>");
    //                sb.Append(Descp);
    //                sb.Append("</th>");
    //                sb.Append("<th style = 'background-color: #D20B0C;color:#ffffff'>");
    //                sb.Append(prixu);
    //                sb.Append("</th>");
    //                sb.Append("<th style = 'background-color: #D20B0C;color:#ffffff'>");
    //                sb.Append(qte);
    //                sb.Append("</th>");
    //                sb.Append("<th style = 'background-color: #D20B0C;color:#ffffff'>");
    //                sb.Append(prixt);
    //                sb.Append("</th>");

    //                sb.Append("</tr>");

    //                foreach (var row in llcmd)
    //                {
    //                    sb.Append("<tr>");
                      
    //                        sb.Append("<td>");
    //                        sb.Append(row.product.Product_Name);
    //                        sb.Append("</td>");

    //                    sb.Append("<td>");
    //                    sb.Append(row.product.Description);
    //                    sb.Append("</td>");

    //                    sb.Append("<td>");
    //                    sb.Append(row.product.Price);
    //                    sb.Append("</td>");

    //                    sb.Append("<td>");
    //                    sb.Append(row.quantite);
    //                    sb.Append("</td>");

    //                    sb.Append("<td>");
    //                    sb.Append(row.prix+" Dt");
    //                    sb.Append("</td>");
    //                    sb.Append("</tr>");
    //                }
    //                sb.Append("</table>");

    //                sb.Append(prixtotal+" DT");
    //                StringReader sr = new StringReader(sb.ToString());
    //                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
    //                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
    //                using (MemoryStream memoryStream = new MemoryStream())
    //                {
    //                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
    //                    pdfDoc.Open();
    //                    htmlparser.Parse(sr);
    //                    pdfDoc.Close();
    //                    byte[] bytes = memoryStream.ToArray();
    //                    memoryStream.Close();
    //                    MailMessage mm = new MailMessage("testmail2366@gmail.com",luti.Adress);
    //                    mm.Subject = "Facture "+DateTime.Now.Date;
    //                    mm.Body = "Vous trouvez ci-joint votre facture ";
    //                    mm.Attachments.Add(new Attachment(new MemoryStream(bytes), "Facture"+fc.reference+".pdf"));
    //                    mm.IsBodyHtml = true;
    //                    SmtpClient smtp = new SmtpClient();
    //                    smtp.Host = "smtp.gmail.com";
    //                    smtp.EnableSsl = true;
    //                    NetworkCredential NetworkCred = new NetworkCredential();
    //                    NetworkCred.UserName = "testmail2366@gmail.com";
    //                    NetworkCred.Password = "biat2366";
    //                    smtp.UseDefaultCredentials = true;
    //                    smtp.Credentials = NetworkCred;
    //                    smtp.Port = 587;
    //                    smtp.Send(mm);


    //                }

    //                }

    //            }



    //        foreach (var com in llcmd)
    //        {
    //            com.etat = 1;
    //            com.FactdevId = fc.FactdevId;
    //            servLignecmd.Update(com);
    //            servLignecmd.Commit();
    //            domaine.Entities.Product pr = servProduct.GetById(com.ProductId);
    //            pr.Quantity = pr.Quantity - com.quantite;
    //            servProduct.Update(pr);
    //            servProduct.Commit();
    //        }

    //        return RedirectToAction("Index","administrator/Product");
    //    }


    //    // GET: administrator/Factdev/Details/5
    //    public ActionResult Details(int id)
    //    {
    //        int azer = Convert.ToInt32(Session["lidd"]);
    //        List<lignecmd> ldv = servLignecmd.GetAll().ToList();
    //        List<lignecmd> zz = new List<lignecmd>();
    //        foreach (var com in ldv)
    //        {
    //            if (com.FactdevId == id && com.UserId == azer)
    //            {
    //                com.product = servProduct.GetById(com.ProductId);
    //                zz.Add(com);
    //            }
    //        }
    //        factdev fs = servFactdev.GetById(id);
    //        ViewBag.prixtot =fs.prix ;
    //        ViewBag.dvid = id;
    //        return View(zz);
    //    }


    //    public ActionResult Detailf(int id)
    //    {
    //        int azer = Convert.ToInt32(Session["lidd"]);
    //        List<lignecmd> ldv = servLignecmd.GetAll().ToList();
    //        List<lignecmd> zz = new List<lignecmd>();
    //        foreach (var com in ldv)
    //        {
    //            if (com.FactdevId == id && com.UserId == azer)
    //            {
    //                com.product = servProduct.GetById(com.ProductId);
    //                zz.Add(com);
    //            }
    //        }
    //        factdev fs = servFactdev.GetById(id);
    //        ViewBag.prixtot = fs.prix;
    //        ViewBag.dvid = id;
    //        return View(zz);
    //    }



    //    public ActionResult qmx()
    //    {

    //        return View();
    //    }




    //    // GET: administrator/Factdev/Create
    //    public ActionResult Create()
    //    {
    //        return View();
    //    }

    //    // POST: administrator/Factdev/Create
    //    [HttpPost]
    //    public ActionResult Create(FormCollection collection,factdev f)
    //    {
    //        //try
    //        //{

            

    //            servFactdev.Add(f);
    //            servFactdev.Commit();

    //            return RedirectToAction("Index");
    //        //}
    //        //catch
    //        //{
    //        //    return View();
    //        //}
    //    }



    //    // GET: administrator/Factdev/Edit/5
    //    public ActionResult Edit(int id)
    //    {
    //        return View();
    //    }

    //    // POST: administrator/Factdev/Edit/5
    //    [HttpPost]
    //    public ActionResult Edit(int id, FormCollection collection)
    //    {
    //        try
    //        {
    //            // TODO: Add update logic here

    //            return RedirectToAction("Index");
    //        }
    //        catch
    //        {
    //            return View();
    //        }
    //    }

    //    // GET: administrator/Factdev/Delete/5
    //    public ActionResult Delete(int id)
    //    {
    //        factdev df = servFactdev.GetById(id);
    //        servFactdev.Delete(df);
    //        servFactdev.Commit();
    //        return RedirectToAction("affdevis");
    //    }

    //    // POST: administrator/Factdev/Delete/5
    //    [HttpPost]
    //    public ActionResult Delete(int id, FormCollection collection)
    //    {
    //        try
    //        {
    //            // TODO: Add delete logic here

    //            return RedirectToAction("Index");
    //        }
    //        catch
    //        {
    //            return View();
    //        }
    //    }
    }
}
