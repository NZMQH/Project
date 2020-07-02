using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _201817380227易炽昆.Models;

namespace _201817380227易炽昆.Controllers
{
    public class PersonalController : Controller
    {
        HomeDBEntities db = new HomeDBEntities();
        // GET: Personal
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User user)
        {
            User user1 = db.User.Find(user.UserID);
            user1.UserID = user.UserID;
            user1.UserLogin = user.UserLogin;
            user1.UserPwd = user.UserPwd;
            user1.UserName = user.UserName;
            user1.UserAge = user.UserAge;
            user1.UserSex = user.UserSex;
            user1.UserPhone = user.UserPhone;
            user1.State = user.State;
            List<RequestHouse> requestHouse = db.RequestHouse.Where(p => p.Name == user1.UserName).ToList();
            foreach (var item in requestHouse)
            {
                item.Phone = user1.UserPhone;
            }
            db.SaveChanges();
            Session["User"] = user1;
            return Content("<script >alert('修改成功');window.open('" + Url.Content("/Personal/Index") + "', '_self')</script >", "text/html");
        }
        /// <summary>
        /// 用户租房信息
        /// </summary>
        /// <returns></returns>
        public ActionResult LeaseMessage(int UserID)
        {
            List<Lease> list = db.Lease.Where(p => p.UserID == UserID).ToList();
            return View();
        }
        /// <summary>
        /// 用户购房信息
        /// </summary>
        /// <returns></returns>
        public ActionResult SellMessage(int UserID)
        {
            List<BuyHouse> buyList = db.BuyHouse.Where(p => p.UserID == UserID).ToList();
            List<StagesBuyHouse> stageBuyList = db.StagesBuyHouse.Where(p => p.UserID == UserID).ToList();
            return View();
        }
    }
}