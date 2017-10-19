using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using OA.IDAL;

namespace OA.DALFactory
{
    /// <summary>
    /// 抽象工厂通过反射方式创建类的实例
    /// </summary>
    public class DALAbstractFactory
    {
        private static string DalNameSpace = ConfigurationManager.AppSettings["DalNameSpace"];//获取命名空间
        private static string DalAssembly = ConfigurationManager.AppSettings["DalAssembly"];
        public static IUserInfoDal CreateUserInfo()
        {
            string fullClassName = DalNameSpace + ".UserInfoDal";
            return CreateInstance(fullClassName, DalAssembly) as IUserInfoDal;

        }
        private static object CreateInstance(string fullClassName, string assemblyPath)
        {
            var assembly = Assembly.Load(assemblyPath);//加载程序集
            return assembly.CreateInstance(fullClassName);
        }
    }
}
