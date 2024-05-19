﻿using LotusSimulator.Contract.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Client.Models
{
    public class HandDisplayModel : BaseZoneDisplayModel
    {
        public override GameObjectZone Zone => GameObjectZone.Hand;
    }
}
