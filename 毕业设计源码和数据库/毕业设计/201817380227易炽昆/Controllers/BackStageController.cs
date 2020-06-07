using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _201817380227易炽昆.Models;

namespace _201817380227易炽昆.Controllers
{
    public class BackStageController : Controller
    {
        HomeDBEntities db = new HomeDBEntities();
        // GET: BackStage
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UserMsg(string UserName="")
        {
            var list = db.User.Where(p=>p.UserName==UserName || p.UserName.Contains(UserName)).ToList();
            ViewBag.list = list;
            return View();
        }
    }
}