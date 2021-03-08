using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopProject.Areas.Administrator.Sales;
//using Testing_GP;
namespace ShopProject.Areas.Administrator.Controllers
{
    public class PredictController : Controller
    {
        Models.AdminContext dbPre = new Models.AdminContext();
        // GET: Administrator/Predict
        [HandleError]
        public ActionResult Index(string error,string ID)
        {
            if (Session["accname"] == null)
            {
                Session["accname"] = null;
                return RedirectToAction("Login", "Account");
            }
            else
            {
                ViewBag.PreError = error;
                if (!string.IsNullOrEmpty(ID))
                {
                    ViewBag.Product = dbPre.Products.SingleOrDefault(s => s.proID == ID);
                    if (ViewBag.Product != null)
                    {
                        List<Sale> ListS = new List<Sale>();
                        var Details = dbPre.OrderDetails.Where(s => s.proID == ID).ToList(); 
                        foreach(var item in Details)
                        {                            
                            var datatime = dbPre.Orders.SingleOrDefault(s => s.orderID == item.orderID).orderDateTime;
                            if (ListS.Where(s => s.orderDateTime == datatime.ToString("dd/MM/yyyy")).Count() == 0)
                            {
                                ListS.Add(new Sale(datatime.ToString("dd/MM/yyyy"), item.ordtsQuantity));
                            }
                            else
                            {
                                int index=ListS.FindIndex(s => s.orderDateTime == datatime.ToString("dd/MM/yyyy"));
                                ListS[index].totalQuantity += item.ordtsQuantity;
                            }
                        }
                        ViewBag.Detail = ListS;
                    }
                    
                }
                return View();
            }
        }
    }
}