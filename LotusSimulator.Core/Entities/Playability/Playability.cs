﻿using LotusSimulator.Contract.Constants;
using LotusSimulator.Core.Entities.Mana;
using LotusSimulator.Core.Entities.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.Entities.Playability
{
    public class Playability
    {
        public string AssociatedObjectId { get; set; }
        public PlayabilityType Type { get; set; }
        public PlayabilityLocation Location { get; set; }
        public Player PlayableBy { get; set; }
        public string Text { get; set; }

        public static Playability PlayAsLand(string associatedObjectId, Player player)
        {
            return new Playability()
            {
                AssociatedObjectId = associatedObjectId,
                Type = PlayabilityType.PlayAsLand,
                Location = PlayabilityLocation.Hand,
                PlayableBy = player,
                Text = "Play"
            };
        }

        public static Playability Cast(string associatedObjectId, ManaCostCollection cost, Player player)
        {
            return new Playability()
            {
                AssociatedObjectId = associatedObjectId,
                Type = PlayabilityType.Cast,
                Location = PlayabilityLocation.Hand,
                PlayableBy = player,
                Text = "Cast" // todo add cost
            };
        }

        public bool IsSame(Playability other)
        {
            return Type == other.Type
                && Location == other.Location
                && PlayableBy == other.PlayableBy;
        }
    }
}
