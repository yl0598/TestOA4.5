using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA.Model;
using OA.Model.SearchParams;

namespace OA.IBLL
{
    /// <summary>
    /// 批量删除
    /// </summary>
    public interface IUserInfoService : IBaseService<UserInfo>
    {
        bool DeleteEntities(List<int> list);
        IQueryable<UserInfo> LoadSearchUserInfo(UserInfoFilter userInfoFilter);
    }

    
}
