using LotusSimulator.Core.CardLogic;
using LotusSimulator.Core.Entities.Card;
using LotusSimulator.Core.Entities.GameObjects;
using LotusSimulator.Core.Entities.Mana;
using LotusSimulator.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Cards.A.ArchangelOfTithes
{
    public class ArchangelOfTithes : CardLogic
    {
        private CardCharacteristic _characteristic;

        public ArchangelOfTithes()
        {
            InitCharacteristic();
        }

        private void InitCharacteristic()
        {
            _characteristic = new CardCharacteristic()
            {
                Colors = new List<ObjectColor>
                {
                    ObjectColor.White
                },
                ManaCost = new ManaCostCollection
                {
                    ManaCost = new List<ManaCost>
                    {
                        new GenericManaCost(),
                        new RegularManaCost() { ManaColor = ManaColor.White },
                        new RegularManaCost() { ManaColor = ManaColor.White },
                        new RegularManaCost() { ManaColor = ManaColor.White }
                    }
                },
                Name = "Archangel of Tithes",
                Power = 3,
                Toughness = 5,
                Types = new List<ObjectType>
                {
                    ObjectType.Creature
                },
                SubTypes = new List<ObjectSubType>
                {
                    ObjectSubType.Angel
                }
            };
        }

        public override void CopyStatsToCard(Card card)
        {
            _characteristic.CopyStatsToCard(card);
        }
    }
}
