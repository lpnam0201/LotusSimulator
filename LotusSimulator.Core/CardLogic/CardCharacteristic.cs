using LotusSimulator.Contract.Constants;
using LotusSimulator.Core.Entities;
using LotusSimulator.Core.Entities.Abilities;
using LotusSimulator.Core.Entities.Card;
using LotusSimulator.Core.Entities.Counters;
using LotusSimulator.Core.Entities.GameObjects;
using LotusSimulator.Core.Entities.Mana;
using LotusSimulator.Core.Entities.Playability;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.CardLogic
{
    public class CardCharacteristic
    {
        public string OracleId { get; set; }
        public string Name { get; set; }
        public ManaCostCollection ManaCost { get; set; } = new ManaCostCollection();
        public IList<ObjectColor> Colors { get; set; } = new List<ObjectColor>();
        public List<ObjectType> Types { get; set; } = new List<ObjectType>();
        public IList<ObjectSuperType> SuperTypes { get; set; } = new List<ObjectSuperType>();
        public IList<ObjectSubType> SubTypes { get; set; } = new List<ObjectSubType>();
        public IList<Ability> Abilities { get; set; } = new List<Ability>();
        public MtgNumber Power { get; set; }
        public MtgNumber Toughness { get; set; }
        public IList<Counter> StartingLoyaltyCounters { get; set; } = new List<Counter>();

        public void CopyStatsToCard(Card card)
        {
            card.OracleId = OracleId;
            card.Name = Name;
            card.ManaCost = ManaCost;
            card.Colors = Colors;
            card.Types = Types;
            card.SuperTypes = SuperTypes;
            card.SubTypes = SubTypes;
            card.Power = Toughness;
            card.LoyaltyCounters = StartingLoyaltyCounters;
        }
    }
}
