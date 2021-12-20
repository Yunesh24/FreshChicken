using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreshChicken.Controllers.Orderform
{
    public class orderController : Controller
    {
        // GET: order
        public ActionResult Index()
        {
            return View();
        }
    }
}