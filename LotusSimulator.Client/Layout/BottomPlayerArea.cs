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
    public class BottomPlayerArea
    {
        private const int HandWidth = 700;
        private const int HandHeight = 70;
        private const int HandDistFromTop = 870;

        private const int PlaneswalkerAndBattleZoneWidth = 200;
        private const int PlaneswalkerAndBattleZoneHeight = 70;
        private const int PlaneswalkerAndBattleZoneDistFromLeft = 100;

        private const int FirstPlaneswalkerAndBattleZoneDistFromTop = 20;
        private const int FirstSecondPlaneswalkerBattleGap = 10;
        private const int SecondPlaneswalkerAndBattleZoneDistFromTop = FirstPlaneswalkerAndBattleZoneDistFromTop + PlaneswalkerAndBattleZoneHeight + FirstSecondPlaneswalkerBattleGap;

        private const int CreatureZoneWidth = HandWidth * 5 / 7;
        private const int CreatureZoneHeight = 70;
        private const int CreatureZoneDistFromLeft = PlaneswalkerAndBattleZoneDistFromLeft + PlaneswalkerAndBattleZoneWidth;

        private const int FirstCreatureZoneDistFromTop = 20;
        private const int FirstSecondCreatureGap = 10;
        private const int SecondCreatureZoneDistFromTop = FirstCreatureZoneDistFromTop + CreatureZoneHeight + FirstSecondCreatureGap;

        private const int CreatureArtifactEnchantmentGap = 10;

        private const int ArtifactEnchantmentZoneWidth = 700;
        private const int ArtifactEnchantmentZoneHeight = 70;
        private const int ArtifactEnchantmentZoneDistFromTop = SecondCreatureZoneDistFromTop + CreatureZoneHeight + CreatureArtifactEnchantmentGap;

        private const int ArtifactEnchantmentLandGap = 10;

        private const int LandZoneWidth = 700;
        private const int LandZoneHeight = 70;
        private const int LandZoneDistFromTop = ArtifactEnchantmentZoneDistFromTop + ArtifactEnchantmentZoneHeight + ArtifactEnchantmentLandGap;

        private const int ExileDistFromLeft = 820;
        private const int ExileDistFromTop = 100;

        private const int ExileGraveyardGap = 10;

        private const int GraveyardDistFromLeft = 820;
        private const int GraveyardDistFromTop = ExileDistFromTop + 70 + ExileGraveyardGap;

        private const int DeckGraveyardGap = 10;

        private const int DeckDistFromLeft = 820;
        private const int DeckDistFromTop = GraveyardDistFromTop + 70 + DeckGraveyardGap;

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Hand.Hand TopPlayerHand { get; set; } = new Hand.Hand();

        public void Draw(GameTime gameTime)
        {
            var greenBar = new Texture2D(HostedService.GraphicsDevice, 1, 1);
            greenBar.SetData(new[] { Color.Yellow });
            HostedService.SpriteBatch.Draw(greenBar, new Rectangle(X, Y, Width, Height), Color.White);

            DrawHand(gameTime);
            DrawDeck(gameTime);
            DrawGraveyard(gameTime);
            DrawExile(gameTime);
            DrawLandZone(gameTime);
            DrawArtifactEnchantmentZone(gameTime);

            DrawPlaneswalkerAndBattleZone(gameTime, FirstPlaneswalkerAndBattleZoneDistFromTop);
            DrawPlaneswalkerAndBattleZone(gameTime, SecondPlaneswalkerAndBattleZoneDistFromTop);

            DrawCreatureZone(gameTime, FirstCreatureZoneDistFromTop);
            DrawCreatureZone(gameTime, SecondCreatureZoneDistFromTop);
        }

        private void DrawHand(GameTime gameTime)
        {
            var hand = new Hand.Hand();
            hand.X = X + (Width - HandWidth) / 2;
            hand.Y = HandDistFromTop;
            hand.Width = HandWidth;
            hand.Height = HandHeight;

            hand.Draw(gameTime);
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
            creatureZone.X = X + CreatureZoneDistFromLeft;
            creatureZone.Y = Y + y;
            creatureZone.Width = CreatureZoneWidth;
            creatureZone.Height = CreatureZoneHeight;

            creatureZone.Draw(gameTime);
        }

        private void DrawPlaneswalkerAndBattleZone(GameTime gameTime, int y)
        {
            var planeswalkerAndBattleZone = new PlaneswalkerAndBattleZone();
            // Use PlayerHandWidth for Left-Align creature zones
            planeswalkerAndBattleZone.X = X + PlaneswalkerAndBattleZoneDistFromLeft;
            planeswalkerAndBattleZone.Y = Y + y;
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
