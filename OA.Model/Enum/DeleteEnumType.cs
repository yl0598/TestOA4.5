﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Model.Enum
{
    public enum DeleteEnumType
    {
        /// <summary>
        /// 正常显示
        /// </summary>
        Nomal = 0,
        /// <summary>
        /// 逻辑删除
        /// </summary>
        LogicDelete = 1,
        /// <summary>
        /// 物理删除
        /// </summary>
        PhyicDelete = 2

    }
}
