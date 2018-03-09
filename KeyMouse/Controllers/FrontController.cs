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
    public class FrontController : Controller
    {
        //
        // GET: /Front/
        public ActionResult Index()
        {
            return View();
        }
        #region 资料设置
        public ActionResult Setup() //资料设置
        {
            dl_basic_user user = Session["user"] as dl_basic_user;
            decimal userid1 = user.userid;
            KeyMouseEntities db = new KeyMouseEntities();
            dl_basic_user dd = db.dl_basic_user.Where(s => s.userid == userid1).First();
            ViewData["userid"] = dd.userid;//用户ID，手机号码
            ViewData["userphone"] = dd.userphone;
            ViewData["username"] = dd.username;
            ViewData["jointime"] = dd.jointime;
            ViewData["comment"] = dd.comment;
            ViewData["option1"] = dd.option1;
            ViewData["option2"] = dd.option2;
            ViewData["option3"] = dd.option3;
            return View();
        }
        [HttpPost]//保存新资料
        public string SaveM(string json)
        {
            JsonObject obj = new JsonObject(json);
            dl_basic_user user = Session["user"] as dl_basic_user;
            decimal userid = user.userid;
            decimal userphone = decimal.Parse(obj["userphone"].Value.ToString());
            string username = obj["username"].Value.ToString();
            string comment = obj["comment"].Value.ToString();
            string option1 = obj["option1"].Value.ToString();
            try
            {
                using (var db = new KeyMouseEntities())
                {
                    var uuser = db.dl_basic_user.FirstOrDefault(x => x.userid == userid);
                    if (uuser != null)
                    {
                        uuser.userphone = userphone;
                        uuser.username = username;
                        uuser.comment = comment;
                        uuser.option1 = option1;
                    }
                    if (db.SaveChanges() > 0)
                        return "success";
                    else
                        return "existed";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion
        #region 修改密码
        public ActionResult ChangePwd()
        {
            dl_basic_user user = Session["user"] as dl_basic_user;
            decimal userid1 = user.userid;
            KeyMouseEntities db = new KeyMouseEntities();
            dl_basic_user dd = db.dl_basic_user.Where(s => s.userid == userid1).First();
            ViewData["username"] = dd.username;//获取用户密码的值
            ViewData["userid"] = dd.userid;
            ViewData["userpwd"] = dd.userpwd;
            return View();
        }
        [HttpPost]//保存SaveNewPassword
        public ActionResult SaveNewPassword(string newPassword, string old, decimal userid)
        {
            var result = new ResultInfo(false);
            try
            {
                using (var db = new KeyMouseEntities())
                {
                    var user = db.dl_basic_user.FirstOrDefault(s => s.userid == userid);
                    if (user.userpwd != old)
                    {
                        result.IsSucceed = false;
                        result.Message = "原密码错误！";
                        return Json(result);
                    }
                    user.userpwd = newPassword;
                    if (db.SaveChanges() > 0)
                    {
                        result.IsSucceed = true;
                    }
                    else
                    {
                        result.IsSucceed = false;
                    }
                }
            }
            catch (Exception e)
            {
                result.IsSucceed = false;
                result.Message = e.Message;
            }
            return Json(result);
        }
        #endregion
        #region 写日记
        public ActionResult CreatPassage()
        {
            dl_basic_user user = Session["user"] as dl_basic_user;
            decimal userid1 = user.userid;
            KeyMouseEntities db = new KeyMouseEntities();
            dl_basic_user dd = db.dl_basic_user.Where(s => s.userid == userid1).First();
            ViewData["userid"] = dd.userid;
            return View();
        }
        public ActionResult SaveNewPassage(string newPassage, DateTime starttime, decimal userid)
        {
            var result = new ResultInfo(false);
            System.DateTime endtime = new System.DateTime();
            endtime = DateTime.Now;
            try
            {
                using (var db = new KeyMouseEntities())
                {
                        var passage = new t_f_data()
                        {
                            userid = userid,
                            content = newPassage,
                            starttime = starttime,
                            endtime = endtime,
                        };
                        db.t_f_data.Add(passage);
                    if(db.SaveChanges() > 0)
                    {
                        result.IsSucceed = true;
                    }
                    else
                    {
                        result.IsSucceed = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.IsSucceed = false;
            }
            return Json(result);
        }
        #endregion
        #region 日记列表
        public ActionResult DayNoteList()
        {
            return View();
        }
        public ActionResult DayNotePage(string pid)
        {
            KeyMouseEntities db = new KeyMouseEntities();
            decimal pid1 = decimal.Parse(pid);
            t_f_data dd = db.t_f_data.Where(s => s.did == pid1).First();
            ViewData["did"] = dd.did;//编号
            ViewData["endtime"] = dd.endtime;//时间
            ViewData["content"] = dd.content;//内容
            return View();
        }
        #endregion
    }
}