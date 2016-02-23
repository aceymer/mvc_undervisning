using Jysk2_0.ToastrHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jysk2_0.Controllers
{
    public class HomeController : AbstractMessageController
    {
        public ActionResult Index()
        {
            AddToastMessage("Welcome", "Index opened", ToastType.Error);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
    }
}