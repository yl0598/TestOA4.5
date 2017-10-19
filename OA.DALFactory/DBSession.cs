using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA.DAL;
using OA.IDAL;

namespace OA.DALFactory
{
    public class DbSession : IDBSession
    {
        //  DbContext Db = new OAEntities();
        public DbContext Db { get { return DBContextFactory.CreateDbContext(); } }

        private IUserInfoDal _UserInfoDal;


        public IUserInfoDal UserInfoDal
        {

            get
            {
                if (_UserInfoDal == null)
                {
                    _UserInfoDal = DALAbstractFactory.CreateUserInfo();

                }
                return _UserInfoDal;
            }

            set { _UserInfoDal = value; }
        }


        /// <summary>
        /// 保存数据,，一个业务可能涉及到多张表的操作，先将操作的数据追加到EF上下文中，然后一次性操作
        /// </summary>
        /// <returns></returns>
        public bool SaveChanges()
        {
            return Db.SaveChanges() > 0;
        }
    }
}
