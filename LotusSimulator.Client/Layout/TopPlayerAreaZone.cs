using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LotusSimulator.Client.Layout
{
    public class TopPlayerAreaZone : IPlayerIdentity
    {
        private const int HandWidth = 700;
        private const int HandHeight = 70;

        private const int DeckDistFromLeft = 40;
        private const int DeckDistFromTop = 120;

        private const int DeckGraveyardGap = 10;

        private const int GraveyardDistFromLeft = 40;
        private const int GraveyardDistFromTop = DeckDistFromTop + 70 + DeckGraveyardGap;

        private const int GraveyardExileGap = 10;

        private const int ExileDistFromLeft = 40;
        private const int ExileDistFromTop = GraveyardDistFromTop + 70 + GraveyardExileGap;

        private const int LandZoneWidth = 700;
        private const int LandZoneHeight = 70;
        private const int LandZoneDistFromTop = 120;

        private const int LandArtifactEnchantmentGap = 10;

        private const int ArtifactEnchantmentZoneWidth = 700;
        private const int ArtifactEnchantmentZoneHeight = 70;
        private const int ArtifactEnchantmentZoneDistFromTop = LandZoneDistFromTop + LandZoneHeight + LandArtifactEnchantmentGap;

        private const int ArtifactEnchantmentCreatureGap = 10;

        private const int CreaturePlaneswalkerBattleZoneWidth = HandWidth;
        private const int CreaturePlaneswalkerBattleZoneHeight = 70 * 2 + 10;
        private const int CreaturePlaneswalkerBattleZoneDistFromTop = ArtifactEnchantmentZoneDistFromTop + ArtifactEnchantmentZoneHeight + ArtifactEnchantmentCreatureGap;

        private const int PriorityDistFromTop = 40;

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string ConnectionId { get; set; }

        private Hand.HandZone _hand { get; set; } = new Hand.HandZone();
        private Deck.DeckZone _deck { get; set; } = new Deck.DeckZone();
        private GraveyardZone _graveyard { get; set; } = new GraveyardZone();
        private ExileZone _exile { get; set; } = new ExileZone();
        private LandZone _landZone { get; set; } = new LandZone();
        private CreaturePlaneswalkerBattleZone _creaturePlaneswalkerBattleZone { get; set; } = new CreaturePlaneswalkerBattleZone();
        private ArtifactEnchantmentZone _artifactEnchantmentZone { get; set; } = new ArtifactEnchantmentZone();
        private PlaneswalkerAndBattleZone _planeswalkerAndBattleZone { get; set; } = new PlaneswalkerAndBattleZone();
        private LifeBar _lifeBar { get; set; } = new LifeBar();
        private Priority _priority { get; set; } = new Priority();

        public void Draw(GameTime gameTime)
        {
            var greenBar = new Texture2D(GlobalInstances.GraphicsDevice, 1, 1);
            greenBar.SetData(new[] { Color.Yellow });
            GlobalInstances.SpriteBatch.Draw(greenBar, new Rectangle(X, Y, Width, Height), Color.White);

            DrawHand(gameTime);
            DrawDeck(gameTime);
            DrawGraveyard(gameTime);
            DrawExile(gameTime);
            DrawLandZone(gameTime);
            DrawArtifactEnchantmentZone(gameTime);
            DrawCreaturePlaneswalkerBattleZone(gameTime, CreaturePlaneswalkerBattleZoneDistFromTop);

            DrawPriority(gameTime);
        }

        private void DrawHand(GameTime gameTime)
        {
            _hand.X = X + (Width - HandWidth) / 2;
            _hand.Y = 0;
            _hand.Width = HandWidth;
            _hand.Height = HandHeight;

            _hand.Draw(gameTime);
        }

        private void DrawDeck(GameTime gameTime)
        {
            _deck.X = X + DeckDistFromLeft;
            _deck.Y = Y + DeckDistFromTop;
            _deck.Draw(gameTime);
        }

        private void DrawLandZone(GameTime gameTime)
        {
            _landZone.X = X + (Width - LandZoneWidth) / 2;
            _landZone.Y = Y + LandZoneDistFromTop;
            _landZone.Width = LandZoneWidth;
            _landZone.Height = LandZoneHeight;
            
            _landZone.Draw(gameTime);
        }

        private void DrawArtifactEnchantmentZone(GameTime gameTime)
        {
            _artifactEnchantmentZone.X = X + (Width - ArtifactEnchantmentZoneWidth) / 2;
            _artifactEnchantmentZone.Y = Y + ArtifactEnchantmentZoneDistFromTop;
            _artifactEnchantmentZone.Width = ArtifactEnchantmentZoneWidth;
            _artifactEnchantmentZone.Height = ArtifactEnchantmentZoneHeight;

            _artifactEnchantmentZone.Draw(gameTime);
        }

        private void DrawCreaturePlaneswalkerBattleZone(GameTime gameTime, int y)
        {
            _creaturePlaneswalkerBattleZone.X = X + (Width - HandWidth) / 2;
            _creaturePlaneswalkerBattleZone.Y = y;
            _creaturePlaneswalkerBattleZone.Width = CreaturePlaneswalkerBattleZoneWidth;
            _creaturePlaneswalkerBattleZone.Height = CreaturePlaneswalkerBattleZoneHeight;

            _creaturePlaneswalkerBattleZone.Draw(gameTime);
        }

        private void DrawGraveyard(GameTime gameTime)
        {
            _graveyard.X = X + GraveyardDistFromLeft;
            _graveyard.Y = Y + GraveyardDistFromTop;
            _graveyard.Draw(gameTime);
        }

        private void DrawExile(GameTime gameTime)
        {
            _exile.X = X + ExileDistFromLeft;
            _exile.Y = Y + ExileDistFromTop;
            _exile.Draw(gameTime);
        }

        private void DrawPriority(GameTime gameTime)
        {
            _priority.X = 0;
            _priority.Y = Y + PriorityDistFromTop;
            _priority.Draw(gameTime);
        }

        public void Update(GameTime gameTime)
        {
            _hand.ConnectionId = ConnectionId;
            _hand.Update(gameTime);

            _deck.ConnectionId = ConnectionId;
            _deck.Update(gameTime);

            _graveyard.ConnectionId = ConnectionId;
            _graveyard.Update(gameTime);

            _exile.ConnectionId = ConnectionId;
            _exile.Update(gameTime);

            _landZone.ConnectionId = ConnectionId;
            _landZone.Update(gameTime);

            _creaturePlaneswalkerBattleZone.ConnectionId = ConnectionId;
            _creaturePlaneswalkerBattleZone.Update(gameTime);

            _artifactEnchantmentZone.ConnectionId = ConnectionId;
            _artifactEnchantmentZone.Update(gameTime);

            _planeswalkerAndBattleZone.ConnectionId = ConnectionId;
            _planeswalkerAndBattleZone.Update(gameTime);

            _priority.ConnectionId = ConnectionId;
            _priority.Update(gameTime);
        }
    }
}
