﻿using LotusSimulator.Contract.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Contract.MessageOut
{
    public class GameObjectDto
    {
        public string OracleId { get; set; }
        public bool IsRevealed { get; set; }
        public string Id { get; set; }
        public bool IsTapped { get; set; }
        public List<ObjectType> Types { get; set; } = new List<ObjectType>();
        public List<PlayabilityDto> Playabilities { get; set; } = new List<PlayabilityDto>();
    }
}
