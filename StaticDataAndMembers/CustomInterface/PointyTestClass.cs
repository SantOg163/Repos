﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterface
{
    internal class PointyTestClass : IPointy
    {
        public byte Points => throw new NotImplementedException();
    }
}
