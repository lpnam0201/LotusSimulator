using LotusSimulator.Core.CardLogic;
using LotusSimulator.Core.CardLogic.Common;
using LotusSimulator.Core.Entities.Abilities;
using LotusSimulator.Core.Entities.Card;
using LotusSimulator.Core.Entities.GameObjects;
using LotusSimulator.Core.Entities.Mana;
using LotusSimulator.Core.Entities.Playability;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Cards.L
{
    public class LlanowarElves : CardLogic
    {
        private CardCharacteristic _characteristic;
        private GreenManaAbility _greenManaAbility;

        public LlanowarElves(GreenManaAbility greenManaAbility)
        {
            _greenManaAbility = greenManaAbility;
            InitCharacteristic();
        }

        private void InitCharacteristic()
        {
            var manaCost = new ManaCostCollection
            {
                ManaCost = new List<ManaCost>
                    {
                        new RegularManaCost() { ManaColor = ManaColor.Green }
                    }
            };

            _characteristic = new CardCharacteristic()
            {
                OracleId = "68954295-54e3-4303-a6bc-fc4547a4e3a3",
                Colors = new List<ObjectColor>
                {
                    ObjectColor.Green
                },
                ManaCost = manaCost,
                Name = "Llanowar Elves",
                Power = 1,
                Toughness = 1,
                Types = new List<ObjectType>
                {
                    ObjectType.Creature
                },
                SubTypes = new List<ObjectSubType>
                {
                    ObjectSubType.Elf
                },
                Abilities = new List<Ability>
                {
                    _greenManaAbility
                }
            };
        }

        public override void CopyStatsToCard(Card card)
        {
            _characteristic.CopyStatsToCard(card);
        }
    }
}
