﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessMultipleExpceptions
{
    internal class Radio
    {
        public void TurnOn(bool on)
        {
            Console.WriteLine(on ? "Играет" : "Не играет");
        }
    }
}
