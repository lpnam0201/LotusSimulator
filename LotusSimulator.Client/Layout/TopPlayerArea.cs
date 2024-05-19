using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LotusSimulator.Client.Layout
{
    public class TopPlayerArea : IPlayerIdentity
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

        private const int CreatureZoneWidth = HandWidth * 5 / 7;
        private const int CreatureZoneHeight = 70;
        private const int FirstCreatureZoneDistFromTop = ArtifactEnchantmentZoneDistFromTop + ArtifactEnchantmentZoneHeight + ArtifactEnchantmentCreatureGap;

        private const int FirstSecondCreatureGap = 10;
        private const int SecondCreatureZoneDistFromTop = FirstCreatureZoneDistFromTop + CreatureZoneHeight + FirstSecondCreatureGap;

        private const int ArtifactEnchantmentPlaneswalkerBattleGap = 10;

        private const int PlaneswalkerAndBattleZoneWidth = HandWidth * 2 / 7;
        private const int PlaneswalkerAndBattleZoneHeight = 70;
        private const int FirstPlaneswalkerAndBattleZoneDistFromTop = ArtifactEnchantmentZoneDistFromTop + ArtifactEnchantmentZoneHeight + ArtifactEnchantmentPlaneswalkerBattleGap;

        private const int FirstSecondPlaneswalkerBattleGap = 10;
        private const int SecondPlaneswalkerAndBattleZoneDistFromTop = FirstPlaneswalkerAndBattleZoneDistFromTop + PlaneswalkerAndBattleZoneHeight + FirstSecondPlaneswalkerBattleGap;

        private const int PriorityDistFromTop = 40;

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Slot { get; set; }

        private Hand.Hand _hand { get; set; } = new Hand.Hand();
        private Deck.Deck _deck { get; set; } = new Deck.Deck();
        private Graveyard _graveyard { get; set; } = new Graveyard();
        private Exile _exile { get; set; } = new Exile();
        private LandZone _landZone { get; set; } = new LandZone();
        private CreatureZone _creatureZone { get; set; } = new CreatureZone();
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
            DrawCreatureZone(gameTime, FirstCreatureZoneDistFromTop);
            DrawCreatureZone(gameTime, SecondCreatureZoneDistFromTop);

            DrawPlaneswalkerAndBattleZone(gameTime, FirstPlaneswalkerAndBattleZoneDistFromTop);
            DrawPlaneswalkerAndBattleZone(gameTime, SecondPlaneswalkerAndBattleZoneDistFromTop);

            DrawPriority(gameTime);
        }

        private void DrawHand(GameTime gameTime)
        {
            _hand.Slot = Slot;
            _hand.X = X + (Width - HandWidth) / 2;
            _hand.Y = 0;
            _hand.Width = HandWidth;
            _hand.Height = HandHeight;

            _hand.Draw(gameTime);
        }

        private void DrawDeck(GameTime gameTime)
        {
            _deck.Slot = Slot;
            _deck.X = X + DeckDistFromLeft;
            _deck.Y = Y + DeckDistFromTop;
            _deck.Draw(gameTime);
        }

        private void DrawLandZone(GameTime gameTime)
        {
            _landZone.Slot = Slot;
            _landZone.X = X + (Width - LandZoneWidth) / 2;
            _landZone.Y = Y + LandZoneDistFromTop;
            _landZone.Width = LandZoneWidth;
            _landZone.Height = LandZoneHeight;
            
            _landZone.Draw(gameTime);
        }

        private void DrawArtifactEnchantmentZone(GameTime gameTime)
        {
            _artifactEnchantmentZone.Slot = Slot;
            _artifactEnchantmentZone.X = X + (Width - ArtifactEnchantmentZoneWidth) / 2;
            _artifactEnchantmentZone.Y = Y + ArtifactEnchantmentZoneDistFromTop;
            _artifactEnchantmentZone.Width = ArtifactEnchantmentZoneWidth;
            _artifactEnchantmentZone.Height = ArtifactEnchantmentZoneHeight;

            _artifactEnchantmentZone.Draw(gameTime);
        }

        private void DrawCreatureZone(GameTime gameTime, int y)
        {
            _creatureZone.Slot = Slot;
            // Use PlayerHandWidth for Left-Align creature zones
            _creatureZone.X = X + (Width - HandWidth) / 2;
            _creatureZone.Y = y;
            _creatureZone.Width = CreatureZoneWidth;
            _creatureZone.Height = CreatureZoneHeight;

            _creatureZone.Draw(gameTime);
        }

        private void DrawPlaneswalkerAndBattleZone(GameTime gameTime, int y)
        {
            _planeswalkerAndBattleZone.Slot = Slot;
            // Use PlayerHandWidth for Left-Align creature zones
            _planeswalkerAndBattleZone.X = X + (Width - HandWidth) / 2 + CreatureZoneWidth;
            _planeswalkerAndBattleZone.Y = y;
            _planeswalkerAndBattleZone.Width = PlaneswalkerAndBattleZoneWidth;
            _planeswalkerAndBattleZone.Height = PlaneswalkerAndBattleZoneHeight;

            _planeswalkerAndBattleZone.Draw(gameTime);
        }

        private void DrawGraveyard(GameTime gameTime)
        {
            _graveyard.Slot = Slot;
            _graveyard.X = X + GraveyardDistFromLeft;
            _graveyard.Y = Y + GraveyardDistFromTop;
            _graveyard.Draw(gameTime);
        }

        private void DrawExile(GameTime gameTime)
        {
            _exile.Slot = Slot;
            _exile.X = X + ExileDistFromLeft;
            _exile.Y = Y + ExileDistFromTop;
            _exile.Draw(gameTime);
        }

        private void DrawPriority(GameTime gameTime)
        {
            _priority.Slot = Slot;
            _priority.X = 0;
            _priority.Y = Y + PriorityDistFromTop;
            _priority.Draw(gameTime);
        }

        public void Update(GameTime gameTime)
        {
            _hand.Update(gameTime);
            _deck.Update(gameTime);
            _graveyard.Update(gameTime);
            _exile.Update(gameTime);
            _landZone.Update(gameTime);
            _creatureZone.Update(gameTime);
            _artifactEnchantmentZone.Update(gameTime);
            _planeswalkerAndBattleZone.Update(gameTime);
            _priority.Update(gameTime);
        }
    }
}
