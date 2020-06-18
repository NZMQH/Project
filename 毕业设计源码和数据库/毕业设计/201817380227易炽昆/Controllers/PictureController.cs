using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _201817380227易炽昆.Models;
using System.IO;

namespace _201817380227易炽昆.Controllers
{
    public class PictureController : Controller
    {
        HomeDBEntities db = new HomeDBEntities();
        // GET: Picture
        public ActionResult LeasePicture(string Position = "")
        {
            var list = db.LeaseHouse.Where(p => p.Position == Position || p.Position.Contains(Position)).ToList();
            ViewBag.list = list;
            return View();
        }
        public ActionResult PictureSee(int LeaseID)
        {
            LeaseHouse leasehouse = db.LeaseHouse.Find(LeaseID);
            List<Picture> list = db.Picture.Where(p => p.LeaseID == LeaseID).ToList();
            ViewBag.lease = leasehouse;
            ViewBag.list = list;
            return View();
        }
        public ActionResult PictureDelete(int ID)
        {
            var pic = db.Picture.Find(ID);
            db.Picture.Remove(pic);
            db.SaveChanges();
            return Content("<script >alert('删除成功');window.open('" + Url.Content("/Picture/PictureSee") + "', '_self')</script >", "text/html");
        }
        /// <summary>
        /// 添加图片
        /// </summary>
        /// <returns></returns>
        public ActionResult PictureAdd(int LeaseID)
        {
            LeaseHouse lease = db.LeaseHouse.Find(LeaseID);
            ViewBag.lease = lease;
            return View();
        }
        [HttpPost]
        public ActionResult PictureAdd(List<HttpPostedFileBase> file, int LeaseID)
        {
            LeaseHouse leasehouse = db.LeaseHouse.Find(LeaseID);
            if (file[0] == null)
            {
                return Content("<script>alert('请至少选择一张图片');window.history.go(-1);</script>");
            }
            else
            {
                foreach (var item in file)
                {
                    //获得文件名
                    string fileName = Path.GetFileName(item.FileName);
                    //获得文件后缀
                    string suffix = fileName.Substring(fileName.LastIndexOf(".") + 1);
                    if (suffix == "jpg" || suffix == "png" || suffix == "gif" || suffix == "jpeg")
                    {
                        item.SaveAs(Server.MapPath("~/Image/" + fileName));
                    }
                    Picture pic = new Picture
                    {
                        PictureName = fileName,
                        LeaseID = LeaseID
                    };
                    db.Picture.Add(pic);
                    db.SaveChanges();
                }
                LeaseHouse lease = db.LeaseHouse.Find(LeaseID);
                ViewBag.lease = lease;
                int num = file.Count();
                return Content("<script >alert('" + num + "张图片添加成功');window.open('" + Url.Content("/Picture/LeasePicture") + "', '_self')</script >", "text/html");
            }
        }
    }
}