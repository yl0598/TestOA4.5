using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Model.SearchParams
{
   public class UserInfoFilter: BaseParams
    {
        public string UName { get; set; }
        public string URemark { get; set; }
    }
}
