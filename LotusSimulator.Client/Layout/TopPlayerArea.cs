using LotusSimulator.Client.DependencyInjection;
using LotusSimulator.Client.Hand;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Client.Layout
{
    public class TopPlayerArea
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

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Hand.Hand TopPlayerHand { get; set; } = new Hand.Hand();

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
        }

        private void DrawHand(GameTime gameTime)
        {
            var topPlayerHand = new Hand.Hand();
            topPlayerHand.X = X + (Width - HandWidth) / 2;
            topPlayerHand.Y = 0;
            topPlayerHand.Width = HandWidth;
            topPlayerHand.Height = HandHeight;

            topPlayerHand.Draw(gameTime);
        }

        private void DrawDeck(GameTime gameTime)
        {
            var deck = new Deck.Deck();
            deck.X = X + DeckDistFromLeft;
            deck.Y = Y + DeckDistFromTop;
            deck.Draw(gameTime);
        }

        private void DrawLandZone(GameTime gameTime)
        {
            var landZone = new LandZone();
            landZone.X = X + (Width - LandZoneWidth) / 2;
            landZone.Y = Y + LandZoneDistFromTop;
            landZone.Width = LandZoneWidth;
            landZone.Height = LandZoneHeight;
            
            landZone.Draw(gameTime);
        }

        private void DrawArtifactEnchantmentZone(GameTime gameTime)
        {
            var artifactEnchantmentZone = new ArtifactEnchantmentZone();
            artifactEnchantmentZone.X = X + (Width - ArtifactEnchantmentZoneWidth) / 2;
            artifactEnchantmentZone.Y = Y + ArtifactEnchantmentZoneDistFromTop;
            artifactEnchantmentZone.Width = ArtifactEnchantmentZoneWidth;
            artifactEnchantmentZone.Height = ArtifactEnchantmentZoneHeight;

            artifactEnchantmentZone.Draw(gameTime);
        }

        private void DrawCreatureZone(GameTime gameTime, int y)
        {
            var creatureZone = new CreatureZone();
            // Use PlayerHandWidth for Left-Align creature zones
            creatureZone.X = X + (Width - HandWidth) / 2;
            creatureZone.Y = y;
            creatureZone.Width = CreatureZoneWidth;
            creatureZone.Height = CreatureZoneHeight;

            creatureZone.Draw(gameTime);
        }

        private void DrawPlaneswalkerAndBattleZone(GameTime gameTime, int y)
        {
            var planeswalkerAndBattleZone = new PlaneswalkerAndBattleZone();
            // Use PlayerHandWidth for Left-Align creature zones
            planeswalkerAndBattleZone.X = X + (Width - HandWidth) / 2 + CreatureZoneWidth;
            planeswalkerAndBattleZone.Y = y;
            planeswalkerAndBattleZone.Width = PlaneswalkerAndBattleZoneWidth;
            planeswalkerAndBattleZone.Height = PlaneswalkerAndBattleZoneHeight;

            planeswalkerAndBattleZone.Draw(gameTime);
        }

        private void DrawGraveyard(GameTime gameTime)
        {
            var graveyard = new Graveyard();
            graveyard.X = X + GraveyardDistFromLeft;
            graveyard.Y = Y + GraveyardDistFromTop;
            graveyard.Draw(gameTime);
        }

        private void DrawExile(GameTime gameTime)
        {
            var exile = new Exile();
            exile.X = X + ExileDistFromLeft;
            exile.Y = Y + ExileDistFromTop;
            exile.Draw(gameTime);
        }

        public void Update(GameTime gameTime)
        {
            TopPlayerHand?.Update(gameTime);
        }
    }
}
