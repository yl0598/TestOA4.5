using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OA.IDAL
{
    public interface IBaseDal<T> where T : class, new()
    {
        IQueryable<T> LoadEntities(Expression<Func<T, bool>> wherelamdba);

        IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLamdba,
            Expression<Func<T, s>> orderbyLamdba, bool isAsc
            );
        bool DeleteEntity(T entity);
        bool UpdateEntity(T entity);
        T AddEntity(T entity);
        //bool DeleteEntities(List<int> list,T entity,Expression<Func<T,bool>> wherelamdba);
    }
}
