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

namespace LotusSimulator.Cards.F
{
    public class Forest : CardLogic
    {
        private CardCharacteristic _characteristic;

        public Forest()
        {
            InitCharacteristic();
        }

        private void InitCharacteristic()
        {
            _characteristic = new CardCharacteristic()
            {
                Colors = new List<ObjectColor>
                {
                    ObjectColor.Colorless
                },
                Name = "Forest",
                Types = new List<ObjectType>
                {
                    ObjectType.Land
                }
            };
        }

        public override void CopyStatsToCard(Card card)
        {
            _characteristic.CopyStatsToCard(card);
        }
    }
}
