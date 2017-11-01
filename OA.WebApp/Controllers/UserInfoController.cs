using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OA.Model;
using OA.Model.Enum;
using OA.Model.SearchParams;

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
            int totalCount=0;
            string name = Request["name"];
            string remark = Request["remark"];
            UserInfoFilter userInfoFilter = new UserInfoFilter()
            {
                UName = name,
                URemark=remark,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalCount = totalCount
            };
          var userlist=  userInfoService.LoadSearchUserInfo(userInfoFilter);
          //  short deletetype = (short)DeleteEnumType.Nomal;
          //  var userlist = userInfoService.LoadPageEntities<string>(pageIndex, pageSize, out totalCount, c => c.DelFlag == deletetype, c => c.Sort, true);
            var temp = from u in userlist
                       select new { ID = u.ID, UName = u.UName, UPwd = u.UPwd, Remark = u.Remark, SubTime = u.SubTime,DelFlag=u.DelFlag,Sort=u.Sort
 };


            return Json(new { rows = temp, total = userInfoFilter.TotalCount }, JsonRequestBehavior.AllowGet);

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

        #region 修改用户
        public ActionResult EditUserInfo(UserInfo userInfo) {
            userInfo.ModifiedOn = DateTime.Now;
           if(userInfoService.UpdateEntity(userInfo))
            {
                return Content("OK");
            }
            else
            {
                return Content("not OK!");
            }
        }

        #endregion

    }
}