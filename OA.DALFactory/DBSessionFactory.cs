using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using OA.IDAL;

namespace OA.DALFactory
{
    public class DBSessionFactory
    {
        public static IDBSession CreateDBSession()
        {
            IDBSession dbsession = (IDBSession)CallContext.GetData("dbSession");
            if (dbsession == null)
            {
                dbsession = new DbSession();
                CallContext.SetData("dbSession", dbsession);
            }
            return dbsession;
        }

    }
}
