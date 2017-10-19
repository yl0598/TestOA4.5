using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OA.Model;
using OA.Model.Enum;

namespace OA.WebApp.Controllers
{
    public class UserInfoController : Controller
    {
        IBLL.IUserInfoService userInfoService = new BLL.UserInfoService();
        public ActionResult Index()
        {

            return View();
        }
        #region 获取用户信息

        public ActionResult GetUserInfo()
        {
            int pageIndex = int.Parse(Request["page"]);
            int pageSize = int.Parse(Request["rows"]);
            int totalCount;
            short deletetype = (short)DeleteEnumType.Nomal;
            var userlist = userInfoService.LoadPageEntities<int>(pageIndex, pageSize, out totalCount, c => c.DelFlag == deletetype, c => c.ID, true);
            var temp = from u in userlist
                       select new { ID = u.ID, UName = u.UName, UPwd = u.UPwd, Remark = u.Remark, SubTime = u.SubTime };


            return Json(new { rows = temp, total = totalCount }, JsonRequestBehavior.AllowGet);

        }
        #endregion
        #region 删除用户
        public ActionResult DeleteUserInfo()
        {

            string strid = Request["strid"];
            string[] strids = strid.Split(',');
            List<int> list = new List<int>();
            foreach (var id in strids)
            {
                list.Add(int.Parse(id));

            }

            if (userInfoService.DeleteEntities(list))
            {
                return Content("OK");
            }
            else
            {
                return Content("buok");
            }


        }

        #endregion
        #region 添加用户信息

        public ActionResult AddUserInfo(UserInfo userinfo)
        {
            userinfo.SubTime = DateTime.Now;
            userinfo.ModifiedOn = DateTime.Now;
            userinfo.Sort ="0";
            userinfo.DelFlag = 0;
            userInfoService.AddEntity(userinfo);

            //  return Redirect("Index");
            return Content("ok");
        }

        #endregion

    }
}