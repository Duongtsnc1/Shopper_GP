using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopProject.Areas.Administrator.Controllers
{
    public class OdersController : Controller
    {
        Models.AdminContext dbCate = new Models.AdminContext();
        // GET: Administrator/Oders
        [HandleError]
        public ActionResult Index(string error)
        {
            if (Session["accname"] == null)
            {
                Session["accname"] = null;
                return RedirectToAction("Login", "Account");
            }
            else
            {
                ViewBag.CateError = error;
                var modelCate = dbCate.Orders.ToList();
                return View(modelCate);
            }
        }
    }
}