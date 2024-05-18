using LotusSimulator.Core.CardLogic;
using LotusSimulator.Core.Entities.Card;
using LotusSimulator.Core.Entities.GameObjects;
using LotusSimulator.Core.Entities.Mana;
using LotusSimulator.Core.Entities.Playability;
using LotusSimulator.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Cards.C
{
    public class ColossalDreadmaw : CardLogic
    {
        private CardCharacteristic _characteristic;

        public ColossalDreadmaw()
        {
            InitCharacteristic();
        }

        private void InitCharacteristic()
        {
            var manaCost = new ManaCostCollection
            {
                ManaCost = new List<ManaCost>
                    {
                        new GenericManaCost(),
                        new GenericManaCost(),
                        new GenericManaCost(),
                        new GenericManaCost(),
                        new GenericManaCost(),
                        new RegularManaCost() { ManaColor = ManaColor.Green }
                    }
            };

            _characteristic = new CardCharacteristic()
            {
                OracleId = "08c7db90-c0cf-4482-b7ee-bb033e5996d2",
                Colors = new List<ObjectColor>
                {
                    ObjectColor.Green
                },
                ManaCost = manaCost,
                Name = "Colossal Dreadmaw",
                Power = 6,
                Toughness = 6,
                Types = new List<ObjectType>
                {
                    ObjectType.Creature
                },
                SubTypes = new List<ObjectSubType>
                {
                    ObjectSubType.Dinosaur
                }
            };
        }

        public override void CopyStatsToCard(Card card)
        {
            _characteristic.CopyStatsToCard(card);
        }
    }
}
