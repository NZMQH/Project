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
        public ActionResult UserMsg(string UserName = "")
        {
            var list = db.User.Where(p => p.UserName == UserName || p.UserName.Contains(UserName)).ToList();
            ViewBag.list = list;
            return View();
        }
        [HttpPost]
        public ActionResult UserMsg()
        {
            var list = db.User.Where(p => p.State == 2).ToList();
            ViewBag.list=list;
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
            return Content("<script >alert('保存成功');window.open('" + Url.Content("/BackStage/UserEdit?UserID="+userEdit.UserID) + "', '_self')</script >", "text/html");
        }
        /// <summary>
        /// 删除客户
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteUser(int UserID)
        {
            var user = db.User.Find(UserID);
            //2为注销状态，此处用来做标记删除
            user.State = 2;
            db.SaveChanges();
            return RedirectToAction("UserMsg", "BackStege");
        }
    }
}