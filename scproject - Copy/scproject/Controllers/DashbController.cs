using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace scproject.Controllers
{
    public class DashbController : Controller
    {
        // GET: Dashb
        public ActionResult Index()
        {
            HttpCookie cookie = Request.Cookies["Category"];
            if (cookie != null)
            {
                ViewBag.Message = Request.Cookies["Category"].Value.ToString();
            }
            else
            {
                return RedirectToAction("Index","Admin");
            }
            return View();
        }
    }
}