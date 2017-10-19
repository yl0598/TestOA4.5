using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA.IBLL;
using OA.Model;

namespace OA.BLL
{
    public class UserInfoService : BaseService<UserInfo>, IUserInfoService
    {
        public override void SetCurrentDal()
        {
            CurrentDal = this.DbSession.UserInfoDal;
        }

        public bool DeleteEntities(List<int> list)
        {
            var userInfos = this.DbSession.UserInfoDal.LoadEntities(u => list.Contains(u.ID));
            if (userInfos != null)
            {
                foreach (UserInfo userInfo in userInfos)
                {
                    this.DbSession.UserInfoDal.DeleteEntity(userInfo);
                }

            }

            return this.DbSession.SaveChanges();
        }



    }
}
