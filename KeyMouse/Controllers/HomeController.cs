using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KeyMouse.Models;
using Newtonsoft.Json;
using System.Text;
using System.Data;
using DoorLaw.Web.Models;

namespace KeyMouse.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            if (Session["user"] == null)
                return RedirectToAction("Logon", "Home");
            return View();
        }
        public ActionResult Header()
        {
            return View();
        }
        public ActionResult Left()
        {
            return View();
        }
        public ActionResult Main()
        {
            return View();
        }

        public ActionResult Setup()
        {
            return View();
        }

        public void LogOff()//注销
        {
            Session.Abandon();  //把当前Session对象删除了
            Session.Clear();  //把Session对象中的所有项目都删除了
            Response.Redirect("./Index");

        }
        #region 登录
        public ActionResult Logon()
        {
            return View();
        }
        [HttpPost]
        public string LogOn(decimal userphone, string pwd)
        {
            try
            {
                using (var db = new KeyMouseEntities())
                {
                    var user = db.dl_basic_user.Where(p => p.userphone == userphone && p.userpwd == pwd && p.isDel == false).FirstOrDefault();
                    if (user != null)
                    {
                        Session["user"] = user;
                        return "success";
                    }
                    else
                    {
                        return "密码有误！";
                    }
                }
            }
            catch (Exception ex)
            {
                return "用户名有误！" + ex.Message;
            }
        }
        #endregion
        #region 注册
        public ActionResult Regist()
        {
            return View();
        }
        [HttpPost]//保存new user
        public string Save(string json)
        {
            JsonObject obj = new JsonObject(json);
            var phone = decimal.Parse(obj["phone"].Value.ToString());
            string username = obj["user"].Value.ToString();
            string userpwd = obj["passwd"].Value.ToString();
            System.DateTime com_starttime = new System.DateTime();
            com_starttime = DateTime.Now;
            try
            {
                using (var db = new KeyMouseEntities())
                {
                    var uuser = db.dl_basic_user.FirstOrDefault(x => x.userphone == phone && x.isDel == false);
                    if (uuser == null)
                    {
                        var user = new dl_basic_user()
                        {
                            userpwd = userpwd,
                            jointime = com_starttime,
                            userphone = phone,
                            username = username,
                            isDel = false
                        };
                        db.dl_basic_user.Add(user);
                        db.SaveChanges();

                        var nuser = new sys_user_role()
                        {
                            userid = user.userid,
                            rid = 2
                        };
                        db.sys_user_role.Add(nuser);
                        db.SaveChanges();
                        return "success";
                    }
                    else
                    {
                        return "existed";
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion
    }
}