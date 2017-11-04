using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OA.DALFactory;
using OA.IDAL;

namespace OA.BLL
{
    public  class BaseService<T> where T : class, new()
    {
        public IDBSession DbSession
        {
            get
            {
                //return new DbSession();
                return DBSessionFactory.CreateDBSession();
            }
        }

        public IDAL.IBaseDal<T> CurrentDal { get; set; }

       // public abstract void SetCurrentDal();

//        public BaseService() { SetCurrentDal(); }//子类必须实现该抽象方法
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="wherelamdba"></param>
        /// <returns></returns>
        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> wherelamdba)
        {

            return this.CurrentDal.LoadEntities(wherelamdba);
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="s"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <param name="whereLamdba"></param>
        /// <param name="orderbyLamdba"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLamdba, Expression<Func<T, s>> orderbyLamdba, bool isAsc)
        {


            return this.CurrentDal.LoadPageEntities<s>(pageIndex, pageSize, out totalCount, whereLamdba, orderbyLamdba, isAsc);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteEntity(T entity)
        {
            this.CurrentDal.DeleteEntity(entity);
            return this.DbSession.SaveChanges();
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool UpdateEntity(T entity)
        {
            this.CurrentDal.UpdateEntity(entity);
            return this.DbSession.SaveChanges();

        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T AddEntity(T entity)
        {
            this.CurrentDal.AddEntity(entity);
            this.DbSession.SaveChanges();
            return entity;
        }
        //public bool DeleteEntities(Expression<Func<T,bool>> wherelamdba)
        //{
        //   var Info= this.CurrentDal.LoadEntities(wherelamdba);
        //    if(Info != null)
        //    {
        //        foreach(var infos in Info)
        //        {
        //            this.CurrentDal.DeleteEntity(infos);
        //        }

        //    }
        //    return this.DbSession.SaveChanges();
        //}
    }
}
