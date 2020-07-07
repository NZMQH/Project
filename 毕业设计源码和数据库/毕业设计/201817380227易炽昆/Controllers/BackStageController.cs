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
            //用户数量
            int users = db.User.ToList().Count();
            //出租房数量
            int leaseHouses = db.LeaseHouse.ToList().Count();
            //出租房订单数量
            int leases = db.Lease.ToList().Count();
            //出售房数量
            int sellHouses = db.SellHouse.ToList().Count();
            //全款订单数量
            int buy = db.BuyHouse.ToList().Count();
            //分期订单数量
            int stageBuy = db.StagesBuyHouse.ToList().Count();
            //求租信息数量
            int request = db.RequestHouse.ToList().Count();


            ViewBag.users = users;
            ViewBag.leaseHouses = leaseHouses;
            ViewBag.leases = leases;
            ViewBag.sellHouses = sellHouses;
            ViewBag.buy = buy;
            ViewBag.stageBuy = stageBuy;
            ViewBag.request = request;

            return View();
        }
        public ActionResult UserMsg(string UserName = "")
        {
            var list = db.User.Where(p => p.UserName == UserName || p.UserName.Contains(UserName)).ToList();
            ViewBag.list = list;
            return View();
        }
        [HttpPost]
        public ActionResult UserMsg()
        {
            var list = db.User.Where(p => p.State == 1).ToList();
            ViewBag.list = list;
            return View();
        }
        /// <summary>
        /// 查看客户信息
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public ActionResult UserSee(int UserID)
        {
            User user = db.User.Find(UserID);
            ViewBag.user = user;
            return View();
        }
        /// <summary>
        /// 客户信息修改
        /// </summary>
        /// <returns></returns>
        public ActionResult UserEdit(int UserID)
        {
            User user = db.User.Find(UserID);
            ViewBag.user = user;
            return View();
        }
        [HttpPost]
        public ActionResult UserEdit(User user)
        {
            var rent = db.RequestHouse.Where(p => p.Name == user.UserName && p.Phone == user.UserPhone).ToList();
            if (rent.Count > 0)
            {
                foreach (var item in rent)
                {
                    item.Name = user.UserName;
                    item.Phone = user.UserPhone;
                    if (item.ReqAge!=null)
                    {
                        item.ReqAge = user.UserAge;
                    }
                }
            }
            User userEdit = db.User.Find(user.UserID);
            userEdit.UserName = user.UserName;
            userEdit.UserLogin = user.UserLogin;
            userEdit.UserPwd = user.UserPwd;
            userEdit.UserSex = user.UserSex;
            userEdit.UserAge = user.UserAge;
            userEdit.UserPhone = user.UserPhone;
            userEdit.State = user.State;
            db.SaveChanges();
            ViewBag.user = userEdit;
            //return RedirectToAction("UserEdit", "BackStage",new { UserID= userEdit.UserID});
            return Content("<script >alert('保存成功');window.open('" + Url.Content("/BackStage/UserEdit?UserID=" + userEdit.UserID) + "', '_self')</script >", "text/html");
        }
        /// <summary>
        /// 删除客户
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteUser(int UserID)
        {
            var user = db.User.Find(UserID);
            //2为注销状态，此处用来做标记删除
            user.State = 1;
            db.SaveChanges();
            return Content("<script >alert('删除成功');window.open('" + Url.Content("/BackStage/UserMsg") + "', '_self')</script >", "text/html");
        }
    }
}