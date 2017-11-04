using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA.IBLL;
using OA.Model;
using OA.Model.SearchParams;

namespace OA.BLL
{
    public class UserInfoService : BaseService<UserInfo>, IUserInfoService
    {
        //public override void SetCurrentDal()
        //{
        //    CurrentDal = this.DbSession.UserInfoDal("UserInfoDal");
        //}
        public UserInfoService()
        {
            CurrentDal = this.DbSession.ModelInfoDal("UserInfoDal");
        }

        public bool DeleteEntities(List<int> list)
        {
            var userInfos = this.DbSession.ModelInfoDal("UserInfoDal").LoadEntities(u => list.Contains(u.ID));
            if (userInfos != null)
            {
                foreach (UserInfo userInfo in userInfos)
                {
                    this.DbSession.ModelInfoDal("UserInfoDal").DeleteEntity(userInfo);
                }

            }

            return this.DbSession.SaveChanges();
        }

        #region 多条件搜索
        public IQueryable<UserInfo> LoadSearchUserInfo(UserInfoFilter userInfoFilter)
        {
            var temp = this.DbSession.ModelInfoDal("UserInfoDal").LoadEntities(c=>true);
            if (!string.IsNullOrEmpty(userInfoFilter.UName))
            {
                temp = temp.Where<UserInfo>(u=>u.UName.Contains(userInfoFilter.UName));
            }
            if (!string.IsNullOrEmpty(userInfoFilter.URemark))
            {
                temp = temp.Where<UserInfo>(u => u.Remark.Contains(userInfoFilter.URemark));
            }
            userInfoFilter.TotalCount = temp.Count();

            return temp.OrderBy<UserInfo, string>(u => u.Sort).Skip<UserInfo>((userInfoFilter.PageIndex - 1) * userInfoFilter.PageSize).Take<UserInfo>(userInfoFilter.PageSize);
        }
        #endregion


    }
}
