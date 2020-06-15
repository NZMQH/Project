using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _201817380227易炽昆.Models;

namespace _201817380227易炽昆.Controllers
{
    public class RequestHouseController : Controller
    {
        HomeDBEntities db = new HomeDBEntities();
        // GET: RequestHouse
        public ActionResult Index(string Position="")
        {
            var list = db.RequestHouse.Where(p=>p.Position==Position || p.Position.Contains(Position)).ToList();
            ViewBag.list = list;
            return View();
        }
        public ActionResult AddMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddMessage(RequestHouse rent)
        {
            var user = db.User.Where(p => p.UserName == rent.Name && p.UserLogin == rent.UserLogin).FirstOrDefault();
            if (user == null)
            {
                return Content("<script>alert('未找到该客户，请重新添加');window.history.back(-1);</script>");
            }
            else
            {
                if (user.UserPhone == rent.Phone)
                {
                    db.RequestHouse.Add(rent);
                    db.SaveChanges();
                    return Content("<script >alert('添加成功');window.open('" + Url.Content("/RequestHouse/Index") + "', '_self')</script >", "text/html");
                }
                else
                {
                    return Content("<script>alert('该客户手机号输入错误，添加失败');window.history.back(-1);</script>");
                }

            }

        }
        public ActionResult DeleteMessage(int ID)
        {
            RequestHouse house = db.RequestHouse.Find(ID);
            db.RequestHouse.Remove(house);
            db.SaveChanges();
            return Content("<script >alert('删除成功');window.open('" + Url.Content("/RequestHouse/Index") + "', '_self')</script >", "text/html");
        }
    }
}