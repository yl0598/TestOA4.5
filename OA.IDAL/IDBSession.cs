﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.IDAL
{
    public interface IDBSession
    {

        IBaseDal ModelInfoDal(string dalName);
        bool SaveChanges();

    }

}
