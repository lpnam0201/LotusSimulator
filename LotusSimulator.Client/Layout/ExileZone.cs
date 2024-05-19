using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Client.Layout
{
    public class ExileZone : IPlayerIdentity
    {
        public IList<Card.CardZone> Cards = new List<Card.CardZone>();

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string ConnectionId { get; set; }

        public ExileZone()
        {
            Cards = new List<Card.CardZone>();
            for (int i = 0; i < 6; i++)
            {
                Cards.Add(new Card.CardZone());
            }
        }

        public void Draw(GameTime gameTime)
        {

            for (int i = 0; i < Cards.Count; i++)
            {
                var card = Cards[i];
                card.X = X - i;
                card.Y = Y - i;
                card.Draw(gameTime);
            }

        }

        public void Update(GameTime gameTime)
        {
            Cards.Clear();

            var exile = GlobalInstances.GameDisplayModel.GetExile(ConnectionId);
            foreach (var gameObject in exile.GameObjects)
            {
                var card = new Card.CardZone();
                card.Id = gameObject.Id;
                card.OracleId = gameObject.OracleId;
                card.IsRevealed = gameObject.IsRevealed;
                Cards.Add(card);
            }
        }
    }
}
