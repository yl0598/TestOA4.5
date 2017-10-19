using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OA.Model;
using System.Data.Entity;
namespace OA.DAL
{
    public class BaseDal<T> where T : class, new()
    {
        DbContext Db = DBContextFactory.CreateDbContext();//完成EF上下文创建.
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T AddEntity(T entity)
        {
            Db.Entry<T>(entity).State = EntityState.Added;
            //  Db.SaveChanges();
            return entity;
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteEntity(T entity)
        {
            Db.Entry<T>(entity).State = EntityState.Deleted;
            // return Db.SaveChanges() > 0;
            return true;
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="wherelamdba"></param>
        /// <returns></returns>
        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> wherelamdba)
        {
            return Db.Set<T>().Where<T>(wherelamdba);
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="s">排序约束</typeparam>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页显示记录数</param>
        /// <param name="totalCount">总条数</param>
        /// <param name="whereLamdba">过滤条件</param>
        /// <param name="orderbyLamdba">排序条件</param>
        /// <param name="isAsc">排序方式</param>
        /// <returns></returns>
        public IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLamdba, Expression<Func<T, s>> orderbyLamdba, bool isAsc)
        {
            var temp = Db.Set<T>().Where<T>(whereLamdba);
            totalCount = temp.Count();
            if (isAsc)//升序
            {
                temp = temp.OrderBy<T, s>(orderbyLamdba).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            }
            else
            {
                temp = temp.OrderByDescending<T, s>(orderbyLamdba).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            }

            return temp;
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool UpdateEntity(T entity)
        {
            Db.Entry<T>(entity).State = EntityState.Modified;
            // return Db.SaveChanges() > 0;
            return true;
        }




    }
}
