﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Contract.MessageOut
{
    public class HandDto
    {
        public IList<CardDto> Cards { get; set; } = new List<CardDto>();
    }
}