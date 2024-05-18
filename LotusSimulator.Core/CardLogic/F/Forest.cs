using LotusSimulator.Core.CardLogic;
using LotusSimulator.Core.CardLogic.Common;
using LotusSimulator.Core.Entities.Abilities;
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

namespace LotusSimulator.Cards.F
{
    public class Forest : CardLogic
    {
        private CardCharacteristic _characteristic;
        private GreenManaAbility _greenManaAbility;

        public Forest(GreenManaAbility greenManaAbility)
        {
            _greenManaAbility = greenManaAbility;
            InitCharacteristic();
        }

        private void InitCharacteristic()
        {
            _characteristic = new CardCharacteristic()
            {
                OracleId = "b34bb2dc-c1af-4d77-b0b3-a0fb342a5fc6",
                Colors = new List<ObjectColor>
                {
                    ObjectColor.Colorless
                },
                Name = "Forest",
                Types = new List<ObjectType>
                {
                    ObjectType.Land
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
